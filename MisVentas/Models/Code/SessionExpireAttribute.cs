using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;



namespace MisVentas.Models.Code
{

    public class SessionExpireAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            //Verificar Session

            //if (ctx.Session != null)
            //{
            //    if (ctx.Session.IsNewSession)
            //    {
            //        string sessionCookie = ctx.Request.Headers["Cookie"];
            //        var reqCook = ctx.Request.Cookies;
            //        if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId")
            //            {

            //            ctx.Response.Redirect("~/Account/Login", true);
            //        }


            //    }

            //}
            if (HttpContext.Current.Session["username"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            base.OnActionExecuted(filterContext);
        }
    }
}