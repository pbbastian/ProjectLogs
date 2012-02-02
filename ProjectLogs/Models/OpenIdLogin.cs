using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLogs.Models
{
    public class OpenIdLogin
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ClaimedIdentifier { get; set; }
        public string FriendlyIdentifier { get; set; }
    }
}