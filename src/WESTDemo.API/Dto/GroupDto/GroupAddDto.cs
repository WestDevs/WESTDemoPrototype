using System.ComponentModel.DataAnnotations;

namespace WESTDemo.API.Dto.GroupDto
{
    public class GroupAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 1)]
        public string Name { get; set; }
    }
}