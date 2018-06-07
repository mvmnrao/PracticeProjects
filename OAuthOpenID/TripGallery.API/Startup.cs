using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using TripGallery.Constants;
using IdentityServer3.AccessTokenValidation;

//[assembly: OwinStartup(typeof(TripGallery.API.Startup))]

namespace TripGallery.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var config = WebApiConfig.Register();
            //app.UseWebApi(config);
            //InitAutoMapper();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions {
                Authority = Constants.Constants.TripGallerySTS,
                RequiredScopes = new[] { "gallerymanagement" }
            });
            //IdentityServerBearerTokenAuthenticationOptions()

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
