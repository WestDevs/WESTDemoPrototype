using System.ComponentModel.DataAnnotations;

namespace WESTDemo.API.Dto.CourseDto
{
    public class CourseEditDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 1)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 1)]
        public string IconPath { get; set; }

        
    }
}