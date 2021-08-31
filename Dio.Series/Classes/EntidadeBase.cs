namespace Dio.Series
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; } 

        //Método para retornar Id da série
         public int retornaId(){
            return this.Id;
        }
    }


}