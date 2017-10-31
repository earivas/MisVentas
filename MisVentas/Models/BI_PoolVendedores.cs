
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MisVentas.Models
{
    public class BI_PoolVendedores
    {
        [Key]
        public int IdUserDomain { get; set; }
        public string UserDomain { get; set; }
        public string Email { get; set; }
        public string IdVendedor { get; set; }
        public string VendFilter { get; set; }
    }
}