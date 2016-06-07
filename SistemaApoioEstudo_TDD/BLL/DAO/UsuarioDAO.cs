using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.DAL.Persistencia;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaApoioEstudo.BLL.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private ConexaoBD conexaoBD;

        public UsuarioDAO()
        {
            conexaoBD = new ConexaoBD();
        }

        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Nome_usuario", usuario.Nome);
                conexaoBD.AdicionarParametros("@Senha_usuario", usuario.Senha);
                if (conexaoBD.ExecutarManipulacao("uspUsuarioCadastrar"))
                {
                    return true;
                }
                throw new Exception("Não foi possível cadastrar o usuário, contate o suporte técnico!");
            }
            catch (SqlException sqlException)
            {
                if (sqlException.Number == 2627)
                {
                    throw new Exception("O nome já existe!");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario Consultar(Usuario usuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Nome_usuario", usuario.Nome);
                conexaoBD.AdicionarParametros("@Senha_usuario", usuario.Senha);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsulta("uspUsuarioConsultar");
                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception("Dados incorretos!");
                }
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    usuario.Id = Convert.ToInt32(dataRow[0]);
                    usuario.Nome = Convert.ToString(dataRow[1]);
                    usuario.Senha = Convert.ToString(dataRow[2]);
                }
                return usuario;
            }
            catch (Exception)
            {  
                throw;
            }
        }

        public Usuario ConsultarNome(string nomeUsuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Nome_usuario", nomeUsuario);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsulta("uspUsuarioConsultarNome");
                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }
                Usuario usuario = new Usuario();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    usuario.Id = Convert.ToInt32(dataRow[0]);
                    usuario.Nome = Convert.ToString(dataRow[1]);
                    usuario.Senha = Convert.ToString(dataRow[2]);
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario ConsultarDados(int idUsuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_usuario", idUsuario);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsulta("uspUsuarioConsultarDados");
                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }
                Usuario usuario = new Usuario();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    usuario.Id = Convert.ToInt32(dataRow[0]);
                    usuario.Nome = Convert.ToString(dataRow[1]);
                    usuario.Senha = Convert.ToString(dataRow[2]);
                    usuario.QtdAssuntos = Convert.ToInt32(dataRow[3]);
                    usuario.QtdCategorias = Convert.ToInt32(dataRow[4]);
                    usuario.QtdTermos = Convert.ToInt32(dataRow[5]);
                    usuario.QtdDicas = Convert.ToInt32(dataRow[6]);
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Atualizar(Usuario usuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_usuario", usuario.Id);
                conexaoBD.AdicionarParametros("@Nome_usuario", usuario.Nome);
                conexaoBD.AdicionarParametros("@Senha_usuario", usuario.Senha);
                if (conexaoBD.ExecutarManipulacao("uspUsuarioAtualizar"))
                {
                    return true;
                }
                throw new Exception("Não foi possível atualizar o usuário, contate o suporte técnico!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new Exception("O nome já existe!");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AtualizarNome(Usuario usuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_usuario", usuario.Id);
                conexaoBD.AdicionarParametros("@Nome_usuario", usuario.Nome);
                return conexaoBD.ExecutarManipulacao("uspUsuarioAtualizarNome");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new Exception("O nome já existe!");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(int idUsuario)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_usuario", idUsuario);
                if (conexaoBD.ExecutarManipulacao("uspUsuarioExcluir"))
                {
                    return true;
                }
                throw new Exception("Não foi possível excluir o usuário, contate o suporte técnico!");
            }
            catch (Exception)
            {               
                throw;
            }
        }
    }
}