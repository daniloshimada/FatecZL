using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleUsuario
    {
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;

        public ControleUsuario()
        {
            negocioUsuario = new NegocioUsuario();
            usuarioDAO = new UsuarioDAO();
        }

        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                ValidarCampos(usuario);
                return usuarioDAO.Cadastrar(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Atualizar(Usuario usuario, string senhaConfirmacao)
        {
            try
            {
                bool resultado = ValidarCampos(usuario, senhaConfirmacao);
                usuario.Id = Login.Usuario.Id;
                if (resultado)
                {
                    resultado = usuarioDAO.Atualizar(usuario);
                }
                else
                {
                    resultado = usuarioDAO.AtualizarNome(usuario);
                    usuario.Senha = senhaConfirmacao;
                }
                return new NegocioLogin().AtualizarLogin(usuario, resultado); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario ConsultarDados()
        {
            try
            {
                return usuarioDAO.ConsultarDados(Login.Usuario.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir()
        {
            try
            {
                if (usuarioDAO.Excluir(Login.Usuario.Id))
                {
                    Login.RemoverUsuario();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region ...método ValidarCampos() utilizando sobrecarga...
        public void ValidarCampos(Usuario usuario)
        {
            try
            {
                negocioUsuario.ValidarNome(usuario.Nome);
                negocioUsuario.ValidarSenha(usuario.Senha);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidarCampos(Usuario usuario, string senhaConfirmacao)
        {
            try
            {
                negocioUsuario.ValidarNome(usuario.Nome);
                negocioUsuario.ValidarSenhaConfirmacao(senhaConfirmacao);
                return negocioUsuario.ValidarSenhaNova(usuario.Senha);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}