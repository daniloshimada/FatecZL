using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Utilitarios;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;

namespace SistemaApoioEstudo.Teste.TestesTermo
{
    [TestFixture]
    public class UC15_AtualizarTermo
    {
        private NegocioTermo negocioTermo;
        private ITermoDAO termoDAO;
        private ICategoriaDAO categoriaDAO;
        private IAssuntoDAO assuntoDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Categoria categoriaProgramacao;
        private Termo termoInicial;

        public UC15_AtualizarTermo()
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

            //_Cadastra o termo "Cite uma linguagem de programação." para a categoria "Programação".
            Termo termoLinguagem = new Termo()
            {
                Nome = "Cite uma linguagem de programação.",
                Correspondencia = "Java.",
                Dica = ""
            };
            termoDAO.Cadastrar(categoriaProgramacao.Id, termoLinguagem);
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
        public void CT01UC14FB_Atualizar_termoComDadosValidos_comSucesso()
        {
            Termo termoValido = new Termo()
            {
                Id = termoInicial.Id,
                Nome = "Qual o significa de POO?",
                Correspondencia = termoInicial.Correspondencia,
                Dica = termoInicial.Dica
            };
            negocioTermo.ValidarNome(termoValido.Nome);
            negocioTermo.ValidarCorrespondencia(termoValido.Correspondencia);
            negocioTermo.ValidarDica(termoValido.Dica);
            bool resultado = termoDAO.Atualizar(termoValido);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC14FA_Atualizar_campoTermoEmBranco_semSucesso()
        {
            Termo termoTermoBranco = new Termo()
            {
                Id = termoInicial.Id,
                Nome = " ",
                Correspondencia = termoInicial.Correspondencia,
                Dica = termoInicial.Dica
            };
            negocioTermo.ValidarNome(termoTermoBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC14FA_Atualizar_campoCorrespondenciaEmBranco_semSucesso()
        {
            Termo termoCorrespondenciaBranco = new Termo()
            {
                Id = termoInicial.Id,
                Nome = termoInicial.Nome,
                Correspondencia = " ",
                Dica = termoInicial.Dica
            };
            negocioTermo.ValidarCorrespondencia(termoCorrespondenciaBranco.Correspondencia);
        }

        [Test]
        public void CT04UC14FB_Atualizar_campoDicaEmBranco_comSucesso()
        {
            Termo termoDicaBranco = new Termo()
            {
                Id = termoInicial.Id,
                Nome = termoInicial.Nome,
                Correspondencia = termoInicial.Correspondencia,
                Dica = " " 
            };
            negocioTermo.ValidarNome(termoDicaBranco.Nome);
            negocioTermo.ValidarCorrespondencia(termoDicaBranco.Correspondencia);
            negocioTermo.ValidarDica(termoDicaBranco.Dica);
            bool resultado = termoDAO.Atualizar(termoDicaBranco);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC14FA_Atualiar_campoTermoAcimaDe300Caracteres_semSucesso()
        {
            Termo termoTermoCaracteres = new Termo()
            {
                Id = termoInicial.Id,
                Nome = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo termo não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo termo não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro?",
                Correspondencia = termoInicial.Correspondencia,
                Dica = termoInicial.Dica
            };
            negocioTermo.ValidarNome(termoTermoCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC14FA_Atualizar_campoCorrespondenciaAcimaDe300Caracteres_semSucesso()
        {
            Termo termoCorrespondenciaBranco = new Termo()
            {
                Id = termoInicial.Id,
                Nome = termoInicial.Nome,
                Correspondencia = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo correspondência não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo correspondência não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro.",
                Dica = termoInicial.Dica
            };
            negocioTermo.ValidarCorrespondencia(termoCorrespondenciaBranco.Correspondencia);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT07UC14FA_Atualizar_campoDicaAcimaDe100Caracteres_semSucesso()
        {
            Termo termoDicaBranco = new Termo()
            {
                Id = termoInicial.Id,
                Nome = termoInicial.Nome,
                Correspondencia = termoInicial.Correspondencia,
                Dica = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo dica não deve conter acima de 100 caracteres."
            };
            negocioTermo.ValidarDica(termoDicaBranco.Dica);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT08UC14FA_Atualizar_campoTermoNULL_semSucesso()
        {
            Termo termoTermoNULL = new Termo()
            {
                Id = termoInicial.Id,
                Nome = "Qual o significado de POO?",
                Correspondencia = termoInicial.Correspondencia,
                Dica = termoInicial.Dica
            };
            negocioTermo.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT09UC14FA_Atualizar_campoCorrespondenciaNULL_semSucesso()
        {
            Termo termoCorrespondenciaNULL = new Termo()
            {
                Id = termoInicial.Id,
                Nome = termoInicial.Nome,
                Correspondencia = "Programação Orientada a Objetos",
                Dica = termoInicial.Dica
            };
            negocioTermo.ValidarCorrespondencia(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT10UC14FA_Atualizar_campoDicaNULL_semSucesso()
        {
            Termo termoDicaNULL = new Termo()
            {
                Id = termoInicial.Id,
                Nome = termoInicial.Nome,
                Correspondencia = termoInicial.Correspondencia,
                Dica = "sem dica"
            };
            negocioTermo.ValidarDica(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT11UC14FA_Atualizar_campoTermoJaExistente_semSucesso()
        {
            Termo termoExistente = new Termo()
            {
                Id = termoInicial.Id,
                Nome = "Cite uma linguagem de programação.",
                Correspondencia = termoInicial.Correspondencia,
                Dica = termoInicial.Dica
            };
            negocioTermo.ValidarNome(termoExistente.Nome);
            negocioTermo.ValidarCorrespondencia(termoExistente.Correspondencia);
            negocioTermo.ValidarDica(termoExistente.Dica);
            termoDAO.Atualizar(termoExistente);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT12UC14FA_Atualizar_termoSemConsulta_semSucesso()
        {
            negocioTermo.VerificarTermoSelecionado(new int());
        }
    }
}