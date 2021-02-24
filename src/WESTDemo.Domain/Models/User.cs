using System;
using System.Collections.Generic;
using System.Text;

namespace WESTDemo.Domain.Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        // public byte[] PasswordHash { get; set; }
        // public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Status { get; set; }
        public int TypeId { get; set; }
        public int OrganisationId { get; set; }
        
        
        // Navigation properties
        
        public UserType Type { get; set; }
        public Organisation Organisation { get; set; }
    }
}
