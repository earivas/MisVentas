using MisVentas.Models;
using MisVentas.Models.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MisVentas.Controllers
{
    public  class DataOutputController : DemoController
    {
        public override string Name { get { return "DataOutput"; } }

        public ActionResult Index()
        {
            return RedirectToAction("ChartsIntegration");
        }
    }
}