using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Negocio;
using System;
using System.Collections.Generic;

namespace SistemaApoioEstudo.BLL.Controles
{
    public class ControleConfiguracao
    {
        private NegocioConfiguracao negocioConfiguracao;

        public ControleConfiguracao()
        {
            negocioConfiguracao = new NegocioConfiguracao();
        }

        public void ValidarAssunto(Assunto assunto)
        {
            try
            {
                negocioConfiguracao.ValidarAssunto(assunto);
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
                negocioConfiguracao.ValidarCategoria(categoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarTermo(List<Termo> termos)
        {
            try
            {
                negocioConfiguracao.ValidarTermos(termos);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}