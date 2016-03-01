using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Controles;
using System.Data.SqlClient;

namespace Testes
{
    [TestFixture]
    public class UC01_CadastrarUsuario
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            ControleUsuario controleUsuario = new ControleUsuario();
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            controleUsuario.Consultar(usuario);
            controleUsuario.Excluir(usuario.Id);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            ControleUsuario controleUsuario = new ControleUsuario();
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            controleUsuario.Consultar(usuario);
            controleUsuario.Excluir(usuario.Id);
        }

        [Test]
        public void CT01UC01FB_CadastrarUsuario_comSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            ControleUsuario controleUsuario = new ControleUsuario();
            bool resultadoCadastrar = controleUsuario.Cadastrar(usuario);

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
            ControleUsuario controleUsuario = new ControleUsuario();
            controleUsuario.ValidarNome(usuario.Nome);
            controleUsuario.Cadastrar(usuario);
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
            ControleUsuario controleUsuario = new ControleUsuario();
            controleUsuario.ValidarSenha(usuario.Nome);
            controleUsuario.Cadastrar(usuario);
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
            ControleUsuario controleUsuario = new ControleUsuario();
            controleUsuario.ValidarNome(usuario.Nome);
            controleUsuario.Cadastrar(usuario);
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
            ControleUsuario controleUsuario = new ControleUsuario();
            controleUsuario.ValidarSenha(usuario.Nome);
            controleUsuario.Cadastrar(usuario);
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
            ControleUsuario controleUsuario = new ControleUsuario();
            controleUsuario.ValidarNome(usuario.Nome);
            controleUsuario.Cadastrar(usuario);
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
            ControleUsuario controleUsuario = new ControleUsuario();
            controleUsuario.ValidarSenha(usuario.Nome);
            controleUsuario.Cadastrar(usuario);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT08UC01FA_CadastrarUsuario_comNomeJaExistente_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            ControleUsuario controleUsuario = new ControleUsuario();
            controleUsuario.Cadastrar(usuario);
            controleUsuario.Cadastrar(usuario);
        }
    }
}