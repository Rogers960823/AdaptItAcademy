using AdaptItAcademy.BusinnessLogic.Abstract;
using AdaptItAcademy.BusinnessLogic.Data;
using AdaptItAcademy.BusinnessLogic.Services;
using AdaptItAcademy.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptITAcademy
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AdaptItAcademyContext>(options =>
             options.UseSqlServer(_configuration.GetConnectionString("AdaptItAcademyDB")));

            services.AddDbContext<AdaptItAcademyContext>(options =>
            options.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("AdaptItAcademy.ApiWeb"))
                                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Demo API",
                        Description = "Demo API for showing Swagger",
                    Version = "v1"
                    });
            }
            );
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<ILookUpService, LookUpService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                options.RoutePrefix = "";
            });
        }
    }
}
