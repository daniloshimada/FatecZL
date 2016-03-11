
namespace SistemaApoioEstudo.BLL.Entidades
{
    public static class Login
    {
        public static Usuario Usuario { get; set; }

        public static void RegistrarUsuario(Usuario usuario)
        {
            Login.Usuario = usuario;
        }

        public static void RemoverUsuario()
        {
            Login.Usuario = null;
        }
    }
}