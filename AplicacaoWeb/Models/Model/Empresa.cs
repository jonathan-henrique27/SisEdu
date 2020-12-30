using AplicacaoWeb.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AplicacaoWeb.Models.Model
{
    public class Empresa
    {
        public string IdEmpresa { get; set; }
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
                    IdEmpresa = dt.Rows[i]["IdEmpresa"].ToString(),
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
        public Empresa RetornarEmpresa(int? id)
        {

            Empresa item;
            DAL objDAL = new DAL();
            string sql = $"SELECT idEmpresa, RazaoSocial, CNPJ, IE, IM, Complemento FROM Empresa order by RazaoSocial asc";
            DataTable dt = objDAL.RetDataTable(sql);

            item = new Empresa
            {
                IdEmpresa = dt.Rows[0]["IdEmpresa"].ToString(),
                RazaoSocial = dt.Rows[0]["RazaoSocial"].ToString(),
                CNPJ = dt.Rows[0]["CNPJ"].ToString(),
                IE = dt.Rows[0]["IE"].ToString(),
                IM = dt.Rows[0]["IM"].ToString(),
                Complemento = dt.Rows[0]["Complemento"].ToString()
            };

            return item;
        }
        public void Gravar()
        {
            DAL objDal = new DAL();
            string sql = string.Empty;

            if (IdEmpresa!= null)
            {
                sql = $"UPDATE EMPRESA SET RAZAOSOCIAL='{RazaoSocial}', CNPJ='{CNPJ}', IE='{IE}', IM='{IM}', COMPLEMENTO='{Complemento}' WHERE IDEMPRESA = '{IdEmpresa}'";
            }
            else
            {
                sql = $"INSERT INTO EMPRESA(RazaoSocial, CNPJ, IE, IM, COMPLEMENTO) VALUES('{RazaoSocial}', '{CNPJ}', '{IE}', '{IM}', '{Complemento}')";
            }

            objDal.ExecutarComandoSQL(sql);
        }

        //DELETE
        public void Excluir(int id)
        {
            DAL objDal = new DAL();
            string sql = $"DELETE FROM EMPRESA WHERE IDEMPRESA='{id}'";
            objDal.ExecutarComandoSQL(sql);
        }


    }
}
