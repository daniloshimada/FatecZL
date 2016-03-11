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

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC08_AtualzarAssunto
    {
        private NegocioAssunto negocioAssunto;
        private IAssuntoDAO assuntoDAO;
        private Assunto assuntoFaculdade;

        public UC08_AtualzarAssunto()
        {
            negocioAssunto = new NegocioAssunto();
            assuntoDAO = new AssuntoDAO();
            assuntoFaculdade = new Assunto();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
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

            assuntoFaculdade.Nome = "Faculdade";
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFaculdade);
            assuntoFaculdade = assuntoDAO.ConsultarNomeIdUsuario(assuntoFaculdade.Nome, Login.Usuario.Id);

            Assunto assuntoFatecZL = new Assunto()
            {
                Nome = "FatecZL"
            };
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFatecZL);
        }

        [Test]
        public void CT01UC08FB_Atualizar_comDadosValidos_comSucesso()
        {
            Assunto assuntoCurso = new Assunto()
            {
                Nome = "Curso"
            };
            assuntoCurso.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(assuntoCurso.Nome);
            bool resultado = assuntoDAO.Atualizar(assuntoCurso);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC08FA_Atualizar_assuntoEmBranco_semSucesso()
        {
            Assunto assuntoBranco = new Assunto()
            {
                Nome = " "
            };
            assuntoBranco.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(assuntoBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC08FA_Atualizar_assuntoAcimaDe30Caracteres()
        {
            Assunto assuntoCaracteres = new Assunto()
            {
                Nome = "Faculdade de Tecnologia da Zona Leste"
            };
            assuntoCaracteres.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(assuntoCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC08FA_Atualizar_assuntoNULL_semSucesso()
        {
            Assunto assuntoNULL = new Assunto()
            {
                Nome = "Curso"
            };
            assuntoNULL.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT05UC08FA_Atualziar_assuntoJaExistente_semSucesso()
        {
            Assunto assuntoFatecZL = new Assunto()
            {
                Nome = "FatecZL"
            };
            assuntoFatecZL.Id = assuntoFaculdade.Id;
            negocioAssunto.ValidarNome(assuntoFatecZL.Nome);
            bool resultado = assuntoDAO.Atualizar(assuntoFatecZL);
            Assert.IsTrue(resultado);
        }
    }
}