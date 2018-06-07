using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TripGallery.MVCClient.Helper;

namespace TripGallery.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            HttpClient client = TripGalleryHttpClient.GetClient();

            var response = await client.GetAsync("http://localhost:51528/api/Pictures");

            ViewBag.Message = "Following content is received from API: " + response.Content.ReadAsStringAsync().Result;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}