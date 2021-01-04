using AplicacaoWeb.Uteis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Models.Model
{
    public class Login
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o e-mail do usuario!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="O e-mail informado é inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Informe a senha do usuário!")]
        public string Senha { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"SELECT ID, NOME FROM USUARIO WHERE EMAIL=@email AND SENHA=@senha";
            SqlCommand Command = new SqlCommand();
            Command.CommandText = sql;
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@senha", Senha);

            DAL objDAL = new DAL();

            DataTable dt = objDAL.RetDataTable(Command);
            if (dt.Rows.Count == 1)
            {
                Id = dt.Rows[0]["ID"].ToString();
                Nome = dt.Rows[0]["NOME"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
