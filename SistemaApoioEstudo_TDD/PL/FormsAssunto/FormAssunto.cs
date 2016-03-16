using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                limparCampos();
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

        private void limparCampos()
        {
            try
            {
                textBoxAssunto.Clear();
                textBoxCategorias.Clear();
                textBoxTermos.Clear();
                textBoxDicas.Clear();
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
                Assunto assuntoCadastrar = new Assunto()
                {
                    Nome = textBoxAssunto.Text
                };
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

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Assunto assuntoExcluir = new Assunto()
                {
                    Id = (comboBoxAssuntos.SelectedItem as Assunto).Id
                };
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir o assunto?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleAssunto.Excluir(assuntoExcluir.Id);
                    if (resultado)
                    {
                        MessageBox.Show("Assunto excluído com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregarTela();
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