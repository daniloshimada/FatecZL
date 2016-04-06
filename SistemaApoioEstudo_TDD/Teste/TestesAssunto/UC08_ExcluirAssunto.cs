using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.Negocio;
using System;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC08_ExcluirAssunto
    {
        private Usuario usuarioInicial;
        private Assunto assuntoInicial;
        private NegocioAssunto negocioAssunto;
        private IUsuarioDAO usuarioDAO;
        private IAssuntoDAO assuntoDAO;

        public UC08_ExcluirAssunto()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            assuntoInicial = new Assunto()
            {
                Nome = "Faculdade"
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

            //_Cadastra o assunto "Faculdade" para o usuário "Alexandre".
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoInicial);
            //_Consulta o id do assunto "Faculdade".
            assuntoInicial = assuntoDAO.ConsultarNomeIdUsuario(assuntoInicial.Nome, Login.Usuario.Id);
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
        public void CT01UC08FB_Excluir_assuntoEDadosRelacionados_comSucesso()
        {
            Assert.IsTrue(assuntoDAO.Excluir(assuntoInicial.Id));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC08FA_Excluir_assuntoSemConsulta_semSucesso()
        {
            negocioAssunto.VerificarAssuntoConsultado(-1);
        }
    }
}