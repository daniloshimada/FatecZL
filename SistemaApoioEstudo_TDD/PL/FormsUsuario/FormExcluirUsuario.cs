using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaApoioEstudo.BLL.Utilitarios;
using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;

using SistemaApoioEstudo.PL.FormsLogin;
using SistemaApoioEstudo.PL.FormsUtilitarios;

namespace SistemaApoioEstudo.PL.FormsUsuario
{
    public partial class FormExcluirUsuario : Form
    {
        private FormLogin formLogin;
        private FormMenu formMenu;

        public FormExcluirUsuario(FormLogin formLogin, FormMenu formMenu)
        {
            InitializeComponent();
            this.formLogin = formLogin;
            this.formMenu = formMenu;
        }

        private void FormExcluirUsuario_Shown(object sender, EventArgs e)
        {
            textBoxNome.Text = Login.Usuario.Nome;
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Todos os seus dados serão perdidos!\nDeseja mesmo excluir o usuário?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                ControleUsuario controleUsuario = new ControleUsuario();
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleUsuario.Excluir(textBoxSenhaConfirmacao.Text);
                    if (resultado)
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
            Close();
        }
    }
}