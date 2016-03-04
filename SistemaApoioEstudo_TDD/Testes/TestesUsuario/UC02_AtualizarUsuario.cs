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
    public class UC02_AtualizarUsuario
    {
        private NegocioUsuario negocioUsuario;
        private NegocioLogin negocioLogin;
        private IUsuarioDAO usuarioDAO;

        public UC02_AtualizarUsuario()
        {
            negocioUsuario = new NegocioUsuario();
            negocioLogin = new NegocioLogin();
            usuarioDAO = new UsuarioDAO();
        }

        [SetUp]
        public void SetUp()
        {
            //_(CT01-CT13) Cadastra e loga o usuário com nome "Alexandre" e senha "athens".
            Usuario usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }
            usuarioDAO.Cadastrar(usuarioAlexandre);
            Login.RegistrarUsuario(usuarioDAO.ConsultarNome(usuarioAlexandre.Nome));

            //_(CT01-CT02) Exclui o usuário com nome "Clayton".
            Usuario usuarioClayton = usuarioDAO.ConsultarNome("Clayton");
            if (usuarioClayton != null)
            {
                usuarioDAO.Excluir(usuarioClayton.Id);
            }

            //_(CT13) Cadastra o usuário com nome "Danilo" e senha "delphi".
            Usuario usuarioDanilo = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
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
            Usuario usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            Usuario usuarioRetorno = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioRetorno != null)
            {
                usuarioDAO.Excluir(usuarioRetorno.Id);
            }

            Usuario usuarioDanilo = new Usuario()
            {
                Nome = "Danilo",
                Senha = "delphi"
            };
            Usuario usuarioDaniloRetorno = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioDaniloRetorno != null)
            {
                usuarioDAO.Excluir(usuarioDaniloRetorno.Id);
            }
        }

        [Test]
        public void CT01UC02FB_AtualizarUsuario_comNomeESenha_comSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = "creta"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
            bool resultado = negocioUsuario.ValidarSenhaNova(usuario.Senha);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            usuario.Id = Login.Usuario.Id;
            if (resultado)
            {
                resultado = usuarioDAO.Atualizar(usuario);
            }
            else
            {
                resultado = usuarioDAO.AtualizarNome(usuario);
            }
            resultado = negocioLogin.AtualizarLogin(usuario, resultado);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void CT02UC02FA_AtualizarUsuario_apenasNomeComSenhaEmBranco_comSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = " "
            };
            negocioUsuario.ValidarNome(usuario.Nome);
            bool resultado = negocioUsuario.ValidarSenhaNova(usuario.Senha);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            usuario.Id = Login.Usuario.Id;
            if (resultado)
            {
                resultado = usuarioDAO.Atualizar(usuario);
            }
            else
            {
                resultado = usuarioDAO.AtualizarNome(usuario);
            }
            resultado = negocioLogin.AtualizarLogin(usuario, resultado);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void CT03UC02FA_AtualizarUsuario_apenasSenha_comSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "cretanova"
            };
            negocioUsuario.ValidarNome(usuario.Nome);
            bool resultado = negocioUsuario.ValidarSenhaNova(usuario.Senha);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            usuario.Id = Login.Usuario.Id;
            if (resultado)
            {
                resultado = usuarioDAO.Atualizar(usuario);
            }
            else
            {
                resultado = usuarioDAO.AtualizarNome(usuario);
            }
            resultado = negocioLogin.AtualizarLogin(usuario, resultado);

            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT04UC02FA_AtualizarUsuario_comNomeEmBranco_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = " ",
                Senha = ""
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC02FA_AtualizarUsuario_comSenhaDeConfirmacaoEmBranco_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(" ");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC02FA_AtualizarUsuario_comNomeAcimaDe15Caracteres_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandreshigueru",
                Senha = ""
            };
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT07UC02FA_AtualizarUsuario_comSenhaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "danilodelphi"
            };
            negocioUsuario.ValidarSenhaNova(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT08UC02FA_AtualizarUsuario_comSenhaDeConfirmacaoAcimaDe10Caracteres_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("danilodelphi");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT09UC02FA_AtualizarUsuario_comNomeNULL_semSucesso()
        {
            negocioUsuario.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT10UC02FA_AtualizarUsuario_comSenhaNULL_semSucesso()
        {
            negocioUsuario.ValidarSenhaNova(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT11UC02FA_AtualizarUsuario_comSenhaDeConfirmacaoNULL_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT12UC02FA_AtualizarUsuario_comSenhaDeConfirmacaoIncorreta_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("delphi");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT13UC02FA_AtualizarUsuaro_comNomeJaExistente_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Danilo",
                Senha = ""
            };
            negocioUsuario.ValidarNome(usuario.Nome);
            negocioUsuario.ValidarSenhaConfirmacao("athens");
            usuario.Id = Login.Usuario.Id;
            bool resultado = negocioUsuario.ValidarSenhaNova(usuario.Senha);
            if (resultado)
            {
                resultado = usuarioDAO.Atualizar(usuario);
            }
            else
            {
                resultado = usuarioDAO.AtualizarNome(usuario);
            }
        }
    }
}