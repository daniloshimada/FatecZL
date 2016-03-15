using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;

namespace SistemaApoioEstudo.Teste.TestesAssunto
{
    [TestFixture]
    public class UC08_ExcluirAssunto
    {
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Assunto assuntoFaculdade;
        private Usuario usuarioAlexandre;
        

        public UC08_ExcluirAssunto()
        {
            assuntoDAO = new AssuntoDAO();
            usuarioDAO = new UsuarioDAO();
            usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            assuntoFaculdade = new Assunto()
            {
                Nome = "Faculdade"
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
            Login.RegistrarUsuario(usuarioDAO.Consultar(usuarioAlexandre));

            //_Cadastra o assunto "Faculdade" para o usuário com nome "Alexandre.
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFaculdade);

            //_Consulta o id do assunto "Faculdade".
            assuntoFaculdade = assuntoDAO.ConsultarNomeIdUsuario(assuntoFaculdade.Nome, Login.Usuario.Id);
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
        public void CT01UC08FB_Excluir_assuntoEDadosRelacionados_comSucesso()
        {
            bool resultado = assuntoDAO.Excluir(assuntoFaculdade.Id);
            Assert.IsTrue(resultado);
        }
    }
}