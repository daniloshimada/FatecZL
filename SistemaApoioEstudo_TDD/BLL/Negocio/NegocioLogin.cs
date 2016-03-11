using SistemaApoioEstudo.BLL.Entidades;
using System;

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