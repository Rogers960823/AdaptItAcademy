using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.Model.Models
{
    public class UpcomingTrainingDto
    {
        public int Id { get; set; } 
        public int? UserId { get; set; }
        public DateTime TrainingDate { get; set; }
        public string CompanyName { get; set; }
        public string TrainingVenue { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime ReggistrationClosingDate { get; set; }
        public double CourseTrainingcost { get; set; }
        public string TrainingPaymentStatus { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual UserDetailsDto USR_UserDetail { get; set; }
        public virtual CourseDto DTA_Course { get; set; }
    }
}
