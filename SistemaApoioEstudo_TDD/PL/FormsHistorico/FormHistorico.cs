using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsUtilitarios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsHistorico
{
    public partial class FormHistorico : Form
    {
        private ControleHistorico controleHistorico;
        private FormMenu formMenu;

        public FormHistorico(FormMenu formMenu)
        {
            InitializeComponent();
            controleHistorico = new ControleHistorico();
            this.formMenu = formMenu;
        }

        private void FormHistorico_Shown(object sender, EventArgs e)
        {
            carregarComboBoxAssuntos();
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
                carregarDataGridViewHistorico((comboBoxCategorias.SelectedItem as Categoria).Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            catch (Exception)
            {
                limparCampos();
            }
        }

        private void carregarDataGridViewHistorico(int idCategoria)
        {
            try
            {
                limparCampos();
                foreach (Historico historico in controleHistorico.Consultar(idCategoria))
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dataGridViewHistoricos);
                    dgvRow.Cells[0].Value = historico.Id.ToString();
                    dgvRow.Cells[1].Value = historico.Data.ToShortDateString();
                    dgvRow.Cells[2].Value = historico.Treino.Tempo.ToString();
                    dgvRow.Cells[3].Value = historico.Acertos.ToString();
                    dgvRow.Cells[4].Value = (historico.Acertos + historico.Erros).ToString();
                    dataGridViewHistoricos.Rows.Add(dgvRow);
                }
            }
            catch (Exception)
            {
                limparCampos();
                //_Nenhum termo cadastrado, mas não é preciso lançar a exceção!
            }
        }

        private void verificarDataGridViewHistoricos()
        {
            try
            {
                if (dataGridViewHistoricos.SelectedRows.Count < 1)
                {
                    throw new Exception("Nenhum histórico selecionado!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void limparCampos()
        {
            try
            {
                dataGridViewHistoricos.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                verificarDataGridViewHistoricos();
                Configuracao configuracao = new Configuracao()
                {
                    Assunto = (comboBoxAssuntos.SelectedItem) as Assunto,
                    Categoria = (comboBoxCategorias.SelectedItem) as Categoria
                };
                Treino treino = new Treino(configuracao);
                Historico historico = new Historico(treino)
                {
                    Id = Convert.ToInt32(dataGridViewHistoricos.SelectedRows[0].Cells[0].Value),

                };
                FormHistoricoConsultar formHistoricoConsultar = new FormHistoricoConsultar(historico);
                formHistoricoConsultar.MdiParent = formMenu;
                formHistoricoConsultar.Show();
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
                verificarDataGridViewHistoricos();
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir o histórico?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleHistorico.Excluir(Convert.ToInt32(dataGridViewHistoricos.SelectedRows[0].Cells[0].Value));
                    if (resultado)
                    {
                        MessageBox.Show("Histórico excluído com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregarDataGridViewHistorico((comboBoxCategorias.SelectedItem as Categoria).Id);
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