using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Negocio;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC06_CadastrarAssunto
    {
        private NegocioAssunto negocioAssunto;
        private IAssuntoDAO assuntoDAO;

        public UC06_CadastrarAssunto()
        {
            negocioAssunto = new NegocioAssunto();
            assuntoDAO = new AssuntoDAO();
        }

        [TestFixtureSetUp]
        public void SetUp()
        {
            Usuario usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            IUsuarioDAO usuarioDAO = new UsuarioDAO();
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
            assuntoFaculdade = assuntoDAO.ConsultarNomeIdUsuario(assuntoFaculdade.Nome, Login.Usuario.Id);
            if (assuntoFaculdade != null)
            {
                assuntoDAO.Excluir(assuntoFaculdade.Id);
            }

            Assunto assuntoFatec = new Assunto()
            {
                Nome = "FatecZL"
            };
            Assunto assuntoRetorno = assuntoDAO.ConsultarNomeIdUsuario(assuntoFatec.Nome, Login.Usuario.Id);
            if (assuntoRetorno == null)
            {
                assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFatec);
            }
        }

        [Test]
        public void CT01UC06FB_Cadastrar_comDadosValidos_comSucesso()
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
        public void CT02UC06FA_Cadastrar_comAssuntoEmBranco_semSucesso()
        {
            Assunto assunto = new Assunto()
            {
                Nome = " "
            };
            negocioAssunto.ValidarNome(assunto.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC06FA_Cadastrar_comAssuntoAcimaDe30Caracteres_semSucesso()
        {
            Assunto assunto = new Assunto()
            {
                Nome = "Faculdade de Tecnologia da Zona Leste"
            };
            negocioAssunto.ValidarNome(assunto.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC06FA_Cadastrar_comAssuntoNULL_semSucesso()
        {
            negocioAssunto.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT05UC06FA_Cadastrar_comAssuntoJaExistente_semSucesso()
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