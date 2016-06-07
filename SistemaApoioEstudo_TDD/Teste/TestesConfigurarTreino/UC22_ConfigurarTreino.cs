using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;
using System.Collections.Generic;

namespace SistemaApoioEstudo.Teste.TestesConfigurarTreino
{
    [TestFixture]
    public class UC22_ConfigurarTreino
    {
        private Usuario usuarioInicial;
        private Configuracao configuracao;
        private NegocioConfiguracao negocioConfiguracao;
        private IUsuarioDAO usuarioDAO;

        public UC22_ConfigurarTreino()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            configuracao = new Configuracao();
            negocioConfiguracao = new NegocioConfiguracao();
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

            configuracao.Assunto = assuntoInicial;
            configuracao.Categoria = categoriaInicial;
            configuracao.Termos = termoDAO.ConsultarDadosIdCategoria(categoriaInicial.Id);
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
        public void CT01UC22FB_Configurar_treinoComDadosValidos_comSucesso()
        {
            negocioConfiguracao.ValidarAssunto(configuracao.Assunto);
            negocioConfiguracao.ValidarCategoria(configuracao.Categoria);
            negocioConfiguracao.ValidarTermos(configuracao.Termos);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT02UC22FA_Configurar_treinoSemAssunto_semSucesso()
        {
            negocioConfiguracao.ValidarAssunto(new Assunto());
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT03UC22FA_Configurar_treinoSemCategoria_semSucesso()
        {
            negocioConfiguracao.ValidarCategoria(new Categoria());
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT04UC22FA_Configurar_treinoSemTermo_semSucesso()
        {
            negocioConfiguracao.ValidarTermos(new List<Termo>());
        }
    }
}