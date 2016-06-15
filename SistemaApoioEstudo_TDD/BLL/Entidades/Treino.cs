using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Treino
    {
        public Configuracao Configuracao { get; set; }
        public List<string> Respostas { get; set; }
        public List<bool> Assercoes { get; set; }
        public TimeSpan Tempo { get; set; }

        public Treino(Configuracao configuracao)
        {
            this.Configuracao = configuracao;
            Respostas = new List<string>();
            Assercoes = new List<bool>();
        }
    }
}