using DevExpress.Web.Mvc;
using MisVentas.Models;
using MisVentas.Models.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;


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

        public ActionResult General()
        {

            //            var AllBook2 = MyEntity.Books.GroupBy(g => g.Name)
            //.Select(s => new { Name = s.Key, Group = s });


            //dashboardSqlDataSource1

            string userName = System.Web.HttpContext.Current.Session["Username"] as String;

            var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();

            var result = ppto.GroupBy(g => g.MesNombre)
                .Select(s => new
                {
                    MesNombre = s.Key,
                    Ppto =       s.Sum(v => v.PptoMlocal),
                    VentaMLAct = s.Sum(v=> v.VentaMLActual),
                    VentaMLAnt = s.Sum(v=> v.VentaMLAnterior)
                });

            //var ListByOwner = list.GroupBy(l => l.Owner)
            //            .Select(lg =>
            //                  new {
            //                      Owner = lg.Key,
            //                      Boxes = lg.Count(),
            //                      TotalWeight = lg.Sum(w => w.Weight),
            //                      TotalVolume = lg.Sum(w => w.Volume)
            //                  });



            //var result = from p in ppto
            //             group p by new { p.MesNombre, p.Linea } into r
            //             select new
            //             {
            //                 MesNombre = r.Key.MesNombre,
            //                 PptoMlocal = r.Sum(),
            //                 VentaMLActual = r.Sum(),
            //                 VentaMLAnterior=r.Sum()

            //             };

            return View(result.ToList());
    }


        public ActionResult ChartPartial()
        {

            string userName = System.Web.HttpContext.Current.Session["Username"] as String;

            var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();

            var model = ppto.GroupBy(g => g.MesNombre)
                .Select(s => new
                {
                    MesNombre = s.Key,
                    Ppto = s.Sum(v => v.PptoMlocal),
                    VentaMLAct = s.Sum(v => v.VentaMLActual),
                    VentaMLAnt = s.Sum(v => v.VentaMLAnterior)
                });

           // var model = new object[0];

            //return PartialView("_ChartPartial", model);
            return PartialView("_ChartPartial", model);
        }
    }
}