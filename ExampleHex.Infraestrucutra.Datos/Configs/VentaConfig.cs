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
    internal class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("tblVentas");
            builder.HasKey(x => x.Id);

            builder
                .HasMany(venta => venta.VentaDetalles)
                .WithOne(detalle => detalle.Venta);
        }
    }
}
