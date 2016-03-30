using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;

namespace SistemaApoioEstudo.Teste.TestesTermo
{
    [TestFixture]
    public class UC13_ConsultarTermo
    {
        private NegocioTermo negocioTermo;
        private ITermoDAO termoDAO;
        private ICategoriaDAO categoriaDAO;
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Categoria categoriaProgramacao;
        private Termo termoInicial;

        public UC13_ConsultarTermo()
        {
            negocioTermo = new NegocioTermo();
            termoDAO = new TermoDAO();
            categoriaDAO = new CategoriaDAO();
            assuntoDAO = new AssuntoDAO();
            usuarioDAO = new UsuarioDAO();
            usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            categoriaProgramacao = new Categoria()
            {
                Nome = "Programacao"
            };
            termoInicial = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
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

            //_Cadastra o assunto "Faculdade" para o usuário com nome "Alexandre".
            Assunto assuntoFaculdade = new Assunto()
            {
                Nome = "Faculdade"
            };
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFaculdade);
            //_Consulta o id do assunto "Faculdade".
            assuntoFaculdade = assuntoDAO.ConsultarNomeIdUsuario(assuntoFaculdade.Nome, Login.Usuario.Id);

            //_Cadastra a categoria "Programacao" para o assunto "Faculdade".
            categoriaDAO.Cadastrar(assuntoFaculdade.Id, categoriaProgramacao);
            //_Consulta o id da categoria "Programação".
            categoriaProgramacao = categoriaDAO.ConsultarNomeIdAssunto(categoriaProgramacao.Nome, assuntoFaculdade.Id);

            //_Cadastra o termo "Qual o significado de IDE?" para a categoria "Programação".
            termoDAO.Cadastrar(categoriaProgramacao.Id, termoInicial);
            //_Consulta o id do termo "Qual o significado de IDE?".
            termoInicial = termoDAO.ConsultarNomeIdCategoria(termoInicial.Nome, categoriaProgramacao.Id);
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
        public void CT01UC13FB_Consultar_termosDeUmaCategoria_comSucesso()
        {
            List<Termo> termosRetorno = termoDAO.ConsultarDadosIdCategoria(categoriaProgramacao.Id);
            Assert.AreEqual(1, termosRetorno.Count);
        }

        [Test]
        public void CT02UC13FB_Consultar_dadosDeUmTermo_comSucesso()
        {
            List<Termo> termosRetorno = termoDAO.ConsultarDadosIdCategoria(categoriaProgramacao.Id);
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