using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioUsuario
    {
        public void ValidaNome(Usuario usuario)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(usuario.Nome))
                {
                    throw new ArgumentException("O campo nome deve ser preenchido!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}