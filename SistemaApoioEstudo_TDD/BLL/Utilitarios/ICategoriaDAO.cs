using SistemaApoioEstudo.BLL.Entidades;
using System.Collections.Generic;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public interface ICategoriaDAO
    {
        bool Cadastrar(int idAssunto, Categoria categoria);
        List<Categoria> ConsultarDadosIdAssunto(int idAssunto);
        Categoria ConsultarNomeIdAssunto(string nomeCategoria, int idAssunto);
        bool Atualizar(Categoria categoria);
        bool Excluir(int idCategoria);
    }
}