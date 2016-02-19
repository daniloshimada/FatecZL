using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SistemaApoioEstudo.DAL.Persistencia
{
    public class ConexaoBD
    {
        private SqlParameterCollection sqlParameterCollection;

        public ConexaoBD()
        {
            sqlParameterCollection = new SqlCommand().Parameters;
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.AddWithValue(nomeParametro, valorParametro);
        }

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public bool ExecutarManipulacao(string userStoredProcedure)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = userStoredProcedure;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.AddWithValue(sqlParameter.ParameterName, sqlParameter.Value);
                }
                return Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                LimparParametros();
                sqlConnection.Close();
            }
        }

        public DataTable ExecutarConsultar(string userStoredProcedure)
        {
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = userStoredProcedure;

                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                {
                    sqlCommand.Parameters.AddWithValue(sqlParameter.ParameterName, sqlParameter.Value);
                }

                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                LimparParametros();
                sqlConnection.Close();
            }
        }
    }
}