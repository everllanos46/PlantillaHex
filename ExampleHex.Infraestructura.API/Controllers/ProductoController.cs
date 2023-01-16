using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using ExampleHex.Dominio;
using ExampleHex.Aplicaciones.Servicios;
using ExampleHex.Infraestrucutra.Datos.Contextos;
using ExampleHex.Infraestrucutra.Datos.Repositorios;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExampleHex.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        ProductoServicio servicio;
        public ProductoController()
        {
            VentaContexto db = new VentaContexto();
            ProductoRepositorio repo = new ProductoRepositorio(db);
            servicio = new ProductoServicio(repo);
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(string id)
        {
            return Ok(servicio.ListarPorId(Guid.Parse(id)));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto value)
        {
            servicio.Agregar(value);
            return Ok("Agregado correctamente");
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Producto value)
        {
            value.Id = id;
            servicio.Editar(value);
            return Ok("Editado correctamente");
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            servicio.Eliminar(id);
            return Ok("Eliminado Correctamente");
        }
    }
}
