﻿using System;
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
    public class UC04_AtualizarUsuario
    {
        private NegocioUsuario negocioUsuario;
        private NegocioLogin negocioLogin;
        private IUsuarioDAO usuarioDAO;
        private Usuario usuarioAlexandre;
        private Usuario usuarioDanilo;

        public UC04_AtualizarUsuario()
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
            //_Exclui o usuário com nome "Alexandre" e senha "athens".
            usuarioAlexandre = usuarioDAO.ConsultarNome(usuarioAlexandre.Nome);
            if (usuarioAlexandre != null)
            {
                usuarioDAO.Excluir(usuarioAlexandre.Id);
            }

            //_Exclui o usuário com nome "Danilo" e senha "delphi".
            usuarioDanilo = usuarioDAO.ConsultarNome(usuarioDanilo.Nome);
            if (usuarioDanilo != null)
            {
                usuarioDAO.Excluir(usuarioDanilo.Id);
            }
        }

        [Test]
        public void CT01UC04FB_Atualizar_comNomeESenha_comSucesso()
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
                //_Atualiza o nome e a senha.
                resultado = usuarioDAO.Atualizar(usuario);
            }
            else
            {
                //_Atualiza apenas o nome.
                resultado = usuarioDAO.AtualizarNome(usuario);
                usuario.Senha = "athens";
            }
            resultado = negocioLogin.AtualizarLogin(usuario, resultado);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void CT02UC04FA_Atualizar_apenasNomeComSenhaEmBranco_comSucesso()
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
                usuario.Senha = "athens";
            }
            resultado = negocioLogin.AtualizarLogin(usuario, resultado);
            Assert.IsTrue(resultado);
        }

        [Test]
        public void CT03UC04FA_Atualizar_apenasSenha_comSucesso()
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
                usuario.Senha = "athens";
            }
            resultado = negocioLogin.AtualizarLogin(usuario, resultado);
            Assert.IsTrue(resultado);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT04UC04FA_Atualizar_comNomeEmBranco_semSucesso()
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
        public void CT05UC04FA_Atualizar_comSenhaDeConfirmacaoEmBranco_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(" ");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT06UC04FA_Atualizar_comNomeAcimaDe15Caracteres_semSucesso()
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
        public void CT07UC04FA_Atualizar_comSenhaAcimaDe10Caracteres_semSucesso()
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
        public void CT08UC04FA_Atualizar_comSenhaDeConfirmacaoAcimaDe10Caracteres_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("danilodelphi");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT09UC04FA_Atualizar_comNomeNULL_semSucesso()
        {
            negocioUsuario.ValidarNome(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT10UC04FA_Atualizar_comSenhaNULL_semSucesso()
        {
            negocioUsuario.ValidarSenhaNova(null);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void CT11UC04FA_Atualizar_comSenhaDeConfirmacaoNULL_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CT12UC04FA_Atualizar_comSenhaDeConfirmacaoIncorreta_semSucesso()
        {
            negocioUsuario.ValidarSenhaConfirmacao("delphi");
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CT13UC04FA_Atualizar_comNomeJaExistente_semSucesso()
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