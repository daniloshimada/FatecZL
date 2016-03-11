using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC02_CadastrarUsuario
    {
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Usuario usuarioDanilo;

        public UC02_CadastrarUsuario()
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
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioRetorno == null)
            {
                usuarioDAO.Cadastrar(usuarioDanilo);
            }
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //_Exclui o usuário com nome "Alexandre" e senha "athens".
            usuarioAlexandre = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioAlexandre != null)
            {
                usuarioDAO.Excluir(usuarioAlexandre.Id);
            }

            //_Exclui o usuário com nome "Danilo" e senha "delphi".
            usuarioDanilo = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioDanilo != null)
            {
                usuarioDAO.Excluir(usuarioDanilo.Id);
            }
        }

        [Test]
        public void CT01UC02FB_Cadastrar_comDadosValidos_comSucesso()
        {
            bool resultado = usuarioDAO.Cadastrar(usuarioAlexandre);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC02FA_Cadastrar_comNomeEmBranco_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = " ",
                Senha = "baralho"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC02FA_Cadastrar_comSenhaEmBranco_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = " "
            };
            negocioUsuario.ValidarSenha(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT04UC02FA_Cadastrar_comNomeAcimaDe15Caracteres_semSucesso()
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
        public void CT05UC02FA_Cadastrar_comSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphidanilo"
            };
            negocioUsuario.ValidarSenha(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT06UC02FA_Cadastrar_comNomeNull_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = null,
                Senha = "creta"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT07UC02FA_Cadastrar_comSenhaNull_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = null
            };
            negocioUsuario.ValidarSenha(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT08UC02FA_Cadastrar_comNomeJaExistente_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
            negocioUsuario.ValidarSenha(usuario.Senha);
            usuarioDAO.Cadastrar(usuario);
        }
    }
}