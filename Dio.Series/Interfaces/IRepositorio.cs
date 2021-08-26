using System;
using System.Collections.Generic;

namespace Dio.Series.Interfaces
{
    public interface IRepositorio<T>
    {
        //Retorna uma lista de T
        List<T> Lista(); // --> Lista de série
        //Retorna Id
        T RetornarPoId(int id);// --> Retorna série por id
        //Insere uma entidade 
        void Insere(T entidade);// --> Inserir uma nova série
        //Exclui entidade
        void Exclui(int id);// --> Excluir uma série
        //Atualiza a entidade
        void Atualizar(int id, T entidade);// --> atualizar uma série
        //Retorna o próximo Id
        int ProximoId();

       
    }
}