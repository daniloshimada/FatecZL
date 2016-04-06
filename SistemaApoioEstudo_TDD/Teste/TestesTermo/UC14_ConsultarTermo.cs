using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using System.Collections.Generic;

namespace SistemaApoioEstudo.Teste.TestesTermo
{
    [TestFixture]
    public class UC14_ConsultarTermo
    {
        private Usuario usuarioInicial;
        private Categoria categoriaInicial;
        private Termo termoInicial;
        private IUsuarioDAO usuarioDAO;
        private ITermoDAO termoDAO;

        public UC14_ConsultarTermo()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            categoriaInicial = new Categoria()
            {
                Nome = "Programacao"
            };
            termoInicial = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            usuarioDAO = new UsuarioDAO();
            termoDAO = new TermoDAO();
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

            //_Cadastra a categoria "Programacao" para o assunto "Faculdade".
            ICategoriaDAO categoriaDAO = new CategoriaDAO();
            categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaInicial);
            //_Consulta o id da categoria "Programação".
            categoriaInicial = categoriaDAO.ConsultarNomeIdAssunto(categoriaInicial.Nome, assuntoInicial.Id);

            //_Cadastra o termo "Qual o significado de IDE?" para a categoria "Programação".
            termoDAO.Cadastrar(categoriaInicial.Id, termoInicial);
            //_Consulta o id do termo "Qual o significado de IDE?".
            termoInicial = termoDAO.ConsultarNomeIdCategoria(termoInicial.Nome, categoriaInicial.Id);
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
        public void CT01UC14FB_Consultar_termosDeUmaCategoria_comSucesso()
        {
            Assert.AreEqual(1, termoDAO.ConsultarDadosIdCategoria(categoriaInicial.Id).Count);
        }

        [Test]
        public void CT02UC14FB_Consultar_dadosDeUmTermo_comSucesso()
        {
            List<Termo> termosRetorno = termoDAO.ConsultarDadosIdCategoria(categoriaInicial.Id);
            Termo termoEsperado = new Termo()
            {
                Id = termoInicial.Id,
                Nome = termoInicial.Nome,
                Correspondencia = termoInicial.Correspondencia,
                Dica = termoInicial.Dica
            };
            Assert.IsTrue(termoEsperado.Equals(termosRetorno[0]));
        }
    }
}