using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuValidation;

namespace ProjectLogs.Handlers.Home
{
    public class HomeInputModel
    {
        [Required]
        public string Message { get; set; }
    }
}