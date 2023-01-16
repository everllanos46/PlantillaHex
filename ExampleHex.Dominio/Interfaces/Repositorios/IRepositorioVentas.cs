using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleHex.Dominio.Interfaces;

namespace ExampleHex.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioVentas<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
        void Anular(TEntidadID entidadID);
    }
}
