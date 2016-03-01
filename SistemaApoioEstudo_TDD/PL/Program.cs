using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.PL.FormUsuario;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.DAO;

namespace PL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormCadastrarUsuario());
            Usuario usuario = new Usuario();
            usuario.Nome = "hkjh";
            usuario.Senha = "asdfas";
            IUsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario retorno = usuarioDAO.Consultar(usuario);
            System.Diagnostics.Debug.WriteLine(usuario == null ? "NULL" : "CHEIO");
        }
    }
}
