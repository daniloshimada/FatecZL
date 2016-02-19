using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Controles;

namespace Testes
{
    [TestFixture]
    public class UC01_CadastrarUsuario
    {
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
    }
}