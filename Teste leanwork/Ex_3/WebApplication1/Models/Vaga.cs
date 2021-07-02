using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Vaga
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Vaga(int id, string desc)
        {
            this.Id = id;
            this.Descricao = desc;
        }
        public Vaga()
        {
        }
    }
}
