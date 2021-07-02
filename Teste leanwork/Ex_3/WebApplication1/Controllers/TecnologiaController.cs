using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using System.Text.Json;
using WebApplication1.Util;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnologiaController : ControllerBase
    {
        // GET: api/<TecnologiaController>
        [HttpGet]
        public string Get()
        {
            return DAL.Load("tecnologias");
        }

        // GET api/<TecnologiaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<Tecnologia> tecnologias = JsonSerializer.Deserialize<List<Tecnologia>>(DAL.Load("tecnologias"));
            return JsonSerializer.Serialize(tecnologias.Where(x => x.Id == id).ToList());
        }

        // POST api/<TecnologiaController>
        [HttpPost]
        public void Post([FromBody] Tecnologia value)
        {
            List<Tecnologia> tecnologias = JsonSerializer.Deserialize<List<Tecnologia>>(DAL.Load("tecnologias"));
            tecnologias.Add(value);
            DAL.Save(tecnologias, "tecnologias");
        }

        // DELETE api/<TecnologiaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            List<Tecnologia> tecnologias = JsonSerializer.Deserialize<List<Tecnologia>>(DAL.Load("tecnologias"));
            tecnologias.Remove(tecnologias.Where(x => x.Id == id).FirstOrDefault());
            DAL.Save(tecnologias, "tecnologias");
        }
    }
}
