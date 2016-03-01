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

namespace Testes
{
    [TestFixture]
    public class UC02_AtualizarUsuario
    {
        private Usuario usuarioAlexandre;
        private IUsuarioDAO usuarioDAO;

        public UC02_AtualizarUsuario()
        {
            usuarioAlexandre = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "athens"
            };
            usuarioDAO = new UsuarioDAO();
        }

        [SetUp]
        public void SetUp()
        {
            if (usuarioDAO.Consultar(usuarioAlexandre) == null)
            {
                usuarioDAO.Cadastrar(usuarioAlexandre);
            }
            Login.RegistrarUsuario(usuarioDAO.Consultar(usuarioAlexandre));

            Usuario usuarioClaytonCreta = new Usuario()
            {
                Nome = "Clayton",
                Senha = "creta"
            };
            usuarioClaytonCreta = usuarioDAO.Consultar(usuarioClaytonCreta);
            if (usuarioClaytonCreta != null)
            {
                usuarioDAO.Excluir(usuarioClaytonCreta.Id);
            }

            Usuario usuarioClaytonAthens = new Usuario()
            {
                Nome = "Clayton",
                Senha = "athens"
            };
            usuarioClaytonAthens = usuarioDAO.Consultar(usuarioClaytonAthens);
            if (usuarioClaytonAthens != null)
            {
                usuarioDAO.Excluir(usuarioClaytonAthens.Id);
            }

            Usuario usuarioClaytonCretanova = new Usuario()
            {
                Nome = "Clayton",
                Senha = "cretanova"
            };
            usuarioClaytonCretanova = usuarioDAO.Consultar(usuarioClaytonCretanova);
            if (usuarioClaytonCretanova != null)
            {
                usuarioDAO.Excluir(usuarioClaytonCretanova.Id);
            }
        }

        [Test]
        public void CT01UC02FB_AtualizarUsuario_comNomeESenhaNova_comSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = "creta"
            };
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarNome(usuario.Nome);
            negocioUsuario.ValidarSenhaNova(usuario.Senha);
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
            resultado = Login.AtualizarLogin(usuario, resultado);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void CT02UC02FA_AtualizarUsuario_apenasNomeComSenhaNovaEmBranco_comSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = " "
            };
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarNome(usuario.Nome);
            negocioUsuario.ValidarSenhaNova(usuario.Senha);
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
            resultado = Login.AtualizarLogin(usuario, resultado);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void CT03UC02FA_AtualizarUsuario_apenasSenhaNova_comSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = "cretanova"
            };
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarNome(usuario.Nome);
            negocioUsuario.ValidarSenhaNova(usuario.Senha);
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
            resultado = Login.AtualizarLogin(usuario, resultado);

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
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT05UC02FA_AtualizarUsuario_comSenhaDeConfirmacaoEmBranco_semSucesso()
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
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
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarNome(usuario.Nome);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT07UC02FA_AtualizarUsuario_comSenhaNovaAcimaDe10Caracteres_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "danilodelphi"
            };
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarSenhaNova(usuario.Senha);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT08UC02FA_AtualizarUsuario_comSenhaDeConfirmacaoAcimaDe10Caracteres_semSucesso()
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarSenhaConfirmacao("danilodelphi");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT09UC02FA_AtualizarUsuario_comNomeNULL_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Clayton",
                Senha = ""
            };
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT10UC02FA_AtualizarUsuario_comSenhaNovaNULL_semSucesso()
        {
            Usuario usuario = new Usuario()
            {
                Nome = "Alexandre",
                Senha = "cretanull"
            };
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarSenhaNova(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT11UC02FA_AtualizarUsuario_comSenhaDeConfirmaçãoNULL_semSucesso()
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            negocioUsuario.ValidarSenhaConfirmacao(null);
        }
    }
}