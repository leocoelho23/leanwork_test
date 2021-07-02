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
    public class CandidatoController : ControllerBase
    {
        // GET: api/<CandidatoController>
        [HttpGet]
        public string Get()
        {
            return DAL.Load("candidatos");
        }

        // GET api/<CandidatoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<Candidato> candidatos = JsonSerializer.Deserialize<List<Candidato>>(DAL.Load("candidatos"));
            return JsonSerializer.Serialize(candidatos.Where(x => x.Id == id).ToList());
        }

        // POST api/<CandidatoController>
        [HttpPost]
        public void Post([FromBody] Candidato value)
        {
            List<Candidato> candidatos = JsonSerializer.Deserialize<List<Candidato>>(DAL.Load("candidatos"));
            candidatos.Add(value);
            DAL.Save(candidatos, "candidatos");
        }

        // DELETE api/<CandidatoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            List<Candidato> candidatos = JsonSerializer.Deserialize<List<Candidato>>(DAL.Load("candidatos"));
            candidatos.Remove(candidatos.Where(x => x.Id == id).FirstOrDefault());
            DAL.Save(candidatos, "candidatos");
        }
    }
}
