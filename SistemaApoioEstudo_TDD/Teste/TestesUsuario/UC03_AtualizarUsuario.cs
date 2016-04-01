using NUnit.Framework;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using System;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC03_AtualizarUsuario
    {
        private Usuario usuarioInicial;
        private Usuario usuarioSecundario;
        private NegocioUsuario negocioUsuario;
        private NegocioLogin negocioLogin;
        private IUsuarioDAO usuarioDAO;

        public UC03_AtualizarUsuario()
        {
            negocioUsuario = new NegocioUsuario();
            negocioLogin = new NegocioLogin();
            usuarioDAO = new UsuarioDAO();
            usuarioInicial = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            usuarioSecundario = new Usuario()
            {
                Nome = "Sônia",
                Senha = "son"
            };
        }

        [SetUp]
        public void SetUp()
        {
            //_Exclui, Cadastra e Loga o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioInicialRetorno = usuarioDAO.ConsultarNome(usuarioInicial.Nome);
            if (usuarioInicialRetorno != null)
            {
                usuarioDAO.Excluir(usuarioInicialRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioInicial);
            Login.RegistrarUsuario(usuarioDAO.ConsultarNome(usuarioInicial.Nome));

            //_Cadastra o usuário com nome "Sonia" e senha "son".
            Usuario usuarioSecundarioRetorno = usuarioDAO.ConsultarNome(usuarioSecundario.Nome);
            if (usuarioSecundarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioSecundarioRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioSecundario);

            //_Exclui o usuário com nome "Danilo".
            Usuario usuarioDaniloRetorno = usuarioDAO.ConsultarNome("Danilo");
            if (usuarioDaniloRetorno != null)
            {
                usuarioDAO.Excluir(usuarioDaniloRetorno.Id);
            }
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

            //_Exclui o usuário com nome "Sônia".
            usuarioSecundario = usuarioDAO.ConsultarNome(usuarioSecundario.Nome);
            if (usuarioSecundario != null)
            {
                usuarioDAO.Excluir(usuarioSecundario.Id);
            }
        }

        [Test]
        public void CT01UC03FB_Atualizar_usuarioComNomeESenha_comSucesso()
        {
            Usuario usuarioNomeSenha = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Danilo",
                Senha = "delphi"
            };
            negocioUsuario.ValidarNome(usuarioNomeSenha.Nome);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            bool resultado = negocioUsuario.ValidarSenhaNova(usuarioNomeSenha.Senha);
            if (resultado)
            {
                //_Atualiza o nome e a senha.
                resultado = usuarioDAO.Atualizar(usuarioNomeSenha);
            }
            else
            {
                //_Atualiza apenas o nome.
                resultado = usuarioDAO.AtualizarNome(usuarioNomeSenha);
                usuarioNomeSenha.Senha = "athens";
            }
            resultado = negocioLogin.AtualizarLogin(usuarioNomeSenha, resultado);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void CT02UC03FB_Atualizar_usuarioApenasComNome_comSucesso()
        {
            Usuario usuarioSenhaBranco = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Danilo",
                Senha = " "
            };
            negocioUsuario.ValidarNome(usuarioSenhaBranco.Nome);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            bool resultado = negocioUsuario.ValidarSenhaNova(usuarioSenhaBranco.Senha);
            if (resultado)
            {
                resultado = usuarioDAO.Atualizar(usuarioSenhaBranco);
            }
            else
            {
                resultado = usuarioDAO.AtualizarNome(usuarioSenhaBranco);
                usuarioSenhaBranco.Senha = "athens";
            }
            resultado = negocioLogin.AtualizarLogin(usuarioSenhaBranco, resultado);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void CT03UC03FB_Atualizar_usuarioApenasComSenha_comSucesso()
        {
            Usuario usuarioSenha = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Alexandre",
                Senha = "cretanova"
            };
            negocioUsuario.ValidarNome(usuarioSenha.Nome);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            bool resultado = negocioUsuario.ValidarSenhaNova(usuarioSenha.Senha);
            if (resultado)
            {
                resultado = usuarioDAO.Atualizar(usuarioSenha);
            }
            else
            {
                resultado = usuarioDAO.AtualizarNome(usuarioSenha);
                usuarioSenha.Senha = "athens";
            }
            resultado = negocioLogin.AtualizarLogin(usuarioSenha, resultado);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT04UC03FA_Atualizar_usuarioComNomeEmBranco_semSucesso()
        {
            Usuario usuarioNomeBranco = new Usuario()
            {
                Nome = " ",
                Senha = ""
            };
            negocioUsuario.ValidarNome(usuarioNomeBranco.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC03FA_Atualizar_usuarioComSenhaDeConfirmacaoEmBranco_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(" ");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC03FA_Atualizar_usuarioComNomeAcimaDe15Caracteres_semSucesso()
        {
            Usuario usuarioNomeCaracteres = new Usuario()
            {
                Nome = "Alexandreshigueru",
                Senha = ""
            };
            negocioUsuario.ValidarNome(usuarioNomeCaracteres.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT07UC03FA_Atualizar_usuarioComSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuarioSenhaCaracteres = new Usuario()
            {
                Nome = Login.Usuario.Nome,
                Senha = "danilodelphi"
            };
            negocioUsuario.ValidarSenhaNova(usuarioSenhaCaracteres.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT08UC03FA_Atualizar_usuarioComSenhaDeConfirmacaoAcimaDe10Caracteres_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("danilodelphi");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT09UC03FA_Atualizar_usuarioComNomeNulo_semSucesso()
        {
            Usuario usuarioNomeNulo = new Usuario()
            {
                Nome = "Danilo",
                Senha = ""
            };
            negocioUsuario.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT10UC03FA_Atualizar_usuarioComSenhaNula_semSucesso()
        {
            Usuario usuarioSenhaNula = new Usuario()
            {
                Nome = Login.Usuario.Nome,
                Senha = "delphinull"
            };
            negocioUsuario.ValidarSenhaNova(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT11UC03FA_Atualizar_usuarioComSenhaDeConfirmacaoNula_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT12UC03FA_Atualizar_usuarioComSenhaDeConfirmacaoIncorreta_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("delphi");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT13UC03FA_Atualizar_usuarioComNomeJaExistente_semSucesso()
        {
            Usuario usuarioNomeExistente = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Sônia",
                Senha = ""
            };
            negocioUsuario.ValidarNome(usuarioNomeExistente.Nome);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            bool resultado = negocioUsuario.ValidarSenhaNova(usuarioNomeExistente.Senha);
            if (resultado)
            {
                resultado = usuarioDAO.Atualizar(usuarioNomeExistente);
            }
            else
            {
                resultado = usuarioDAO.AtualizarNome(usuarioNomeExistente);
            }
        }
    }
}