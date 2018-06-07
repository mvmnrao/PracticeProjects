using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TripGallery.API.Models;

namespace TripGallery.API.Controllers
{
    
    public class PicturesController : ApiController
    {
        // GET: api/Pictures
        [Authorize]
        public HttpResponseMessage Get()
        {
            PicturesModel model = new PicturesModel();
            HttpResponseMessage msg = Request.CreateResponse<PicturesModel>(HttpStatusCode.OK, model);
            return msg;
        }

        // GET: api/Pictures/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pictures
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pictures/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pictures/5
        public void Delete(int id)
        {
        }
    }
}
