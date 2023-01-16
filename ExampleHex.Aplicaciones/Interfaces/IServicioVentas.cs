using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleHex.Dominio.Interfaces;

namespace ExampleHex.Aplicaciones.Interfaces
{
    public interface IServicioVentas<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>
    {
        void Anular(TEntidadID entidadID);
    }
}
