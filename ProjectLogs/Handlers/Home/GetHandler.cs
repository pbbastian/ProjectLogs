using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLogs.Handlers.Home
{
    public class GetHandler
    {
        public HomeViewModel Execute(HomeRequestModel model)
        {
            return new HomeViewModel();
        }
    }
}