using ArqSecurity.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WA_UNAM_NB_PR.Models.Services
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : WebApiIdentity
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Test()
        {
            var _user = Usuario;
            if (_user != null) return Ok(_user);
            return NotFound();
        }
    }
}