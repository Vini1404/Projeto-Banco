using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace BibliotecaBanco
{
    public class Banco : IDisposable
    {
        private readonly MySqlConnection conexao;

        public Banco()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaComando(string StrQuery)
        {
            var comando = new MySqlCommand (StrQuery,conexao);
            return comando.ExecuteReader();
        }

        public void Dispose()
        {
            if(conexao.State == ConnectionState.Open)
            conexao.Close();
        }
    }
}
