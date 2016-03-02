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

        public ControleUsuario()
        {
            negocioUsuario = new NegocioUsuario();
        }

        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                negocioUsuario.ValidarNome(usuario.Nome);
                negocioUsuario.ValidarSenha(usuario.Senha);
                IUsuarioDAO usuarioDAO = new UsuarioDAO();
                return usuarioDAO.Cadastrar(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Consultar(Usuario usuario)
        {
            try
            {
                IUsuarioDAO usuarioDAO = new UsuarioDAO();
                return usuarioDAO.Consultar(usuario);
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
                IUsuarioDAO usuarioDAO = new UsuarioDAO();
                if (resultado)
                {
                    resultado = usuarioDAO.Atualizar(usuario);
                }
                else
                {
                    resultado = usuarioDAO.AtualizarNome(usuario);
                }
                return Login.AtualizarLogin(usuario, resultado); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(int idUsuario)
        {
            try
            {
                IUsuarioDAO usuarioDAO = new UsuarioDAO();
                return usuarioDAO.Excluir(idUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}