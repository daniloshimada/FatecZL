using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC02_ConsultarUsuario
    {
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;

        public UC02_ConsultarUsuario()
        {
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
            Login.RegistrarUsuario(usuarioDAO.ConsultarNome(usuarioAlexandre.Nome));
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
        public void CT01UC02FB_Consultar_dadosDoUsuario_comSucesso()
        {
            Usuario usuarioRetorno = usuarioDAO.ConsultarDados(Login.Usuario.Id);
            Usuario usuarioEsperado = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Alexandre",
                Senha = "athens",
                QtdAssuntos = 0,
                QtdCategorias = 0,
                QtdTermos = 0,
                QtdDicas = 0
            };
            bool resultado = usuarioRetorno.Equals(usuarioEsperado);
            Assert.IsTrue(resultado);
        }
    }
}