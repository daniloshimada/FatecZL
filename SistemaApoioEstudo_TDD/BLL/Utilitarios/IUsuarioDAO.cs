﻿using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public interface IUsuarioDAO
    {
        bool Cadastrar(Usuario usuario);
        Usuario Consultar(Usuario usuario);
        Usuario ConsultarNome(string nomeUsuario);
        Usuario ConsultarDados(int idUsuario);
        bool Atualizar(Usuario usuario);
        bool AtualizarNome(Usuario usuario);
        bool Excluir(int idUsuario);
    }
}