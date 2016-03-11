using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesLogin
{
    [TestFixture]
    public class UC01_Logar
    {
        private NegocioLogin negocioLogin;
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;

        public UC01_Logar()
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
        public void CT01UC01FB_Logar_comDadosValidos_comSucesso()
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
        public void CT02UC01FA_Logar_comNomeEmBranco_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = " ",
                Senha = "athens"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC01FA_Logar_comSenhaEmBranco_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = " "
            };
            negocioUsuario.ValidarSenha(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT04UC01FA_Logar_comNomeAcimaDe15Caracteres_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandreshigueru",
                Senha = "athens"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC01FA_Logar_comSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athensalexandre"
            };
            negocioUsuario.ValidarSenha(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT06UC01FA_Logar_comNomeNULL_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            negocioUsuario.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT07UC01FA_Logar_comSenhaNULL_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            negocioUsuario.ValidarSenha(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT08UC01FA_Logar_comNomeIncorreto_semSucesso()
        {
            Usuario usuarioLogin = new Usuario()
            {
                Nome = "Clayton",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioLogin);
            Assert.IsNull(usuarioRetorno);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT09UC01FA_Logar_comSenhaIncorreta_semSucesso()
        {
            Usuario usuarioLogin = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "creta"
            };
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioLogin);
        }
    }
}