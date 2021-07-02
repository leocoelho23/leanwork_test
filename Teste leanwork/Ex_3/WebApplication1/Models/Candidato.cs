using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdVaga { get; set; }
        public List<int> IdSkills { get; set; }

        public Candidato(int id, string nom, int vag, List<int> ski)
        {
            this.Id = id;
            this.Nome = nom;
            this.IdVaga = vag;
            this.IdSkills = ski;
        }
        public Candidato()
        {
            IdSkills = new List<int>();
        }
    }
}
