using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using System;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsUsuario
{
    public partial class FormAtualizarUsuario : Form
    {
        private FormConsultarUsuario formConsultarUsuario;

        public FormAtualizarUsuario(FormConsultarUsuario formConsultarUsuario)
        {
            InitializeComponent();
            this.formConsultarUsuario = formConsultarUsuario;
        }

        private void FormAtualizarUsuario_Shown(object sender, EventArgs e)
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
                textBoxNome.Text = Login.Usuario.Nome;
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
                Usuario usuario = new Usuario()
                {
                    Nome = textBoxNome.Text,
                    Senha = textBoxSenha.Text
                };
                ControleUsuario controleUsuario = new ControleUsuario();
                controleUsuario.ValidarCampos(usuario, textBoxSenhaConfirmacao.Text);
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo atualizar seus dados?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    if (controleUsuario.Atualizar(usuario, textBoxSenhaConfirmacao.Text))
                    {
                        MessageBox.Show("Usuário atualizado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        formConsultarUsuario.CarregarTela();
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSenha.Clear();
                textBoxSenhaConfirmacao.Clear();
                CarregarTela();
                textBoxNome.Focus();
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