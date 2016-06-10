using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

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