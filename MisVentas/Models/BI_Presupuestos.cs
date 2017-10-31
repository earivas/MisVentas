using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MisVentas.Models
{
    public partial class BI_Presupuestos
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        public decimal? VentaMLActual { get; set; }

        public decimal? VentaMLAnterior { get; set; }

        public decimal? VentaMGActual { get; set; }

        public decimal? VentaMGAnterior { get; set; }

        public decimal? VentaMFActual { get; set; }

        public decimal? VentaMFAnterior { get; set; }

        public decimal? PptoMlocal { get; set; }

        public decimal? PptoUSD { get; set; }

        public decimal? CostoML { get; set; }

        public decimal? CostoMG { get; set; }

        public decimal? CostoMF { get; set; }

        [StringLength(3)]
        public string IdVendedor { get; set; }

        [StringLength(20)]
        public string Vendedor { get; set; }

        [StringLength(30)]
        public string MesNombre { get; set; }

        [StringLength(80)]
        public string Linea { get; set; }

        [StringLength(50)]
        public string UndNegocio { get; set; }

        [StringLength(10)]
        public string IdCeBe { get; set; }

        [StringLength(80)]
        public string UndNegocioProducto { get; set; }

        [StringLength(4)]
        public string IdOrgVentas { get; set; }

        [StringLength(80)]
        public string OrgVentas { get; set; }

        [StringLength(40)]
        public string NombreG1 { get; set; }

        [StringLength(40)]
        public string NombreG2 { get; set; }

        [StringLength(40)]
        public string NombreG3 { get; set; }

        [StringLength(18)]
        public string idmaterial { get; set; }

        [StringLength(40)]
        public string Producto { get; set; }

        public int Intercompany { get; set; }

        [StringLength(3)]
        public string VendFilter { get; set; }

        public DateTime? Fecha { get; set; }
    }
}