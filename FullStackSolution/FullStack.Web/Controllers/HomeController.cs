using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FullStack.Web.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult PrivateInfo()
        {
            ViewBag.Message = "This is private info view.";
            var claimsPrincipal = User as ClaimsPrincipal;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", claimsPrincipal.FindFirst("access_token").Value);

                // Here, you can add logic to call APIs (using client) which require authorization.
                //var profile = await client.GetAsync("")
            }

                return View(claimsPrincipal.Claims);
        }

        [Authorize]
        public ActionResult Logout()
        {
            if (!Request.GetOwinContext().Authentication.User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "You are not logged-in";
                return View();
            }

            return Redirect("/");
        }
    }
}