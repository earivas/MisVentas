using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MisVentas.Models;

namespace MisVentas.Controllers
{
    [HandleError(View = "Error")]
    public class BI_PresupuestosController : Controller
    {

        // GET: BI_PRESUPUESTOS
        public ActionResult Index()
        {
            ViewBag.UserName = HttpContext.User.Identity.Name;
            return View();
        }

        MisVentas.Models.MisVentasContext db = new Models.MisVentasContext();

        //  [Authorize]
        [ValidateInput(false)]
        //   [HttpPost, Authorize, ValidateAntiForgeryToken] // nuevo
        public ActionResult PivotGridPartial()
        {

            string userName = System.Web.HttpContext.Current.Session["Username"] as String;

            try
            {
                var vendedor = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
               
            }
            catch (Exception)
            {
                throw new  MisVentasException("No se pudo establecer conexión a la base de datos");
            }

            // Obtengo el Codigo de vendedor de la tabla BI_PoolVendedores
              //if (db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).Count() == 0)
                //{

                //}

                 var  vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
                 var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();
                 return PartialView("_PivotGridPartial", ppto.ToList());
        }


        [ValidateInput(false)]
        public ActionResult DashboardViewerPartial()
        {
            string userName = System.Web.HttpContext.Current.Session["Username"] as String;
            var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();
            //return PartialView("~/Views/Pages/_DashboardViewerPartial.cshtml", DashboardViewerSettings.Model);
            return PartialView("~/Views/Pages/_DashboardViewerPartial.cshtml", ppto);
        }
        public FileStreamResult DashboardViewerPartialExport()
        {
            return DevExpress.DashboardWeb.Mvc.DashboardViewerExtension.Export("DashboardViewer", DashboardViewerSettings.Model);
        }

       
    }
    class DashboardViewerSettings
    {
        public static DevExpress.DashboardWeb.Mvc.DashboardSourceModel Model
        {
            get
            {
                return new DevExpress.DashboardWeb.Mvc.DashboardSourceModel();
            }
        }
    }
}