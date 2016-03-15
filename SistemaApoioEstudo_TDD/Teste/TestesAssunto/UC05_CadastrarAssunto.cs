using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC05_CadastrarAssunto
    {
        private NegocioAssunto negocioAssunto;
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;

        public UC05_CadastrarAssunto()
        {
            negocioAssunto = new NegocioAssunto();
            assuntoDAO = new AssuntoDAO();
            usuarioDAO = new UsuarioDAO();
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

            //_Cadastra o assunto "FatecZL" para o usuário com nome "Alexandre.
            Assunto assuntoFatec = new Assunto()
            {
                Nome = "FatecZL"
            };
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFatec);
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
        public void CT01UC05FB_Cadastrar_comDadosValidos_comSucesso()
        {
            Assunto assunto = new Assunto()
            {
                Nome = "Faculdade"
            };
            negocioAssunto.ValidarNome(assunto.Nome);
            bool resultado = assuntoDAO.Cadastrar(Login.Usuario.Id, assunto);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC05FA_Cadastrar_comAssuntoEmBranco_semSucesso()
        {
            Assunto assunto = new Assunto()
            {
                Nome = " "
            };
            negocioAssunto.ValidarNome(assunto.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC05FA_Cadastrar_comAssuntoAcimaDe30Caracteres_semSucesso()
        {
            Assunto assunto = new Assunto()
            {
                Nome = "Faculdade de Tecnologia da Zona Leste"
            };
            negocioAssunto.ValidarNome(assunto.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC05FA_Cadastrar_comAssuntoNULL_semSucesso()
        {
            Assunto assunto = new Assunto()
            {
                Nome = "Curso"
            };
            negocioAssunto.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT05UC05FA_Cadastrar_comAssuntoJaExistente_semSucesso()
        {
            Assunto assunto = new Assunto()
            {
                Nome = "FatecZL"
            };
            negocioAssunto.ValidarNome(assunto.Nome);
            bool resultado = assuntoDAO.Cadastrar(Login.Usuario.Id, assunto);
            Assert.IsTrue(resultado);
        }
    }
}