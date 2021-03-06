
using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        List<Filme> listaFilme = new List<Filme>();
        public void Atualizar(int id, Filme entidade)
        {
            listaFilme[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaFilme[id].excluirFilme();
        }

        public void Insere(Filme entidade)
        {
            listaFilme.Add(entidade);
        }

        public List<Filme> Lista()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filme RetornarPoId(int id)
        {
            return listaFilme[id];
        }
    }
}