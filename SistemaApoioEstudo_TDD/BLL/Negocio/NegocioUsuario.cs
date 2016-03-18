using SistemaApoioEstudo.BLL.Entidades;
using System;

namespace SistemaApoioEstudo.BLL.Negocio
{
    public class NegocioUsuario
    {
        public void ValidarNome(string nome)
        {
            try
            {
                if (nome.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo nome deve ser preenchido!");
                }
                else if (nome.Trim().Length > 15)
                {
                    throw new ArgumentException("O campo nome não deve conter acima de 15 caracteres!");
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo nome, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarSenha(string senha)
        {
            try
            {
                if (senha.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo senha deve ser preenchido!");
                }
                else if (senha.Trim().Length > 10)
                {
                    throw new ArgumentException("O campo senha não deve conter acima de 10 caracteres!");
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo senha, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidarSenhaNova(string senhaNova)
        {
            try
            {
                if (senhaNova.Trim().Length > 10)
                {
                    throw new ArgumentException("O campo senha não deve conter acima de 10 caracteres!");
                }
                else if (!senhaNova.Trim().Equals(string.Empty)) //_Possui alguma senha
                {
                    return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo senha, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarSenhaConfirmacao(string senhaConfirmacao)
        {
            try
            {
                if (senhaConfirmacao.Trim().Equals(string.Empty))
                {
                    throw new ArgumentException("O campo com a senha de confirmação deve ser prrenchido!");
                }
                else if (senhaConfirmacao.Trim().Length > 10)
                {
                    throw new ArgumentException("O campo com a senha de confirmação não deve conter acima de 10 caracteres!");
                }
                else if (!senhaConfirmacao.Equals(Login.Usuario.Senha))
                {
                    throw new ArgumentException("Senha de confirmação incorreta!");
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Ocorreu um erro no campo de senha de confirmação, contate o suporte técnico!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}