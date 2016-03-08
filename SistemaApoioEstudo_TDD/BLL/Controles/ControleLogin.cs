﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;
using SistemaApoioEstudo.BLL.Negocio;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleLogin
    {
        public bool Logar(Usuario usuarioLogin)
        {
            try
            {
                IUsuarioDAO usuarioDAO = new UsuarioDAO();   
                Usuario usuarioRetorno = usuarioDAO.Consultar(usuarioLogin);
                Usuario[] usuarios = new Usuario[] { usuarioLogin, usuarioRetorno };
                NegocioUsuario negocioUsuario = new NegocioUsuario();
                negocioUsuario.ValidarNome(usuarioLogin.Nome);
                negocioUsuario.ValidarSenha(usuarioLogin.Senha);
                NegocioLogin negocioLogin = new NegocioLogin();
                bool resultado = negocioLogin.ValidarDados(usuarios);
                if (resultado)
                {
                    Login.RegistrarUsuario(usuarioRetorno);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}