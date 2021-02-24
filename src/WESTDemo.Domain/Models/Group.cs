using System.Collections.Generic;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Models
{
    public class Group : Entity
    {
        public string Name { get; set; }

    // Navigation Property
        public ICollection<LearnerGroup> LearnerGroups { get; set; }
}
}