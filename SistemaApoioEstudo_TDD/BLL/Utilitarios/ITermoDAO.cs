using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public interface ITermoDAO
    {
        bool Cadastrar(int idCategoria, Termo termo);
        List<Termo> ConsultarDadosIdCategoria(int idCategoria);
        Termo ConsultarNomeIdCategoria(string nomeTermo, int IdCategoria);
        int ConsultarQuantidade(int idCategoria);
        bool Atualizar(Termo termo);
        bool Excluir(int idTermo);
    }
}