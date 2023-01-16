using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExampleHex.Dominio;
using ExampleHex.Dominio.Interfaces.Repositorios;
using ExampleHex.Aplicaciones.Interfaces;

namespace ExampleHex.Aplicaciones.Servicios
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repoProducto;
        public ProductoServicio(IRepositorioBase<Producto, Guid> _repoProducto)
        {
            repoProducto = _repoProducto; 
        }
        public Producto Agregar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Producto es requerido");

            var resultProducto = repoProducto.Agregar(entidad);
            repoProducto.GuardarCambios();
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("El Producto es requerido");
            repoProducto.Editar(entidad);
            repoProducto.GuardarCambios();

        }

        public void Eliminar(Guid entidadID)
        {
            repoProducto.Eliminar(entidadID);
            repoProducto.GuardarCambios();

        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto ListarPorId(Guid entidadID)
        {
            return repoProducto.ListarPorId(entidadID);
        }
    }
}
