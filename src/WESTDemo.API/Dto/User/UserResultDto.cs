using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WESTDemo.API.Dto.User
{
    public class UserResultDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
