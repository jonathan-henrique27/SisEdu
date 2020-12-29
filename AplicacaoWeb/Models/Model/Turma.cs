using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models.Model
{
    public class Turma
    {
        public int IdTurma { get; set; }
        public string Nome { get; set; }
        public int AnoVigente { get; set; }
        public int IdCurso { get; set; }
        public int IdGradeCur { get; set; }


    }
}
