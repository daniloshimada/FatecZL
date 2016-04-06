using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.DAL.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaApoioEstudo.BLL.DAO
{
    public class CategoriaDAO : ICategoriaDAO
    {
        private ConexaoBD conexaoBD;

        public CategoriaDAO()
        {
            conexaoBD = new ConexaoBD();
        }

        public bool Cadastrar(int idAssunto, Categoria categoria)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_assunto", idAssunto);
                conexaoBD.AdicionarParametros("@Nome_categoria", categoria.Nome);
                if (conexaoBD.ExecutarManipulacao("uspCategoriaCadastrar"))
                {
                    return true;
                }
                throw new Exception("Não foi possível cadastrar a categoria, contate o suporte técnico!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new Exception("A categoria já existe!");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Categoria> ConsultarDadosIdAssunto(int idAssunto)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_assunto", idAssunto);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsultar("uspCategoriaConsultarDadosIdAssunto");
                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception("Nenhuma categoria cadastrada!");
                }

                List<Categoria> categorias = new List<Categoria>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Categoria categoriaForeach = new Categoria()
                    {
                        Id = Convert.ToInt32(dataRow[0]),
                        Nome = Convert.ToString(dataRow[1])
                    };
                    categorias.Add(categoriaForeach);
                }
                return categorias;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Categoria ConsultarNomeIdAssunto(string nomeCategoria, int idAssunto)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Nome_categoria", nomeCategoria);
                conexaoBD.AdicionarParametros("@Id_assunto", idAssunto);
                DataTable dataTable = new DataTable();
                dataTable = conexaoBD.ExecutarConsultar("uspCategoriaConsultarNomeIdAssunto");
                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }

                Categoria categoria = new Categoria();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    categoria.Id = Convert.ToInt32(dataRow[0]);
                    categoria.Nome = Convert.ToString(dataRow[1]);
                }
                return categoria;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Atualizar(Categoria categoria)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_categoria", categoria.Id);
                conexaoBD.AdicionarParametros("@Nome_categoria", categoria.Nome);
                if (conexaoBD.ExecutarManipulacao("uspCategoriaAtualizar"))
                {
                    return true;
                }
                throw new Exception("Não foi possível atualizar a categoria, contate o suporte técnico!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new Exception("A categoria já existe!");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Excluir(int idCategoria)
        {
            try
            {
                conexaoBD.AdicionarParametros("@Id_categoria", idCategoria);
                if (conexaoBD.ExecutarManipulacao("uspCategoriaExcluir"))
                {
                    return true;
                }
                throw new Exception("Não foi possível excluir a categoria, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}