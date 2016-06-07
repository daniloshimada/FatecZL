using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsAssunto;
using SistemaApoioEstudo.PL.FormsCategoria;
using SistemaApoioEstudo.PL.FormsLogin;
using SistemaApoioEstudo.PL.FormsTermo;
using SistemaApoioEstudo.PL.FormsUsuario;
using SistemaApoioEstudo.PL.FormsConfiguracao;
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
            try
            {
                carregarTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
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

        private void carregarTela()
        {
            try
            {
                if (Login.Usuario != null)
                {
                    textBoxNome.Text = Login.Usuario.Nome;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void buttonCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                FormCategoria formCategoria = new FormCategoria();
                formCategoria.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTermo_Click(object sender, EventArgs e)
        {
            try
            {
                FormTermo formTermo = new FormTermo();
                formTermo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonConfiguracao_Click(object sender, EventArgs e)
        {
            try
            {
                FormConfiguracao formConfiguracao = new FormConfiguracao();
                formConfiguracao.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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