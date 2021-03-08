using System.Collections.Generic;

namespace WESTDemo.Domain.Models
{
    public class Learner : Entity
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        
        //Navigation Property
        public ICollection<LearnerStatus> LearnerStatus { get; set; }
        public Group Group { get; set; }
        public User User { get; set; }
    }
}