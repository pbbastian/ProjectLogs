using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.Continuations;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace ProjectLogs.Handlers.Logins.OpenId.Callback
{
    public class GetHandler
    {
        public string Execute(InputModel model)
        {
            using (var openId = new OpenIdRelyingParty())
            {
                var response = openId.GetResponse();
                if (response != null)
                {
                    switch (response.Status)
                    {
                        case AuthenticationStatus.Authenticated:
                            var claimsResponse = response.GetExtension<ClaimsResponse>();
                            return String.Format("Authenticated as {0} ({1}) with email {2}", response.FriendlyIdentifierForDisplay, response.ClaimedIdentifier, claimsResponse.Email);
                        case AuthenticationStatus.Canceled:
                            return "User canceled authentication.";
                        case AuthenticationStatus.Failed:
                            return "Authentication failed.";
                    }
                }
            }
            return "Invalid!";
        }
    }
}