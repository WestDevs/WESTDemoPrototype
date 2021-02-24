using System.Collections.Generic;

namespace WESTDemo.Domain.Models
{
    public class Organisation : Entity
    {
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Centre> Centres { get; set; }

    }
}