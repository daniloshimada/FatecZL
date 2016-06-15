using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.DAL.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;

namespace SistemaApoioEstudo.BLL.DAO
{
    public class HistoricoDAO : IHistoricoDAO
    {
        private ConexaoBD conexaoBD;

        public HistoricoDAO()
        {
            conexaoBD = new ConexaoBD();
        }

        public int Cadastrar(Historico historico)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_usuario", Login.Usuario.Id);
                conexaoBD.AdicionarParametros("@Tempo_historico", historico.Treino.Tempo);
                conexaoBD.AdicionarParametros("@Data_historico", historico.Data);
                int idHistorico = conexaoBD.ExecutarManipulacaoRetornoID("uspHistoricoCadastrar");
                if (cadastrarHistoricoTermo(historico, idHistorico))
                {
                    return idHistorico;
                }
                throw new Exception("Não foi possível cadastrar o histórico, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool cadastrarHistoricoTermo(Historico historico, int idHistorico)
        {
            string userStoredProcedure = "uspHistorico_TermoCadastrar";
            try
            {
                for (int contador = 0; contador < historico.Treino.Configuracao.Termos.Count; contador++)
                {
                    conexaoBD.AdicionarParametros("@Id_historico", idHistorico);
                    conexaoBD.AdicionarParametros("@Id_termo", historico.Treino.Configuracao.Termos[contador].Id);
                    conexaoBD.AdicionarParametros("@Resposta_historico_termo", historico.Treino.Respostas[contador]);
                    conexaoBD.AdicionarParametros("@Resultado_historico_termo", historico.Treino.Assercoes[contador]);
                    conexaoBD.ExecutarManipulacao(userStoredProcedure);
                }
                return true;
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
                conexaoBD.AdicionarParametros("@Id_categoria", idCategoria);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsulta("uspHistoricoConsultar");
                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception("Nenhum histórico cadastrado!");
                }

                List<Historico> historicos = new List<Historico>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Treino treinoInterno = new Treino(new Configuracao())
                    {
                        Tempo = (TimeSpan)dataRow[4]
                    };
                    Historico historicoForeach = new Historico(treinoInterno)
                    {
                        Id = Convert.ToInt32(dataRow[0]),
                        Acertos = Convert.ToByte(dataRow[1]),
                        Erros = Convert.ToByte(dataRow[2]),
                        Data = Convert.ToDateTime(dataRow[5])
                    };
                    historicos.Add(historicoForeach);
                }
                return historicos;
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
                conexaoBD.AdicionarParametros("@Id_historico", idHistorico);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsulta("uspHistorico_TermoConsultar");
                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception("Nenhum histórico cadastrado! (termos)");
                }

                List<Historico> historicos = new List<Historico>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Termo termo = new Termo()
                    {
                        Nome = dataRow[0].ToString(),
                        Correspondencia = dataRow[1].ToString()
                    };
                    Configuracao configuracao = new Configuracao();
                    configuracao.Assunto = new Assunto();
                    configuracao.Categoria = new Categoria();
                    configuracao.Termos = new List<Termo>();
                    Treino treino = new Treino(configuracao);

                    treino.Configuracao.Termos.Add(termo);
                    treino.Respostas.Add(dataRow[2].ToString());
                    treino.Assercoes.Add(Convert.ToBoolean(dataRow[3]));

                    Historico historicoForeach = new Historico(treino);
                    historicos.Add(historicoForeach);
                }
                return historicos;
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
                conexaoBD.AdicionarParametros("@Id_historico", idHistorico);
                if (conexaoBD.ExecutarManipulacao("uspHistoricoExcluir"))
                {
                    return true;
                }
                throw new Exception("Não foi possível excluir o histórico, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}