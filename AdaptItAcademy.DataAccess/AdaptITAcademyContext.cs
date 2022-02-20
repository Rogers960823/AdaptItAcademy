using AdaptItAcademy.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using AdaptItAcademy.DataAccess.Models.Data;
using AdaptItAcademy.EFDataAccess.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess
{
    public class AdaptItAcademyContext: DbContext
    {
        public AdaptItAcademyContext(DbContextOptions<AdaptItAcademyContext> options)
        : base(options)
        {
        }

        public virtual DbSet<LUT_DietaryRequirement> LUT_DietaryRequirements { get; set; }

        //Data Tables
        public virtual DbSet<DTA_UpcomingTraining> DTA_UpcomingTrainings { get; set; }
        public virtual DbSet<DTA_Course> DTA_Courses { get; set; }

        //User Tables
        public virtual DbSet<USR_UserDetail> USR_UserDetails { get; set; }
    }
}
