using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioConfiguracao
    {
        public void ValidarAssunto(Assunto assunto)
        {
            try
            {
                if (assunto.Id == 0 || assunto.Nome == null)
                {
                    throw new Exception("Não é possível treinar sem nenhum assunto!");
                }
            }
            catch (NullReferenceException)
            {
                throw new Exception("Não é possível treinar sem nenhum assunto! (nulo)");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarCategoria(Categoria categoria)
        {
            try
            {
                if (categoria.Id == 0 || categoria.Nome == null)
                {
                    throw new Exception("Não é possível treinar sem nenhuma categoria!");
                }
            }
            catch (NullReferenceException)
            {
                throw new Exception("Não é possível treinar sem nenhuma categoria! (nula)");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarTermos(List<Termo> termos)
        {
            try
            {
                if (termos.Count < 1)
                {
                    throw new Exception("Não é possível treinar sem nenhuma termo!");
                }
            }
            catch (NullReferenceException)
            {
                throw new Exception("Não é possível treinar sem nenhuma termo! (nulo)");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}