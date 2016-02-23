using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Interfaces;
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
                ValidarNome(usuario);
                ValidarSenha(usuario);
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

        public void ValidarNome(Usuario usuario)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            try
            {
                negocioUsuario.ValidaNome(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarSenha(Usuario usuario)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            try
            {
                negocioUsuario.ValidarSenha(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}