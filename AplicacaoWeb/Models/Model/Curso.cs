using AplicacaoWeb.Uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models.Model
{
    public class Curso
    {
        public string IdCurso { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string IdInstituicao { get; set; }


        public List<Instituicao> RetornarListaInstituicoes(int? id)
        {
            return new Instituicao().ListarTodasInstituicoes();
        }


        public List<Curso> ListarTodosCursos()
        {
            List<Curso> lista = new List<Curso>();
            Curso item;
            DAL objDAL = new DAL();
            string sql = "SELECT C.IdCurso, C.Nome, C.Tipo, IT.IdInstituicao from Curso C join Instituicao IT on C.IdInstituicao = IT.IdInstituicao order by C.Nome asc";
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Curso
                {
                    IdCurso = dt.Rows[i]["IDCURSO"].ToString(),
                    Nome = dt.Rows[i]["NOME"].ToString(),
                    Tipo = dt.Rows[i]["TIPO"].ToString(),
                    IdInstituicao = dt.Rows[i]["IDINSTITUICAO"].ToString(),

                };
                lista.Add(item);
            }
            return lista;
        }

        public Curso RetornarCurso(int? id)
        {

            Curso item;
            DAL objDAL = new DAL();
            string sql = $"SELECT idCurso, Nome, Tipo, IdInstituicao from Curso ";
            DataTable dt = objDAL.RetDataTable(sql);

            item = new Curso
            {
                IdCurso = dt.Rows[0]["IDCURSO"].ToString(),
                Nome = dt.Rows[0]["NOME"].ToString(),
                Tipo = dt.Rows[0]["TIPO"].ToString(),
                IdInstituicao = dt.Rows[0]["IDINSTITUICAO"].ToString(),

            };

            return item;
        }

        public void Gravar()
        {
            DAL objDal = new DAL();
            string sql = string.Empty;

            if (IdCurso != null)
            {
                sql = $"UPDATE Curso SET NOME='{Nome}', TIPO='{Tipo}', IDINSTITUICAO='{IdInstituicao}' WHERE IDCURSO = '{IdCurso}'";
            }
            else
            {
                sql = $"INSERT INTO Curso(Nome, Tipo, idInstituicao) VALUES('{Nome}', '{Tipo}', '{IdInstituicao}')";
            }

            objDal.ExecutarComandoSQL(sql);
        }

        //DELETE
        public void Excluir(int id)
        {
            DAL objDal = new DAL();
            string sql = $"DELETE FROM Curso WHERE IDCURSO='{id}'";
            objDal.ExecutarComandoSQL(sql);
        }
    }
}
