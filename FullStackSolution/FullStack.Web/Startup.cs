using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OpenIdConnect;

[assembly: OwinStartup(typeof(FullStack.Web.Startup))]

namespace FullStack.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions {
                ClientId = "fullstack_web",
                Authority = "http://localhost:58636/",
                RedirectUri = "http://localhost:49867/Home/PrivateInfo",
                ResponseType = "token id_token",
                Scope = "openid profile read",
                PostLogoutRedirectUri = "http://localhost:49867",
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                RequireHttpsMetadata = false,

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    SecurityTokenValidated = notification =>
                    {
                        var identity = notification.AuthenticationTicket.Identity;

                        identity.AddClaim(new System.Security.Claims.Claim("id_token", notification.ProtocolMessage.IdToken));
                        identity.AddClaim(new System.Security.Claims.Claim("access_token", notification.ProtocolMessage.AccessToken));

                        notification.AuthenticationTicket = new AuthenticationTicket(identity, notification.AuthenticationTicket.Properties);

                        return Task.FromResult(0);
                    },
                    RedirectToIdentityProvider = notification =>
                    {
                        if(notification.ProtocolMessage.RequestType != 
                           Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectRequestType.Logout)
                        {
                            return Task.FromResult(0);
                        }

                        notification.ProtocolMessage.IdTokenHint = notification.OwinContext.Authentication.User.FindFirst("id_token").Value;

                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
}
