using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Controles;
using System.Data.SqlClient;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Utilitarios;

namespace Testes
{
    [TestFixture]
    public class UC01_CadastrarUsuario
    {
        private NegocioUsuario negocioUsuario;
        private IUsuarioDAO usuarioDAO;

        public UC01_CadastrarUsuario()
        {
            negocioUsuario = new NegocioUsuario();
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
            usuarioAlexandre = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioAlexandre != null)
            {
                usuarioDAO.Excluir(usuarioAlexandre.Id);
            }

            Usuario usuarioDanilo = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
            usuarioDanilo = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioDanilo == null)
            {
                usuarioDAO.Cadastrar(usuarioDanilo);
            }
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            usuario = usuarioDAO.ConsultarNome(usuario.Nome);
            if (usuario != null)
            {
                usuarioDAO.Excluir(usuario.Id);
            }
        }

        [Test]
        public void CT01UC01FB_CadastrarUsuario_comSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            bool resultadoCadastrar = usuarioDAO.Cadastrar(usuario);
            Assert.IsTrue(resultadoCadastrar);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC01FA_CadastrarUsuario_comNomeEmBranco_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "   ",
                Senha = "baralho"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC01FA_CadastrarUsuario_comSenhaEmBranco_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = "   "
            };
            negocioUsuario.ValidarSenha(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT04UC01FA_CadastrarUsuario_comNomeAcimaDe15Caracteres_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandreshigueru",
                Senha = "athens"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC01FA_CadastrarUsuario_comSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphidanilo"
            };
            negocioUsuario.ValidarSenha(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT06UC01FA_CadastrarUsuario_comNomeNull_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = null,
                Senha = "creta"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT07UC01FA_CadastrarUsuario_comSenhaNull_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = null
            };
            negocioUsuario.ValidarSenha(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT08UC01FA_CadastrarUsuario_comNomeJaExistente_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
            negocioUsuario.ValidarSenha(usuario.Senha);
            usuarioDAO.Cadastrar(usuario);
        }
    }
}