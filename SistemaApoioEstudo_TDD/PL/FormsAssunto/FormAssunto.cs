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
            carregarTela();
        }

        private void comboBoxAssuntos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxAssunto.Text = (comboBoxAssuntos.SelectedItem as Assunto).Nome;
                textBoxCategorias.Text = (comboBoxAssuntos.SelectedItem as Assunto).QtdCategorias.ToString();
                textBoxTermos.Text = (comboBoxAssuntos.SelectedItem as Assunto).QtdTermos.ToString();
                textBoxDicas.Text = (comboBoxAssuntos.SelectedItem as Assunto).QtdDicas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregarTela(int idAssunto=0)
        {
            try
            {
                comboBoxAssuntos.Items.Clear();
                comboBoxAssuntos.ValueMember = "Id";
                comboBoxAssuntos.DisplayMember = "Nome";
                List<Assunto> assuntosRetorno = controleAssunto.ConsultarDadosIdUsuario();
                foreach (Assunto assunto in assuntosRetorno)
                {
                    comboBoxAssuntos.Items.Add(assunto);
                }
                for (int i = 0; i < assuntosRetorno.Count; i++)
                {
                    if (assuntosRetorno[i].Id == idAssunto)
                    {
                        comboBoxAssuntos.SelectedIndex = i;
                        return;
                    }
                }
                comboBoxAssuntos.SelectedIndex = idAssunto;
            }
            catch (Exception)
            {
                //_Nenhum assunto cadastrado, mas não é preciso lançar a exceção!
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Assunto assuntoCadastrar = new Assunto()
                {
                    Nome = textBoxAssunto.Text
                };
                ControleAssunto controleAssunto = new ControleAssunto();
                bool resultado = controleAssunto.Cadastrar(assuntoCadastrar);
                if (resultado)
                {
                    MessageBox.Show("Assunto cadastrado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarTela(controleAssunto.ConsultarNomeIdUsuario(assuntoCadastrar.Nome).Id);
                }
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
                Assunto assuntoAtualizar = new Assunto()
                {
                    Nome = textBoxAssunto.Text
                };
                assuntoAtualizar.Id = (comboBoxAssuntos.SelectedItem as Assunto).Id;
                ControleAssunto controleAssunto = new ControleAssunto();
                controleAssunto.ValidarCampos(assuntoAtualizar);
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo atualizar o assunto?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleAssunto.Atualizar(assuntoAtualizar);
                    if (resultado)
                    {
                        MessageBox.Show("Assunto atualizado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregarTela(assuntoAtualizar.Id);
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