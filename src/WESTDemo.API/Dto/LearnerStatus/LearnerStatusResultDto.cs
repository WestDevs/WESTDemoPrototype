using System.Collections.Generic;
using WESTDemo.API.Dto.CourseDto;
using WESTDemo.API.Dto.LearnerDto;

namespace WESTDemo.API.Dto.LearnerStatusDto
{
    public class LearnerStatusResultDto
    {
        public LearnerResultDto Learner { get; set; }
        public ICollection<CourseResultDto> Course { get; set; }
    }
}