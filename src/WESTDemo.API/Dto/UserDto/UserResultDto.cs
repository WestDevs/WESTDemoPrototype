using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WESTDemo.API.Dto.OrganisationDto;
using WESTDemo.API.Dto.UserTypeDto;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Dto.UserDto
{
    public class UserResultDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public UserTypeResultDto Type { get; set; }
        public OrganisationResultDto Organisation { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Status { get; set; }
    }
}
