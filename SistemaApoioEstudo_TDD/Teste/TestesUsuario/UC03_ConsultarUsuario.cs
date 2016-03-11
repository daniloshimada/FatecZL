using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC03_ConsultarUsuario
    {
        private IUsuarioDAO usuarioDAO;

        public UC03_ConsultarUsuario()
        {
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
            IUsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioAlexandre);
            Login.RegistrarUsuario(usuarioDAO.ConsultarNome(usuarioAlexandre.Nome));
        }

        [Test]
        public void CT01UC03FB_Consultar_dadosDoUsuario_comSucesso()
        {
            Usuario usuarioRetorno = usuarioDAO.ConsultarDados(Login.Usuario.Id);
            Usuario usuarioComparacao = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = Login.Usuario.Nome,
                Senha = Login.Usuario.Senha,
                QtdAssuntos = 0,
                QtdCategorias = 0,
                QtdTermos = 0,
                QtdDicas = 0
            };
            bool resultado = usuarioRetorno.Equals(usuarioComparacao);
            Assert.IsTrue(resultado);
        }
    }
}