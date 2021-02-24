using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WESTDemo.API.Dto.CentreDto;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Dto.OrganisationDto
{
    public class OrganisationAddDto
    {        
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 1)]
        public string Name { get; set; }

        public IEnumerable<CentreAddDto> Centres {get; set;}
    }
}