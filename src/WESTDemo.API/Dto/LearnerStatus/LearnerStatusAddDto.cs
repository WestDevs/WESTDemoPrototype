using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Dto.LearnerStatusDto
{
    public class LearnerStatusAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int LearnerId { get; set; }
        
        [Required(ErrorMessage = "The field {0} is required")]
        public int CourseId { get; set; }

    }
}