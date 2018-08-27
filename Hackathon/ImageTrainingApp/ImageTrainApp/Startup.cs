using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageTrainApp.Startup))]
namespace ImageTrainApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
