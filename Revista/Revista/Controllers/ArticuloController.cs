using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Revista.Models;
using Microsoft.AspNetCore.Cors;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Revista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]//libreria cors
    public class ArticuloController : ControllerBase
    {
        // GET: api/<ArticuloController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArticuloController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticuloController>
        [HttpPost]
        public String Post([FromBody] JsonElement datosI)
        {
            //DateTime dateTime = DateTime.UtcNow.Date;
            //int id_art = datosI.GetProperty("id_art").GetInt32();
            String ced = datosI.GetProperty("ced").ToString();
            String titulo = datosI.GetProperty("titulo").ToString();
            String desc = datosI.GetProperty("descripcion").ToString();
            String cont = datosI.GetProperty("contenido").ToString();
            //Boolean estado = datosI.GetProperty("estado").GetBoolean();
            String fecha = datosI.GetProperty("fecha").ToString();

            //Se crea objeto de la clase ClsArticulo
            ClsArticulo articulo = new ClsArticulo(0, ced, titulo, desc, cont, false, fecha);

            articulo.conectar();
            String mensaje = articulo.ingresarArticulo();
            return mensaje;
        }
       
        // PUT api/<ArticuloController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticuloController>/5
        [HttpDelete("{ced}/{titulo}")]
        public String Delete(string ced, string titulo)
        {
            //int id_art = datosI.GetProperty("id_art").GetInt32();

            ClsArticulo articulo = new ClsArticulo(0, ced, titulo, "", "", false, "");
            
            articulo.conectar();

            String mensaje = articulo.eliminarArticulo();
            return mensaje;
        }
    }
}
