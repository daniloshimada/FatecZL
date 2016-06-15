using SistemaApoioEstudo.BLL.Entidades;
using System.Collections.Generic;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public interface IHistoricoDAO
    {
        int Cadastrar(Historico historico);
        List<Historico> Consultar(int idCategoria);
        List<Historico> ConsultarTermos(int idHistorico);
        bool Excluir(int idHistorico);
    }
}