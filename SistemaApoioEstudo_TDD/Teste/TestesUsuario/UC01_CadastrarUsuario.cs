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
        private Usuario usuarioInicial;
        private Usuario usuarioSecundario;
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;

        public UC01_CadastrarUsuario()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            usuarioSecundario = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
            negocioUsuario = new NegocioUsuario();
            usuarioDAO = new UsuarioDAO();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //_Exclui o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioInicialRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicialRetorno != null)
            {
                usuarioDAO.Excluir(usuarioInicialRetorno.Id);
            }

            //_Cadastra o usuário com nome "Danilo" e senha "delphi".
            Usuario usuarioSecundarioRetorno = usuarioDAO.ConsultarNome(usuarioSecundario.Nome);
            if (usuarioSecundarioRetorno == null)
            {
                usuarioDAO.Cadastrar(usuarioSecundario);
            }
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

            //_Exclui o usuário com nome "Danilo".
            usuarioSecundario = usuarioDAO.ConsultarNome(usuarioSecundario.Nome);
            if (usuarioSecundario != null)
            {
                usuarioDAO.Excluir(usuarioSecundario.Id);
            }
        }

        [Test]
        public void CT01UC01FB_Cadastrar_usuarioComDadosValidos_comSucesso()
        {
            negocioUsuario.ValidarNome(usuarioInicial.Nome);
            negocioUsuario.ValidarSenha(usuarioInicial.Senha);
            bool resultado = usuarioDAO.Cadastrar(usuarioInicial);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC01FA_Cadastrar_usuarioComNomeEmBranco_semSucesso()
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
        public void CT03UC01FA_Cadastrar_usuarioComSenhaEmBranco_semSucesso()
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
        public void CT04UC01FA_Cadastrar_usuarioComNomeAcimaDe15Caracteres_semSucesso()
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
        public void CT05UC01FA_Cadastrar_usuarioComSenhaAcimaDe10Caracteres_semSucesso()
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
        public void CT06UC01FA_Cadastrar_usuarioComNomeNulo_semSucesso()
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
        public void CT07UC01FA_Cadastrar_usuarioComSenhaNulo_semSucesso()
        {
            Usuario usuarioSenhaNulo = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
            negocioUsuario.ValidarSenha(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT08UC01FA_Cadastrar_usuarioComNomeJaExistente_semSucesso()
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