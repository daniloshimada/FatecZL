using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.Negocio;
using System;

namespace SistemaApoioEstudo.Teste.TestesCategoria
{
    [TestFixture]
    public class UC12_ExcluirCategoria
    {
        private NegocioCategoria negocioCategoria;
        private ICategoriaDAO categoriaDAO;
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Assunto assuntoFaculdade;
        private Categoria categoriaPOO;

        public UC12_ExcluirCategoria()
        {
            negocioCategoria = new NegocioCategoria();
            categoriaDAO = new CategoriaDAO();
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
            categoriaPOO = new Categoria()
            {
                Nome = "POO"
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

            //_Cadastra a categoria "POO" para o assunto "Faculdade".
            categoriaDAO.Cadastrar(assuntoFaculdade.Id, categoriaPOO);

            //_Consulta o id da categoria "POO".
            categoriaPOO = categoriaDAO.ConsultarNomeIdAssunto(categoriaPOO.Nome, assuntoFaculdade.Id);
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
        public void CT01UC12FB_Excluir_categoriaEDadosRelacionados()
        {
            bool resultado = categoriaDAO.Excluir(categoriaPOO.Id);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC12FA_Excluir_categoriaSemConsulta_semSucesso()
        {
            negocioCategoria.VerificarCategoriaSelecionada(-1);
        }
    }
}