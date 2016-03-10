using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC05_ExcluirUsuario
    {
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;

        public UC05_ExcluirUsuario()
        {
            negocioUsuario = new NegocioUsuario();
            usuarioDAO = new UsuarioDAO();
        }

        [SetUp]
        public void SetUp()
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
            Login.RegistrarUsuario(usuarioDAO.ConsultarNome(usuarioAlexandre.Nome));
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
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
        }

        [Test]
        public void CT01UC05FB_Excluir_comSenhaDeConfirmacaoCorreta_comSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            bool resultado = usuarioDAO.Excluir(Login.Usuario.Id);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC05FA_Excluir_comSenhaDeConfirmacaoEmBranco_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(" ");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC05FA_Excluir_comSenhaDeConfirmacaoAcimaDe10Caracteres_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("danilodelphi");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC05FA_Excluir_comSenhaDeConfirmacaoNULL_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC05FA_Excluir_comSenhaDeConfirmacaoIncorreta_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("creta");
        }
    }
}