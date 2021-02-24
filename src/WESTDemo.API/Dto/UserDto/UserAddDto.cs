using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WESTDemo.API.Dto.UserDto
{
    public class UserAddDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Username { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public virtual int TypeId { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public int OrganisationId { get; set; }
        
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string FirstName { get; set; }


        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
