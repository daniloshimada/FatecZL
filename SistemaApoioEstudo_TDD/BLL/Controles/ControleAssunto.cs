using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleAssunto
    {
        private NegocioAssunto negocioAssunto;
        private IAssuntoDAO assuntoDAO;

        public ControleAssunto()
        {
            negocioAssunto = new NegocioAssunto();
            assuntoDAO = new AssuntoDAO();
        }

        public bool Cadastrar(Assunto assunto)
        {
            try
            {
                negocioAssunto.ValidarNome(assunto.Nome);
                return assuntoDAO.Cadastrar(Login.Usuario.Id, assunto); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Assunto> ConsultarIdUsuario()
        {
            try
            {
                return assuntoDAO.ConsultarIdUsuario(Login.Usuario.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Assunto ConsultarDados(int idAssunto)
        {
            try
            {
                return assuntoDAO.ConsultarDados(idAssunto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}