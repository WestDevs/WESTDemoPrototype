using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WESTDemo.API.Dto.User
{
    public class UserAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
