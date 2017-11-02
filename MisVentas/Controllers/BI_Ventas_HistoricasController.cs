using DevExpress.Web.Mvc;
using MisVentas.Models;
using MisVentas.Models.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisVentas.Controllers
{
    public class BI_Ventas_HistoricasController : Controller
    {
        // GET: BI_Ventas_Historicas
        public ActionResult Index()
        {
            ViewBag.UserName = HttpContext.User.Identity.Name;
            return View();
        }

        MisVentas.Models.MisVentasContext db = new Models.MisVentasContext();

        [ValidateInput(false)]
        public ActionResult PivotGridPartial()
        {
            string userName = System.Web.HttpContext.Current.Session["Username"] as string;
            try
            {
                var vendedor = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            }
            catch (Exception)
            {
                if (userName == null)
                {
                    throw new MisVentasException("");
                }
                else
                {
                    throw new MisVentasException("No se pudo establecer conexión a la base de datos");
                }
            }
            var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var vtas = db.BI_Ventas_Historicas.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();
            return PartialView("_PivotGridPartial", vtas.ToList());

        }
    }
}