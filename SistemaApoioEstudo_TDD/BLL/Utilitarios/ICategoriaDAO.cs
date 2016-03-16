using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public interface ICategoriaDAO
    {
        bool Cadastrar(int idAssunto, Categoria categoria);
        List<Categoria> ConsultarDadosIdAssunto(int idAssunto);
        Categoria ConsultarNomeIdAssunto(string nomeCategoria, int idAssunto);
    }
}