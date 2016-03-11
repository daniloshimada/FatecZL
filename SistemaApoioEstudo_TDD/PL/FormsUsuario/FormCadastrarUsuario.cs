using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.BLL.Controles;

namespace SistemaApoioEstudo.PL.FormsUsuario
{
    public partial class FormCadastrarUsuario : Form
    {
        public FormCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nome = textBoxNome.Text,
                    Senha = textBoxSenha.Text
                };
                ControleUsuario controleUsuario = new ControleUsuario();
                bool resultadoCadastrar = controleUsuario.Cadastrar(usuario);
                if (resultadoCadastrar)
                {
                    MessageBox.Show("Usuário cadastrado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNome.Clear();
                textBoxSenha.Clear();
                textBoxNome.Focus();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}