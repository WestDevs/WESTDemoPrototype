using System.Collections.Generic;

namespace WESTDemo.Domain.Models
{
    public class Group : Entity
    {
        public string Name { get; set; }

    // Navigation Property
        public ICollection<Learner> Learners { get; set; }
}
}