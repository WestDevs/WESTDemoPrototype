using System.ComponentModel.DataAnnotations;
using WESTDemo.API.Dto.UserDto;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Dto.LearnerDto
{
    public class LearnerAddDto 
    {

        [Required(ErrorMessage = "The field {0} is required")]
        public int GroupId { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public UserAddDto UserDetails { get; set; }


    }
}