using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC07_AssuntoConsultar
    {
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;

        public UC07_AssuntoConsultar()
        {
            assuntoDAO = new AssuntoDAO();
            usuarioDAO = new UsuarioDAO();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Usuario usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioAlexandre);
            Login.RegistrarUsuario(usuarioDAO.Consultar(usuarioAlexandre));

            Assunto assuntoFaculdade = new Assunto()
            {
                Nome = "Faculdade"
            };
            Assunto assuntoRetorno = assuntoDAO.ConsultarNomeIdUsuario(assuntoFaculdade.Nome, Login.Usuario.Id);
            if (assuntoRetorno == null)
            {
                assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFaculdade);
            }
        }

        [Test]
        public void CT01UC07FB_Consultar_assuntosDoUsuario_comSucesso()
        {
            List<Assunto> assuntos = assuntoDAO.ConsultarIdUsuario(Login.Usuario.Id);
            Assert.AreEqual(1, assuntos.Count);
        }

        [Test]
        public void CT02UC07FB_Consultar_dadosDoAssunto_comSucesso()
        {
            List<Assunto> assuntos = assuntoDAO.ConsultarIdUsuario(Login.Usuario.Id);
            Assunto assuntoRetorno = assuntoDAO.ConsultarDados(assuntos[0].Id);
            Assunto assuntoEsperado = new Assunto()
            {
                Id = assuntos[0].Id,
                Nome = "Faculdade",
                QtdCategorias = 0,
                QtdTermos = 0,
                QtdDicas = 0
            };
            Assert.IsTrue(assuntoRetorno.Equals(assuntoEsperado));
        }
    }
}