
namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Assunto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override bool Equals(object obj)
        {
            Assunto assunto = obj as Assunto;
            if (obj == null || GetType() != assunto.GetType())
            {
                return false;
            }
            return (this.Id == assunto.Id && this.Nome.Equals(assunto.Nome));
        }
    }
}