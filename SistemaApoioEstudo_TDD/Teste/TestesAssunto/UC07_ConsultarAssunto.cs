using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using System.Collections.Generic;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC07_ConsultarAssunto
    {
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;

        public UC07_ConsultarAssunto()
        {
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

            //_Cadastra o assunto "Faculdade" para o usuário com nome "Alexandre.
            Assunto assuntoFaculdade = new Assunto()
            {
                Nome = "Faculdade"
            };
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFaculdade);
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
        public void CT01UC07FB_Consultar_assuntosDoUsuario_comSucesso()
        {
            List<Assunto> assuntos = assuntoDAO.ConsultarDadosIdUsuario(Login.Usuario.Id);
            Assert.AreEqual(1, assuntos.Count);
        }

        [Test]
        public void CT02UC07FB_Consultar_dadosDoAssunto_comSucesso()
        {
            List<Assunto> assuntosRetorno = assuntoDAO.ConsultarDadosIdUsuario(Login.Usuario.Id);
            Assunto assuntoEsperado = new Assunto()
            {
                Id = assuntosRetorno[0].Id,
                Nome = "Faculdade",
                QtdCategorias = 0,
                QtdTermos = 0,
                QtdDicas = 0
            };
            Assert.IsTrue(assuntosRetorno[0].Equals(assuntoEsperado));
        }
    }
}