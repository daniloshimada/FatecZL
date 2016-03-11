using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Negocio;

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
                ValidarCamposCadastrar(usuario);
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
                bool resultado = ValidarCamposAtualizar(usuario, senhaConfirmacao);
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

        public bool Excluir(string senhaConfirmacao)
        {
            try
            {
                ValidarCamposExcluir(senhaConfirmacao);
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

        public void ValidarCamposCadastrar(Usuario usuario)
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

        public bool ValidarCamposAtualizar(Usuario usuario, string senhaConfirmacao)
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

        public void ValidarCamposExcluir(string senhaConfirmacao)
        {
            try
            {
                negocioUsuario.ValidarSenhaConfirmacao(senhaConfirmacao);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}