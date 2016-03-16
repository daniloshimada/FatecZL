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

namespace SistemaApoioEstudo.PL.FormsCategoria
{
    public partial class FormCategoria : Form
    {
        private ControleCategoria controleCategoria;
        private ControleAssunto controleAssunto;

        public FormCategoria()
        {
            InitializeComponent();
            controleCategoria = new ControleCategoria();
            controleAssunto = new ControleAssunto();
        }

        private void FormCategoria_Shown(object sender, EventArgs e)
        {
            carregarComboBoxAssuntos();
        }

        private void comboBoxAssuntos_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarComboBoxCategorias();
        }
        private void comboBoxCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxCategoria.Text = (comboBoxCategorias.SelectedItem as Categoria).Nome;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregarTela(int idAssunto, Categoria categoria)
        {
            carregarComboBoxAssuntos(idAssunto);
            carregarComboBoxCategorias(categoria.Id);
        }

        private void carregarComboBoxAssuntos(int idAssunto = 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void carregarComboBoxCategorias(int idCategoria = 0)
        {
            try
            {
                limparCampos();
                comboBoxCategorias.Items.Clear();
                comboBoxCategorias.ValueMember = "Id";
                comboBoxCategorias.DisplayMember = "Nome";
                List<Categoria> categoriasRetorno = controleCategoria.ConsultarDadosIdAssunto((comboBoxAssuntos.SelectedItem as Assunto).Id);
                foreach (Categoria categoria in categoriasRetorno)
                {
                    comboBoxCategorias.Items.Add(categoria);
                }
                for (int i = 0; i < categoriasRetorno.Count; i++)
                {
                    if (categoriasRetorno[i].Id == idCategoria)
                    {
                        comboBoxCategorias.SelectedIndex = i;
                        return;
                    }
                }
                comboBoxCategorias.SelectedIndex = idCategoria;
            }
            catch (Exception)
            {
                //_Nenhuma categoria cadastrada, mas não é preciso lançar a exceção!
            }
        }

        private void limparCampos()
        {
            try
            {
                textBoxCategoria.Clear();
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
                Categoria categoriaCadastrar = new Categoria()
                {
                    Nome = textBoxCategoria.Text
                };
                int idAssunto = (comboBoxAssuntos.SelectedItem as Assunto).Id;
                bool resultado = controleCategoria.Cadastrar(idAssunto, categoriaCadastrar);
                if (resultado)
                {
                    MessageBox.Show("Categoria cadastrada com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    carregarTela(idAssunto, controleCategoria.ConsultarNomeIdAssunto(categoriaCadastrar.Nome, idAssunto));
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