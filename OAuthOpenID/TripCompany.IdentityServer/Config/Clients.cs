using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripGallery.Constants;

namespace TripCompany.IdentityServer.Config
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[] {
                new Client
                {
                    ClientId = "ClientOne",
                    ClientName = "MVC Client Application",
                    Flow = Flows.ClientCredentials,
                    //Flow = Flows.ResourceOwner,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret(Constants.TripGalleryClientSecret.Sha256())
                    },
                    AllowAccessToAllScopes = true,
                    //Enabled = true,
                    //AccessTokenType = AccessTokenType.Jwt
                }
            };
        }
    }
}
