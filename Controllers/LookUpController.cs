using AdaptItAcademy.BusinnessLogic.Abstract;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.Model.Models;
using AdaptITAcademy.ApiWeb.Utility;
using AutoMapper;
using AdaptItAcademy.EFDataAccess.Models;
using AdaptItAcademy.Model.Models;
//using AdaptITAcademy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptITAcademy.Controllers
{

    [Route("api/lookup")]
    public class LookUpController : Controller
    {
        private readonly ILookUpService _lookUpService;
        private readonly ILogger<LookUpController> _logger;

        public LookUpController(ILogger<LookUpController> logger, ILookUpService lookUpService)
        {
            _logger = logger;
            _lookUpService = lookUpService;
        }

        #region Grade

        [AllowAnonymous]
        [HttpGet("GetDietById")]
        public IActionResult GetDietById(int Id)
        {
            _ = new ObjectResult(false);

            try
            {
                var result = _lookUpService.GetDietById(Id);

                if (result == null)
                {
                    return NotFound(new { message = "Diet was not found" });
                }
                else
                {
                    return new OkObjectResult(result);
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAllDiets")]
        public IActionResult GetAllDiets()
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Grades = _lookUpService.GetAllDietary();

                if (Grades == null)
                {
                    return NotFound(new { message = "Dietary not found" });
                }
                else
                {
                    return new OkObjectResult(Grades);
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpPost("AddDiet")]
        public IActionResult AddDiet([FromBody] DietaryRequirementsDto item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var result = _lookUpService.InsertDiet(item);
                    return Ok(new { message = "Diet is added successfully." });
                }

            }

            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpPut("UpdateDiet")]
        public IActionResult UpdateDiet(int Id, [FromBody()] DietaryRequirementsDto item)
        {
            try
            {
                if (!ModelState.IsValid || item == null || Id == 0)
                {
                    return BadRequest(ModelState);
                }

                else
                {
                    var result = _lookUpService.GetDietById(Id);
                    if (result == null)
                    {
                        return NotFound(new { message = "Diet not found" });
                    }

                    _lookUpService.UpdateDiet(item);

                    return Ok(new { message = "Diet is updated successfully." });

                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpDelete("DeleteDiet")]
        public IActionResult DeleteDiet(int Id)
        {
            try
            {
                var result = _lookUpService.GetDietById(Id);

                if (result == null)
                {
                    return NotFound(new { message = "Diet not found" });
                }
                else
                {
                    _lookUpService.DeleteDiet(Id);

                    return Ok(new { message = "Diet is deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }
        }

        #endregion
      }
    }
