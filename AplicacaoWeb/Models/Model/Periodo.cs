using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models.Model
{
    public class Periodo
    {
        public int IdPeriodo { get; set; }
        public string Nome { get; set; }
        public int IdDisciplina { get; set; }
        public int IdGradeCur { get; set; }

    }
}
