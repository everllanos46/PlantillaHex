using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleHex.Dominio;
using ExampleHex.Dominio.Interfaces.Repositorios;
using ExampleHex.Infraestrucutra.Datos.Contextos;

namespace ExampleHex.Infraestrucutra.Datos.Repositorios
{
    public class VentaDetalleRepositorio : IRepositorioDetalle<VentaDetalle, Guid>
    {

        private VentaContexto db;
        public VentaDetalleRepositorio(VentaContexto _db)
        {
            db = _db;
        }
        public VentaDetalle Agregar(VentaDetalle entidad)
        {
            db.VentaDetalles.Add(entidad);
            return entidad;
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }
    }
}
