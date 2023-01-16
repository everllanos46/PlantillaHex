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
    public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
    {
        private VentaContexto db;
        public ProductoRepositorio(VentaContexto _db)
        {
                db = _db;
        }
        public Producto Agregar(Producto entidad)
        {
            entidad.Id = Guid.NewGuid();
            db.Productos.Add(entidad); 
            return entidad;
        }

        public void Editar(Producto entidad)
        {
            var productoSeleccionado = db.Productos.Where(c => c.Id == entidad.Id).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                productoSeleccionado.Name = entidad.Name;
                productoSeleccionado.Description = entidad.Description;
                productoSeleccionado.CantidadStock = entidad.CantidadStock;
                productoSeleccionado.Precio = entidad.Precio;
                productoSeleccionado.Costo = entidad.Costo;

                db.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadID)
        {
            var productoSeleccionado = db.Productos.Where(c => c.Id == entidadID).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                db.Productos.Remove(productoSeleccionado);
            }
        }

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            return db.Productos.ToList();
        }

        public Producto ListarPorId(Guid entidadID)
        {
            var productoSeleccionado = db.Productos.Where(c => c.Id == entidadID).FirstOrDefault();
            return productoSeleccionado;
        }
    }
}
