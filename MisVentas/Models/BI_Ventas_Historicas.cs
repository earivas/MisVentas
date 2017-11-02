using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MisVentas.Models
{
    public  class BI_Ventas_Historicas
    {  
        [Column(TypeName = "numeric")]
     //   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        public int Anyo { get; set; }
        public string Trimestre { get; set; }
        public string Mes { get; set; }
        public string MesNombre { get; set; }
        public string UndNegocio { get; set; }
        public string Linea { get; set; }
        public string IdOrgVentas { get; set; }
        public string OrgVentas { get; set; }
        public string IdVendedor { get; set; }
        public string IdCliente { get; set; }
        public string NombreComercial { get; set; }
        public string IdCeBe { get; set; }
        public string UndNegocioProducto { get; set; }
        public string NombreG1 { get; set; }
        public string NombreG2 { get; set; }
        public string NombreG3 { get; set; }
        public string Producto { get; set; }
        public string idmaterial { get; set; }
        public int Intercompany { get; set; }
        public decimal? CantidadTotal { get; set; }
        public decimal? CantidadBonificada { get; set; }
        public decimal? CantidadMuestra { get; set; }
        public decimal? CantidadFacturada { get; set; }
        public decimal? VentaML { get; set; }
        public decimal? CostoML { get; set; }
        public decimal? CostoBonificadoML { get; set; }
        public decimal? VentaMF { get; set; }
        public decimal? CostoMF { get; set; }
        public decimal? VentaMG { get; set; }
        public decimal? CostoMG { get; set; }
        public string VendFilter { get; set; }
        public DateTime? Fecha { get; set; }

        public string Vendedor { get; set; }
    }
}