using System.Collections.Generic;

namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Configuracao
    {
        public Assunto Assunto { get; set; }
        public Categoria Categoria { get; set; }
        public List<Termo> Termos { get; set; }
    }
}