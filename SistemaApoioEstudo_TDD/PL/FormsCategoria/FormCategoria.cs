using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsCategoria
{
    public partial class FormCategoria : Form
    {
        private ControleCategoria controleCategoria;

        public FormCategoria()
        {
            InitializeComponent();
            controleCategoria = new ControleCategoria();
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

        private void carregarTela(int idAssunto=0, int idCategoria=0)
        {
            carregarComboBoxAssuntos(idAssunto);
            carregarComboBoxCategorias(idCategoria);
        }

        private void carregarComboBoxAssuntos(int idAssunto = 0)
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
                    carregarTela(idAssunto, controleCategoria.ConsultarNomeIdAssunto(categoriaCadastrar.Nome, idAssunto).Id);
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
                controleCategoria.VerificarCategoriaSelecionada(comboBoxCategorias.SelectedIndex);
                Categoria categoriaAtualizar = new Categoria()
                {
                    Id = (comboBoxCategorias.SelectedItem as Categoria).Id,
                    Nome = textBoxCategoria.Text
                };
                controleCategoria.ValidarCampos(categoriaAtualizar);
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo atualizar a categoria?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleCategoria.Atualizar(categoriaAtualizar);
                    if (resultado)
                    {
                        MessageBox.Show("Categoria atualizada com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregarTela((comboBoxAssuntos.SelectedItem as Assunto).Id, categoriaAtualizar.Id);
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
                controleCategoria.VerificarCategoriaSelecionada(comboBoxCategorias.SelectedIndex);
                Categoria categoriaExcluir = new Categoria()
                {
                    Id = (comboBoxCategorias.SelectedItem as Categoria).Id
                };
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir a categoria?", "CONFIRMAÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.OK)
                {
                    bool resultado = controleCategoria.Excluir(categoriaExcluir.Id);
                    if (resultado)
                    {
                        MessageBox.Show("Categoria excluída com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carregarTela((comboBoxAssuntos.SelectedItem as Assunto).Id);
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