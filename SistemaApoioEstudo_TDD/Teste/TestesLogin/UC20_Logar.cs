using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesLogin
{
    [TestFixture]
    public class UC20_Logar
    {
        private NegocioLogin negocioLogin;
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;

        public UC20_Logar()
        {
            negocioLogin = new NegocioLogin();
            negocioUsuario = new NegocioUsuario();
            usuarioDAO = new UsuarioDAO();
            usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
        }

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            //_Exclui e Cadastra o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioAlexandre);
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
        public void CT01UC20FB_Logar_comDadosValidos_comSucesso()
        {
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioAlexandre);
            negocioUsuario.ValidarNome(usuarioAlexandre.Nome);
            negocioUsuario.ValidarSenha(usuarioAlexandre.Senha);
            bool resultado = false;
            if (usuarioRetorno != null)
            {
                Login.RegistrarUsuario(usuarioRetorno);
                resultado = true;
            }
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC20FA_Logar_comNomeEmBranco_semSucesso()
        {
            Usuario usuarioNomeBranco = new Usuario()
            {
                Nome = " ",
                Senha = "athens"
            };
            negocioUsuario.ValidarNome(usuarioNomeBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC20FA_Logar_comSenhaEmBranco_semSucesso()
        {
            Usuario usuarioSenhaBranco = new Usuario()
            {
                Nome = "Alexandre",
                Senha = " "
            };
            negocioUsuario.ValidarSenha(usuarioSenhaBranco.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT04UC20FA_Logar_comNomeAcimaDe15Caracteres_semSucesso()
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
        public void CT05UC20FA_Logar_comSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuarioSenhaCaracteres = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athensalexandre"
            };
            negocioUsuario.ValidarSenha(usuarioSenhaCaracteres.Senha);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT06UC20FA_Logar_comNomeNULL_semSucesso()
        {
            Usuario usuarioNomeNULL = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            negocioUsuario.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT07UC20FA_Logar_comSenhaNULL_semSucesso()
        {
            Usuario usuarioSenhaNULL = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            negocioUsuario.ValidarSenha(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT08UC20FA_Logar_comNomeIncorreto_semSucesso()
        {
            Usuario usuarioNomeIncorreto = new Usuario()
            {
                Nome = "Clayton",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioNomeIncorreto);
            Assert.IsNull(usuarioRetorno);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT09UC20FA_Logar_comSenhaIncorreta_semSucesso()
        {
            Usuario usuarioSenhaIncorreta = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "creta"
            };
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioSenhaIncorreta);
        }
    }
}