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
        private Usuario usuarioInicial;
        private NegocioAssunto negocioAssunto;
        private IUsuarioDAO usuarioDAO;
        private IAssuntoDAO assuntoDAO;
        
        public UC05_CadastrarAssunto()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            negocioAssunto = new NegocioAssunto();
            usuarioDAO = new UsuarioDAO();
            assuntoDAO = new AssuntoDAO(); 
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //_Exclui, Cadastra e Loga o usuário "Alexandre" com senha "athens".
            Usuario usuarioInicialRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicialRetorno != null)
            {
                usuarioDAO.Excluir(usuarioInicialRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioInicial);
            Login.RegistrarUsuario(usuarioDAO.Consultar(usuarioInicial));

            //_Cadastra o assunto "FatecZL" para o usuário "Alexandre".
            Assunto assuntoInicial = new Assunto()
            {
                Nome = "FatecZL"
            };
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoInicial);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //_Exclui o usuário "Alexandre".
            usuarioInicial = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicial != null)
            {
                usuarioDAO.Excluir(usuarioInicial.Id);
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
            Assert.IsTrue(assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoValido));
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
        public void CT04UC05FA_Cadastrar_assuntoNulo_semSucesso()
        {
            Assunto assuntoNulo = new Assunto()
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
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoExistente);
        }
    }
}