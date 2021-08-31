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
                        InserirSerie();

                    break;

                    case("3"):
                        AtualizarSerie();

                    break;

                    case("4"):
                        ExcluirSerie();

                    break;

                    case("5"):
                        VisualizarSerie();

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
                    var serieExcluida = serie.retornarExcluido();

                    if(!serieExcluida){
                    Console.WriteLine("#ID {0}-{1}", serie.retornaId(), serie.retornaritulo());
                    }
                }
            }

        }

            private static void InserirSerie(){
                try{
                    //Vai retornar um obj do tipo Serie
                    var novaSerie = AdicionandoSerie();

                    //Vai inserir nova série passando obj 
                    repositorio.Insere(novaSerie);

                    Console.WriteLine("Nova série salva com sucesso!!");
                }catch(Exception){
                    throw new ArgumentException("Algo deu errado ao cadastrar nova série");
                }
            }

            private static void AtualizarSerie(){
                  Console.WriteLine("Escolha qual série deseja atualizar: ");
                  var series = repositorio.Lista();

                if(series.Count == 0){
                    Console.WriteLine("Nenhuma séries disponível");
                    return;
                }else{
                    //Listando as séries disponíveis
                    foreach(var listaSeries in series){
                        Console.WriteLine("#ID {0}-{1}", listaSeries.retornaId(), listaSeries.retornaritulo());
                    }
                    int escolhaUsuario = int.Parse(Console.ReadLine());

                    var serieAtualizada = AtualizandoSerie(escolhaUsuario);
                    
                    repositorio.Atualizar(escolhaUsuario, serieAtualizada);
                }

            }

            private static void ExcluirSerie(){
                Console.WriteLine("Selecione a série que deseja excluir");
                var listaSeries  = repositorio.Lista();

                foreach(var series in listaSeries){
                    Console.WriteLine("#ID {0}-{1}", series.retornaId(), series.retornaritulo());
                }
                
                int entradaIdParaExcluir = int.Parse(Console.ReadLine());

                repositorio.Exclui(entradaIdParaExcluir);
               
            }

            private static void VisualizarSerie(){

                Console.WriteLine("Escolha um Id para visualizar a série detalhadamente: ");
                var series = repositorio.Lista();

                foreach(var serie in series){
                    Console.WriteLine("#ID {0}-{1}", serie.retornaId(), serie.retornaritulo());
                }

                int escolhaIdSerie = int.Parse(Console.ReadLine());
                
                Console.WriteLine(series[escolhaIdSerie].ToString());
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
            
            return opcaoDesejada;

        }
    
            public static Serie AdicionandoSerie(){
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

            Serie novaSerie = new Serie(id:repositorio.ProximoId(),genero:(Genero)entradaGenero, titulo:entradaTítulo, descricao:entradaDescricao, ano:entradaAno);
            
            return novaSerie;
        }

            public static Serie AtualizandoSerie(int id){
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

            Serie serieAtualizada = new Serie(id:id,genero:(Genero)entradaGenero,titulo:entradaTítulo,descricao:entradaDescricao,ano:entradaAno);

            return serieAtualizada;
        }
    
    
    }
}
