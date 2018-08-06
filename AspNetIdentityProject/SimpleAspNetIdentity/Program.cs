using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAspNetIdentity
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userName = "Manik";
            string password = "password";

            IUserStore<IdentityUser> userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(userStore);

            //IdentityResult identityResult = userManager.Create(new IdentityUser(userName), password);
            //Console.WriteLine("Created user: " + identityResult.Succeeded);
            //foreach (string error in identityResult.Errors)
            //{
            //    Console.WriteLine(error);
            //}

            IdentityUser identityUser = userManager.FindByName(userName);
            userManager.AddClaim(identityUser.Id, new Claim("given_name", "Manikyarao"));
            bool isValidUser = userManager.CheckPassword(identityUser, password);

            Console.WriteLine("Is valid user? " + isValidUser);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
