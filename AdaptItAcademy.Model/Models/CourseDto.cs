using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.Model.Models
{
    public class CourseDto
    {
        public int Id { get; set; } 
        public long CourseCode { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
