using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioLogin
    {
        public bool AtualizarLogin(Usuario usuarioAtualizado, bool resultadoAtualizar)
        {
            try
            {
                if (resultadoAtualizar)
                {
                    Login.Usuario = usuarioAtualizado;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}