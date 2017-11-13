using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WA_UNAM_NB_PR.Controllers.Services
{
    public class ProcessController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [ActionName("go")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}