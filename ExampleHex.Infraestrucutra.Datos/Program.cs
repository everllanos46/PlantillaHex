using System;

using ExampleHex.Infraestrucutra.Datos.Contextos;

namespace ExampleHex.Infraestrucutra.Datos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la bd");
            VentaContexto db = new VentaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("Creada");
            Console.ReadKey();
        }
    }
}
