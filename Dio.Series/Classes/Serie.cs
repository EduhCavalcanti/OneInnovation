using System;

namespace Dio.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }

        private bool Excluido {get; set;}

        //Construtor
        public Serie()
        {
        }
        public Serie(int id, Genero genero, string titulo, string descricao, int ano){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        //Método ToString
        //Converte o Obj para String
        public override string ToString(){
            string retorno = "";
            retorno += "Genêro" + this.Genero + Environment.NewLine;
            retorno += "Título" + this.Titulo + Environment.NewLine;
            retorno += "Descrição" + this.Descricao + Environment.NewLine;
            retorno += "ano" + this.Ano + Environment.NewLine;

            return retorno;
        }

        //Método para retornar titulo da série
        public string retornaritulo(){
            return this.Titulo;
        }
        
        public void Excluir(){
            this.Excluido = true;
        }

    }
}