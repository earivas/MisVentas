using MisVentas.Models;
using MisVentas.Models.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisVentas.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Inicio()
        {
            ViewBag.UserName = HttpContext.User.Identity.Name;
            return View();
        }

        MisVentas.Models.MisVentasContext db = new Models.MisVentasContext();

        [ValidateInput(false)]
        //   [HttpPost, Authorize, ValidateAntiForgeryToken] // nuevo
        [SessionExpire]
        public ActionResult PivotGridPartial()
        {

            string userName = System.Web.HttpContext.Current.Session["Username"] as String;

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

            // Obtengo el Codigo de vendedor de la tabla BI_PoolVendedores
            var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();
            return PartialView("_PivotGridPartial", ppto.ToList());
        }



    }
}