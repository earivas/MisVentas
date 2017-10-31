using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MisVentas.Models
{
    public class MisVentasContext :DbContext
    {


        public MisVentasContext() : base("name=MisVentasContext")
        {
        }



        public virtual DbSet<BI_Presupuestos> BI_Presupuestos { get; set; }
        //public virtual DbSet<BI_PoolVendedores> BI_PoolVendedores { get; set; }
        public System.Data.Entity.DbSet<MisVentas.Models.BI_PoolVendedores> BI_PoolVendedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.VentaMLActual)
                .HasPrecision(38, 2);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.VentaMLAnterior)
                .HasPrecision(38, 2);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.VentaMGActual)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.VentaMGAnterior)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.VentaMFActual)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.VentaMFAnterior)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.PptoMlocal)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.PptoUSD)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.CostoML)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.CostoMG)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.CostoMF)
                .HasPrecision(38, 6);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.IdVendedor)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.Vendedor)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.idmaterial)
                .IsUnicode(false);

            modelBuilder.Entity<BI_Presupuestos>()
                .Property(e => e.Producto)
                 .IsUnicode(false);

        }
    }
}