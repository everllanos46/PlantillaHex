using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleHex.Dominio.Interfaces;

namespace ExampleHex.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioDetalle<TEntidad, TMovimientoID>
        : IAgregar<TEntidad>, ITransaccion
    {
    }
}
