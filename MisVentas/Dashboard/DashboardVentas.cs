using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.DataAccess;
using DevExpress.DashboardCommon;

namespace MisVentas.Dashboard
{
    public partial class DashboardVentas : DevExpress.DashboardCommon.Dashboard
    {
        MisVentas.Models.MisVentasContext db = new Models.MisVentasContext();
        string userName = System.Web.HttpContext.Current.Session["Username"] as String;

     
        public DashboardVentas()
        {
              InitializeComponent();
        }

    }
}
