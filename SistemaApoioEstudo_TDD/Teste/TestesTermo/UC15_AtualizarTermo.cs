using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesTermo
{
    [TestFixture]
    public class UC15_AtualizarTermo
    {
        private Usuario usuarioInicial;
        private Termo termoInicial;
        private NegocioTermo negocioTermo;
        private IUsuarioDAO usuarioDAO;
        private ITermoDAO termoDAO;

        public UC15_AtualizarTermo()
        {
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            termoInicial = new Termo()
            {
                Nome = "Qual o significado de IDE?",
                Correspondencia = "Ambiente de Desenvolvimento Integrado",
                Dica = ""
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
            Assunto assuntoFaculdade = new Assunto()
            {
                Nome = "Faculdade"
            };
            IAssuntoDAO assuntoDAO = new AssuntoDAO();
            assuntoDAO.Cadastrar(Login.Usuario.Id, assuntoFaculdade);
            //_Consulta o id do assunto "Faculdade".
            assuntoFaculdade = assuntoDAO.ConsultarNomeIdUsuario(assuntoFaculdade.Nome, Login.Usuario.Id);

            //_Cadastra a categoria "Programacao" para o assunto "Faculdade".
            Categoria categoriaInicial = new Categoria()
            {
                Nome = "Programacao"
            };
            ICategoriaDAO categoriaDAO = new CategoriaDAO();
            categoriaDAO.Cadastrar(assuntoFaculdade.Id, categoriaInicial);
            //_Consulta o id da categoria "Programação".
            categoriaInicial = categoriaDAO.ConsultarNomeIdAssunto(categoriaInicial.Nome, assuntoFaculdade.Id);

            //_Cadastra o termo "Qual o significado de IDE?" para a categoria "Programação".
            termoDAO.Cadastrar(categoriaInicial.Id, termoInicial);
            //_Consulta o id do termo "Qual o significado de IDE?".
            termoInicial = termoDAO.ConsultarNomeIdCategoria(termoInicial.Nome, categoriaInicial.Id);

            //_Cadastra o termo "Cite uma linguagem de programação." para a categoria "Programação".
            Termo termoSecundaria = new Termo()
            {
                Nome = "Cite uma linguagem de programação.",
                Correspondencia = "Java.",
                Dica = ""
            };
            termoDAO.Cadastrar(categoriaInicial.Id, termoSecundaria);
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
        public void CT01UC15FB_Atualizar_termoComDadosValidos_comSucesso()
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
            Assert.IsTrue(termoDAO.Atualizar(termoValido));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT02UC15FA_Atualizar_termoEmBranco_semSucesso()
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
        public void CT03UC15FA_Atualizar_termoComCorrespondenciaEmBranco_semSucesso()
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
        public void CT04UC15FB_Atualizar_termoComDicaEmBranco_comSucesso()
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
            Assert.IsTrue(termoDAO.Atualizar(termoDicaBranco));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC15FA_Atualiar_termoAcimaDe300Caracteres_semSucesso()
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
        public void CT06UC15FA_Atualizar_termoComCorrespondenciaAcimaDe300Caracteres_semSucesso()
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
        public void CT07UC15FA_Atualizar_termoComDicaAcimaDe100Caracteres_semSucesso()
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
        public void CT08UC15FA_Atualizar_termoNulo_semSucesso()
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
        public void CT09UC15FA_Atualizar_termoComCorrespondenciaNula_semSucesso()
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
        public void CT10UC15FA_Atualizar_termoComDicaNula_semSucesso()
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
        public void CT11UC15FA_Atualizar_termoJaExistente_semSucesso()
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
        public void CT12UC15FA_Atualizar_termoSemConsulta_semSucesso()
        {
            negocioTermo.VerificarTermoSelecionado(new int());
        }
    }
}