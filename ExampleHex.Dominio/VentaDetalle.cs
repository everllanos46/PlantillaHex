using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleHex.Dominio
{
    public class VentaDetalle
    {
        public Guid ProductoId { get; set; }
        public Guid VentaId { get; set;}
        public double CostoUnitario { get; set; }
        public double PrecioUnitario { get; set; }
        public int CantidadVendida { get; set; }
        public double SubTotal { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public Producto Producto { get; set; }
        public Venta Venta { get; set; }
    }
}
