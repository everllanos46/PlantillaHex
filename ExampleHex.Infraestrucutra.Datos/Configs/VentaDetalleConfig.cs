using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleHex.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleHex.Infraestrucutra.Datos.Configs
{
    internal class VentaDetalleConfig : IEntityTypeConfiguration<VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("tblVentaDetalle");
            builder.HasKey(x => new { x.ProductoId, x.VentaId});

            builder
                .HasOne(x => x.Producto)
                .WithMany(producto => producto.VentaDetalles);

            builder
                .HasOne(x => x.Venta)
                .WithMany(venta => venta.VentaDetalles);
        }
    }
}
