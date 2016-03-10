using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.DAL.Persistencia;
using System.Data;
using System.Data.SqlClient;

namespace SistemaApoioEstudo.BLL.DAO
{
    public class AssuntoDAO : IAssuntoDAO
    {
        private ConexaoBD conexaoBD;

        public AssuntoDAO()
        {
            conexaoBD = new ConexaoBD();
        }

        public bool Cadastrar(int idUsuario, Assunto assunto)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_Usuario", idUsuario);
                conexaoBD.AdicionarParametros("@Nome_assunto", assunto.Nome);
                if (conexaoBD.ExecutarManipulacao("uspAssuntoCadastrar"))
                {
                    return true;
                }
                throw new Exception("Não foi possível cadastrar o assunto, contate o suporte técnico!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new Exception("Assunto já existe!");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Assunto ConsultarNomeIdUsuario(string nomeAssunto, int idUsuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Nome_assunto", nomeAssunto);
                conexaoBD.AdicionarParametros("@Id_usuario", idUsuario);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsultar("uspAssuntoConsultarNomeIdUsuario");
                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }

                Assunto assunto = new Assunto();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    assunto.Id = Convert.ToInt32(dataRow[0]);
                    assunto.Nome = Convert.ToString(dataRow[1]);
                }
                return assunto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Assunto> ConsultarIdUsuario(int idUsuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_usuario", idUsuario);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsultar("uspAssuntoConsultarIdUsuario");
                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception("Nenhum assunto cadastrado!");
                }

                List<Assunto> assuntos = new List<Assunto>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Assunto assuntoForeach = new Assunto()
                    {
                        Id = Convert.ToInt32(dataRow[0]),
                        Nome = Convert.ToString(dataRow[1])
                    };
                    assuntos.Add(assuntoForeach);
                }
                return assuntos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Assunto ConsultarDados(int idAssunto)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_assunto", idAssunto);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsultar("uspAssuntoConsultarDados");
                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }

                Assunto assunto = new Assunto();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    assunto.Id = Convert.ToInt32(dataRow[0]);
                    assunto.Nome = Convert.ToString(dataRow[1]);
                    assunto.QtdCategorias = Convert.ToByte(dataRow[2]);
                    assunto.QtdDicas = Convert.ToByte(dataRow[3]); ;
                    assunto.QtdTermos = Convert.ToByte(dataRow[4]);

                }
                return assunto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(int idAssunto)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_assunto", idAssunto);
                if (conexaoBD.ExecutarManipulacao("uspAssuntoExcluir"))
                {
                    return true;
                }
                throw new Exception("Não foi possível excluir o assunto, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}