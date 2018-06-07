
using IdentityServer3.Core.Configuration;
using Owin;
using Serilog;
//using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TripCompany.IdentityServer.Certificates;
using TripCompany.IdentityServer.Config;
using TripGallery.Constants;

namespace TripCompany.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            Log.Information("Test Serilog message.");

            //.MinimumLevel.Debug()
            //.WriteTo.Trace()
            //.CreateLogger();

            //        Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Debug()
            //.WriteTo.LiterateConsole()
            //.CreateLogger();

            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo
            //    .Console(outputTemplate: "{Timestamp:HH:MM} [{Level}] ({Name:l}){NewLine} {Message}{NewLine}{Exception}")
            //    .CreateLogger();

            app.Map("/identity", idsrvApp =>
            {
                var idServerServiceFactory = new IdentityServerServiceFactory()
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get())
                    .UseInMemoryUsers(Users.Get());

                var options = new IdentityServerOptions
                {
                    Factory = idServerServiceFactory,
                    SiteName = "Trip Company Security Token Service",
                    IssuerUri = Constants.TripGalleryIssuerUri,
                    PublicOrigin = Constants.TripGallerySTSOrigin,
                    //SigningCertificate = Certificate.Load(),
                    RequireSsl = false
                };

                idsrvApp.UseIdentityServer(options);
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return
                new X509Certificate2(
                    @"D:\Manik\Practice\OAuthOpenID\TripCompany.IdentityServer\Certificates\idsrv3test.pfx",
                    "idsrv3test");
//String.Format({0}\certificates\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}
