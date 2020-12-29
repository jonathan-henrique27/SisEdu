using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models.Model
{
    public class Instituicao
    {
        public int IdInstituicao { get; set; }
        public string Nome { get; set; }
        public string RegistroDiario { get; set; }
        public int IdEmpresa { get; set; }
    }
}
