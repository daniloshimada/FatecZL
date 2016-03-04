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

        // override object.Equals
        public override bool Equals(object obj)
        {
            Usuario usuario = obj as Usuario;
            if (usuario == null || GetType() != usuario.GetType())
            {
                return false;
            }
            return (this.Nome.Equals(usuario.Nome) && this.Senha.Equals(usuario.Senha));
        }
    }
}