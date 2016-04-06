using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.DAL.Persistencia;
using System.Data.SqlClient;
using System.Data;

namespace SistemaApoioEstudo.BLL.DAO
{
    public class TermoDAO : ITermoDAO
    {
        private ConexaoBD conexaoBD;

        public TermoDAO()
        {
            conexaoBD = new ConexaoBD();
        }

        public bool Cadastrar(int idCategoria, Termo termo)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_categoria", idCategoria);
                conexaoBD.AdicionarParametros("@Nome_termo", termo.Nome);
                conexaoBD.AdicionarParametros("@Correspondencia_termo", termo.Correspondencia);
                conexaoBD.AdicionarParametros("@Dica_termo", string.IsNullOrWhiteSpace(termo.Dica) ? (object)DBNull.Value : termo.Dica);
                if (conexaoBD.ExecutarManipulacao("uspTermoCadastrar"))
                {
                    return true;
                }
                throw new Exception("Não foi possível cadastrar o termo, contate o suporte técnico!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new Exception("O termo já existe!");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Termo> ConsultarDadosIdCategoria(int idCategoria)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_categoria", idCategoria);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsultar("uspTermoConsultarDadosIdCategoria");
                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception("Nenhum termo cadastrado!");
                }

                List<Termo> termos = new List<Termo>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Termo termoForeach = new Termo()
                    {
                        Id = Convert.ToInt32(dataRow[0]),
                        Nome = Convert.ToString(dataRow[1]),
                        Correspondencia = Convert.ToString(dataRow[2]),
                        Dica = Convert.ToString(dataRow[3])
                    };
                    termos.Add(termoForeach);
                }
                return termos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Termo ConsultarNomeIdCategoria(string nomeTermo, int IdCategoria)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Nome_termo", nomeTermo);
                conexaoBD.AdicionarParametros("@Id_categoria", IdCategoria);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsultar("uspTermoConsultarNomeIdCategoria");
                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }

                Termo termo = new Termo();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    termo.Id = Convert.ToInt32(dataRow[0]);
                    termo.Nome = Convert.ToString(dataRow[1]);
                    termo.Correspondencia = Convert.ToString(dataRow[2]);
                    termo.Dica = Convert.ToString(dataRow[3]);
                }
                return termo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Atualizar(Termo termo)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_termo", termo.Id);
                conexaoBD.AdicionarParametros("@Nome_termo", termo.Nome);
                conexaoBD.AdicionarParametros("@Correspondencia_termo", termo.Correspondencia);
                conexaoBD.AdicionarParametros("@Dica_termo", string.IsNullOrWhiteSpace(termo.Dica) ? (object)DBNull.Value : termo.Dica);
                if (conexaoBD.ExecutarManipulacao("uspTermoAtualizar"))
                {
                    return true;
                }
                throw new Exception("Não foi possível atualizar o termo, contate o suporte técnico!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new Exception("O termo já existe!");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(int idTermo)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_termo", idTermo);
                if (conexaoBD.ExecutarManipulacao("uspTermoExcluir"))
                {
                    return true;
                }
                throw new Exception("Não foi possível excluir o termo, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}