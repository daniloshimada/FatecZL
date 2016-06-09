using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleHistorico
    {
        private NegocioHistorico negocioHistorico;

        public ControleHistorico()
        {
            negocioHistorico = new NegocioHistorico();
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
    }
}