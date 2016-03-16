using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleCategoria
    {
        private ICategoriaDAO categoriaDAO;

        public ControleCategoria()
        {
            categoriaDAO = new CategoriaDAO();
        }

        public bool Cadastrar(int idAssunto, Categoria categoria)
        {
            try
            {
                return categoriaDAO.Cadastrar(idAssunto, categoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Categoria> ConsultarDadosIdAssunto(int idAssunto)
        {
            try
            {
                return categoriaDAO.ConsultarDadosIdAssunto(idAssunto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Categoria ConsultarNomeIdAssunto(string nomeCategoria, int idAssunto)
        {
            try
            {
                return categoriaDAO.ConsultarNomeIdAssunto(nomeCategoria, idAssunto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}