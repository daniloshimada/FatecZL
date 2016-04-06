using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC07_AtualizarAssunto
    {
        private Usuario usuarioInicial;
        private Assunto assuntoInicial;
        private NegocioAssunto negocioAssunto;
        private IUsuarioDAO usuarioDAO;
        private IAssuntoDAO assuntoDAO;

        public UC07_AtualizarAssunto()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            assuntoInicial = new Assunto();
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

            //_Cadastra o assunto "Faculdade" para o usuário "Alexandre".
            assuntoInicial.Nome = "Faculdade";
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoInicial);

            //_Consulta o id do assunto "Faculdade".
            assuntoInicial = assuntoDAO.ConsultarNomeIdUsuario(assuntoInicial.Nome, Login.Usuario.Id);

            //_Cadastra o assunto "FatecZL" para o usuário "Alexandre".
            Assunto assuntoSecundario = new Assunto()
            {
                Nome = "FatecZL"
            };
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoSecundario);
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
        public void CT01UC07FB_Atualizar_assuntoComDadosValidos_comSucesso()
        {
            Assunto assuntoValido = new Assunto()
            {
                Id = assuntoInicial.Id,
                Nome = "Curso"
            };
            negocioAssunto.ValidarNome(assuntoValido.Nome);
            Assert.IsTrue(assuntoDAO.Atualizar(assuntoValido));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC07FA_Atualizar_assuntoEmBranco_semSucesso()
        {
            Assunto assuntoBranco = new Assunto()
            {
                Id = assuntoInicial.Id,
                Nome = " "
            };
            negocioAssunto.ValidarNome(assuntoBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC07FA_Atualizar_assuntoAcimaDe30Caracteres()
        {
            Assunto assuntoCaracteres = new Assunto()
            {
                Id = assuntoInicial.Id,
                Nome = "Faculdade de Tecnologia da Zona Leste"
            };
            negocioAssunto.ValidarNome(assuntoCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC07FA_Atualizar_assuntoNulo_semSucesso()
        {
            Assunto assuntoNulo = new Assunto()
            {
                Id = assuntoInicial.Id,
                Nome = "Curso"
            };
            negocioAssunto.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT05UC07FA_Atualziar_assuntoJaExistente_semSucesso()
        {
            Assunto assuntoExistente = new Assunto()
            {
                Id = assuntoInicial.Id,
                Nome = "FatecZL"
            };
            negocioAssunto.ValidarNome(assuntoExistente.Nome);
            Assert.IsTrue(assuntoDAO.Atualizar(assuntoExistente));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC07FA_Atualizar_assuntoSemConsulta_semSucesso()
        {
            negocioAssunto.VerificarAssuntoConsultado(-1);
        }
    }
}