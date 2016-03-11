using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsAssunto;
using SistemaApoioEstudo.PL.FormsLogin;
using SistemaApoioEstudo.PL.FormsUsuario;
using System;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsUtilitarios
{
    public partial class FormMenu : Form
    {
        private FormLogin formLogin;

        public FormMenu(FormLogin formLogin)
        {
            InitializeComponent();
            this.formLogin = formLogin;
        }

        private void FormMenu_Shown(object sender, EventArgs e)
        {
            carregarTela();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void carregarTela()
        {
            if (Login.Usuario != null)
            {
                textBoxNome.Text = Login.Usuario.Nome;
            }
        }

        private void buttonUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                FormConsultarUsuario formConsultarUsuario = new FormConsultarUsuario(formLogin, this);
                formConsultarUsuario.ShowDialog();
                carregarTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAssunto_Click(object sender, EventArgs e)
        {
            try
            {
                FormAssunto formAssunto = new FormAssunto();
                formAssunto.ShowDialog();
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