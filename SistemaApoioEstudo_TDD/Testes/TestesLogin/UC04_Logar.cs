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
    public class UC04_Logar
    {
        private NegocioUsuario negocioUsuario;
        private NegocioLogin negocioLogin;
        private IUsuarioDAO usuarioDAO;

        public UC04_Logar()
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
        public void CT01UC04FB_Logar_comDadosValidos_comSucesso()
        {
            Usuario usuarioLogin = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioLogin);
            Usuario[] usuarios = new Usuario[] { usuarioLogin, usuarioRetorno };
            negocioUsuario.ValidarNome(usuarioLogin.Nome);
            negocioUsuario.ValidarSenha(usuarioLogin.Senha);
            bool resultado = negocioLogin.ValidarDados(usuarios);
            if (resultado)
            {
                Login.RegistrarUsuario(usuarioRetorno);
            }
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC04FA_Logar_comNomeEmBranco_semSucesso()
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
        public void CT03UC04FA_Logar_comSenhaEmBranco_semSucesso()
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
        public void CT04UC04FA_Logar_comNomeAcimaDe15Caracteres_semSucesso()
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
        public void CT05UC04FA_Logar_comSenhaAcimaDe10Caracteres_semSucesso()
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
        public void CT06UC04FA_Logar_comNomeNULL_semSucesso()
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
        public void CT07UC04FA_Logar_comSenhaNULL_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            negocioUsuario.ValidarSenha(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT08UC04FA_Logar_comNomeIncorreto_semSucesso()
        {
            Usuario usuarioLogin = new Usuario()
            {
                Nome = "Clayton",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioLogin);
            Usuario[] usuarios = new Usuario[] { usuarioLogin, usuarioRetorno };
            negocioUsuario.ValidarNome(usuarioLogin.Nome);
            negocioUsuario.ValidarSenha(usuarioLogin.Senha);
            negocioLogin.ValidarDados(usuarios);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT09UC04FA_Logar_comSenhaIncorreta_semSucesso()
        {
            Usuario usuarioLogin = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "creta"
            };
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioLogin);
            Usuario[] usuarios = new Usuario[] { usuarioLogin, usuarioRetorno };
            negocioUsuario.ValidarNome(usuarioLogin.Nome);
            negocioUsuario.ValidarSenha(usuarioLogin.Senha);
            negocioLogin.ValidarDados(usuarios);
        }
    }
}