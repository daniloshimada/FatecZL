using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesTermo
{
    [TestFixture]
    public class UC13_CadastrarTermo
    {
        private Usuario usuarioInicial;
        private Categoria categoriaInicial;
        private NegocioTermo negocioTermo;
        private IUsuarioDAO usuarioDAO;
        private ITermoDAO termoDAO;

        public UC13_CadastrarTermo()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            categoriaInicial = new Categoria()
            {
                Nome = "Programação"
            };
            negocioTermo = new NegocioTermo();
            usuarioDAO = new UsuarioDAO();
            termoDAO = new TermoDAO();
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //_Exclui, Cadastra e Loga o usuário "Alexandre" com senha "athens".
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
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

            //_Cadastra a categoria "Programação" para o assunto "Faculdade".
            ICategoriaDAO categoriaDAO = new CategoriaDAO();
            categoriaDAO.Cadastrar(assuntoInicial.Id, categoriaInicial);
            //_Consulta o id da categoria "Programação".
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
        public void CT01UC13FB_Cadastrar_termoComDadosValidos_comSucesso()
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
            Assert.IsTrue(termoDAO.Cadastrar(categoriaInicial.Id, termoValido));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC13FA_Cadastrar_termoEmBranco_semSucesso()
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
        public void CT03UC13FA_Cadastrar_termoComCorrespondenciaEmBranco_semSucesso()
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
        public void CT04UC13FB_Cadastrar_termoComDicaEmBranco_comSucesso()
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
            Assert.IsTrue(termoDAO.Cadastrar(categoriaInicial.Id, termoDicaBranco));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC13FA_Cadastrar_termoAcimaDe300Caracteres_semSucesso()
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
        public void CT06UC13FA_Cadastrar_termoComCorrespondenciaAcimaDe300Caracteres_semSucesso()
        {
            Termo termoCorrespondenciaCaracteres = new Termo()
            {
                Nome = "Correspondência acima de 300 caracteres.",
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
        public void CT07UC13FA_Cadastrar_termoComDicaAcimaDe100Caracteres_semSucesso()
        {
            Termo termoDicaCaracteres = new Termo()
            {
                Nome = "Dica acima de 100 caracteres.",
                Correspondencia = "Não deve aceitar.",
                Dica = "O sistema valida as informações e envia uma mensagem de erro,"
                    + " informando que o campo dica não deve conter acima de 100 caracteres."
            };
            negocioTermo.ValidarDica(termoDicaCaracteres.Dica);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT08UC13FA_Cadastrar_termoNulo_semSucesso()
        {
            Termo termoTermoNULL = new Termo()
            {
                Nome = "Qual o significado de IDE?”, ",
                Correspondencia = "",
                Dica = ""
            };
            negocioTermo.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT09UC13FA_Cadastrar_termoComCorrespondenciaNula_semSucesso()
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
        public void CT10UC13FA_Cadastrar_termoComDicaNula_semSucesso()
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
        public void CT11UC13FA_Cadastrar_termoJaExistente_semSucesso()
        {
            Termo termoExistente = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
            };
            termoDAO.Cadastrar(categoriaInicial.Id, termoExistente);
        }
    }
}