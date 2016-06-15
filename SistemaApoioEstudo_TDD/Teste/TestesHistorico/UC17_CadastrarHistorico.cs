using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesHistorico
{
    [TestFixture]
    public class UC17_CadastrarHistorico
    {
        private Usuario usuarioInicial;
        private Treino treinoInicial;
        private Historico historico;
        private NegocioHistorico negocioHistorico;
        private IUsuarioDAO usuarioDAO;

        public UC17_CadastrarHistorico()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            treinoInicial = new Treino(null);
            historico = new Historico(treinoInicial);
            negocioHistorico = new NegocioHistorico();
            usuarioDAO = new UsuarioDAO();
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
            Categoria categoriaInicial = new Categoria()
            {
                Nome = "Programacao"
            };
            categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaInicial);
            //_Consulta o id da categoria "Programação".
            categoriaInicial = categoriaDAO.ConsultarNomeIdAssunto(categoriaInicial.Nome, assuntoInicial.Id);

            //_Cadastra o termo "Qual o significado de IDE?" para a categoria "Programação".
            Termo termoInicial = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            ITermoDAO termoDAO = new TermoDAO();
            termoDAO.Cadastrar(categoriaInicial.Id, termoInicial);
            //_Consulta o id do termo "Qual o significado de IDE?".
            termoInicial = termoDAO.ConsultarNomeIdCategoria(termoInicial.Nome, categoriaInicial.Id);

            Configuracao configuracaoInicial = new Configuracao();
            configuracaoInicial.Assunto = assuntoInicial;
            configuracaoInicial.Categoria = categoriaInicial;
            configuracaoInicial.Termos = termoDAO.ConsultarDadosIdCategoria(categoriaInicial.Id);
            treinoInicial.Assercoes.Add(true);
            treinoInicial.Respostas.Add("resposta teste");
            treinoInicial.Configuracao = configuracaoInicial;
            treinoInicial.Tempo = TimeSpan.Parse("00:09:03");
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
        public void CT01UC17FB_Cadastrar_comDadosValidos_comSucesso()
        {
            negocioHistorico.ValidarDados(historico);
            new HistoricoDAO().Cadastrar(historico);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT02UC17FA_Cadastrar_comAssercoesNulas_semSucesso()
        {
            historico.Treino.Assercoes = null;
            negocioHistorico.ValidarDados(historico);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT03UC17FA_Cadastrar_comRespostasNulas_semSucesso()
        {
            historico.Treino.Respostas = null;
            negocioHistorico.ValidarDados(historico);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT04UC17FA_Cadastrar_comDadosTreinoNulos_semSucesso()
        {
            historico = null;
            negocioHistorico.ValidarDados(historico);
        }
    }
}