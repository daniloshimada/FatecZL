using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC02_ConsultarUsuario
    {
        private Usuario usuarioInicial;
        private IUsuarioDAO usuarioDAO;

        public UC02_ConsultarUsuario()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            usuarioDAO = new UsuarioDAO();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //_Exclui, Cadastra, Consulta o id e Loga o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioInicialRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicialRetorno != null)
            {
                usuarioDAO.Excluir(usuarioInicialRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioInicial);
            usuarioInicial = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            Login.RegistrarUsuario(usuarioInicial);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //_Exclui o usuário com nome "Alexandre".
            usuarioInicial = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicial != null)
            {
                usuarioDAO.Excluir(usuarioInicial.Id);
            }
        }

        [Test]
        public void CT01UC02FB_Consultar_dadosDoUsuarioLogado_comSucesso()
        {
            Usuario usuarioEsperado = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = Login.Usuario.Nome,
                Senha = Login.Usuario.Senha,
                QtdAssuntos = 0,
                QtdCategorias = 0,
                QtdTermos = 0,
                QtdDicas = 0
            };
            Assert.IsTrue(usuarioInicial.Equals(usuarioEsperado));
        }
    }
}