using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoWeb.Uteis
{
    public class DAL
    {

        
        private static string ConnectionString = GetConnectionString();
        private static SqlConnection Connection;
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return "Server=192.168.0.14;Initial Catalog=SisEdu;Integrated Security=true;Persist Security Info=False;";
        }


        public DAL()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        public DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            SqlCommand Command = new SqlCommand(sql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(Command);
            da.Fill(data);
            return data;
        }

        public DataTable RetDataTable(SqlCommand Command)
        {
            DataTable data = new DataTable();
            Command.Connection = Connection;
            SqlDataAdapter da = new SqlDataAdapter(Command);
            da.Fill(data);
            return data;
        }

        public void ExecutarComandoSQL(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, Connection);
            Command.ExecuteNonQuery();
        }
    }
}
