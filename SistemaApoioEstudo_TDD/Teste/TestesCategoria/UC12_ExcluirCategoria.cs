using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesCategoria
{
    [TestFixture]
    public class UC12_ExcluirCategoria
    {
        private Usuario usuarioInicial;
        private Categoria categoriaInicial;
        private NegocioCategoria negocioCategoria;
        private IUsuarioDAO usuarioDAO;
        private ICategoriaDAO categoriaDAO;

        public UC12_ExcluirCategoria()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            categoriaInicial = new Categoria()
            {
                Nome = "POO"
            };
            negocioCategoria = new NegocioCategoria();
            usuarioDAO = new UsuarioDAO();
            categoriaDAO = new CategoriaDAO();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //_Exclui, Cadastra e Loga o usuário "Alexandre" com senha "athens".
            Usuario usuarioInicialRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicialRetorno != null)
            {
                usuarioDAO.Excluir(usuarioInicialRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioInicial);
            Login.RegistrarUsuario(usuarioDAO.Consultar(usuarioInicial));

            //_Cadastra o assunto "Faculdade" para o usuário "Alexandre".
            Assunto assuntoInicial = new Assunto()
            {
                Nome = "Faculdade"
            };
            IAssuntoDAO assuntoDAO = new AssuntoDAO();
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoInicial);
            //_Consulta o id do assunto "Faculdade".
            assuntoInicial = assuntoDAO.ConsultarNomeIdUsuario(assuntoInicial.Nome, Login.Usuario.Id);

            //_Cadastra a categoria "POO" para o assunto "Faculdade".
            categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaInicial);
            //_Consulta o id da categoria "POO".
            categoriaInicial = categoriaDAO.ConsultarNomeIdAssunto(categoriaInicial.Nome, assuntoInicial.Id);
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
        public void CT01UC12FB_Excluir_categoriaEDadosRelacionados()
        {
            Assert.IsTrue(categoriaDAO.Excluir(categoriaInicial.Id));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC12FA_Excluir_categoriaSemConsulta_semSucesso()
        {
            negocioCategoria.VerificarCategoriaSelecionada(-1);
        }
    }
}