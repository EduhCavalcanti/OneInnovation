namespace Dio.Series
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; } 
        public int Ano { get; set; }

        //Método para retornar Id da série ou  Filme
        public int retornaId(){
        return this.Id;
        }
    }

    


}