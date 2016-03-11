using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleLogin
    {
        public bool Logar(Usuario usuarioLogin)
        {
            try
            {
                IUsuarioDAO usuarioDAO = new UsuarioDAO();   
                Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioLogin);
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                negocioUsuario.ValidarNome(usuarioLogin.Nome);
                negocioUsuario.ValidarSenha(usuarioLogin.Senha);
                if (usuarioRetorno != null)
                {
                    Login.RegistrarUsuario(usuarioRetorno);
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