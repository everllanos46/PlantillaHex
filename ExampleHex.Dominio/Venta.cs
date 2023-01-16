using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleHex.Dominio
{
    public class Venta
    {
        public Guid Id { get; set; }
        public long NumeroVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Concepto { get; set; }
        public double SubTotal { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public Boolean Anulada { get; set; }
        public List<VentaDetalle> VentaDetalles { get; set; }
    }
}
