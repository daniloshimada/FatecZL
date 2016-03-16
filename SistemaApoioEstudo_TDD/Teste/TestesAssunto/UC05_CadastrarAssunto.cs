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
        public void CT01UC05FB_Cadastrar_assuntoComDadosValidos_comSucesso()
        {
            Assunto assuntoValido = new Assunto()
            {
                Nome = "Faculdade"
            };
            negocioAssunto.ValidarNome(assuntoValido.Nome);
            bool resultado = assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoValido);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC05FA_Cadastrar_assuntoEmBranco_semSucesso()
        {
            Assunto assuntoBranco = new Assunto()
            {
                Nome = " "
            };
            negocioAssunto.ValidarNome(assuntoBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC05FA_Cadastrar_assuntoAcimaDe30Caracteres_semSucesso()
        {
            Assunto assuntoCaracteres = new Assunto()
            {
                Nome = "Faculdade de Tecnologia da Zona Leste"
            };
            negocioAssunto.ValidarNome(assuntoCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC05FA_Cadastrar_assuntoNULL_semSucesso()
        {
            Assunto assuntoNULL = new Assunto()
            {
                Nome = "Curso"
            };
            negocioAssunto.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT05UC05FA_Cadastrar_assuntoJaExistente_semSucesso()
        {
            Assunto assuntoExistente = new Assunto()
            {
                Nome = "FatecZL"
            };
            negocioAssunto.ValidarNome(assuntoExistente.Nome);
            bool resultado = assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoExistente);
            Assert.IsTrue(resultado);
        }
    }
}