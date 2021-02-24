using System.Collections.Generic;
using WESTDemo.Domain.Models;

namespace WESTDemo.Domain.Models
{
    public class Course : Entity
    {
        public string Name { get; set; }
        public string IconPath { get; set; }          
        //NavigationProperty
        public ICollection<LearnerStatus> LearnerCourses { get; set; }
    }
}