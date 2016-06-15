using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleHistorico
    {
        private NegocioHistorico negocioHistorico;
        private IHistoricoDAO historicoDAO;

        public ControleHistorico()
        {
            negocioHistorico = new NegocioHistorico();
            historicoDAO = new HistoricoDAO();
        }

        public string GerarRelatorio(Historico historico)
        {
            try
            {
                return negocioHistorico.GerarRelatorio(historico);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Historico historico)
        {
            try
            {
                historicoDAO.Cadastrar(historico);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Historico> Consultar(int idCategoria)
        {
            try
            {
                return historicoDAO.Consultar(idCategoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Historico> ConsultarTermos(int idHistorico)
        {
            try
            {
                return historicoDAO.ConsultarTermos(idHistorico);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(int idHistorico)
        {
            try
            {
                return historicoDAO.Excluir(idHistorico);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}