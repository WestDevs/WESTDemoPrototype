using System.Collections.Generic;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Models
{
    public class Learner : Entity
    {
        public int UserId { get; set; }
        //Navigation Property
        public ICollection<LearnerStatus> LearnerCourses { get; set; }
        public LearnerGroup LearnerGroup { get; set; }
        public User User { get; set; }
    }
}