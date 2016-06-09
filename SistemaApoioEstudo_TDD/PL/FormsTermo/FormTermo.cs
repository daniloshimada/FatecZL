using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsTermo
{
    public partial class FormTermo : Form
    {
        private ControleTermo controleTermo;

        public FormTermo()
        {
            InitializeComponent();
            controleTermo = new ControleTermo();
        }

        #region ...EVENTOS...
        private void FormTermo_Shown(object sender, EventArgs e)
        {
            carregarComboBoxAssuntos();
            carregarCampos();
            textBoxTermo.Clear();
            textBoxCorrespondencia.Clear();
            textBoxDica.Clear();
            textBoxTermo.Focus();
        }

        private void comboBoxAssuntos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregarComboBoxCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregarDataGridViewTermos((comboBoxCategorias.SelectedItem as Categoria).Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTermos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                carregarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ...MÉTODOS PRIVADOS...
        private void carregarComboBoxAssuntos()
        {
            try
            {
                comboBoxAssuntos.Items.Clear();
                comboBoxAssuntos.ValueMember = "Id";
                comboBoxAssuntos.DisplayMember = "Nome";
                List<Assunto> assuntosRetorno = new ControleAssunto().ConsultarDadosIdUsuario();
                foreach (Assunto assunto in assuntosRetorno)
                {
                    comboBoxAssuntos.Items.Add(assunto);
                }
                comboBoxAssuntos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void carregarComboBoxCategorias()
        {
            try
            {
                comboBoxCategorias.Items.Clear();
                comboBoxCategorias.ValueMember = "Id";
                comboBoxCategorias.DisplayMember = "Nome";
                List<Categoria> categoriasRetorno = new ControleCategoria().ConsultarDadosIdAssunto((comboBoxAssuntos.SelectedItem as Assunto).Id);
                foreach (Categoria categoria in categoriasRetorno)
                {
                    comboBoxCategorias.Items.Add(categoria);
                }
                comboBoxCategorias.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dataGridViewTermos.DataSource = new List<Termo>();
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregarDataGridViewTermos(int idCategoria)
        {
            try
            {
                limparCampos();
                dataGridViewTermos.DataSource = controleTermo.ConsultarDadosIdCategoria(idCategoria);
            }
            catch (Exception)
            {
                //_Nenhum termo cadastrado, mas não é preciso lançar a exceção!
            }
        }

        private void carregarCampos()
        {
            try
            {
                if (dataGridViewTermos.SelectedRows.Count == 1)
                {
                    Termo termoDataGrid = (dataGridViewTermos.SelectedRows[0].DataBoundItem as Termo);
                    textBoxTermo.Text = termoDataGrid.Nome;
                    textBoxCorrespondencia.Text = termoDataGrid.Correspondencia;
                    textBoxDica.Text = termoDataGrid.Dica;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limparCampos()
        {
            try
            {
                textBoxTermo.Clear();
                textBoxCorrespondencia.Clear();
                textBoxDica.Clear();
                dataGridViewTermos.DataSource = new List<Termo>();
                textBoxTermo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region ...BOTÕES...
        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Termo termoCadastrar = new Termo()
                {
                    Nome = textBoxTermo.Text,
                    Correspondencia = textBoxCorrespondencia.Text,
                    Dica = textBoxDica.Text
                };
                int idCategoria = (comboBoxCategorias.SelectedItem as Categoria).Id;
                bool resultado = controleTermo.Cadastrar(idCategoria, termoCadastrar);
                if (resultado)
                {
                    MessageBox.Show("Termo cadastrado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarDataGridViewTermos(idCategoria);
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
                controleTermo.VeriricarTermoSelecionado(dataGridViewTermos.SelectedRows.Count);
                Termo termoAtualizar = new Termo()
                {
                    Id = (dataGridViewTermos.SelectedRows[0].DataBoundItem as Termo).Id,
                    Nome = textBoxTermo.Text,
                    Correspondencia = textBoxCorrespondencia.Text,
                    Dica = textBoxDica.Text
                };
                controleTermo.ValidarCampos(termoAtualizar);
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo atualizar o termo?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleTermo.Atualizar(termoAtualizar);
                    if (resultado)
                    {
                        MessageBox.Show("Termo atualizado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregarDataGridViewTermos((comboBoxCategorias.SelectedItem as Categoria).Id);
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
                controleTermo.VeriricarTermoSelecionado(dataGridViewTermos.SelectedRows.Count);
                Termo termoExcluir = new Termo()
                {
                    Id = (dataGridViewTermos.SelectedRows[0].DataBoundItem as Termo).Id
                };
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir o termo?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleTermo.Excluir(termoExcluir.Id);
                    if (resultado)
                    {
                        MessageBox.Show("Termo excluído com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregarDataGridViewTermos((comboBoxCategorias.SelectedItem as Categoria).Id);
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
        #endregion
    }
}