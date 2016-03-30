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

namespace SistemaApoioEstudo.PL.FormsTermo
{
    public partial class FormTermo : Form
    {
        private ControleTermo controleTermo;
        private ControleAssunto controleAssunto;
        private ControleCategoria controleCategoria;

        public FormTermo()
        {
            InitializeComponent();
            controleTermo = new ControleTermo();
            controleAssunto = new ControleAssunto();
            controleCategoria = new ControleCategoria();
        }

        private void FormTermo_Shown(object sender, EventArgs e)
        {
            carregarComboBoxAssuntos();
        }

        private void comboBoxAssuntos_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarComboBoxCategorias();
        }

        private void comboBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarDataGridViewTermos((comboBoxCategorias.SelectedItem as Categoria).Id);
        }

        private void dataGridViewTermos_RowEnter(object sender, DataGridViewCellEventArgs e)
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

        private void carregarComboBoxAssuntos()
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
                List<Categoria> categoriasRetorno = controleCategoria.ConsultarDadosIdAssunto((comboBoxAssuntos.SelectedItem as Assunto).Id);
                foreach (Categoria categoria in categoriasRetorno)
                {
                    comboBoxCategorias.Items.Add(categoria);
                }
                comboBoxCategorias.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
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

        private void limparCampos()
        {
            try
            {
                textBoxTermo.Clear();
                textBoxCorrespondencia.Clear();
                textBoxDica.Clear();
                dataGridViewTermos.DataSource = new List<Termo>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}