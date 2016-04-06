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
        private Usuario usuarioInicial;
        private Termo termoInicial;
        private NegocioTermo negocioTermo;
        private IUsuarioDAO usuarioDAO;
        private ITermoDAO termoDAO;
        
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
            Categoria categoriaProgramacao = new Categoria()
            {
                Nome = "Programacao"
            };
            categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaProgramacao);
            //_Consulta o id da categoria "Programação".
            categoriaProgramacao = categoriaDAO.ConsultarNomeIdAssunto(categoriaProgramacao.Nome, assuntoInicial.Id);

            //_Cadastra o termo "Qual o significado de IDE?" para a categoria "Programação".
            termoDAO.Cadastrar(categoriaProgramacao.Id, termoInicial);
            //_Consulta o id do termo "Qual o significado de IDE?".
            termoInicial = termoDAO.ConsultarNomeIdCategoria(termoInicial.Nome, categoriaProgramacao.Id);
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
        public void CT01UC6FB_Excluir_termoEDadosRelacionados_comSucesso()
        {
            Assert.IsTrue(termoDAO.Excluir(termoInicial.Id));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC6FA_Excluir_termoSemConsulta_semSucesso()
        {
            negocioTermo.VerificarTermoSelecionado(new int());
        }
    }
}