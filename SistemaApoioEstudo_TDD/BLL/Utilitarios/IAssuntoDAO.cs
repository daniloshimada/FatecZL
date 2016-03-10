using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;
using System.Data;

namespace SistemaApoioEstudo.BLL.Utilitarios
{
    public interface IAssuntoDAO
    {
        bool Cadastrar(int idUsuario, Assunto assunto);
        Assunto ConsultarNomeIdUsuario(string nomeAssunto, int idUsuario);
        List<Assunto> ConsultarIdUsuario(int idUsuario);
        Assunto ConsultarDados(int idAssunto);
        bool Excluir(int idAssunto);
    }
}