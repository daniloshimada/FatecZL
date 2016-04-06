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
        private Usuario usuarioInicial;
        private Assunto assuntoInicial;
        private NegocioCategoria negocioCategoria;
        private IUsuarioDAO usuarioDAO;
        private ICategoriaDAO categoriaDAO;

        public UC09_CadastrarCategoria()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            assuntoInicial = new Assunto()
            {
                Nome = "Faculdade"
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

            //_Cadastra o assunto "Faculdade" para o usuário "Alexandre.
            IAssuntoDAO assuntoDAO = new AssuntoDAO();
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoInicial);
            //_Consulta o id do assunto "Faculdade".
            assuntoInicial = assuntoDAO.ConsultarNomeIdUsuario(assuntoInicial.Nome, Login.Usuario.Id);

            //_Cadastra a categoria "POO" para o assunto "Faculdade".
            Categoria categoriaInicial = new Categoria()
            {
                Nome = "POO"
            };
            categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaInicial);
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
        public void CT01UC09FB_Cadastrar_categoriaComDadosValidos_comSucesso()
        {
            Categoria categoriaValida = new Categoria()
            {
                Nome = "Programação"
            };
            negocioCategoria.ValidarNome(categoriaValida.Nome);
            Assert.IsTrue(categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaValida));
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
        public void CT04UC09FA_Cadastrar_categoriaNula_semSucesso()
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
            categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaExistente);
        }
    }
}