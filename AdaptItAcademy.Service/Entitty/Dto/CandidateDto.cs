using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdaptItAcademy.Service.Entitty.Dto
{
    public class CandidateDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Code")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public dietary Dietary { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string CompanyName { get; set; }
        [Required]
        public int TrainingID { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Address PhysicalAddress { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Address PostalAddress { get; set; }
    }

    public class Address
    {
        [Required(ErrorMessage = "{0} is required")]
        public string StreetNo { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Suburb { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^[0-9]{1,8}$",ErrorMessage = "Invalid Code")]
        public string Code { get; set; }

    }
    public enum dietary
    {
        Vegetarian,
        Halal,
        Vegan,
        other
    }
}
