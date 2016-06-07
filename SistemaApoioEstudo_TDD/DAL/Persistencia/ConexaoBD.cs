using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SistemaApoioEstudo.DAL.Persistencia
{
    public class ConexaoBD
    {
        private SqlConnection sqlConnection;
        private SqlParameterCollection sqlParameterCollection;
        private SqlCommand sqlCommand;

        public ConexaoBD()
        {
            sqlConnection = new SqlConnection();
            sqlParameterCollection = new SqlCommand().Parameters;
            sqlCommand = new SqlCommand();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.AddWithValue(nomeParametro, valorParametro);
        }

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
            sqlCommand.Parameters.Clear();
        }

        public bool ExecutarManipulacao(string userStoredProcedure)
        {
            try
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;
                sqlConnection.Open();
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

        public DataTable ExecutarConsulta(string userStoredProcedure)
        {
            try
            {
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConexaoSqlServer"].ConnectionString;
                sqlConnection.Open();
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