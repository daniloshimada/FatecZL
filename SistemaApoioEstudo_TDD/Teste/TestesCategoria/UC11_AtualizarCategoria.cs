using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesCategoria
{
    [TestFixture]
    public class UC11_AtualizarCategoria
    {
        private NegocioCategoria negocioCategoria;
        private ICategoriaDAO categoriaDAO;
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Assunto assuntoFaculdade;
        private Categoria categoriaPOO;

        public UC11_AtualizarCategoria()
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

            //_Cadastra a categoria "Banco de Dados" para o assunto "Faculdade".
            Categoria categoriaBancoDados = new Categoria()
            {
                Nome = "Banco de Dados"
            };
            categoriaDAO.Cadastrar(assuntoFaculdade.Id, categoriaBancoDados);
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
        public void CT01UC11FB_Atualizar_categoriaComDadosValidos_comSucesso()
        {
            Categoria categoriaValida = new Categoria()
            {
                Id = categoriaPOO.Id,
                Nome = "Programação"
            };
            negocioCategoria.ValidarNome(categoriaValida.Nome);
            bool resultado = categoriaDAO.Atualizar(categoriaValida);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC11FA_Atualizar_categoriaEmBranco_semSucesso()
        {
            Categoria categoriaBranco = new Categoria()
            {
                Id = categoriaPOO.Id,
                Nome = ""
            };
            negocioCategoria.ValidarNome(categoriaBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC11FA_Atualizar_categoriaAcimaDe50Caracteres_semSucesso()
        {
            Categoria categoriaCaracteres = new Categoria()
            {
                Id = categoriaPOO.Id,
                Nome = "Programação Orientada a Objetos utilizando a linguagem de programação Java"
            };
            negocioCategoria.ValidarNome(categoriaCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC11FA_Atualizar_categoriaNULL_semSucesso()
        {
            Categoria categoriaNULL = new Categoria()
            {
                Id = categoriaPOO.Id,
                Nome = "Programação"
            };
            negocioCategoria.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT05UC11FA_Atualizar_categoriaJaExistente_semSucesso()
        {
            Categoria categoriaExistente = new Categoria()
            {
                Id = categoriaPOO.Id,
                Nome = "Banco de Dados"
            };
            negocioCategoria.ValidarNome(categoriaExistente.Nome);
            bool resultado = categoriaDAO.Atualizar(categoriaExistente);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC11FA_Atualizar_categoriaSemConsulta_semSucesso()
        {
            negocioCategoria.VerificarCategoriaSelecionada(-1);
        }
    }
}