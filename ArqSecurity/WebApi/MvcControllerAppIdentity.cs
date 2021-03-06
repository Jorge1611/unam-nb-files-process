﻿using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using ArqSecurity.ViewModel;

namespace ArqSecurity.WebApi
{
    public class MvcControllerAppIdentity : Controller
    {
        private ApplicationUserManager _userManager;

        public MvcControllerAppIdentity()
        {

        }

        public MvcControllerAppIdentity(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        protected ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
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
                if (_user != null)
                {
                    return _user;
                }else
                {
                    return null;
                }
                //return (_user != null) ? _user :  null;

            }
        }
    }
}
