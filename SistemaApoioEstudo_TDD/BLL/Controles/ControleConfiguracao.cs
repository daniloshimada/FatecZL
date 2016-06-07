using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleConfiguracao
    {
        private NegocioConfiguracao negocioConfiguracao;

        public ControleConfiguracao()
        {
            negocioConfiguracao = new NegocioConfiguracao();
        }

        public void ValidarConfiguracao(Configuracao configuracao)
        {
            try
            {
                negocioConfiguracao.ValidarAssunto(configuracao.Assunto);
                negocioConfiguracao.ValidarCategoria(configuracao.Categoria);
                negocioConfiguracao.ValidarTermos(configuracao.Termos);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}