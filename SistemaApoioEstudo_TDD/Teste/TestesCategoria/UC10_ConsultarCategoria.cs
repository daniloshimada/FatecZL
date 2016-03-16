using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using System.Collections.Generic;

namespace SistemaApoioEstudo.Teste.TestesCategoria
{
    public class UC10_ConsultarCategoria
    {
        private ICategoriaDAO categoriaDAO;
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Assunto assuntoFaculdade;

        public UC10_ConsultarCategoria()
        {
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
        public void CT01UC10FA_Consultar_categoriasDoAssunto_comSucesso()
        {
            List<Categoria> categoriasRetorno = categoriaDAO.ConsultarDadosIdAssunto(assuntoFaculdade.Id);
            Assert.AreEqual(1, categoriasRetorno.Count);
        }

        [Test]
        public void CT02UC10FA_Consultar_dadosDaCategoria_comSucesso()
        {
            List<Categoria> categoriasRetorno = categoriaDAO.ConsultarDadosIdAssunto(assuntoFaculdade.Id);
            Categoria categoriaEsperada = new Categoria()
            {
                Id = categoriasRetorno[0].Id,
                Nome = "POO"
            };
            Assert.IsTrue(categoriaEsperada.Equals(categoriasRetorno[0]));
        }
    }
}