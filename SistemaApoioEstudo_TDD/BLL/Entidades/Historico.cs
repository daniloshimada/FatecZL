using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Historico
    {
        public Treino Treino { get; set; }
        public byte Acertos { get; set; }
        public byte Erros { get; set; }
        public DateTime Data { get; set; }

        public Historico(Treino treino)
        {
            this.Treino = treino;
            Data = DateTime.Now;
        }
    }
}