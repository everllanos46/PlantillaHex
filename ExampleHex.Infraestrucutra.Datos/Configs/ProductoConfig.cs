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
    internal class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("tblProductos");
            builder.HasKey(x => x.Id);

            builder
                .HasMany(producto => producto.VentaDetalles)
                .WithOne(detalle => detalle.Producto);
        }
    }
}
