using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsLogin;
using SistemaApoioEstudo.PL.FormsUtilitarios;
using System;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsUsuario
{
    public partial class FormConsultarUsuario : Form
    {
        private FormLogin formLogin;
        private FormMenu formMenu;
        private ControleUsuario controleUsuario;

        public FormConsultarUsuario(FormLogin formLogin, FormMenu formMenu)
        {
            InitializeComponent();
            this.formLogin = formLogin;
            this.formMenu = formMenu;
            controleUsuario = new ControleUsuario();
        }

        private void FormConsultarUsuario_Shown(object sender, EventArgs e)
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

        public void CarregarTela()
        {
            try
            {
                Usuario usuarioDados = controleUsuario.ConsultarDados();
                textBoxNome.Text = usuarioDados.Nome;
                textBoxAssuntos.Text = usuarioDados.QtdAssuntos.ToString();
                textBoxCategorias.Text = usuarioDados.QtdCategorias.ToString();
                textBoxTermos.Text = usuarioDados.QtdTermos.ToString();
                textBoxDicas.Text = usuarioDados.QtdDicas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                FormAtualizarUsuario formAtualizarUsuario = new FormAtualizarUsuario(this, formMenu);
                formAtualizarUsuario.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Todos os seus dados serão perdidos!\nDeseja mesmo excluir o usuário?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                ControleUsuario controleUsuario = new ControleUsuario();
                if (dialogResult == DialogResult.OK)
                {
                    if (controleUsuario.Excluir())
                    {
                        MessageBox.Show("Usuário excluído com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        formMenu.Hide();
                        formLogin.Show();
                    }
                }
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
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
