using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models.Model
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int IdInstituicao { get; set; }

    }
}
