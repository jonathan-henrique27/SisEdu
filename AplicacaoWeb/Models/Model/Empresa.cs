using AplicacaoWeb.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models.Model
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string Complemento { get; set; }

        public List<Empresa> ListarTodasEmpresas()
        {
            List<Empresa> lista = new List<Empresa>();
            Empresa item;
            DAL objDAL = new DAL();
            string sql = "SELECT idEmpresa, RazaoSocial, CNPJ, IE, IM, Complemento FROM Empresa order by RazaoSocial asc";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Empresa
                {
                    IdEmpresa = (int)dt.Rows[i]["IdEmpresa"],
                    RazaoSocial = dt.Rows[i]["RazaoSocial"].ToString(),
                    CNPJ = dt.Rows[i]["CNPJ"].ToString(),
                    IE = dt.Rows[i]["IE"].ToString(),
                    IM = dt.Rows[i]["IM"].ToString(),
                    Complemento = dt.Rows[i]["Complemento"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }


    }
}
