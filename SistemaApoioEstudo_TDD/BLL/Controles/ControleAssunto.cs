﻿using System;
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
                ValidarCampos(assunto);
                return assuntoDAO.Cadastrar(Login.Usuario.Id, assunto); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Assunto> ConsultarDadosIdUsuario()
        {
            try
            {
                return assuntoDAO.ConsultarDadosIdUsuario(Login.Usuario.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Assunto ConsultarNomeIdUsuario(string nomeAssunto)
        {
            try
            {
                return assuntoDAO.ConsultarNomeIdUsuario(nomeAssunto, Login.Usuario.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Atualizar(Assunto assunto)
        {
            try
            {
                return assuntoDAO.Atualizar(assunto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarCampos(Assunto assunto)
        {
            try
            {
                negocioAssunto.ValidarNome(assunto.Nome);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}