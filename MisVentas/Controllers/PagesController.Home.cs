using MisVentas.Models.Code;
using System.Web.Mvc;
using DevExpress.DashboardWeb.Mvc;
using System.IO;
using System;
using DevExpress.DataAccess.EntityFramework;
using DevExpress.DashboardCommon;
using MisVentas.Models;
using System.Linq;
using MisVentas.Dashboard;
using DevExpress.DataAccess.Sql;

namespace MisVentas.Controllers
{


    public partial class PagesController : Controller

    {

        [SessionExpire]

        public ActionResult Home()
        {
            return View();
        }

      

        [ValidateInput(false)]
        public ActionResult DashboardViewerPartial()
        {
            return PartialView("~/Views/Pages/_DashboardViewerPartial.cshtml", DashboardViewerSettings.Model);
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
                MisVentas.Models.MisVentasContext db = new Models.MisVentasContext();
                string userName = System.Web.HttpContext.Current.Session["Username"] as String;
                var vendedorID = db.BI_PoolVendedores.Where(vd => vd.UserDomain == userName).Select(vd => vd.VendFilter).First();
                var ppto = db.BI_Presupuestos.Where(bi => bi.VendFilter == vendedorID.ToString()).ToList();

                DashboardSourceModel model = new DashboardSourceModel();
                model.DashboardSource = ppto; //typeof(BI_Presupuestos);
                return DashboardViewerSettings.DashboardSourceModel();
            }
        }
        private static DashboardSourceModel DashboardSourceModel()
        {
            DashboardSourceModel model = new DashboardSourceModel();
            model.DashboardSource = System.Web.Hosting.HostingEnvironment.MapPath(@"~\App_Data\DashboardMisventas.xml");

            model.DashboardSource = typeof(DashboardVentas);
            model.DashboardLoaded = new DevExpress.DashboardWeb.DashboardLoadedWebEventHandler((s, e) =>
            {
               

                //  ((DevExpress.DataAccess.Sql.CustomSqlQuery)(((DevExpress.DataAccess.Sql.SqlDataSource)(e.Dashboard.DataSources[0])).Queries[0])).Sql += " where (\"Invoices\".\"Discount\" > 0)";
                ((DevExpress.DataAccess.Sql.SelectQuery)(((DevExpress.DataAccess.Sql.SqlDataSource)(e.Dashboard.DataSources[0])).Queries[0])).FilterString  += "VendFilter =  001"; //e += vendedorID;// "017"; //+= " where (\"VendFilder\" = 017)";
             //   " WHERE [Categories].[CategoryID] IN " + builder.ToString();

            });
            return model;

            //return new DashboardSourceModel();

            //*     DashboardSourceModel model = new DashboardSourceModel();
            //*     model.DashboardSource = @"~\App_Data\DashboardMisventas.xml";// your dashboard definition file
            //*     model.DashboardLoaded = (sender, e) => {
            //*      Dashboard dashboard = e.Dashboard;
            //TODO initialize parameter values
        }

        private void dashboardViewer_CustomParameters(object sender, CustomParametersEventArgs e)
        {
            var custIDParameter = e.Parameters.FirstOrDefault(p => p.Name == "VendID");
            if (custIDParameter != null)
            {
                custIDParameter.Value = "017";
            }

        }
    }
}


