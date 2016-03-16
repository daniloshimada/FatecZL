using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioCategoria
    {
        public void ValidarNome(string nomeCategoria)
        {
            try
            {
                if (nomeCategoria.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo categoria deve ser preenchido!");
                }
                else if (nomeCategoria.Length > 50)
                {
                    throw new ArgumentException("O campo categoria não deve conter acima de 50 caracteres!");
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo categoria, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}