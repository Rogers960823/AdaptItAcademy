using AdaptItAcademy.BusinnessLogic.Abstract;
using AdaptItAcademy.DataAccess;
using AdaptItAcademy.DataAccess.Models.Data;
using AdaptItAcademy.Model.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinnessLogic.Services
{

    public class DataService : IDataService
    {
        private readonly AdaptItAcademyContext _context;
        private readonly ILookUpService _lookUpService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public DataService(IUserService userService, IMapper mapper, ILookUpService lookUpService, AdaptItAcademyContext context)
        {
            this._lookUpService = lookUpService;
            this._userService = userService;
            this._context = context;
            this._mapper = mapper;
        }

        #region Upcoming Training
        public async Task <IEnumerable<UpcomingTrainingDto>> GetAllTrainingDetails()
        {
            var records = _context.DTA_UpcomingTrainings.ToList();
            var results = _mapper.Map<IEnumerable<UpcomingTrainingDto>>(records);
            return results;
        }

        public UpcomingTrainingDto InsertUpcomingTraining(UpcomingTrainingDto TrainingDto)
        {
            UpcomingTrainingDto training = new UpcomingTrainingDto();
            var record = _context.DTA_UpcomingTrainings.AsNoTracking().Where(x => x.UserId == TrainingDto.UserId).FirstOrDefault();
            if (record == null)
            {
                var result = _mapper.Map<DTA_UpcomingTraining>(TrainingDto);
                _context.DTA_UpcomingTrainings.Add(result);
                training = _mapper.Map<UpcomingTrainingDto>(result);
                _context.SaveChanges();
                return training;
            }
            else
            {
                return training;
            }
        }

        public UpcomingTrainingDto GetUpcomingTrainingById(int Id)
        {
            var record = _context.DTA_UpcomingTrainings.AsNoTracking().Where(x => x.Id == Id).FirstOrDefault();
            var result = _mapper.Map<UpcomingTrainingDto>(record);
            return result;
        }

        public UpcomingTrainingDto UpdateAcademicDetail(UpcomingTrainingDto trainigDto)
        {

            UpcomingTrainingDto training = new UpcomingTrainingDto();
            var record = GetUpcomingTrainingById(trainigDto.Id);

            if (record != null)
            {
                var result = _mapper.Map<DTA_UpcomingTraining>(trainigDto);
                result.UpdatedAt = DateTime.Now;
                _context.DTA_UpcomingTrainings.Update(result);

                training = _mapper.Map<UpcomingTrainingDto>(result);
                _context.SaveChanges();

                return training;
            }
            else
            {
                return training;
            }
        }

        public void DeleteUpcomingTrainig(int Id)
        {
            var record = GetUpcomingTrainingById(Id);
            if (record != null)
            {
                var result = _mapper.Map<DTA_UpcomingTraining>(record);
                _context.DTA_UpcomingTrainings.Remove(result);
                _context.SaveChanges();
            }
        }
        #endregion

        #region Courses
        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            var records = _context.DTA_Courses.ToList();
            var results = _mapper.Map<IEnumerable<CourseDto>>(records);
            return results;
        }

        public CourseDto InsertCourse(CourseDto courseDto)
        {
            CourseDto courses = new CourseDto();
            var record = _context.DTA_Courses.AsNoTracking().Where(x => x.Id == courseDto.Id).FirstOrDefault();
            if (record == null)
            {
                var result = _mapper.Map<DTA_Course>(courseDto);
                _context.DTA_Courses.Add(result);
                courses = _mapper.Map<CourseDto>(result);
                _context.SaveChanges();
                return courses;
            }
            else
            {
                return courses;
            }
        }

        public CourseDto GetCourseById(int Id)
        {
            var record = _context.DTA_Courses.AsNoTracking().Where(x => x.Id == Id).FirstOrDefault();
            var result = _mapper.Map<CourseDto>(record);
            return result;
        }

        public CourseDto UpdateCourse(CourseDto courseDto)
        {

            CourseDto course = new CourseDto();
            var record = GetCourseById(courseDto.Id);

            if (record != null)
            {
                var result = _mapper.Map<DTA_Course>(courseDto);
                result.UpdatedAt = DateTime.Now;
                _context.DTA_Courses.Update(result);

                course = _mapper.Map<CourseDto>(result);
                _context.SaveChanges();

                return course;
            }
            else
            {
                return course;
            }
        }

        public void DeleteCourse(int Id)
        {
            var record = GetCourseById(Id);
            if (record != null)
            {
                var result = _mapper.Map<DTA_Course>(record);
                _context.DTA_Courses.Remove(result);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
