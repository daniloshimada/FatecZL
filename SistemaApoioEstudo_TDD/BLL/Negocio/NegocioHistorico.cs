using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioHistorico
    {
        public string GerarRelatorio(Historico historico)
        {
            try
            {
                string relatorio = string.Format("Assunto: {0}\nCategoria: {1}\nAcertos: {2}/{4}\nErros: {3}/{4}\nTestes: {4}\nTempo: {5}\nData: {6}\n\n*Relatório gravado no histórico!",
                        historico.Treino.Configuracao.Assunto.Nome, historico.Treino.Configuracao.Categoria.Nome, historico.Acertos,
                        historico.Erros, historico.Treino.Configuracao.Termos.Count, historico.Treino.Tempo, historico.Data.ToShortDateString());
                return relatorio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarDados(Historico historico)
        {
            try
            {
                if (historico.Treino.Assercoes == null || (historico.Treino.Respostas == null))
                {
                    throw new NullReferenceException("Não foi possível cadastrar o histórico, contate o suporte técnico! (treino)");
                }else if(historico == null || historico.Treino == null)
                {
                    throw new NullReferenceException("Não foi possível cadastrar o histórico, contate o suporte técnico! (histórico)");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}