using AdaptItAcademy.EFDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess.Models.Data
{
    public class DTA_UpcomingTraining
    {
        [Key]
        public int Id { get; set; }
        public long? UserId { get; set; }
        public DateTime TrainingDate { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string TrainingVenue { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime RegistrationClosingDate { get; set; }
        public double CourseTrainingCost { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string TrainingPaymentStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual USR_UserDetail USR_UserDetail { get; set; }
        public virtual DTA_Course DTA_Course { get; set; }
    }
}
