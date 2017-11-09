using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MisVentas.Models
{
    public class BI_Inventarios
    {
        [Column(TypeName = "numeric")]
        [Key]
        public int ID { get; set; }
        public string IdCentro { get; set; }
        public string Centro { get; set; }
        public string Producto { get; set; }
        public string IdMaterial { get; set; }
        public string IdAlmacen { get; set; }
        public string Almacen { get; set; }
        public string Ciudad { get; set; }
        public string NombreG1 { get; set; }
        public string Idlote { get; set; }
        public string LoteVencimiento { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string UndNegocio { get; set; }
        public string Linea { get; set; }
        public int EsdConsignacion { get; set; }
        public decimal? CtdLibreU { get; set; }
        public decimal? CtdTraslado { get; set; }
        public decimal? CtdCtrlCalidad { get; set; }
        public decimal? CtdBloqueado { get; set; }
        public decimal? CostoBloqueado { get; set; }
        public decimal? CostoUnd { get; set; }
        public decimal? CostoLibreU { get; set; }
        public int DiasVencimiento { get; set; }
        public string RangoVcto { get; set; }

    }
}