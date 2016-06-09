using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleTreino
    {
        private NegocioTreino negocioTreino;

        public ControleTreino()
        {
            negocioTreino = new NegocioTreino();
        }

        public void ValidarConfiguracao(Configuracao configuracao)
        {
            try
            {
                negocioTreino.ValidarConfiguracao(configuracao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarRespostas(List<string> respostas)
        {
            try
            {
                negocioTreino.ValidarRespostasColetadas(respostas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarAssercoes(List<bool> assercoes)
        {
            try
            {
                negocioTreino.ValidarAssercoesColetadas(assercoes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public byte CalcularAcertos(List<bool> assercoes)
        {
            try
            {
                return negocioTreino.CalcularAcertos(assercoes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public byte CalcularErros(List<bool> assercoes)
        {
            try
            {
                return negocioTreino.CalcularErros(assercoes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}