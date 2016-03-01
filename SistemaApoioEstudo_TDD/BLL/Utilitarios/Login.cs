using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public static class Login
    {
        public static Usuario Usuario { get; set; }

        public static void RegistrarUsuario(Usuario usuario)
        {
            Login.Usuario = usuario;
        }

        public static void RemoverUsuario(Usuario usuario)
        {
            Login.Usuario = null;
        }

        public static bool AtualizarLogin(Usuario usuarioAtualizado, bool resultadoAtualizar)
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