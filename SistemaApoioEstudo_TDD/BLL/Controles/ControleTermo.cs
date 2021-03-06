﻿using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;
using System.Collections.Generic;

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
                ValidarCampos(termo);
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

        public int ConsultarQuantidadeTermos(int idCategoria)
        {
            try
            {
                return termoDAO.ConsultarQuantidade(idCategoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Termo> ConsultarRandomico(int idCategoria)
        {
            try
            {
                return termoDAO.ConsultarRandomico(idCategoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Atualizar(Termo termo)
        {
            try
            {
                ValidarCampos(termo);
                return termoDAO.Atualizar(termo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(int idTermo)
        {
            try
            {
                return termoDAO.Excluir(idTermo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarCampos(Termo termo)
        {
            try
            {
                negocioTermo.ValidarNome(termo.Nome);
                negocioTermo.ValidarCorrespondencia(termo.Correspondencia);
                negocioTermo.ValidarDica(termo.Dica);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void VeriricarTermoSelecionado(int termoSelecionado)
        {
            try
            {
                negocioTermo.VerificarTermoSelecionado(termoSelecionado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}