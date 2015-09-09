using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpOut.Models
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
    }
}