using SistemaApoioEstudo.BLL.Entidades;
using System.Collections.Generic;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public interface ITermoDAO
    {
        bool Cadastrar(int idCategoria, Termo termo);
        List<Termo> ConsultarDadosIdCategoria(int idCategoria);
        Termo ConsultarNomeIdCategoria(string nomeTermo, int IdCategoria);
        int ConsultarQuantidade(int idCategoria);
        List<Termo> ConsultarRandomico(int idCategoria);
        bool Atualizar(Termo termo);
        bool Excluir(int idTermo);
    }
}