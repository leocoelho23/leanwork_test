using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Report
    {
        public int IdVaga { get; set; }
        public Dictionary<int, double> SkillWeights { get; set; }

        public Report()
        {
        }
    }
}
