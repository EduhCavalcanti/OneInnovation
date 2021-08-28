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
                        IserirSerie();

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

                Console.WriteLine("Lista de séries: ");
                foreach(var serie in lista){
                    
                    Console.WriteLine("#ID {0}-{1}", serie.retornaId(), serie.retornaritulo());
                }
            }

        }

            private static void IserirSerie(){
                try{
                    //Vai mostrar lista de gêneros
                    foreach(int i in Enum.GetValues(typeof(Genero))){
                        Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
                    }
                    Console.WriteLine("Selecione um gênero acima: ");
                    int entradaGenero = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o título da série: ");
                    string entradaTítulo = Console.ReadLine();

                    Console.WriteLine("Digite o ano de inicio da série: ");
                    int entradaAno = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite a descrição da série: ");
                    string entradaDescricao = Console.ReadLine();

                    Serie novaSerie = new Serie(id:repositorio.ProximoId(), genero:(Genero)entradaGenero,titulo:entradaTítulo,descricao:entradaDescricao,ano:entradaAno);
                    //Vai inserir nova série passando obj 
                    repositorio.Insere(novaSerie);

                    Console.WriteLine("Nova série salva com sucesso!!");
                }catch(Exception){
                    throw new ArgumentException("Algo deu errado ao cadastrar nova série");
                }
            }

            private static void AtualizarSerie(){
                  
            }

            private static void ExcluirSerie(){

            }

            private static void VisualizarSerie(){

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
            //Console.ReadLine();
            return opcaoDesejada;

        }
    }
}
