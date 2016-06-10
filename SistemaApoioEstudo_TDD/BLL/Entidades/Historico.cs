using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Historico : Object
    {
        public int Id { get; set; }
        public Treino Treino { get; set; }
        public byte Acertos { get; set; }
        public byte Erros { get; set; }
        public int Testes { get; set; }
        public DateTime Data { get; set; }

        public Historico(Treino treino)
        {
            this.Treino = treino;
            Data = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            Historico historico = obj as Historico;
            if (historico == null || GetType() != historico.GetType())
            {
                return false;
            }
            return (this.Id == historico.Id); 
        }
    }
}