using System;

namespace Dio.Series
{
    class Program
    {
        //Repositorio de séries
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();

        static void Main(string[] args)
        {
            

            string opcao = OpcaoDoUsuario();

            while(opcao != "X"){

                switch(opcao){

                    case("1"):
                       ListarCatalogo();

                    break;

                    case("2"):
                        InserirCatalogo();

                    break;

                    case("3"):
                        AtualizarCatalogo();

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

            public static void ListarCatalogo(){

            var listaSerie = repositorioSerie.Lista();
            var listaFilme = repositorioFilme.Lista();

            Console.WriteLine("O que você deseja listar: ");
            Console.WriteLine("------1 - Series");
            Console.WriteLine("------2 - Filmes");
            int escolha = int.Parse(Console.ReadLine());

            //Série escolhida
            if(escolha == 1){
            //Ferifica se existe série
                if(listaSerie.Count != 0){
                    Console.WriteLine("Lista de séries: ");

                    foreach(var serie in listaSerie){
                        //Verifica se a série foi excluida
                        var serieExcluida = serie.retornarExcluido();
                        if(!serieExcluida){
                        Console.WriteLine("#ID {0}-{1}", serie.retornaId(), serie.retornaritulo());
                        }
                    }
                }else{
                    Console.WriteLine("Nenhuma série encontrada!");
                }
            //Filme escolhido
            }else if(escolha == 2){
                //Verifica se existe filme
                if(listaFilme.Count !=0){
                    Console.WriteLine("Lista de filme: ");

                    foreach(var filmes in listaFilme){
                        //Verifica se a filme foi excluido
                        var filmeExcluido = filmes.retornarExcluido();
                        if(!filmeExcluido){
                            Console.WriteLine("#ID {0}-{1}", filmes.retornaId(), filmes.retornarNome());
                        }
                    }
                }else{
                    Console.WriteLine("Nenhum filme encontrado!");
                }
            }
            
        }

            public static void InserirCatalogo(){
                try{

                    Console.WriteLine("O que você deseja adicionar?");
                    Console.WriteLine("------1 - Series");
                    Console.WriteLine("------2 - Filme");
                    int escolhaUsuario = int.Parse(Console.ReadLine());

                    //Adicionando Série
                    if(escolhaUsuario == 1){
                    
                        //Vai retornar um obj do tipo Serie
                        var novaSerie = AdicionandoSerie();

                        //Vai inserir nova série passando obj 
                        repositorioSerie.Insere(novaSerie);

                        Console.WriteLine("Nova série salva com sucesso!!");
                    }

                    //Adicionando Filme
                    if(escolhaUsuario == 2){
                        //Método para adicionar filme, vai retornar obj do tipo Filme
                        var novoFilme = AdicionandoFilme();
                        //Vai inserir novo filme
                        repositorioFilme.Insere(novoFilme);

                        Console.WriteLine("Novo filme salvo com sucesso!!");
                    }
                }catch(Exception){
                    throw new ArgumentException("Algo deu errado ao cadastrar nova série");
                }
            }

            public static void AtualizarCatalogo(){

                Console.WriteLine("O que você deseja atualizar adicionar?");
                Console.WriteLine("------1 - Series");
                Console.WriteLine("------2 - Filme");
                int escolhaUsuario = int.Parse(Console.ReadLine());

                if(escolhaUsuario == 1){
                    //Retorna a lista de séries
                    var series = repositorioSerie.Lista();

                    //Verifica se existe alguma série
                    if(series.Count == 0){
                        Console.WriteLine("Nenhuma séries disponível");
                        return;
                    }else{
                        Console.WriteLine("Escolha qual série deseja atualizar: ");

                        //Listando as séries disponíveis
                        foreach(var listaSeries in series){
                            Console.WriteLine("#ID {0}-{1}", listaSeries.retornaId(), listaSeries.retornaritulo());
                        }
                        int entradausuario = int.Parse(Console.ReadLine());

                        var serieAtualizada = AtualizandoSerie(entradausuario);
                        
                        repositorioSerie.Atualizar(entradausuario, serieAtualizada);
                    }
                }else if(escolhaUsuario == 2){
                    var listaFilme = repositorioFilme.Lista();

                    //Verifica se existe algum filme
                    if(listaFilme.Count != 0){
                        Console.WriteLine("Escolha qual filme deseja atualizar: ");
                        //Vai listar os filmes
                        foreach(var filmes in listaFilme){
                            Console.WriteLine("{0}-{1}", filmes.retornaId(), filmes.retornarNome());
                        }

                        int idFilme = int.Parse(Console.ReadLine());
                        //Vai passar o id escolhido para retorna o filme atualizado
                        var filmeAtualizado = AtualizandoFilme(idFilme);

                        repositorioFilme.Atualizar(idFilme, filmeAtualizado);
                    }else{
                        Console.WriteLine("Nenhum filme encontrado!");
                    }
                }

            }

            public static void ExcluirSerie(){

                Console.WriteLine("O que você deseja excluir?");
                Console.WriteLine("------1 - Series");
                Console.WriteLine("------2 - Filme");
                int escolhaUsuario = int.Parse(Console.ReadLine());

                if(escolhaUsuario == 1){
                    var listaSeries  = repositorioSerie.Lista();
                    
                    if(listaSeries.Count != 0){
                        Console.WriteLine("Selecione a série que deseja excluir");

                        foreach(var series in listaSeries){
                            Console.WriteLine("#ID {0}-{1}", series.retornaId(), series.retornaritulo());
                        }
                        
                        int entradaIdParaExcluir = int.Parse(Console.ReadLine());

                        repositorioSerie.Exclui(entradaIdParaExcluir);

                        Console.WriteLine("Filme excluido com sucesso!");
                    }else{
                        Console.WriteLine("Nenhuma série encontrada!");
                    }
                }else if(escolhaUsuario == 2){
                    var listaFilme = repositorioFilme.Lista();

                    if(listaFilme.Count != 0 ){
                        Console.WriteLine("Escolha qual filme você gostaria de excluir: ");
                        foreach(var filmes in listaFilme){
                            Console.WriteLine("{0}-{1}", filmes.retornaId(), filmes.retornarNome());
                        }
                        //Escolha do filme que vai ser excluido
                        int idFilme = int.Parse(Console.ReadLine());
                        
                        repositorioFilme.Exclui(idFilme);

                        Console.WriteLine("Filme excluido com sucesso!");
                    }else{
                        Console.WriteLine("Nenhum filme encontrado");
                    }
                }
            }

            public static void VisualizarSerie(){

                Console.WriteLine("O que você deseja visualizar?");
                Console.WriteLine("------1 - Series");
                Console.WriteLine("------2 - Filme");
                int escolhaUsuario = int.Parse(Console.ReadLine());

                if(escolhaUsuario == 1){

                    Console.WriteLine("Escolha um Id para visualizar a série detalhadamente: ");
                    var series = repositorioSerie.Lista();

                    foreach(var serie in series){
                        Console.WriteLine("#ID {0}-{1}", serie.retornaId(), serie.retornaritulo());
                    }

                    int escolhaIdSerie = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine(series[escolhaIdSerie].ToString());

                }else if(escolhaUsuario == 2){
                    var listaFilme = repositorioFilme.Lista();

                    Console.WriteLine("Escolha um Id para visualizar o filme detalhadamente");
                    
                    foreach(var filmes in listaFilme){
                        Console.WriteLine("{0}-{1}", filmes.retornaId(), filmes.retornarNome());
                    }
                    int filmeId = int.Parse(Console.ReadLine());

                    Console.WriteLine(listaFilme[filmeId].ToString());
                }
            }
            
            public static string OpcaoDoUsuario(){

            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar séries e filmes");
            Console.WriteLine("2 - Inserir uma nova série ou filme");
            Console.WriteLine("3 - Atualizar série ou filme");
            Console.WriteLine("4 - Excluir série ou filme");
            Console.WriteLine("5 - Visualizar série ou filme");
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

            Serie novaSerie = new Serie(
                id:repositorioSerie.ProximoId(),
                genero:(Genero)entradaGenero, 
                titulo:entradaTítulo, 
                descricao:entradaDescricao, 
                ano:entradaAno
            );
            
            return novaSerie;
        }

            public static Filme AdicionandoFilme(){
                Console.WriteLine("Escolha qual o a plataforma o filme pertence: ");
                foreach(int plataformas in Enum.GetValues(typeof(Plataforma))){
                    Console.WriteLine("{0}-{1}",plataformas, Enum.GetName(typeof(Plataforma), plataformas));
                }
                int entradaPlataforma = int.Parse(Console.ReadLine());

                Console.WriteLine("Escolha o gênero do filme: ");
                foreach(int i in Enum.GetValues(typeof(Genero))){
                    Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
                }
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o nome do filme: ");
                string entradaNome = Console.ReadLine();

                Console.WriteLine("Digite o ano de lançamento: ");
                int entradaLancamento = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a descrição do filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme novoFilme = new Filme(
                    id:repositorioFilme.ProximoId(), 
                    nome:entradaNome, 
                    descricao: entradaDescricao,
                    genero:(Genero)entradaGenero, 
                    plataforma:(Plataforma)entradaPlataforma, 
                    lancamento:entradaLancamento
                );

                return novoFilme;
                
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
    
            public static Filme AtualizandoFilme(int id){
                Console.WriteLine("Escolha qual o a plataforma o filme pertence: ");
                foreach(int plataformas in Enum.GetValues(typeof(Plataforma))){
                    Console.WriteLine("{0}-{1}",plataformas, Enum.GetName(typeof(Plataforma), plataformas));
                }
                int entradaPlataforma = int.Parse(Console.ReadLine());

                Console.WriteLine("Escolha o gênero do filme: ");
                foreach(int i in Enum.GetValues(typeof(Genero))){
                    Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
                }
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o nome do filme: ");
                string entradaNome = Console.ReadLine();

                Console.WriteLine("Digite o ano de lançamento: ");
                int entradaLancamento = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a descrição do filme: ");
                string entradaDescricao = Console.ReadLine();

                Filme filmeAtualizado = new Filme(
                    id:id, 
                    nome:entradaNome, 
                    descricao: entradaDescricao,
                    genero:(Genero)entradaGenero, 
                    plataforma:(Plataforma)entradaPlataforma, 
                    lancamento:entradaLancamento
                );

                return filmeAtualizado;

            }
    }
}
