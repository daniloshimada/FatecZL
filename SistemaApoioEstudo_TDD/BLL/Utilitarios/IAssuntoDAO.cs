using SistemaApoioEstudo.BLL.Entidades;
using System.Collections.Generic;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public interface IAssuntoDAO
    {
        bool Cadastrar(int idUsuario, Assunto assunto);
        List<Assunto> ConsultarDadosIdUsuario(int idUsuario);
        Assunto ConsultarNomeIdUsuario(string nomeAssunto, int idUsuario);
        bool Atualizar(Assunto assunto);
        bool Excluir(int idAssunto);
    }
}