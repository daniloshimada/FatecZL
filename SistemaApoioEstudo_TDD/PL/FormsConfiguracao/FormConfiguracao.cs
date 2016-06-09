using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsTreino;
using SistemaApoioEstudo.PL.FormsUtilitarios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsConfiguracao
{
    public partial class FormConfiguracao : Form
    {
        private ControleConfiguracao controleConfiguracao;
        private FormMenu formMenu;

        public FormConfiguracao(FormMenu formMenu)
        {
            InitializeComponent();
            controleConfiguracao = new ControleConfiguracao();
            this.formMenu = formMenu;
        }

        private void FormConfiguracao_Shown(object sender, EventArgs e)
        {
            carregarComboBoxAssuntos();
            carregarComboBoxCategorias();
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
                carregarTextBoxTermos();
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

        private void carregarTextBoxTermos()
        {
            try
            {
                int idCategoria = (comboBoxCategorias.SelectedItem as Categoria).Id;
                textBoxTermos.Text = new ControleTermo().ConsultarQuantidadeTermos(idCategoria).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verificarCampos()
        {
            try
            {
                controleConfiguracao.ValidarAssunto(comboBoxAssuntos.SelectedItem as Assunto);
                controleConfiguracao.ValidarCategoria(comboBoxCategorias.SelectedItem as Categoria);
                controleConfiguracao.ValidarTermo(new ControleTermo().ConsultarDadosIdCategoria((comboBoxCategorias.SelectedItem as Categoria).Id));
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
                textBoxTermos.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void buttonTreinar_Click(object sender, EventArgs e)
        {
            try
            {
                verificarCampos();
                Configuracao configuracao = new Configuracao()
                {
                    Assunto = comboBoxAssuntos.SelectedItem as Assunto,
                    Categoria = comboBoxCategorias.SelectedItem as Categoria,
                    Termos = new ControleTermo().ConsultarRandomico((comboBoxCategorias.SelectedItem as Categoria).Id)
                };

                FormTreino formTreino = new FormTreino(formMenu, configuracao);
                formTreino.MdiParent = formMenu;
                formTreino.Show();
                Close();
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