using System;

namespace Dio.Series
{
    class Program
    {
        //Repositorio de séries
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            

            string opcao = OpcaoDoUsuario();

            while(opcao != "X"){

                switch(opcao){

                    case("1"):
                       ListarSeries();

                    break;

                    case("2"):


                    break;

                    case("3"):


                    break;

                    case("4"):


                    break;

                    case("5"):


                    break;

                    case("6"):
                    
                        Console.Clear();

                    break;


                }

            
            opcao = OpcaoDoUsuario();
            }
            Console.WriteLine("Programa encerrado");
        }

            private static void ListarSeries(){

            
            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma séries disponível");
                return;
            }else{

                foreach(var serie in lista){
                    Console.WriteLine("Lista de séries: ");
                    Console.WriteLine($"#ID {0}: - {1}", serie.retornaId(), serie.retornaritulo());
                }
            }

        }



        private static string OpcaoDoUsuario()
        {
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
