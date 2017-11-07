using ArqSecurity.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WA_UNAM_NB_PR.Controllers
{
    public class UsersController : MvcControllerAppIdentity
    {
       
        public ActionResult Test()

        {
            //var _user = Usuario;
            //if (_user != null) return Ok(_user);
            //return NotFound();
            var _user = Usuario;
            if (_user != null) return Json(_user, JsonRequestBehavior.AllowGet);
            return View("no funciona");
        }
    }
}
