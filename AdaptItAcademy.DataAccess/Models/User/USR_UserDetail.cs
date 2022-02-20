using AdaptItAcademy.DataAccess.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.EFDataAccess.Models
{
    public class USR_UserDetail
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "varchar(70)")]
        public string EmailAddress { get; set; }
        public int LUT_DietaryRequirementId { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string CompanyName { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string PhysicalAddress { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string PostalAddress { get; set; }
        public int CourseId { get; set; }
        public int TrainingId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual DTA_Course DTA_Course { get; set; }
        public virtual DTA_UpcomingTraining DTA_UpcomingTraining { get; set; }
        public virtual LUT_DietaryRequirement LUT_DietaryRequirement { get; set;}
    }
}
