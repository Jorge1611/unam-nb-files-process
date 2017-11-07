using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using WA_UNAM_NB_PR.Models;
using ArqSecurity.Model;
using ArqSecurity;


namespace WA_UNAM_NB_PR
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    //public class applicationusermanager : usermanager<applicationuser>
    //{
    //    public applicationusermanager(iuserstore<applicationuser> store)
    //        : base(store)
    //    {
    //    }

    //    public static applicationusermanager create(identityfactoryoptions<applicationusermanager> options, iowincontext context)
    //    {
    //        var manager = new applicationusermanager(new userstore<applicationuser>(context.get<applicationdbcontext>()));
    //        // configure validation logic for usernames
    //        manager.uservalidator = new uservalidator<applicationuser>(manager)
    //        {
    //            allowonlyalphanumericusernames = false,
    //            requireuniqueemail = true
    //        };

    //        // configure validation logic for passwords
    //        manager.passwordvalidator = new passwordvalidator
    //        {
    //            requiredlength = 6,
    //            requirenonletterordigit = true,
    //            requiredigit = true,
    //            requirelowercase = true,
    //            requireuppercase = true,
    //        };

    //        // configure user lockout defaults
    //        manager.userlockoutenabledbydefault = true;
    //        manager.defaultaccountlockouttimespan = timespan.fromminutes(5);
    //        manager.maxfailedaccessattemptsbeforelockout = 5;

    //        // register two factor authentication providers. this application uses phone and emails as a step of receiving a code for verifying the user
    //        // you can write your own provider and plug it in here.
    //        manager.registertwofactorprovider("phone code", new phonenumbertokenprovider<applicationuser>
    //        {
    //            messageformat = "your security code is {0}"
    //        });
    //        manager.registertwofactorprovider("email code", new emailtokenprovider<applicationuser>
    //        {
    //            subject = "security code",
    //            bodyformat = "your security code is {0}"
    //        });
    //        manager.emailservice = new emailservice();
    //        manager.smsservice = new smsservice();
    //        var dataprotectionprovider = options.dataprotectionprovider;
    //        if (dataprotectionprovider != null)
    //        {
    //            manager.usertokenprovider =
    //                new dataprotectortokenprovider<applicationuser>(dataprotectionprovider.create("asp.net identity"));
    //        }
    //        return manager;
    //    }
    //}

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
