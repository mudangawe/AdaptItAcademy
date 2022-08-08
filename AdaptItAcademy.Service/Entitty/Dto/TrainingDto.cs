using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdaptItAcademy.Service.Entitty.Dto
{
    public class TrainingDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public DateTime StartingDate { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public DateTime ClosingDate { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Double Amount { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public Boolean IsTrainingPaidFor { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public int VenueId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string CourseCode { get; set; }
       
        public int AvalableSeats { get; set; }
    }
}
