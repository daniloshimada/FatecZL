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
        private Usuario usuarioInicial;
        private Categoria categoriaInicial;
        private NegocioCategoria negocioCategoria;
        private IUsuarioDAO usuarioDAO;
        private ICategoriaDAO categoriaDAO;

        public UC11_AtualizarCategoria()
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

            //_Cadastra o assunto "Faculdade" para o usuário "Alexandre.
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

            //_Cadastra a categoria "Banco de Dados" para o assunto "Faculdade".
            Categoria categoriaSecundaria = new Categoria()
            {
                Nome = "Banco de Dados"
            };
            categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaSecundaria);
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
        public void CT01UC11FB_Atualizar_categoriaComDadosValidos_comSucesso()
        {
            Categoria categoriaValida = new Categoria()
            {
                Id = categoriaInicial.Id,
                Nome = "Programação"
            };
            negocioCategoria.ValidarNome(categoriaValida.Nome);
            Assert.IsTrue(categoriaDAO.Atualizar(categoriaValida));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC11FA_Atualizar_categoriaEmBranco_semSucesso()
        {
            Categoria categoriaBranco = new Categoria()
            {
                Id = categoriaInicial.Id,
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
                Id = categoriaInicial.Id,
                Nome = "Programação Orientada a Objetos utilizando a linguagem de programação Java"
            };
            negocioCategoria.ValidarNome(categoriaCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC11FA_Atualizar_categoriaNula_semSucesso()
        {
            Categoria categoriaNULL = new Categoria()
            {
                Id = categoriaInicial.Id,
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
                Id = categoriaInicial.Id,
                Nome = "Banco de Dados"
            };
            negocioCategoria.ValidarNome(categoriaExistente.Nome);
            categoriaDAO.Atualizar(categoriaExistente);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC11FA_Atualizar_categoriaSemConsulta_semSucesso()
        {
            negocioCategoria.VerificarCategoriaSelecionada(-1);
        }
    }
}