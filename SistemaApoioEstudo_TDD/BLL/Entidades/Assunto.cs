using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Assunto : Object
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte QtdCategorias { get; set; }
        public byte QtdTermos { get; set; }
        public byte QtdDicas { get; set; }

        public override bool Equals(object obj)
        {
            Assunto assunto = obj as Assunto;
            if (obj == null || GetType() != assunto.GetType())
            {
                return false;
            }
            return (this.Id == assunto.Id && this.Nome.Equals(assunto.Nome) && this.QtdCategorias == assunto.QtdCategorias
                && this.QtdTermos == assunto.QtdTermos && this.QtdDicas == assunto.QtdDicas);
        }
    }
}