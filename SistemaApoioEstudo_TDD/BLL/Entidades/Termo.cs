using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Termo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Correspondencia { get; set; }
        public string Dica { get; set; }

        public override bool Equals(object obj)
        {
            Termo termo = obj as Termo;
            if (termo == null || GetType() != termo.GetType())
            {
                return false;
            }
            return this.Id == termo.Id && this.Nome.Equals(termo.Nome) && this.Correspondencia.Equals(termo.Correspondencia)
                && this.Dica.Equals(termo.Dica);
        }
    }
}