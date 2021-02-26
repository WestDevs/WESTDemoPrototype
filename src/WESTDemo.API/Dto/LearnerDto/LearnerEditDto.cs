using System.ComponentModel.DataAnnotations;
using WESTDemo.API.Dto.UserDto;

namespace WESTDemo.API.Dto.LearnerDto
{
    public class LearnerEditDto : UserEditDto
    {        
        private const int _typeId = 2;
        public int TypeId { get => _typeId; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int GroupId { get; set; }
        
    }
}