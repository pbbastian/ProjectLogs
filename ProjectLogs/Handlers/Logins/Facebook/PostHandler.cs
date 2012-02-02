using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLogs.Infrastructure.Login;

namespace ProjectLogs.Handlers.Logins.Facebook
{
    public class PostHandler
    {
        public string Execute(InputModel model)
        {
            FacebookClient client = new FacebookClient()
                {
                    ClientIdentifier = "378177968863661",
                    ClientSecret = "1cb526369e0f68fdaee92732bf99e037",
                };
            client.RequestUserAuthorization(returnTo: null);
            return null;
        }
    }
}