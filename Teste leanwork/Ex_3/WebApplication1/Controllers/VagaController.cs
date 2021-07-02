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
    public class VagaController : ControllerBase
    {
        // GET: api/<VagaController>
        [HttpGet]
        public string Get()
        {
            return DAL.Load("vagas");
        }

        // GET api/<VagaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<Vaga> vagas = JsonSerializer.Deserialize<List<Vaga>>(DAL.Load("vagas"));
            return JsonSerializer.Serialize(vagas.Where(x => x.Id == id).ToList());
        }

        // POST api/<VagaController>
        [HttpPost]
        public void Post([FromBody] Vaga value)
        {
            List<Vaga> vagas = JsonSerializer.Deserialize<List<Vaga>>(DAL.Load("vagas"));
            vagas.Add(value);
            DAL.Save(vagas, "vagas");
        }

        // DELETE api/<VagaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            List<Vaga> vagas = JsonSerializer.Deserialize<List<Vaga>>(DAL.Load("vagas"));
            vagas.Remove(vagas.Where(x => x.Id == id).FirstOrDefault());
            DAL.Save(vagas, "vagas");
        }
    }
}
