using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesCategoria
{
    public class UC09_CadastrarCategoria
    {
        private NegocioCategoria negocioCategoria;
        private ICategoriaDAO categoriaDAO;
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Assunto assuntoFaculdade;

        public UC09_CadastrarCategoria()
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
            Categoria categoriaPOO = new Categoria()
            {
                Nome = "POO"
            };
            categoriaDAO.Cadastrar(assuntoFaculdade.Id, categoriaPOO);
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
        public void CT01UC09FB_Cadastrar_categoriaComDadosValidos_comSucesso()
        {
            Categoria categoriaValida = new Categoria()
            {
                Nome = "Programação"
            };
            negocioCategoria.ValidarNome(categoriaValida.Nome);
            bool resultdo = categoriaDAO.Cadastrar(assuntoFaculdade.Id, categoriaValida);
            Assert.IsTrue(resultdo);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC09FA_Cadastrar_categoriaEmBranco_semSucesso()
        {
            Categoria categoriaBranco = new Categoria()
            {
                Nome = " "
            };
            negocioCategoria.ValidarNome(categoriaBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC09FA_Cadastrar_categoriaAcimaDe50Caracteres_semSucesso()
        {
            Categoria categoriaCaracteres = new Categoria()
            {
                Nome = "Programação Orientada a Objetos, utilizando a linguagem de programação Java"
            };
            negocioCategoria.ValidarNome(categoriaCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC09FA_Cadastrar_categoriaNULL_semSucesso()
        {
            Categoria categoriaNULL = new Categoria()
            {
                Nome = "Programação"
            };
            negocioCategoria.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT05UC09FA_Cadastrar_categoriaJaExistente_semSucesso()
        {
            Categoria categoriaExistente = new Categoria()
            {
                Nome = "POO"
            };
            negocioCategoria.ValidarNome(categoriaExistente.Nome);
            categoriaDAO.Cadastrar(assuntoFaculdade.Id, categoriaExistente);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT06UC09FA_Cadastrar_categoriaSemAssunto_semSucesso()
        {
            Categoria categoriaSemAssunto = new Categoria()
            {
                Nome = "Programação"
            };
            categoriaDAO.Cadastrar(new int(), categoriaSemAssunto);
        }
    }
}