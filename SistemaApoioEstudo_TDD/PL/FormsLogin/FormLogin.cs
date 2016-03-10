using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaApoioEstudo.PL.FormsUsuario;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.PL.FormsUtilitarios;

namespace SistemaApoioEstudo.PL.FormsLogin
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nome = textBoxNome.Text,
                    Senha = textBoxSenha.Text
                };
                ControleLogin controleLogin = new ControleLogin();
                bool resultado = controleLogin.Logar(usuario);
                if (resultado)
                {
                    Hide();
                    FormMenu formMenu = new FormMenu(this);
                    formMenu.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBoxNome.Text = string.Empty;
                textBoxSenha.Text = string.Empty;
                textBoxNome.Focus();
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                FormCadastrarUsuario formCadastrarUsuario = new FormCadastrarUsuario();
                formCadastrarUsuario.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}