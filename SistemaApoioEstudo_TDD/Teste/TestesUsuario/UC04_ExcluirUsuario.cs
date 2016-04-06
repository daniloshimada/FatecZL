using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC04_ExcluirUsuario
    {
        private Usuario usuarioInicial;
        private IUsuarioDAO usuarioDAO;

        public UC04_ExcluirUsuario()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            usuarioDAO = new UsuarioDAO();
        }

        [SetUp]
        public void SetUp()
        {
            //_Exclui, Cadastra e Loga o usuário "Alexandre" com senha "athens".
            Usuario usuarioInicialRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicialRetorno != null)
            {
                usuarioDAO.Excluir(usuarioInicialRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioInicial);
            Login.RegistrarUsuario(usuarioDAO.ConsultarNome(usuarioInicial.Nome));
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //_Exclui o usuário "Alexandre".
            usuarioInicial = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicial != null)
            {
                usuarioDAO.Excluir(usuarioInicial.Id);
            }
        }

        [Test]
        public void CT01UC04FB_Excluir_usuarioEDadosRelacionados_comSucesso()
        {
            if (usuarioDAO.Excluir(Login.Usuario.Id))
            {
                Login.RemoverUsuario();
            }
            Assert.IsNull(Login.Usuario);
        }
    }
}