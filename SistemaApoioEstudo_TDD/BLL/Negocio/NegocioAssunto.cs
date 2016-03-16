using System;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioAssunto
    {
        public void ValidarNome(string nome)
        {
            try
            {
                if (nome.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo assunto deve ser preenchido!");
                }
                else if (nome.Length > 30)
                {
                    throw new ArgumentException("O campo assunto não deve conter acima de 30 caracteres!");
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo assunto, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void VerificarAssuntoConsultado(int assuntoSelecionado)
        {
            try
            {
                if (assuntoSelecionado < 0)
                {
                    throw new ArgumentException("Nenhum assunto selecionado!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}