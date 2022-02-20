using AdaptItAcademy.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.BusinnessLogic.Abstract
{
    public interface IDataService
    {
        //Upcoming Training
        Task<IEnumerable<UpcomingTrainingDto>> GetAllTrainingDetails();
        UpcomingTrainingDto GetUpcomingTrainingById(int Id);
        UpcomingTrainingDto InsertUpcomingTraining(UpcomingTrainingDto TrainingDto);
        UpcomingTrainingDto UpdateAcademicDetail(UpcomingTrainingDto academicDto);
        void DeleteUpcomingTrainig(int Id);


        //Courses
        Task<IEnumerable<CourseDto>> GetAllCourses();
        CourseDto GetCourseById(int Id);
        CourseDto UpdateCourse(CourseDto courseDto);
        CourseDto InsertCourse(CourseDto courseDto);
        void DeleteCourse(int Id);
    }
}
