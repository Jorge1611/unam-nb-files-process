using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using ArqSecurity.ViewModel;

namespace ArqSecurity.WebApi
{
    public class WebApiIdentity : ApiController
    {
        private ApplicationUserManager _userManager;
        protected ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }
            }
            base.Dispose(disposing);
        }
        protected string UserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }
        protected UsuarioViewModel Usuario
        {
            get
            {
                var _user = UserManager.FindById(UserId);
                if (_user != null) return _user;
                return null;
            }
        }
    }
}
