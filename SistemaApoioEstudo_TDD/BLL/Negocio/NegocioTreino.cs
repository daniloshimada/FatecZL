using SistemaApoioEstudo.BLL.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioTreino
    {
        public void ValidarConfiguracao(Configuracao configuracao)
        {
            try
            {
                if (configuracao.Assunto == null || configuracao.Categoria == null || configuracao.Termos == null)
                {
                    throw new ArgumentNullException("Configuração não realizada!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarRespostasColetadas(List<string> respostas)
        {
            try
            {
                foreach (string resposta in respostas)
                {
                    if (resposta == null)
                    {
                        throw new ArgumentNullException("Resposta não coletada!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarAssercoesColetadas(List<bool> assercoes)
        {
            try
            {
                if (assercoes.Count <= 0)
                {
                    throw new ArgumentException("Asserção não coletada!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public byte CalcularAcertos(List<bool> assercoes)
        {
            byte acertos = 0;
            try
            {
                foreach (bool assercao in assercoes)
                {
                    if (assercao)
                    {
                        acertos++;
                    }
                }
                return acertos;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public byte CalcularErros(List<bool> assercoes)
        {
            byte erros = 0;
            try
            {
                foreach (bool assercao in assercoes)
                {
                    if (!assercao)
                    {
                        erros++;
                    }
                }
                return erros;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}