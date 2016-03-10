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

namespace SistemaApoioEstudo.PL.FormsAssunto
{
    public partial class FormAssunto : Form
    {
        private ControleAssunto controleAssunto;

        public FormAssunto()
        {
            InitializeComponent();
            controleAssunto = new ControleAssunto();
        }

        private void FormAssunto_Shown(object sender, EventArgs e)
        {
            try
            {
                comboBoxAssuntos.ValueMember = "Id";
                comboBoxAssuntos.DisplayMember = "Nome";
                foreach (Assunto assunto in controleAssunto.ConsultarIdUsuario())
                {
                    comboBoxAssuntos.Items.Add(assunto);
                }
                comboBoxAssuntos.SelectedIndex = 0;
            }
            catch (Exception)
            {
                //_Nenhum assunto cadastrado, mas não é preciso lançar a exceção!
            }
        }

        private void comboBoxAssuntos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Assunto assunto = controleAssunto.ConsultarDados((comboBoxAssuntos.SelectedItem as Assunto).Id);
                textBoxCategorias.Text = assunto.QtdCategorias.ToString();
                textBoxTermos.Text = assunto.QtdTermos.ToString();
                textBoxDicas.Text = assunto.QtdDicas.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Assunto assunto = new Assunto()
                {
                    Nome = textBoxNome.Text
                };
                ControleAssunto controleAssunto = new ControleAssunto();
                bool resultado = controleAssunto.Cadastrar(assunto);
                if (resultado)
                {
                    MessageBox.Show("Assunto cadastrado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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