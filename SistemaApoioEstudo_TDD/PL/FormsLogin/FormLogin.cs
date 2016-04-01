using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsUsuario;
using SistemaApoioEstudo.PL.FormsUtilitarios;
using System;
using System.Windows.Forms;

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
                Usuario usuarioLogar = new Usuario()
                {
                    Nome = textBoxNome.Text,
                    Senha = textBoxSenha.Text
                };
                ControleLogin controleLogin = new ControleLogin();
                if (controleLogin.Logar(usuarioLogar))
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
                textBoxNome.Clear();
                textBoxSenha.Clear();
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
            finally
            {
                textBoxNome.Clear();
                textBoxSenha.Clear();
                textBoxNome.Focus();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}