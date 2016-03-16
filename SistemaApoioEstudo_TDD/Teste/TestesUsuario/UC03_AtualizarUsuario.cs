using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.DAO;

namespace SistemaApoioEstudo.Teste.TestesUsuario
{
    [TestFixture]
    public class UC03_AtualizarUsuario
    {
        private NegocioUsuario negocioUsuario;
        private NegocioLogin negocioLogin;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Usuario usuarioDanilo;

        public UC03_AtualizarUsuario()
        {
            negocioUsuario = new NegocioUsuario();
            negocioLogin = new NegocioLogin();
            usuarioDAO = new UsuarioDAO();
            usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            usuarioDanilo = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
        }

        [SetUp]
        public void SetUp()
        {
            //_Exclui, Cadastra e Loga o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioAlexandre);
            Login.RegistrarUsuario(usuarioDAO.ConsultarNome(usuarioAlexandre.Nome));

            //_Exclui o usuário com nome "Clayton".
            Usuario usuarioClayton = usuarioDAO.ConsultarNome("Clayton");
            if (usuarioClayton != null)
            {
                usuarioDAO.Excluir(usuarioClayton.Id);
            }

            //_Cadastra o usuário com nome "Danilo" e senha "delphi".
            Usuario usuarioDaniloRetorno = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioDaniloRetorno != null)
            {
                usuarioDAO.Excluir(usuarioDaniloRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioDanilo);
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

            //_Exclui o usuário com nome "Danilo".
            usuarioDanilo = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioDanilo != null)
            {
                usuarioDAO.Excluir(usuarioDanilo.Id);
            }
        }

        [Test]
        public void CT01UC03FB_Atualizar_comNomeESenha_comSucesso()
        {
            Usuario usuarioNomeSenha = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Clayton",
                Senha = "creta"
            };
            negocioUsuario.ValidarNome(usuarioNomeSenha.Nome);
            bool resultado = negocioUsuario.ValidarSenhaNova(usuarioNomeSenha.Senha);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
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
        public void CT02UC03FA_Atualizar_apenasNomeComSenhaEmBranco_comSucesso()
        {
            Usuario usuarioSenhaBranco = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Clayton",
                Senha = " "
            };
            negocioUsuario.ValidarNome(usuarioSenhaBranco.Nome);
            bool resultado = negocioUsuario.ValidarSenhaNova(usuarioSenhaBranco.Senha);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
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
        public void CT03UC03FA_Atualizar_apenasSenha_comSucesso()
        {
            Usuario usuarioSenha = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Alexandre",
                Senha = "cretanova"
            };
            negocioUsuario.ValidarNome(usuarioSenha.Nome);
            bool resultado = negocioUsuario.ValidarSenhaNova(usuarioSenha.Senha);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
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
        public void CT04UC03FA_Atualizar_comNomeEmBranco_semSucesso()
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
        public void CT05UC03FA_Atualizar_comSenhaDeConfirmacaoEmBranco_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(" ");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC03FA_Atualizar_comNomeAcimaDe15Caracteres_semSucesso()
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
        public void CT07UC03FA_Atualizar_comSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuarioSenhaCaracteres = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "danilodelphi"
            };
            negocioUsuario.ValidarSenhaNova(usuarioSenhaCaracteres.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT08UC03FA_Atualizar_comSenhaDeConfirmacaoAcimaDe10Caracteres_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("danilodelphi");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT09UC03FA_Atualizar_comNomeNULL_semSucesso()
        {
            Usuario usuarioNomeNULL = new Usuario()
            {
                Nome = "Clayton",
                Senha = ""
            };
            negocioUsuario.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT10UC03FA_Atualizar_comSenhaNULL_semSucesso()
        {
            Usuario usuarioSenhaCaracteres = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "cretanull"
            };
            negocioUsuario.ValidarSenhaNova(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT11UC03FA_Atualizar_comSenhaDeConfirmacaoNULL_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT12UC03FA_Atualizar_comSenhaDeConfirmacaoIncorreta_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("delphi");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT13UC03FA_Atualizar_comNomeJaExistente_semSucesso()
        {
            Usuario usuarioNomeExistente = new Usuario()
            {
                Id = Login.Usuario.Id,
                Nome = "Danilo",
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