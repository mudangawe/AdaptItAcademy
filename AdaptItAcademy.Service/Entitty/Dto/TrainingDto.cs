using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptItAcademy.Service.Entitty.Dto
{
    public class TrainingDto
    {
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public Double Amount { get; set; }
        public Boolean IsTrainingPaidFor { get; set; }
        public int VenueId { get; set; }
        public string CourseCode { get; set; }
        public int AvalableSeats { get; set; }
    }
}
