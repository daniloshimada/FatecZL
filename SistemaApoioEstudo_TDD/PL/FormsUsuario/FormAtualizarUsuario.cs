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
            CarregarTela();
        }

        public void CarregarTela()
        {
            textBoxNome.Text = Login.Usuario.Nome;
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
                controleUsuario.ValidarCamposAtualizar(usuario, textBoxSenhaConfirmacao.Text);
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo atualizar seus dados?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultadoAtualizar = controleUsuario.Atualizar(usuario, textBoxSenhaConfirmacao.Text);
                    if (resultadoAtualizar)
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
            Close();
        }
    }
}