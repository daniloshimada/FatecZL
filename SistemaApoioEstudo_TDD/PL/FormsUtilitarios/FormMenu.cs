using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsAssunto;
using SistemaApoioEstudo.PL.FormsCategoria;
using SistemaApoioEstudo.PL.FormsConfiguracao;
using SistemaApoioEstudo.PL.FormsHistorico;
using SistemaApoioEstudo.PL.FormsLogin;
using SistemaApoioEstudo.PL.FormsTermo;
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
            try
            {
                CarregarTela();
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

        public void CarregarTela()
        {
            try
            {
                if (Login.Usuario != null)
                {
                    toolStripStatusLabel1.Text = string.Format("USUÁRIO: {0}", Login.Usuario.Nome);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deslogarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Login.RemoverUsuario();
                Hide();
                formLogin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormConsultarUsuario formConsultarUsuario = new FormConsultarUsuario(formLogin, this);
                formConsultarUsuario.MdiParent = this;
                formConsultarUsuario.Show();
                CarregarTela();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void assuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormAssunto formAssunto = new FormAssunto();
                formAssunto.MdiParent = this;
                formAssunto.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormCategoria formCategoria = new FormCategoria();
                formCategoria.MdiParent = this;
                formCategoria.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void termoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormTermo formTermo = new FormTermo();
                formTermo.MdiParent = this;
                formTermo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void históricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormHistorico formHistorico = new FormHistorico(this);
                formHistorico.MdiParent = this;
                formHistorico.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormConfiguracao formConfiguracao = new FormConfiguracao(this);
                formConfiguracao.MdiParent = this;
                formConfiguracao.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}