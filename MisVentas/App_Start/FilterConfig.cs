using MisVentas.Models;
using System.Web;
using System.Web.Mvc;

namespace MisVentas {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionAuthorizeAttribute());
        }
    }
}