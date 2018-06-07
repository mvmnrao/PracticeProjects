using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TripGallery.MVCClient.Startup))]
namespace TripGallery.MVCClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
