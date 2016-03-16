
namespace SistemaApoioEstudo.BLL.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public override bool Equals(object obj)
        {
            Categoria categoria = obj as Categoria;
            if (categoria == null || GetType() != categoria.GetType())
            {
                return false;
            }
            return (this.Id == categoria.Id && this.Nome.Equals(categoria.Nome));
        }
    }
}