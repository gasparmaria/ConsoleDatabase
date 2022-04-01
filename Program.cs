using AppDatabaseDLL;
using AppDatabaseDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDatabase
{
    class Program
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        static void Main(string[] args)
        {
            var program = new Program();
            string operacao = program.menuOperacoes();
            operacao = program.operacoesBanco(operacao);

            while (operacao == "")
            {
                string opcao = program.menuOperacoes();
                
                operacao = program.operacoesBanco(opcao);
            }

            Console.ReadLine();
        }

        public void listarUsuarios()
        {
            var usuarioDAO = new UsuarioDAO();

            var reader = usuarioDAO.selectAllUsuarios();
            foreach (var usuarios in reader)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data de Nascimento: {3}", usuarios.UsuarioId, usuarios.UsuarioNome, usuarios.UsuarioCargo, usuarios.UsuarioDataNasc);
            }
        }

        public Usuario dadosUsuario()
        {
            var usuario = new Usuario();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o nome do usuário:");
            Console.ForegroundColor = ConsoleColor.White;
            usuario.UsuarioNome = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o cargo do usuário:");
            Console.ForegroundColor = ConsoleColor.White;
            usuario.UsuarioCargo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite a data de nascimento do usuário:");
            Console.ForegroundColor = ConsoleColor.White;
            usuario.UsuarioDataNasc = DateTime.Parse(Console.ReadLine());

            return usuario;
        }

        public string menuOperacoes()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Qual a operação desejada?\n 1- Inserção \n 2- Atualização \n 3- Exclusão \n 4- Consulta \n 5- Sair \n");
            Console.ForegroundColor = ConsoleColor.White;
            string operacao = Console.ReadLine();
            return operacao;
        }

        public string operacoesBanco(string operacao)
        {
            switch (operacao)
            {
                case "1":
                    var usuarioInsert = dadosUsuario();
                    usuarioDAO.insertUsuario(usuarioInsert);
                    Console.WriteLine("\n");
                    listarUsuarios();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite o código do usuário:");
                    Console.ForegroundColor = ConsoleColor.White;
                    int id = Int32.Parse(Console.ReadLine());
                    var usuarioUpdate = dadosUsuario();
                    usuarioUpdate.UsuarioId = id;
                    usuarioDAO.updateUsuario(usuarioUpdate);
                    Console.WriteLine("\n");
                    listarUsuarios();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Digite o código do usuário:");
                    var usuarioDelete = new Usuario();
                    Console.ForegroundColor = ConsoleColor.White;
                    usuarioDelete.UsuarioId = Int32.Parse(Console.ReadLine());
                    usuarioDAO.deleteUsuario(usuarioDelete);
                    Console.WriteLine("\n");
                    listarUsuarios();
                    break;
                case "4":
                    listarUsuarios();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    break;

            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPressione Enter para escolher outra operação.");
            Console.ReadLine();
            Console.Clear();
            return operacao = "";
        }
    }
}
