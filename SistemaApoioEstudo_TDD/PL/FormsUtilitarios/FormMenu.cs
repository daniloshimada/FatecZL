using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaApoioEstudo.PL.FormsLogin;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsUsuario;

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

        private void recarregarTela()
        {
            textBoxNome.Text = Login.Usuario.Nome;
        }

        private void FormMenu_Shown(object sender, EventArgs e)
        {
            recarregarTela();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                FormAtualizarUsuario formAtualizarUsuario = new FormAtualizarUsuario();
                formAtualizarUsuario.ShowDialog();
                recarregarTela();
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
                FormExcluirUsuario formExcluirUsuario = new FormExcluirUsuario(formLogin, this);
                formExcluirUsuario.Show();
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