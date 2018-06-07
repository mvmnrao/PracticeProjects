using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripCompany.IdentityServer.Config
{
    public class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser()
                {
                    Username = "Manik",
                    Password = "Manik",
                    Subject = "ManikUserSubject"
                },
                new InMemoryUser()
                {
                    Username = "Test",
                    Password = "Test",
                    Subject = "TestUserSubject"
                }
            };
        }
    }
}
