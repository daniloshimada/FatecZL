using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using System.Collections.Generic;

namespace SistemaApoioEstudo.Teste.TestesCategoria
{
    public class UC10_ConsultarCategoria
    {
        private Usuario usuarioInicial;
        private Assunto assuntoInicial;
        private Categoria categoriaInicial;
        private IUsuarioDAO usuarioDAO;
        private ICategoriaDAO categoriaDAO;

        public UC10_ConsultarCategoria()
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
            categoriaInicial = new Categoria()
            {
                Nome = "POO"
            };
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
        public void CT01UC10FB_Consultar_categoriasDeUmAssunto_comSucesso()
        {
            Assert.AreEqual(1, categoriaDAO.ConsultarDadosIdAssunto(assuntoInicial.Id).Count);
        }

        [Test]
        public void CT02UC10FB_Consultar_dadosDeUmaCategoria_comSucesso()
        {
            List<Categoria> categoriasRetorno = categoriaDAO.ConsultarDadosIdAssunto(assuntoInicial.Id);
            Categoria categoriaEsperada = new Categoria()
            {
                Id = categoriaInicial.Id,
                Nome = categoriaInicial.Nome
            };
            Assert.IsTrue(categoriaEsperada.Equals(categoriasRetorno[0]));
        }
    }
}