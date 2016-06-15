using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsHistorico
{
    public partial class FormHistoricoConsultar : Form
    {
        private Historico historico;
        private ControleHistorico controleHistorico;

        public FormHistoricoConsultar(Historico historico)
        {
            InitializeComponent();
            this.historico = historico;
            controleHistorico = new ControleHistorico();
        }

        private void FormHistoricoConsultar_Shown(object sender, EventArgs e)
        {
            try
            {
                comboBoxAssuntos.Items.Add(historico.Treino.Configuracao.Assunto.Nome.ToString());
                comboBoxCategorias.Items.Add(historico.Treino.Configuracao.Categoria.Nome.ToString());
                comboBoxAssuntos.SelectedIndex = 0;
                comboBoxCategorias.SelectedIndex = 0;
                carregarDataGridViewTermos();
                carregarCampos();
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
                if (dataGridViewTermos.SelectedRows.Count > 0)
                {
                    carregarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregarDataGridViewTermos()
        {
            try
            {
                foreach (Historico historicoForeach in controleHistorico.ConsultarTermos(historico.Id))
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dataGridViewTermos);
                    for (int count = 0; count < historicoForeach.Treino.Configuracao.Termos.Count; count++)
                    {
                        dgvRow.Cells[0].Value = historicoForeach.Treino.Configuracao.Termos[count].Nome.ToString();
                        dgvRow.Cells[1].Value = historicoForeach.Treino.Configuracao.Termos[count].Correspondencia.ToString();
                        dgvRow.Cells[2].Value = historicoForeach.Treino.Respostas[count].ToString();
                        dgvRow.Cells[3].Value = historicoForeach.Treino.Assercoes[count] ? "O" : "X";
                        if (dgvRow.Cells[3].Value.Equals("O"))
                        {
                            dgvRow.DefaultCellStyle.ForeColor = Color.Blue;
                        }
                        else
                        {
                            dgvRow.DefaultCellStyle.ForeColor = Color.Red;
                        }
                        dataGridViewTermos.Rows.Add(dgvRow);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void carregarCampos()
        {
            try
            {
                textBoxTermo.Text = dataGridViewTermos.SelectedRows[0].Cells[0].Value.ToString();
                textBoxCorrespondencia.Text = dataGridViewTermos.SelectedRows[0].Cells[1].Value.ToString();
                textBoxResposta.Text = dataGridViewTermos.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}