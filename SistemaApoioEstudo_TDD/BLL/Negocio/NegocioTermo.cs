using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaApoioEstudo.BLL.Entidades;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioTermo
    {
        public void ValidarNome(string nomeTermo)
        {
            try
            {
                if (nomeTermo.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo termo deve ser preenchido!");
                }
                else if (nomeTermo.Length > 300)
                {
                    throw new ArgumentException("O campo termo não deve conter acima de 300 caracteres!");
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo termo, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarCorrespondencia(string correspondenciaTermo)
        {
            try
            {
                if (correspondenciaTermo.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo correspondência deve ser preenchido!");
                }
                else if (correspondenciaTermo.Length > 300)
                {
                    throw new ArgumentException("O campo correspondência não deve conter acima de 300 caracteres!");
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo correspondência, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarDica(string dicaTermo)
        {
            try
            {
                if (dicaTermo.Length > 100)
                {
                    throw new ArgumentException("O campo dica não deve conter acima de 100 caracteres!");
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo dica, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void VerificarTermoSelecionado(int termoSelecionado)
        {
            try
            {
                if (termoSelecionado < 1)
                {
                    throw new ArgumentException("Nenhum termo selecionado!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}