using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Interfaces;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.DAL.Persistencia;
using System.Data;

namespace SistemaApoioEstudo.BLL.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        public bool Cadastrar(Usuario usuario)
        {
            try
            {
                ConexaoBD conexaoBD = new ConexaoBD();
                conexaoBD.AdicionarParametros("@Nome_usuario", usuario.Nome);
                conexaoBD.AdicionarParametros("@Senha_usuario", usuario.Senha);
                return conexaoBD.ExecutarManipulacao("uspUsuarioCadastrar"); ;
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
                ConexaoBD conexaoBD = new ConexaoBD();
                conexaoBD.AdicionarParametros("@Nome_usuario", usuario.Nome);
                conexaoBD.AdicionarParametros("@Senha_usuario", usuario.Senha);

                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsultar("uspUsuarioConsultar");

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

        public bool Excluir(int idUsuario)
        {
            try
            {
                ConexaoBD conexaoBD = new ConexaoBD();
                conexaoBD.AdicionarParametros("@Id_usuario", idUsuario);
                return conexaoBD.ExecutarManipulacao("uspUsuarioExcluir"); ;
            }
            catch (Exception)
            {               
                throw;
            }
        }
    }
}