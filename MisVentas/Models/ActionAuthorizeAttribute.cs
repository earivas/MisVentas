using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace MisVentas.Models
{

    [AttributeUsage(AttributeTargets.All | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ActionAuthorizeAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
            if (!controller.Equals("account"))
            {

                try
                {
                    if (string.IsNullOrEmpty(HttpContext.Current.Session["Username"].ToString())
                        || string.IsNullOrEmpty(HttpContext.Current.Session["Password"].ToString()))
                    {
                        //send them off to the login page
                        var url = new UrlHelper(filterContext.RequestContext);
                        string access = string.Empty;
                        access = "/ Account / Login";
                        var loginUrl = url.Content(access);
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            filterContext.HttpContext.Response.Write("< script >");
                            filterContext.HttpContext.Response.Write("window.location.reload('" + loginUrl + "');");
                            filterContext.HttpContext.Response.Write("</ script >");
                        }
                        else
                        {
                            var routeValues = new RouteValueDictionary(new
                            {
                                action = "Login",
                                controller = "Account"
                            });
                            filterContext.Result = new RedirectToRouteResult(routeValues);
                        }
                    }

                }
                catch (Exception e)
                {


                }



            }
            base.OnActionExecuting(filterContext);
        }
    }
}