using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DashboardWeb.Mvc;
using DevExpress.DataAccess.EntityFramework;
using System.Web.Routing;

namespace MisVentas.App_Start
{
    public class DashboardConfig
    {
        public static void RegisterService(RouteCollection routes)
        {
            routes.MapDashboardRoute("dashboardControl");
            DashboardFileStorage dashboardFileStorage = new DashboardFileStorage(@"~/App_Data/");
            
            //*  routes.MapDashboardRoute();

            // Uncomment this line to save dashboards to the App_Data folder.
            //DashboardConfigurator.Default.SetDashboardStorage(new DashboardFileStorage(@"~/App_Data/"));
            DashboardConfigurator.Default.SetDashboardStorage(dashboardFileStorage);
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();
            // Registers an Entity Framework data source.
            DashboardEFDataSource efDataSource = new DashboardEFDataSource("EF Data Source");
            //   efDataSource.ConnectionParameters = new EFConnectionParameters(typeof(MisVentas.Models.MisVentasContext));
            efDataSource.ConnectionParameters = new EFConnectionParameters(typeof(MisVentas.Models.BI_Presupuestos));
            dataSourceStorage.RegisterDataSource("efDataSource", efDataSource.SaveToXml());
            // Uncomment these lines to create an in-memory storage of dashboard data sources. Use the DataSourceInMemoryStorage.RegisterDataSource
            // method to register the existing data source in the created storage.
            //var dataSourceStorage = new DataSourceInMemoryStorage();
            DashboardConfigurator.Default.SetDataSourceStorage(dataSourceStorage);
        }
    }

}