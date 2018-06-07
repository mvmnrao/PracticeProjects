using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Thinktecture.IdentityModel.WebApi;
using WebLayerApi.Models;

namespace WebLayerApi.Controllers
{
    public class DefaultController : ApiController
    {
        static IList<string> myList = new List<string>();

        //// GET: api/Default
        //public IEnumerable<string> Get()
        //{
        //    return myList;// new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [ScopeAuthorize("read")]
        public string GetMessage()
        {
            /*MyModel myModel = new MyModel();
            myModel.Dispose();
            GC.SuppressFinalize();
            GC.ReRegisterForFinalize();
            GC.WaitForPendingFinalizers();*/

            var claimsPrincipal = User as ClaimsPrincipal;
            string user = claimsPrincipal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            return $"This is authorized action for {user}";
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            if (myList.Count() > id)
            {
                return myList[id];
            }
            else
            {
                return $"id should be lesser than {myList.Count().ToString()}";
            }

        }

        // POST: api/Default
        public string Post([FromBody]UserDetails value)
        {
            myList.Add(value.Name);
            return value.Name;
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]UserDetails value)
        {
            if(myList.Count() > id)
            {
                myList[id] = value.Name;
            }
            else
            {
                myList.Add(value.Name);
            }
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
            if(myList.Count() > id)
            {
                myList.RemoveAt(id);
            }
        }
    }

    public class UserDetails
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
