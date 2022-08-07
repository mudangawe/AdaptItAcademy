using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.Service.Entitty.Dto
{
    public class CandidateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public dietary Dietary { get; set; }
        public string CompanyName { get; set; }
        public Address PhysicalAddress { get; set; }
        public Address PostalAddress { get; set; }
    }

    public class Address
    {
        public string StreetNo { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
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
