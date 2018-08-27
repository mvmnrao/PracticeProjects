using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sampleWebApiClassic.Controllers
{
    [Route("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            System.IO.File.WriteAllText(@"D:\Manik\PracticeProjects\ASP.NETCore\SampleWebApiSol\sampleWebApiClassic\sample.txt", DateTime.Now.ToString());
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public void Post(string value)
        {
            Debug.WriteLine($"Received string: {value}");
            System.IO.File.WriteAllText(@"D:\Manik\PracticeProjects\ASP.NETCore\SampleWebApiSol\sampleWebApiClassic\sample.txt", value);
        }
    }
}
