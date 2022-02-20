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
    public class DTA_Course
    {
        [Key]
        public int Id { get; set; }
        public long? CourseCode { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string CourseName { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string CourseDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
