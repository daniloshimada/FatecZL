using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;
using System.Collections.Generic;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleCategoria
    {
        private NegocioCategoria negocioCategoria;
        private ICategoriaDAO categoriaDAO;

        public ControleCategoria()
        {
            negocioCategoria = new NegocioCategoria();
            categoriaDAO = new CategoriaDAO();
        }

        public bool Cadastrar(int idAssunto, Categoria categoria)
        {
            try
            {
                ValidarCampos(categoria);
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

        public bool Atualizar(Categoria categoria)
        {
            try
            {
                return categoriaDAO.Atualizar(categoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(int idCategoria)
        {
            try
            {
                return categoriaDAO.Excluir(idCategoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarCampos(Categoria categoria)
        {
            try
            {
                negocioCategoria.ValidarNome(categoria.Nome);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void VerificarCategoriaSelecionada(int categoriaSelecionada)
        {
            try
            {
                negocioCategoria.VerificarCategoriaSelecionada(categoriaSelecionada);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}