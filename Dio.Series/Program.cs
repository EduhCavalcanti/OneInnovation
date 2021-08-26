using System;

namespace Dio.Series
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = OpcaoDoUsuario();

            while(opcao != "X"){

                

            
                OpcaoDoUsuario();
            }
            Console.WriteLine("Programa encerrado");
        }


        private static string OpcaoDoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir uma nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");

            string opcaoDesejada = Console.ReadLine().ToUpper();
            Console.ReadLine();
            return opcaoDesejada;

        }
    }
}
