using System.Collections.Generic;
using WESTDemo.API.Dto.CourseDto;
using WESTDemo.API.Dto.GroupDto;
using WESTDemo.API.Dto.LearnerStatusDto;
using WESTDemo.API.Dto.OrganisationDto;
using WESTDemo.API.Dto.UserDto;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Dto.LearnerDto
{
    public class LearnerResultDto 
    {
        // public GroupResultDto Group { get; set; }

        public int Id { get; set; }
        public GroupResultDto Group { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public OrganisationResultDto Organisation { get; set; }
        public bool Status { get; set; }
        // public UserResultDto User { get; set; }
        public ICollection<CourseResultDto> LearnerStatus { get; set; }

    }
}