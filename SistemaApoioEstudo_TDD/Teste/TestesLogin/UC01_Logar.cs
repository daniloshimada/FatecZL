using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;

namespace SistemaApoioEstudo.Teste.TestesLogin
{
    [TestFixture]
    public class UC01_Logar
    {
        private NegocioUsuario negocioUsuario;
        private NegocioLogin negocioLogin;
        private IUsuarioDAO usuarioDAO;

        public UC01_Logar()
        {
            negocioUsuario = new NegocioUsuario();
            negocioLogin = new NegocioLogin();
            usuarioDAO = new UsuarioDAO();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            Usuario usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
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
            Usuario usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }
        }

        [Test]
        public void CT01UC01FB_Logar_comDadosValidos_comSucesso()
        {
            Usuario usuarioLogin = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioLogin);
            negocioUsuario.ValidarNome(usuarioLogin.Nome);
            negocioUsuario.ValidarSenha(usuarioLogin.Senha);
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