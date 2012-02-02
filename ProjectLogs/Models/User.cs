using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLogs.Models
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Location { get; set; }
        public DateTime Birthday { get; set; }
        public string AboutMe { get; set; }
    }
}