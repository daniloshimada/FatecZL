using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Usuario : Object
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int QtdAssuntos { get; set; }
        public int QtdCategorias { get; set; }
        public int QtdTermos { get; set; }
        public int QtdDicas { get; set; }

        public override bool Equals(object obj)
        {
            Usuario usuario = obj as Usuario;
            if (usuario == null || usuario.GetType() != GetType())
            {
                return false;
            }

            return (this.Id == usuario.Id && this.Nome.Equals(usuario.Nome) && this.Senha.Equals(usuario.Senha)
                && this.QtdAssuntos == usuario.QtdAssuntos && this.QtdCategorias == usuario.QtdCategorias 
                && this.QtdTermos == usuario.QtdTermos && this.QtdDicas == usuario.QtdDicas);
        }
    }
}