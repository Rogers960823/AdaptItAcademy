using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdaptItAcademy.Model.Models
{
    public class UserDetailsDto
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int LUT_DietaryRequirementId { get; set; }
        public string DietaryRequirements { get; set; }
        public string CompanyName { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
