using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioUsuario
    {
        public void ValidaNome(Usuario usuario)
        {
            try
            {
                if (usuario.Nome.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo nome deve ser preenchido!");
                }
                else if (usuario.Nome.Length > 15)
                {
                    throw new ArgumentException("O campo nome não deve conter acima de 15 caracteres!");
                }else if(usuario.Nome == null)
                {
                    throw new NullReferenceException("Não foi possível gravar o nome, contate o suporte técnico!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarSenha(Usuario usuario)
        {
            try
            {
                if (usuario.Senha.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo senha deve ser preenchido!");
                }
                else if (usuario.Senha.Length > 10)
                {
                    throw new ArgumentException("O campo senha não deve conter acima de 10 caracteres!");
                }
                else if (usuario.Senha == null)
                {
                    throw new NullReferenceException("Não foi possível gravar a senha, contate o suporte técnico!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}