using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using System.Collections.Generic;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC06_ConsultarAssunto
    {
        private Usuario usuarioInicial;
        private IUsuarioDAO usuarioDAO;
        private IAssuntoDAO assuntoDAO;

        public UC06_ConsultarAssunto()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
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
            Assunto assuntoInicial = new Assunto()
            {
                Nome = "Faculdade"
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
        public void CT01UC06FB_Consultar_assuntosDeUmUsuario_comSucesso()
        {
            Assert.AreEqual(1, assuntoDAO.ConsultarDadosIdUsuario(Login.Usuario.Id).Count);
        }

        [Test]
        public void CT02UC06FB_Consultar_dadosDeUmAssunto_comSucesso()
        {
            List<Assunto> assuntosRetorno = assuntoDAO.ConsultarDadosIdUsuario(Login.Usuario.Id);
            Assunto assuntoEsperado = new Assunto()
            {
                Id = assuntosRetorno[0].Id,
                Nome = "Faculdade"
            };
            Assert.IsTrue(assuntoDAO.ConsultarDadosIdUsuario(Login.Usuario.Id)[0].Equals(assuntoEsperado));
        }
    }
}