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

        public ActionResult Ventas()
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

        MisVentas.Models.MisVentasContext db1 = new MisVentas.Models.MisVentasContext();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            string userName = System.Web.HttpContext.Current.Session["Username"] as string;
            var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
            var vtas = db.BI_Ventas_Historicas.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();
          //  var model = db1.BI_Ventas_Historicas;
            return PartialView("_GridView1Partial", vtas.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(MisVentas.Models.BI_Ventas_Historicas item)
        {
            var model = db1.BI_Ventas_Historicas;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
                return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(MisVentas.Models.BI_Ventas_Historicas item)
        {
            var model = db1.BI_Ventas_Historicas;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 ID)
        {
            var model = db1.BI_Ventas_Historicas;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model.ToList());
        }
    }
}