using System.Collections.Generic;
using WESTDemo.API.Dto.UserDto;
using WESTDemo.Domain.Models;

namespace WESTDemo.API.Dto.LearnerDto
{
    public class LearnerResultDto 
    {
        public int GroupId { get; set; }
        public UserResultDto User { get; set; }
         public ICollection<LearnerStatus> LearnerStatus { get; set; }

    }
}