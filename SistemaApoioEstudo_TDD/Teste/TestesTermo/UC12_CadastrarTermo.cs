using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Negocio;

namespace SistemaApoioEstudo.Teste.TestesTermo
{
    [TestFixture]
    public class UC12_CadastrarTermo
    {
        private NegocioTermo negocioTermo;
        private ITermoDAO termoDAO;
        private IAssuntoDAO assuntoDAO;
        private ICategoriaDAO categoriaDAO;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Categoria categoriaProgramacao;

        public UC12_CadastrarTermo()
        {
            negocioTermo = new NegocioTermo();
            termoDAO = new TermoDAO();
            assuntoDAO = new AssuntoDAO();
            categoriaDAO = new CategoriaDAO();
            usuarioDAO = new UsuarioDAO();
            usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            categoriaProgramacao = new Categoria()
            {
                Nome = "Programação"
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

            //_Cadastra a categoria "Programação" para o assunto "Faculdade".
            categoriaDAO.Cadastrar(assuntoFaculdade.Id, categoriaProgramacao);
            //_Consulta o id da categoria "Programação".
            categoriaProgramacao = categoriaDAO.ConsultarNomeIdAssunto(categoriaProgramacao.Nome, assuntoFaculdade.Id);
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
        public void CT01UC12FB_Cadastrar_termoComDadosValidos_comSucesso()
        {
            Termo termoValido = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            negocioTermo.ValidarNome(termoValido.Nome);
            negocioTermo.ValidarCorrespondencia(termoValido.Correspondencia);
            negocioTermo.ValidarDica(termoValido.Dica);
            bool resultado = termoDAO.Cadastrar(categoriaProgramacao.Id, termoValido);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC12FA_Cadastrar_campoTermoEmBranco_semSucesso()
        {
            Termo termoTermoBranco = new Termo()
            {
                Nome = " ",
                Correspondencia = "",
                Dica = ""
            };
            negocioTermo.ValidarNome(termoTermoBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT03UC12FA_Cadastrar_campoCorrespondenciaEmBranco_semSucesso()
        {
            Termo termoCorrespondenciaBranco = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = " ",
                Dica = ""
            };
            negocioTermo.ValidarCorrespondencia(termoCorrespondenciaBranco.Correspondencia);
        }

        [Test]
        public void CT04UC12FB_Cadastrar_campoDicaEmBranco_comSucesso()
        {
            Termo termoDicaBranco = new Termo()
            {
                Nome = "Qual o significado de POO?",
                Correspondencia = "Programação Orientada a Objetos",
                Dica = " "
            };
            negocioTermo.ValidarNome(termoDicaBranco.Nome);
            negocioTermo.ValidarCorrespondencia(termoDicaBranco.Correspondencia);
            negocioTermo.ValidarDica(termoDicaBranco.Dica);
            bool resultado = termoDAO.Cadastrar(categoriaProgramacao.Id, termoDicaBranco);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC12FA_Cadastrar_campoTermoAcimaDe300Caracteres_semSucesso()
        {
            Termo termoTermoCaracteres = new Termo()
            {
                Nome = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo termo não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo termo não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro?",
                Correspondencia = "",
                Dica = ""
            };
            negocioTermo.ValidarNome(termoTermoCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC12FA_Cadastrar_campoCorrespondenciaAcimaDe300Caracteres_semSucesso()
        {
            Termo termoCorrespondenciaCaracteres = new Termo()
            {
                Nome = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo termo não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo termo não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro?",
                Correspondencia = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo correspondência não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo correspondência não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro.",
                Dica = ""
            };
            negocioTermo.ValidarCorrespondencia(termoCorrespondenciaCaracteres.Correspondencia);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT07UC12FA_Cadastrar_campoDicaAcimaDe100Caracteres_semSucesso()
        {
            Termo termoDicaCaracteres = new Termo()
            {
                Nome = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo termo não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo termo não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro?",
                Correspondencia = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo correspondência não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo correspondência não deve conter acima de 300 caracteres."
                    + " O sistema valida as informações e envia uma mensagem de erro.",
                Dica = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo dica não deve conter acima de 100 caracteres."
            };
            negocioTermo.ValidarDica(termoDicaCaracteres.Dica);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT08UC12FA_Cadastrar_campoTermoNULL_semSucesso()
        {
            Termo termoTermoNULL = new Termo()
            {
                Nome = "Qual o significado de IDE?”, ",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            negocioTermo.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT09UC12FA_Cadastrar_campoCorrespondenciaNULL_semSucesso()
        {
            Termo termoCorrespondenciaNULL = new Termo()
            {
                Nome = "Qual o significado de IDE?”, ",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            negocioTermo.ValidarCorrespondencia(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT10UC12FA_Cadastrar_campoDicaNULL_semSucesso()
        {
            Termo termoDicaNULL = new Termo()
            {
                Nome = "Qual o significado de IDE?”, ",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = "acrônimo"
            };
            negocioTermo.ValidarDica(null);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT11UC12FA_Cadastrar_termoJaExistente_semSucesso()
        {
            Termo termoExistente = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            termoDAO.Cadastrar(categoriaProgramacao.Id, termoExistente);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT12UC12FA_Cadastrar_termoSemCategoria_semSucesso()
        {
            Termo termoSemCategoria = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            termoDAO.Cadastrar(new int(), termoSemCategoria);
        }
    }
}