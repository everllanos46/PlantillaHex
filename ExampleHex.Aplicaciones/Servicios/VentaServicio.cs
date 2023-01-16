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
    public class VentaServicio : IServicioVentas<Venta, Guid>
    {
        IRepositorioVentas<Venta, Guid> repoVenta;
        IRepositorioBase<Producto, Guid> repoProducto;
        IRepositorioDetalle<VentaDetalle, Guid> repoDetalle;
        public VentaServicio(
            IRepositorioVentas<Venta, Guid> _repoVenta,
            IRepositorioBase<Producto, Guid> _repoProducto,
            IRepositorioDetalle<VentaDetalle, Guid> _repoDetalle)
        {
            repoVenta= _repoVenta;
            repoProducto= _repoProducto;
            repoDetalle= _repoDetalle;
        }
        public Venta Agregar(Venta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La Venta es requerido");

            var ventaAgregada = repoVenta.Agregar(entidad);

            entidad.VentaDetalles.ForEach(e => {
                var productoSeleccionado = repoProducto.ListarPorId(e.ProductoId);
                if (productoSeleccionado == null)
                    throw new NullReferenceException("Producto no encontrado");
                var detalleNuevo = new VentaDetalle();
                detalleNuevo.VentaId = ventaAgregada.Id;
                detalleNuevo.ProductoId = e.ProductoId;
                detalleNuevo.CostoUnitario = productoSeleccionado.Costo;
                detalleNuevo.PrecioUnitario = productoSeleccionado.Precio;
                detalleNuevo.CantidadVendida = e.CantidadVendida;
                detalleNuevo.SubTotal = detalleNuevo.PrecioUnitario * detalleNuevo.CantidadVendida;
                detalleNuevo.Impuesto = detalleNuevo.SubTotal * 15 / 100;
                detalleNuevo.Total = detalleNuevo.SubTotal + detalleNuevo.Impuesto;

                repoDetalle.Agregar(detalleNuevo);

                productoSeleccionado.CantidadStock -= detalleNuevo.CantidadVendida;
                repoProducto.Editar(productoSeleccionado);

                entidad.SubTotal += detalleNuevo.SubTotal;
                entidad.Impuesto += detalleNuevo.Impuesto;
                entidad.Total += detalleNuevo.Total;
            });
            repoVenta.Agregar(entidad);
            return entidad;
        }

        public void Anular(Guid entidadID)
        {
            repoVenta.Anular(entidadID);
            repoVenta.GuardarCambios();
        }

        public List<Venta> Listar()
        {
            return repoVenta.Listar();
        }

        public Venta ListarPorId(Guid entidadID)
        {
            return repoVenta.ListarPorId(entidadID);
        }
    }
}
