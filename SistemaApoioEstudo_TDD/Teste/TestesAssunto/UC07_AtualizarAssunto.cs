﻿using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC07_AtualizarAssunto
    {
        private NegocioAssunto negocioAssunto;
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Assunto assuntoFaculdade;
        private Usuario usuarioAlexandre;

        public UC07_AtualizarAssunto()
        {
            negocioAssunto = new NegocioAssunto();
            assuntoDAO = new AssuntoDAO();
            usuarioDAO = new UsuarioDAO();
            assuntoFaculdade = new Assunto();
            usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //_Exclui, Cadastra e Loga o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioAlexandre);
            Login.RegistrarUsuario(usuarioDAO.Consultar(usuarioAlexandre));

            //_Cadastra o assunto "Faculdade" para o usuário com nome "Alexandre".
            assuntoFaculdade.Nome = "Faculdade";
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFaculdade);

            //_Consulta o id do assunto "Faculdade".
            assuntoFaculdade = assuntoDAO.ConsultarNomeIdUsuario(assuntoFaculdade.Nome, Login.Usuario.Id);

            //_Cadastra o assunto "FatecZL" para o usuário com nome "Alexandre.
            Assunto assuntoFatecZL = new Assunto()
            {
                Nome = "FatecZL"
            };
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFatecZL);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //_Exclui o usuário com nome "Alexandre".
            usuarioAlexandre = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioAlexandre != null)
            {
                usuarioDAO.Excluir(usuarioAlexandre.Id);
            }
        }

        [Test]
        public void CT01UC07FB_Atualizar_assuntoComDadosValidos_comSucesso()
        {
            Assunto assuntoValido = new Assunto()
            {
                Nome = "Curso"
            };
            assuntoValido.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(assuntoValido.Nome);
            bool resultado = assuntoDAO.Atualizar(assuntoValido);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC07FA_Atualizar_assuntoEmBranco_semSucesso()
        {
            Assunto assuntoBranco = new Assunto()
            {
                Nome = " "
            };
            assuntoBranco.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(assuntoBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC07FA_Atualizar_assuntoAcimaDe30Caracteres()
        {
            Assunto assuntoCaracteres = new Assunto()
            {
                Nome = "Faculdade de Tecnologia da Zona Leste"
            };
            assuntoCaracteres.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(assuntoCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC07FA_Atualizar_assuntoNULL_semSucesso()
        {
            Assunto assuntoNULL = new Assunto()
            {
                Nome = "Curso"
            };
            assuntoNULL.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT05UC07FA_Atualziar_assuntoJaExistente_semSucesso()
        {
            Assunto assuntoExistente = new Assunto()
            {
                Nome = "FatecZL"
            };
            assuntoExistente.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(assuntoExistente.Nome);
            bool resultado = assuntoDAO.Atualizar(assuntoExistente);
            Assert.IsTrue(resultado);
        }
    }
}