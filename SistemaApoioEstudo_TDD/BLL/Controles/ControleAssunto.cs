using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;
using System.Collections.Generic;

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

        public bool Excluir(int idAssunto)
        {
            try
            {
                return assuntoDAO.Excluir(idAssunto);
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

        public void VeriricarAssuntoSelecionado(int assuntoSelecionado)
        {
            try
            {
                negocioAssunto.VerificarAssuntoConsultado(assuntoSelecionado);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}