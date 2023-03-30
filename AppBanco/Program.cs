using BibliotecaDAO;
using BibliotecaModel;
using System;

namespace AppBanco
{
    public class Program
    {
        static void Main(string[] args)
        {
            var usuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();
            int opcao;
            do
            {
                usuarioDAO.Menu();
                Console.ForegroundColor = ConsoleColor.Red;
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 4)
                {
                    Console.Write(" Opção Inválida! Digite a opção entre 0 e 4: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Clear();

                switch (opcao)
                {
                    case 0:
                        usuarioDAO.Dados(usuario);
                        usuarioDAO.Insert(usuario);
                        break;
                    case 1:
                        usuarioDAO.ListUser();
                        usuarioDAO.Dados(usuario);
                        usuarioDAO.Id(usuario);
                        usuarioDAO.Update(usuario);
                        break;
                    case 2:
                        usuarioDAO.ListUser();
                        usuarioDAO.Id(usuario);
                        usuarioDAO.Delete(usuario.UsuId);
                        break;
                    case 3:
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
                usuarioDAO.ListUser();
                Console.ReadKey();
                Console.Clear();
            } while (opcao != 4);

        }

    }

}
