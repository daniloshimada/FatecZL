using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesTermo
{
    [TestFixture]
    public class UC16_ExcluirTermo
    {
        private Termo termoInicial;
        private Usuario usuarioInicial;
        private NegocioTermo negocioTermo;
        private ITermoDAO termoDAO;
        private IUsuarioDAO usuarioDAO;
        
        public UC16_ExcluirTermo()
        {
            termoInicial = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            negocioTermo = new NegocioTermo();
            termoDAO = new TermoDAO();
            usuarioDAO = new UsuarioDAO();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //_Exclui, Cadastra e Loga o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioInicial);
            Login.RegistrarUsuario(usuarioDAO.Consultar(usuarioInicial));

            //_Cadastra o assunto "Faculdade" para o usuário com nome "Alexandre".
            Assunto assuntoFaculdade = new Assunto()
            {
                Nome = "Faculdade"
            };
            IAssuntoDAO assuntoDAO = new AssuntoDAO();
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFaculdade);
            //_Consulta o id do assunto "Faculdade".
            assuntoFaculdade = assuntoDAO.ConsultarNomeIdUsuario(assuntoFaculdade.Nome, Login.Usuario.Id);

            //_Cadastra a categoria "Programacao" para o assunto "Faculdade".
            ICategoriaDAO categoriaDAO = new CategoriaDAO();
            Categoria categoriaProgramacao = new Categoria()
            {
                Nome = "Programacao"
            };
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
            usuarioInicial = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicial != null)
            {
                usuarioDAO.Excluir(usuarioInicial.Id);
            }
        }

        [Test]
        public void CT01UC15FB_Excluir_termo_comSucesso()
        {
            bool resultado = termoDAO.Excluir(termoInicial.Id);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC15FA_Excluir_termoSemConsulta_semSucesso()
        {
            negocioTermo.VerificarTermoSelecionado(new int());
        }
    }
}