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
// using System.ComponentModel.DataAnnotations;
// using WESTDemo.API.Dto.UserDto;

// namespace src.WESTDemo.API.Dto.LearnerDto
// {
//     public class LearnerAddDto : UserAddDto
//     {
//         private const int _typeId = 2;

//         public override int TypeId { get => _typeId; }


//         [Required(ErrorMessage = "The field {0} is required")]
//         public int GroupId { get; set; }


//     }
// }