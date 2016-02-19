using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Interfaces
{
    public interface IUsuarioDAO
    {
        bool Cadastrar(Usuario usuario);
        Usuario Consultar(Usuario usuario);
        bool Excluir(int idUsuario);
    }
}