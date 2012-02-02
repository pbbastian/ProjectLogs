using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLogs.Handlers.Home
{
    public class PostHandler
    {
        public HomeViewModel Execute(HomeInputModel model)
        {
            return new HomeViewModel { Message = model.Message };
        }
    }
}