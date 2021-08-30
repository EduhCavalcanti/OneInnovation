using System;

namespace Dio.Series
{
    public class Filme : EntidadeBase
    {
        private string Nome { get; set; }
        private float Duracao { get; set; }
        private Genero Gereno {get; set;}
        private Plataforma Plataforma {get; set;}
        private bool Excluido {get; set;}


        public Filme(int id, int ano, string nome, float duracao, Plataforma plataforma, Genero genero ){
            this.Id = id;
            this.Ano = ano;
            this.Nome = nome;
            this.Duracao = duracao;
            this.Gereno = genero;
            this.Plataforma = plataforma;
            this.Excluido = false;
    }

    public override string ToString(){
        string retorno = "";
            retorno += "Nome" + this.Nome + Environment.NewLine;
            retorno += "Genêro" + this.Gereno + Environment.NewLine;
            retorno += "Duração" + this.Duracao + Environment.NewLine;
            retorno += "Plataforma" + this.Plataforma + Environment.NewLine;
            retorno += "Excluido" + this.Excluido + Environment.NewLine;
            retorno += "Ano" + this.Ano + Environment.NewLine;

            return retorno;
    }

    

        public string retornarNome(){
            return this.Nome;
        }

        public void ExcluirFilme(){
            this.Excluido = true;
        }

        public bool retornarExcluido(){
            return this.Excluido;
        }
    



    }

    
}