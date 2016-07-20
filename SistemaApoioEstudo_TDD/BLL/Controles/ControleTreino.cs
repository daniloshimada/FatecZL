using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using System;
using System.Collections.Generic;

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

        public void ValidarResposta(string respostaTreino)
        {
            try
            {
                negocioTreino.ValidarResposta(respostaTreino); 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}