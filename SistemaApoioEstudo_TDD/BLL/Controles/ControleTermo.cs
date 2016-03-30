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
    public class ControleTermo
    {
        private NegocioTermo negocioTermo;
        private ITermoDAO termoDAO; 

        public ControleTermo()
        {
            negocioTermo = new NegocioTermo();
            termoDAO = new TermoDAO();
        }
        
        public bool Cadastrar(int idCategoria, Termo termo)
        {
            try
            {
                return termoDAO.Cadastrar(idCategoria, termo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Termo> ConsultarDadosIdCategoria(int idCategoria)
        {
            try
            {
                return termoDAO.ConsultarDadosIdCategoria(idCategoria);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}