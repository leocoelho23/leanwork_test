using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Tecnologia
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Tecnologia(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public Tecnologia()
        {
        }
    }
}
