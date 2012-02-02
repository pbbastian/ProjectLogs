using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core.Continuations;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using DotNetOpenAuth.OpenId;
using FubuMVC.Core.Urls;
using ProjectLogs.Infrastructure.Common;

namespace ProjectLogs.Handlers.Logins.OpenId
{
    public class PostHandler
    {
        private readonly IUrlRegistry urlRegistry;

        public PostHandler(IUrlRegistry urlRegistry)
        {
            this.urlRegistry = urlRegistry;
        }

        [ValidationHandler(typeof(Logins.RequestModel))]
        public FubuContinuation Execute(InputModel model)
        {
            using (var openId = new OpenIdRelyingParty())
            {
                var realm = Realm.AutoDetect;
                var url = realm + urlRegistry.UrlFor<Callback.InputModel>().Substring(1);
                var request = openId.CreateRequest(model.OpenId, realm, new Uri(url));
                request.AddExtension(new ClaimsRequest
                {
                    BirthDate = DemandLevel.Request,
                    Country = DemandLevel.Request,
                    Email = DemandLevel.Require,
                    FullName = DemandLevel.Request,
                    Nickname = DemandLevel.Request
                });
                var redirectUrl = request.RedirectingResponse.Headers["Location"];
                return FubuContinuation.RedirectTo(redirectUrl);
            }
        }
    }
}