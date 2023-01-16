using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleHex.Dominio
{
    public class Producto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description   { get; set; }
        public double Costo { get; set; }
        public double Precio    { get; set; }
        public int CantidadStock    { get; set; }
        public List<VentaDetalle> VentaDetalles { get; set; }
    }
}
