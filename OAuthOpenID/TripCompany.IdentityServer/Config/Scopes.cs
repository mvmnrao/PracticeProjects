using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripCompany.IdentityServer.Config
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>()
            {
                new Scope()
                {
                    Name = "gallerymanagement",
                    DisplayName = "Gallary Management",
                    Description = "Allow application to manage Galleries on your behalf.",
                    Type = ScopeType.Resource
                }
            };
        }
    }
}
