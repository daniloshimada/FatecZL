using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;
using System.Collections.Generic;

namespace SistemaApoioEstudo.Teste.TestesTreinar
{
    [TestFixture]
    public class UC21_Treinar
    {
        private Usuario usuarioInicial;
        private Configuracao configuracaoInicial;
        private Treino treino;
        private NegocioTreino negocioTreino;
        private IUsuarioDAO usuarioDAO;

        public UC21_Treinar()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            configuracaoInicial = new Configuracao();
            treino = new Treino(null);
            negocioTreino = new NegocioTreino();
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

            configuracaoInicial.Assunto = assuntoInicial;
            configuracaoInicial.Categoria = categoriaInicial;
            configuracaoInicial.Termos = termoDAO.ConsultarDadosIdCategoria(categoriaInicial.Id);
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
        public void CT01UC21FB_Treinar_comConfiguracao_comSucesso()
        {
            treino.Configuracao = configuracaoInicial;
            negocioTreino.ValidarConfiguracao(treino.Configuracao);
        }

        [Test]
        public void CT02UC21FB_Treinar_coletandoRespostas_comSucesso()
        {
            treino.Respostas.Add("resposta teste");
            negocioTreino.ValidarRespostasColetadas(treino.Respostas); 
        }

        [Test]
        public void CT03UC21FB_Treinar_coletarAssercoes_comSucesso()
        {
            treino.Assercoes.Add(true);
            negocioTreino.ValidarAssercoesColetadas(treino.Assercoes);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CT04UC21FA_Treinar_semConfiguracao_semSucesso()
        {
            treino.Configuracao = new Configuracao();
            negocioTreino.ValidarConfiguracao(treino.Configuracao);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC21FA_Treinar_semColetarAssercoes_semSucesso()
        {
            treino.Assercoes = new List<bool>();
            negocioTreino.ValidarAssercoesColetadas(treino.Assercoes);
        }
    }
}