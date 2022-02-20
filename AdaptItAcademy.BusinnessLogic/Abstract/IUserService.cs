using AdaptItAcademy.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinnessLogic.Abstract
{
    public interface IUserService
    {
         Task<UserDetailsDto> GetUserById(int userId);
        Task<UserDetailsDto> RegisterUser(UserDetailsDto details);
        Task<IEnumerable<UserDetailsDto>> GetAll();
        Task<UserDetailsDto> UpdateUserDetails(UserDetailsDto UserDto);
        void DeleteUserDetails(UserDetailsDto userDetails);
    }
}
