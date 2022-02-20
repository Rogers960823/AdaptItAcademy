using AdaptItAcademy.BusinnessLogic.Abstract;
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
    public class DataController : ControllerBase
    {

        private readonly IDataService _dataService;

        #region Upcoming Training

        [AllowAnonymous]
        [HttpGet("GetAllUpcomingTrainig")]
        public async Task<IActionResult> GetAllTrainingDetails()
        {
            GenericResult output;
            IActionResult _result;
            try
            {
                var results = await _dataService.GetAllTrainingDetails();

                if (results == null)
                {
                    output = new GenericResult()
                    {
                        Success = false,
                        Message = "Get all Upcoming Training details was unsuccessful",
                    };
                    _result = new OkObjectResult(output);
                }
                else
                {
                    output = new GenericResult()
                    {
                        Success = true,
                        Message = "Get all Upcoming Trainig details was successful",
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

        [HttpPost]
        [Route("AddUpcomingTraining")]
        public IActionResult AddUpcomingTrainig([FromBody()] UpcomingTrainingDto item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var result = _dataService.InsertUpcomingTraining(item);

                    return Ok(new { message = "Upcoming training is added successfully." });
                }

            }

            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpPut("UpdateAcademicDetail")]
        public IActionResult UpdateAcademicDetail(int Id, [FromBody()] UpcomingTrainingDto item)
        {
            try
            {
                if (!ModelState.IsValid || item == null || Id == 0)
                {
                    return BadRequest(ModelState);
                }

                else
                {
                    var result = _dataService.GetUpcomingTrainingById(Id);
                    if (result == null)
                    {
                        return NotFound(new { message = "Upcoming Training not found" });
                    }

                    _dataService.UpdateAcademicDetail(item);

                    return Ok(new { message = "Upcoming Training is updated successfully." });

                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpDelete("DeleteUpcomingTraining")]
        public IActionResult DeleteUpcomingTraining(int Id)
        {
            try
            {
                var result = _dataService.GetUpcomingTrainingById(Id);

                if (result == null)
                {
                    return NotFound(new { message = "Upcoming Training not found" });
                }
                else
                {
                    _dataService.DeleteUpcomingTrainig(Id);

                    return Ok(new { message = "Upcoming Training is deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }
        }
        #endregion

        #region Courses

        [AllowAnonymous]
        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            GenericResult output;
            IActionResult _result;
            try
            {
                var results = await _dataService.GetAllCourses();

                if (results == null)
                {
                    output = new GenericResult()
                    {
                        Success = false,
                        Message = "Get all courses was unsuccessful",
                    };
                    _result = new OkObjectResult(output);
                }
                else
                {
                    output = new GenericResult()
                    {
                        Success = true,
                        Message = "Get all courses was successful",
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

        [HttpPost]
        [Route("AddCourses")]
        public IActionResult AddCourses([FromBody()] CourseDto item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var result = _dataService.InsertCourse(item);

                    return Ok(new { message = "Course is added successfully." });
                }

            }

            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse(int Id, [FromBody()] CourseDto item)
        {
            try
            {
                if (!ModelState.IsValid || item == null || Id == 0)
                {
                    return BadRequest(ModelState);
                }

                else
                {
                    var result = _dataService.GetCourseById(Id);
                    if (result == null)
                    {
                        return NotFound(new { message = "Course not found" });
                    }

                    _dataService.UpdateCourse(item);

                    return Ok(new { message = "Course is updated successfully." });

                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpDelete("DeleteCourse")]
        public IActionResult DeleteCourse(int Id)
        {
            try
            {
                var result = _dataService.GetCourseById(Id);

                if (result == null)
                {
                    return NotFound(new { message = "Course not found" });
                }
                else
                {
                    _dataService.DeleteCourse(Id);

                    return Ok(new { message = "Course is deleted successfully." });
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
