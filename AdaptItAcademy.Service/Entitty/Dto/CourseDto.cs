using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdaptItAcademy.Service.Entitty.Dto
{
    public class CourseDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
    }
}
