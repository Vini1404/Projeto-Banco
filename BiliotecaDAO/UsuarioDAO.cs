using BibliotecaBanco;
using BibliotecaModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace BibliotecaDAO
{
    public class UsuarioDAO
    {
        private Banco db;

        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "Insert into tbUsuario(Nome, Cargo, Nasc)";
            strQuery += string.Format("values ('{0}', '{1}', str_to_date('{2}', '%d/%m/%Y %H:%i:%s'));", usuario.Nome, usuario.Cargo, usuario.Nasc);
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Update(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "update tbUsuario set ";
            strQuery += string.Format("Nome = '{0}', ", usuario.Nome);
            strQuery += string.Format("Cargo = '{0}', ", usuario.Cargo);
            strQuery += string.Format("Nasc = str_to_date('{0}', '%d/%m/%Y %H:%i:%s')", usuario.Nasc);
            strQuery += string.Format("where UsuId = '{0}'", usuario.UsuId);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Delete(int id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("delete from tbUsuario where UsuId = {0}", id);
                db.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> Listar()
        {
            using(db = new Banco()) 
            {
                var strQuery = string.Format("Select * from tbUsuario");
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno);
            }
        }

        public List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while(retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    UsuId = int.Parse(retorno["UsuId"].ToString()),
                    Nome = retorno["Nome"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    Nasc = DateTime.Parse(retorno["Nasc"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }

        public void Dados(Usuario usuario)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n Digite o nome do usuário: ");

            Console.ForegroundColor = ConsoleColor.Red;
            usuario.Nome = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Digite o cargo do usuário: ");

            Console.ForegroundColor = ConsoleColor.Red;
            usuario.Cargo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Digite a data de nascimento do usuário: ");

            Console.ForegroundColor = ConsoleColor.Red;
            usuario.Nasc = DateTime.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void Id(Usuario usuario)
        {
            int id;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n Digite o Id do usuário: ");

            Console.ForegroundColor = ConsoleColor.Red;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write(" id Inválida! Digite uma das opções acima: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            usuario.UsuId = id;

            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void ListUser()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var leitor = Listar();
            Console.WriteLine("\n Usuários cadastrados no Banco de Dados\n");
            foreach (var usuarios in leitor)
            {
                Console.WriteLine(" Id: {0,3:D3}, Nome: {1,12}, Cargo: {2,10}, Data: {3:dd/MM/yyyy}",
                usuarios.UsuId, usuarios.Nome, usuarios.Cargo, usuarios.Nasc); //mostra texto em console
            }
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ___________________________________");
            Console.WriteLine(" |         Programa AppBanco         |");
            Console.WriteLine(" |                                   |");
            Console.WriteLine(" | Escolha uma das seguintes opções: |");
            Console.WriteLine(" |                                   |");
            Console.WriteLine(" |       0 - Cadastrar Usuário       |");
            Console.WriteLine(" |       1 - Editar Usuário          |");
            Console.WriteLine(" |       2 - Deletar Usuário         |");
            Console.WriteLine(" |       3 - Listar Usuário          |");
            Console.WriteLine(" |       4 - Encerra Programa        |");
            Console.WriteLine(" |                                   |");
            Console.WriteLine(" |___________________________________|");
            Console.Write("\n\n Digite o número da opção desejada: ");
        }

        public Usuario ListarId(int Id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("SELECT * FROM tbUsuario where UsuId = {0}", Id);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno).FirstOrDefault();
            }
        }
    }
}
