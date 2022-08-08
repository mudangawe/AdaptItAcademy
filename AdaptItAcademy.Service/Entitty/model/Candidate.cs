using AdaptItAcademy.Service.Entitty.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.Service.Entitty.model
{
    public class Candidate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public dietary Dietary { get; set; }
        public string CompanyName { get; set; }
        public int TrainingID { get; set; }
        public Address PhysicalAddress { get; set; }
        public Address PostalAddress { get; set; }
    }
}
