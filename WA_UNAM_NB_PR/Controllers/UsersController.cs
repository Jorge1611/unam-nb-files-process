using ArqSecurity.WebApi;
using System.Web.Http;
using System.Web.Mvc;

namespace WA_UNAM_NB_PR.Controllers
{
    public class UsersController : MvcControllerAppIdentity
    {
        public ActionResult Test()

        {
            var _user = Usuario;
            if (_user != null) { return Json(_user, JsonRequestBehavior.AllowGet); }
            else {
                return Json("Usuario no credencializado",JsonRequestBehavior.AllowGet);
            }
        }
    }
}
