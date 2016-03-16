using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC01_CadastrarUsuario
    {
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Usuario usuarioDanilo;

        public UC01_CadastrarUsuario()
        {
            negocioUsuario = new NegocioUsuario();
            usuarioDAO = new UsuarioDAO();
            usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            usuarioDanilo = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //_Exclui o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioAlexandreRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioAlexandreRetorno != null)
            {
                usuarioDAO.Excluir(usuarioAlexandreRetorno.Id);
            }

            //_Cadastra o usuário com nome "Danilo" e senha "delphi".
            Usuario usuarioDaniloRetorno = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioDaniloRetorno == null)
            {
                usuarioDAO.Cadastrar(usuarioDanilo);
            }
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

            //_Exclui o usuário com nome "Danilo".
            usuarioDanilo = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioDanilo != null)
            {
                usuarioDAO.Excluir(usuarioDanilo.Id);
            }
        }

        [Test]
        public void CT01UC01FB_Cadastrar_comDadosValidos_comSucesso()
        {
            bool resultado = usuarioDAO.Cadastrar(usuarioAlexandre);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC01FA_Cadastrar_comNomeEmBranco_semSucesso()
        {
            Usuario usuarioNomeBranco = new Usuario()
            {
                Nome = " ",
                Senha = "baralho"
            };
            negocioUsuario.ValidarNome(usuarioNomeBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC01FA_Cadastrar_comSenhaEmBranco_semSucesso()
        {
            Usuario usuarioSenhaBranco = new Usuario()
            {
                Nome = "Clayton",
                Senha = " "
            };
            negocioUsuario.ValidarSenha(usuarioSenhaBranco.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT04UC01FA_Cadastrar_comNomeAcimaDe15Caracteres_semSucesso()
        {
            Usuario usuarioNomeCaracteres = new Usuario()
            {
                Nome = "Alexandreshigueru",
                Senha = "athens"
            };
            negocioUsuario.ValidarNome(usuarioNomeCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC01FA_Cadastrar_comSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuarioSenhaCaracteres = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphidanilo"
            };
            negocioUsuario.ValidarSenha(usuarioSenhaCaracteres.Senha);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT06UC01FA_Cadastrar_comNomeNull_semSucesso()
        {
            Usuario usuarioNomeNULL = new Usuario()
            {
                Nome = null,
                Senha = "creta"
            };
            negocioUsuario.ValidarNome(usuarioNomeNULL.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT07UC01FA_Cadastrar_comSenhaNull_semSucesso()
        {
            Usuario usuarioSenhaNULL = new Usuario()
            {
                Nome = "Clayton",
                Senha = null
            };
            negocioUsuario.ValidarSenha(usuarioSenhaNULL.Senha);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT08UC01FA_Cadastrar_comNomeJaExistente_semSucesso()
        {
            Usuario usuarioNomeExistente = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
            negocioUsuario.ValidarNome(usuarioNomeExistente.Nome);
            negocioUsuario.ValidarSenha(usuarioNomeExistente.Senha);
            usuarioDAO.Cadastrar(usuarioNomeExistente);
        }
    }
}