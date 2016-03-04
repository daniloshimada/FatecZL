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
                negocioUsuario.ValidarNome(usuario.Nome);
                negocioUsuario.ValidarSenha(usuario.Senha);
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
                negocioUsuario.ValidarNome(usuario.Nome);
                bool resultado = negocioUsuario.ValidarSenhaNova(usuario.Senha);
                negocioUsuario.ValidarSenhaConfirmacao(senhaConfirmacao);
                usuario.Id = Login.Usuario.Id;
                if (resultado)
                {
                    resultado = usuarioDAO.Atualizar(usuario);
                }
                else
                {
                    resultado = usuarioDAO.AtualizarNome(usuario);
                }
                return new NegocioLogin().AtualizarLogin(usuario, resultado); ;
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
                negocioUsuario.ValidarSenhaConfirmacao(senhaConfirmacao);
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
    }
}