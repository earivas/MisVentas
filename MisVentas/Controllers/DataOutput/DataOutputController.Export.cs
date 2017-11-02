using MisVentas.Models;
using MisVentas.Models.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisVentas.Controllers.DataOutput
{
    public partial class DataOutputController : BI_PresupuestosController
    {
        MisVentas.Models.MisVentasContext db = new Models.MisVentasContext();
        [HttpGet]
        public ActionResult Export()
        {
            string userName = System.Web.HttpContext.Current.Session["Username"] as String;
            var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();
            ViewBag.MisVentasOption = ViewBag.MisVentasOption ?? new PivotGridExportOptions();
            //  return PartialView("Export", ppto.ToList());
            return View("Export", ppto.ToList());

        }
        [HttpPost]
        public ActionResult Export(PivotGridExportOptions options)
        {
            string userName = System.Web.HttpContext.Current.Session["Username"] as String;
            if (Request.Params["ExportTo"] == null)
            { // Theme changing
              //  string userName = System.Web.HttpContext.Current.Session["Username"] as String;
                var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
                var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();

                ViewBag.MisVentasOption = options;
                return View("Export", ppto.ToList());
                //return View("Export", NorthwindDataProvider.GetCustomerReports());
            }

          //  string userName = System.Web.HttpContext.Current.Session["Username"] as String;
            var vendedorIDExp = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var pptoExp = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorIDExp.ToString()).ToList();
            return PivotGridDataOutputHelper.GetExportActionResult(options, pptoExp.ToList());
        }
        public ActionResult ExportPartial()
        {
            string userName = System.Web.HttpContext.Current.Session["Username"] as String;
            var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();
            return PartialView("ExportPartial", ppto.ToList());
        }
    }
}