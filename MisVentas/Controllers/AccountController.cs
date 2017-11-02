using MisVentas.Models;
using MisVentas.Models.Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MisVentas.Controllers
{
    [HandleError(View ="Error")]
    public class AccountController : Controller
    {
        // GET: Account
        
        
      
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            //Check LDAP Authentication
            if (this.AuthenticateAD(model.Username, model.Password))
            {
                //Save credentials to use while accessing reports.
                Session["Username"] = model.Username;
                Session["Password"] = model.Password;


                System.Web.HttpContext.Current.Session["Username"] = model.Username;
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") &&
                    !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))

                {
                    return this.Redirect(returnUrl);
                }
                return this.RedirectToAction("Home", "Pages");
            }
            this.ModelState.AddModelError(string.Empty, "Usuario o password incorrecto.");
            return this.View(model);
        }
        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            // return RedirectToAction("Index", "Home");
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }


        public bool AuthenticateAD(string username, string password)
        {


            try
            {
                var Val = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["DomainName"]);
            }

            catch

            {
                throw new MisVentasException("No se pudo conectar con el servidor");
            }

         
           using ( var context = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["DomainName"]))
                {
                 return context.ValidateCredentials(username, password);
                }
          
          
        }
    }
}