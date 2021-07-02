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
    public class ReportController : ControllerBase
    {
        // POST api/<ReportController>/GetReport
        [HttpPost]
        public string GetReport([FromBody] Report rep)
        {
            Vaga vaga = JsonSerializer.Deserialize<List<Vaga>>(DAL.Load("vagas")).Where(x => x.Id == rep.IdVaga).FirstOrDefault();
            List<Tecnologia> tecnologias = JsonSerializer.Deserialize<List<Tecnologia>>(DAL.Load("tecnologias")).ToList();
            List<Candidato> candidatos = JsonSerializer.Deserialize<List<Candidato>>(DAL.Load("candidatos")).Where(x => x.IdVaga == rep.IdVaga).ToList();
            Dictionary<string, double> ranking = new Dictionary<string, double>();
            foreach (var i in candidatos)
            {
                double nota = 0;
                foreach (var j in rep.SkillWeights)
                    if (i.IdSkills.Exists(x => x == j.Key))
                        nota = nota + j.Value;
                ranking.Add(i.Nome, nota);
            }
            return JsonSerializer.Serialize(ranking.OrderByDescending(x => x.Value).ToList());
        }
    }
}
