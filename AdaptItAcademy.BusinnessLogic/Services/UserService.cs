using AdaptItAcademy.BusinnessLogic.Abstract;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.Model.Models;
using AutoMapper;
using AdaptItAcademy.EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinnessLogic.Services
{
    public class UserService : IUserService
    {
        //private readonly IRepository<UserDetailsDto> _repository;
        private readonly AdaptItAcademyContext _context;
        private readonly IMapper _mapper;
        private readonly ILookUpService _lookUpService;

        public UserService(AdaptItAcademyContext context, ILookUpService lookUpService, IMapper mapper)
        {
            this._context = context;
            this._lookUpService = lookUpService;
            this._mapper = mapper;
        }

        UserDetailsDto UserRegistration = new UserDetailsDto();
        public async Task<UserDetailsDto> GetUserById(int userId)
        {
            try
            {
                var record = await _context.USR_UserDetails.AsNoTracking().Where(x => x.Id == userId).FirstOrDefaultAsync();
                var result = _mapper.Map<UserDetailsDto>(record);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<UserDetailsDto> RegisterUser(UserDetailsDto details)
        {
            try
            {
                UserDetailsDto record = new UserDetailsDto();
                var result = _context.USR_UserDetails.AsNoTracking().Where(x => x.Id == record.Id).FirstOrDefault();
                if (result == null)
                {
                    UserDetailsDto user = new UserDetailsDto()
                    {
                        FirstName = result.FirstName,
                        LastName = result.LastName,
                        PhoneNumber = result.PhoneNumber,
                        EmailAddress = result.EmailAddress,
                        LUT_DietaryRequirementId = result.LUT_DietaryRequirementId,
                        PhysicalAddress = result.PhysicalAddress,
                        PostalAddress = result.PostalAddress,
                        CreatedAt = DateTime.Now
                    };
                    var results = _mapper.Map<USR_UserDetail>(user);

                    await _context.USR_UserDetails.AddAsync(results);
                    await _context.SaveChangesAsync();

                    var userInfo = _mapper.Map<UserDetailsDto>(results);
                    return userInfo;
                }
                else
                {
                    UserDetailsDto adduser = new UserDetailsDto();
                    adduser.FirstName = details.FirstName;
                    adduser.LastName = details.LastName;
                    adduser.EmailAddress = details.EmailAddress;
                    adduser.PhoneNumber = details.PhoneNumber;
                    adduser.EmailAddress = details.EmailAddress;
                    adduser.DietaryRequirements = details.DietaryRequirements;
                    adduser.PhysicalAddress = details.PhysicalAddress;
                    adduser.PostalAddress = details.PostalAddress;
                    adduser.CreatedAt = DateTime.Now;

                    var userRecord = _mapper.Map<USR_UserDetail>(adduser);

                    await _context.USR_UserDetails.AddAsync(userRecord);
                    await _context.SaveChangesAsync();

                    var userInfo = _mapper.Map<UserDetailsDto>(userRecord);
                    return userInfo;
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("User Already Exists");
            }
        }


        public async Task<IEnumerable<UserDetailsDto>> GetAll()
        {
            try
            {
                var record = await _context.USR_UserDetails.ToListAsync();
                var result = _mapper.Map<IEnumerable<UserDetailsDto>>(record);

                if (result != null && result.Count() > 0)
                {
                    foreach (var item in result)
                    {
                        var diet = _lookUpService.GetDietById(item.LUT_DietaryRequirementId);
                        if (diet != null)
                        {
                            item.DietaryRequirements = diet.Name;
                        }
                        else
                        {
                            item.DietaryRequirements = "Uknown Diet";
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could Not find records");
            }

        }

        public async Task<UserDetailsDto> UpdateUserDetails(UserDetailsDto UserDto)
        {
            try
            {
                UserDetailsDto userDto = new UserDetailsDto();
                var record = await GetUserById(UserDto.Id);
                if (record != null)
                {
                    var result = _mapper.Map<USR_UserDetail>(record);

                    result.FirstName = UserDto.FirstName;
                    result.LastName = UserDto.LastName;
                    result.PhoneNumber = UserDto.PhoneNumber;
                    result.EmailAddress = UserDto.EmailAddress;
                    result.LUT_DietaryRequirement.Name = UserDto.DietaryRequirements;
                    result.CompanyName = UserDto.DietaryRequirements;
                    result.PhysicalAddress = UserDto.PhysicalAddress;
                    result.PostalAddress = UserDto.PostalAddress;
                    result.UpdatedAt = DateTime.Now;
                    _context.USR_UserDetails.Update(result);

                    userDto = _mapper.Map<UserDetailsDto>(result);
                    await _context.SaveChangesAsync();
                    return userDto;
                }
                else
                {
                    return userDto;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async void DeleteUserDetails(UserDetailsDto userDetails)
        {
            try
            {
                var record = _mapper.Map<USR_UserDetail>(userDetails);
                _context.USR_UserDetails.Remove(record);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }
    }
}
