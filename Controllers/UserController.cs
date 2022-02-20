using AdaptItAcademy.BusinnessLogic.Abstract;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.Model.Models;
using AdaptITAcademy.ApiWeb.Utility;
//using AdaptITAcademy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptITAcademy.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AdaptItAcademyContext _context;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet("GetUserById")]

        public async Task<IActionResult> GetUserById(int userId)
        {
            GenericResult output;
            IActionResult _result;
            try
            {
                var user = await _userService.GetUserById(userId);

                if (user == null)
                {
                    output = new GenericResult()
                    {
                        Success = false,
                        Message = "Get user was unsuccessful",
                    };
                    _result = new OkObjectResult(output);
                }
                else
                {
                    output = new GenericResult()
                    {
                        Success = true,
                        Message = "Get user was successful",
                    };

                    _result = new OkObjectResult(new { output, user });
                }

            }
            catch (Exception ex)
            {
                output = new GenericResult()
                {
                    Success = false,
                    Message = ex.Message,
                };
                _result = new OkObjectResult(output);
            }

            return _result;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody] UserDetailsDto model)
        {
            GenericResult output;
            IActionResult _result;
            try
            {
                var user = await _userService.RegisterUser(model);

                if (user == null)
                {
                    output = new GenericResult()
                    {
                        Success = false,
                        Message = "The registration process was unsuccessful",
                    };
                    _result = new OkObjectResult(output);
                }
                else
                {
                    output = new GenericResult()
                    {
                        Success = true,
                        Message = "The registration process was successful",
                    };

                    _result = new OkObjectResult(new { output, user });
                }

            }
            catch (Exception ex)
            {
                output = new GenericResult()
                {
                    Success = false,
                    Message = ex.Message,
                };
                _result = new OkObjectResult(output);
            }

            return _result;
        }
        [AllowAnonymous]
        [HttpPut("UpdateUserDetails")]
        public async Task<IActionResult> UpdateUserDetails(int Id, [FromBody()] UserDetailsDto item)
        {
            GenericResult output;
            IActionResult _result;
            try
            {

                if (!ModelState.IsValid || item == null || Id == 0)
                {
                    output = new GenericResult()
                    {
                        Success = false,
                        Message = "Update user details was unsuccessful",
                    };
                    _result = new OkObjectResult(output);
                }
                else
                {
                    var user = await _userService.GetUserById(Id);
                    if (user == null)
                    {
                        output = new GenericResult()
                        {
                            Success = false,
                            Message = "User was not found",
                        };
                        _result = new OkObjectResult(output);
                    }
                    else
                    {
                        item.Id = Id;
                        await _userService.UpdateUserDetails(item);
                        output = new GenericResult()
                        {
                            Success = true,
                            Message = "Update User Details was successful",
                        };
                        _result = new OkObjectResult(output);
                    }

                }

            }
            catch (Exception ex)
            {
                output = new GenericResult()
                {
                    Success = false,
                    Message = ex.Message,
                };
                _result = new OkObjectResult(output);
            }

            return _result;
        }

        [AllowAnonymous]
        [HttpDelete("deleteApplication")]
        public async Task<IActionResult> DeleteApplication(int Id)
        {
            GenericResult output;
            IActionResult _result;
            try
            {
                var application = await _userService.GetUserById(Id);

                if (application == null)
                {
                    output = new GenericResult()
                    {
                        Success = false,
                        Message = "Delete UserDetails was unsuccessful",
                    };
                    _result = new OkObjectResult(output);
                }
                else
                {
                    _userService.DeleteUserDetails(application);

                    output = new GenericResult()
                    {
                        Success = true,
                        Message = "UserDetails are deleted successfully.",
                    };

                    _result = new OkObjectResult(output);
                }

            }
            catch (Exception ex)
            {
                output = new GenericResult()
                {
                    Success = false,
                    Message = ex.Message,
                };
                _result = new OkObjectResult(output);
            }

            return _result;

        }

        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            GenericResult output;
            IActionResult _result;
            try
            {
                var results = await _userService.GetAll();

                if (results == null)
                {
                    output = new GenericResult()
                    {
                        Success = false,
                        Message = "Get all users was unsuccessful",
                    };
                    _result = new OkObjectResult(output);
                }
                else
                {
                    output = new GenericResult()
                    {
                        Success = true,
                        Message = "Get all users was successful",
                    };

                    _result = new OkObjectResult(new { output, results });
                }

            }
            catch (Exception ex)
            {
                output = new GenericResult()
                {
                    Success = false,
                    Message = ex.Message,
                };
                _result = new OkObjectResult(output);
            }

            return _result;
        }
    }
}
