using System;
using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        //Instanciou uma lista do tipo Série
        private List<Serie> listaSerie = new List<Serie>();


        public void Atualizar(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {   //Não vai excluir a posição da lista de fato, só vai marcar o atributo como true
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
            //serie[0]..serie[1]..serie[2]
            //Cout ele coloca sempre 1 a mais 
            //serie[1]..serie[2]..serie[3]
        }

        public Serie RetornarPoId(int id)
        {
            return listaSerie[id];
        }
    }
}