using MisVentas.Models.Code;
using System.Web.Mvc;

namespace MisVentas.Controllers
{
    public partial class PagesController : Controller
    {
        [SessionExpire]
        public ActionResult Home()
        {
            return View();
        }
    }
}