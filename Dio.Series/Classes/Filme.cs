using System;

namespace Dio.Series
{
    public class Filme : EntidadeBase
    {
        private string Nome { get; set; }
        public string Descricao { get; set; }
        private Genero Genero { get; set; }
        private Plataforma Plataforma { get; set; }
        private int Lancamento { get; set; }
        private bool Excluido {get ; set;}


        public Filme(int id, string nome, string descricao, Genero genero, Plataforma plataforma, int lancamento){
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Genero = genero;
            this.Plataforma = plataforma;
            this.Lancamento = lancamento;
            this.Excluido = false;
        }

        public override string ToString(){
            string retorno = "";
            retorno += "Título: " + this.Nome + Environment.NewLine;
            retorno += "Genêro: " + this.Genero + Environment.NewLine;
            retorno += "Plataforma : " + this.Plataforma + Environment.NewLine;
            retorno += "Descrição : " + this.Descricao + Environment.NewLine;
            retorno += "ano: " + this.Lancamento + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;

            return retorno;
        }

        public string retornarNome(){
            return this.Nome;
        }

        public bool retornarExcluido(){
            return this.Excluido;
        }

        public void excluirFilme(){
            this.Excluido = true;
        }


    }
}