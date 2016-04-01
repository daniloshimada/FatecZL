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
        private Usuario usuarioInicial;
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;

        public UC20_Logar()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            negocioUsuario = new NegocioUsuario();
            usuarioDAO = new UsuarioDAO();
        }

        [SetUp]
        public void TestFixtureSetup()
        {
            //_Exclui e Cadastra o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioInicialRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicialRetorno != null)
            {
                usuarioDAO.Excluir(usuarioInicialRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioInicial);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //_Exclui o usuário com nome "Alexandre".
            usuarioInicial = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicial != null)
            {
                usuarioDAO.Excluir(usuarioInicial.Id);
            }
        }

        [Test]
        public void CT01UC20FB_Logar_comDadosValidos_comSucesso()
        {
            negocioUsuario.ValidarNome(usuarioInicial.Nome);
            negocioUsuario.ValidarSenha(usuarioInicial.Senha);
            Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioInicial);
            if (usuarioInicial.Equals(usuarioRetorno))
            {
                Login.RegistrarUsuario(usuarioRetorno);
            }
            Assert.IsTrue(usuarioInicial.Equals(usuarioRetorno));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC20FA_Logar_comNomeEmBranco_semSucesso()
        {
            Usuario usuarioNomeBranco = new Usuario()
            {
                Nome = " ",
                Senha = ""
            };
            negocioUsuario.ValidarNome(usuarioNomeBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC20FA_Logar_comSenhaEmBranco_semSucesso()
        {
            Usuario usuarioSenhaBranco = new Usuario()
            {
                Nome = "Danilo",
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
                Senha = ""
            };
            negocioUsuario.ValidarNome(usuarioNomeCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC20FA_Logar_comSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuarioSenhaCaracteres = new Usuario()
            {
                Nome = "Danilo",
                Senha = "danilodelphi"
            };
            negocioUsuario.ValidarSenha(usuarioSenhaCaracteres.Senha);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT06UC20FA_Logar_comNomeNulo_semSucesso()
        {
            Usuario usuarioNomeNulo = new Usuario()
            {
                Nome = "Alexandre",
                Senha = ""
            };
            negocioUsuario.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT07UC20FA_Logar_comSenhaNula_semSucesso()
        {
            Usuario usuarioSenhaNula = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
            negocioUsuario.ValidarSenha(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT08UC20FA_Logar_comNomeIncorreto_semSucesso()
        {
            Usuario usuarioNomeIncorreto = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
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

        [Test]
        public void CT10UC20FB_Logar_deslogar()
        {
            Login.RemoverUsuario();
            Assert.AreEqual(null, Login.Usuario);
        }
    }
}