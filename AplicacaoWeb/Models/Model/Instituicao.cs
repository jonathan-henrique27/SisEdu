using AplicacaoWeb.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models.Model
{
    public class Instituicao
    {
        public string IdInstituicao { get; set; }
        public string Nome { get; set; }
        public string RegistroDiario { get; set; }
        public int IdEmpresa { get; set; }

        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

        public List<Empresa> RetornarListaEmpresas(int? id)
        {
            return new Empresa().ListarTodasEmpresas();
        }


        public List<Instituicao> ListarTodasInstituicoes()
        {
            List<Instituicao> lista = new List<Instituicao>();
            Instituicao item;
            DAL objDAL = new DAL();
            string sql = "SELECT idInstituicao, Nome, RegistroDiario, IdEmpresa from Instituicao";
            DataTable dt = objDAL.RetDataTable(sql);
         
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Instituicao
                {
                    IdInstituicao = dt.Rows[i]["IDINSTITUICAO"].ToString(),
                    Nome = dt.Rows[i]["NOME"].ToString(),
                    RegistroDiario = dt.Rows[i]["REGISTRODIARIO"].ToString(),
                    IdEmpresa = (int)dt.Rows[i]["IDEMPRESA"],
               
                };
                lista.Add(item);
            }
            return lista;
        }

        public Instituicao RetornarInstituicao(int? id)
        {

            Instituicao item;
            DAL objDAL = new DAL();
            string sql = $"SELECT idInstituicao, Nome, RegistroDiario, IdEmpresa from Instituicao ";
            DataTable dt = objDAL.RetDataTable(sql);

            item = new Instituicao
            {
                IdInstituicao = dt.Rows[0]["IDINSTITUICAO"].ToString(),
                Nome = dt.Rows[0]["NOME"].ToString(),
                RegistroDiario = dt.Rows[0]["REGISTRODIARIO"].ToString(),
                IdEmpresa = (int)dt.Rows[0]["IDEMPRESA"],
               
            };

            return item;
        }
        public void Gravar()
        {
            DAL objDal = new DAL();
            string sql = string.Empty;

            if (IdInstituicao != null)
            {
                sql = $"UPDATE INSTITUICAO SET NOME='{Nome}', REGISTRODIARIO='{RegistroDiario}', IDEMPRESA='{IdEmpresa}' WHERE IDINSTITUICAO = '{IdInstituicao}'";
            }
            else
            {
                sql = $"INSERT INTO Instituicao(Nome, RegistroDiario, idEmpresa) VALUES('{Nome}', '{RegistroDiario}', '{IdEmpresa}')";
            }

            objDal.ExecutarComandoSQL(sql);
        }

        //DELETE
        public void Excluir(int id)
        {
            DAL objDal = new DAL();
            string sql = $"DELETE FROM INSTITUICAO WHERE IDINSTITUICAO='{id}'";
            objDal.ExecutarComandoSQL(sql);
        }
    }
}
