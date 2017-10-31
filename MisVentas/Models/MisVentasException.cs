using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MisVentas.Models
{
    public class MisVentasException:Exception
    {
        public MisVentasException(String msg) : base(msg)
        {

        }
    }
}