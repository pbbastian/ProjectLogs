using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OAuth2;

namespace ProjectLogs.Infrastructure.Login
{
    public class TokenManager : IClientAuthorizationTracker
    {
        public IAuthorizationState GetAuthorizationState(Uri callbackUrl, string clientState)
        {
            return new AuthorizationState
            {
                Callback = callbackUrl,
            };
        }
    }
}