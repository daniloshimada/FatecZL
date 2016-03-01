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
        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                ValidarNome(usuario.Nome);
                ValidarSenha(usuario.Senha);
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

        public bool Atualizar(Usuario usuario)
        {
            try
            {
                IUsuarioDAO usuarioDAO = new UsuarioDAO();
                return usuarioDAO.Atualizar(usuario);
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

        public void ValidarNome(string nome)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            try
            {
                negocioUsuario.ValidarNome(nome);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarSenha(string senha)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            try
            {
                negocioUsuario.ValidarSenha(senha);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarSenhaConfirmacao(string senhaConfirmacao)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
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