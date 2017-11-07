using ArqSecurity.WebApi;
using System.Web.Http;
using System.Web.Mvc;

namespace WA_UNAM_NB_PR.Controllers
{
    public class UsersController : MvcControllerAppIdentity
    {
        //[System.Web.Http.HttpGet]
        //[System.Web.Http.Route("hola")]
        public ActionResult Test()

        {
            //var _user = Usuario;
            //if (_user != null) return Ok(_user);
            //return NotFound();
            var _user = Usuario;
            if (_user != null) { return Json(_user, JsonRequestBehavior.AllowGet); }
            else {
                return Json("Usuario Invalido",JsonRequestBehavior.AllowGet);
            }
        }
    }
}
