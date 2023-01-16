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
    public class VentaRepositorio : IRepositorioVentas<Venta, Guid>
    {
        private VentaContexto db;
        public VentaRepositorio(VentaContexto _db)
        {
             db = _db;
        }
        public Venta Agregar(Venta entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.Ventas.Add(entidad);
            return entidad;
        }

        public void Anular(Guid entidadID)
        {
            var ventaSeleccionada = db.Ventas.Where(c => c.Id == entidadID).FirstOrDefault();
            if (ventaSeleccionada == null)
                throw new NullReferenceException("No se encuentra la venta");

            ventaSeleccionada.Anulada = true;
            db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Venta> Listar()
        {
            return db.Ventas.ToList();
        }

        public Venta ListarPorId(Guid entidadID)
        {
            var ventaSeleccionada = db.Ventas.Where(c => c.Id == entidadID).FirstOrDefault();
            return ventaSeleccionada;
        }
    }
}
