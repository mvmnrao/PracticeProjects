using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace FullStack.OAuth
{
    public class FactoryClass
    {
        public static List<InMemoryUser> GetInMemoryUsers()
        {
            return new List<InMemoryUser> {
                new InMemoryUser
                {
                    Subject = "manik@manik.com",
                    Username = "manik@manik.com",
                    Password = "manik",
                    Claims = new[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Manikyarao Murukutla")
                    }
                }
            };
        }

        public static IEnumerable<Scope> GetInMemoryScopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name = "read",
                    DisplayName = "Only read access"
                }
            };
        }

        public static IEnumerable<Client> GetInMemoryClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "fullstack",
                    ClientSecrets = new List<Secret>{
                        new Secret("secret".Sha256())
                    },
                    ClientName = "FullStack",
                    Flow = Flows.ResourceOwner,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "read"
                    },
                    Enabled = true
                },

                new Client
                {
                    ClientId = "fullstack_web",
                    ClientSecrets = new List<Secret>{
                        new Secret("secret".Sha256())
                    },
                    ClientName = "FullStackWeb",
                    Flow = Flows.Implicit,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        "read"
                    },
                    RedirectUris = new List<string>{
                        "http://localhost:49867/Home/PrivateInfo"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:49867"
                    },
                    Enabled = true
                }
            };
        }
    }
}