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
using SistemaApoioEstudo.PL.FormsUtilitarios;
using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;

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
            CarregarTela();
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
                FormAtualizarUsuario formAtualizarUsuario = new FormAtualizarUsuario(this);
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
                FormExcluirUsuario formExcluirUsuario = new FormExcluirUsuario(formLogin, formMenu, this);
                formExcluirUsuario.ShowDialog();
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
