using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsLogin;
using SistemaApoioEstudo.PL.FormsUtilitarios;
using System;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsUsuario
{
    public partial class FormExcluirUsuario : Form
    {
        private FormLogin formLogin;
        private FormMenu formMenu;
        private FormConsultarUsuario formConsultarUsuario;

        public FormExcluirUsuario(FormLogin formLogin, FormMenu formMenu, FormConsultarUsuario formConsultarUsuario)
        {
            InitializeComponent();
            this.formLogin = formLogin;
            this.formMenu = formMenu;
            this.formConsultarUsuario = formConsultarUsuario;
        }

        private void FormExcluirUsuario_Shown(object sender, EventArgs e)
        {
            textBoxNome.Text = Login.Usuario.Nome;
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ControleUsuario controleUsuario = new ControleUsuario();
                controleUsuario.ValidarCampos(textBoxSenhaConfirmacao.Text);
                DialogResult dialogResult = MessageBox.Show("Todos os seus dados serão perdidos!\nDeseja mesmo excluir o usuário?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleUsuario.Excluir(textBoxSenhaConfirmacao.Text);
                    if (resultado)
                    {
                        MessageBox.Show("Usuário excluído com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        formConsultarUsuario.Close();
                        formMenu.Hide();
                        formLogin.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSenhaConfirmacao.Clear();
                textBoxSenhaConfirmacao.Focus();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}