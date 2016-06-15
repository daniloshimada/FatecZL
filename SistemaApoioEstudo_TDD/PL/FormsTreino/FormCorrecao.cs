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

namespace SistemaApoioEstudo.PL.FormsTreino
{
    public partial class FormCorrecao : Form
    {
        private Treino treino;
        private ControleTreino controleTreino;
        private byte quantidadeTestes;
        private sbyte contador;

        public FormCorrecao(Treino treino)
        {
            InitializeComponent();
            this.treino = treino;
            controleTreino = new ControleTreino();
            quantidadeTestes = (byte)treino.Configuracao.Termos.Count;
            contador = -1;
        }

        private void FormCorrecao_Shown(object sender, EventArgs e)
        {
            proximoTeste();
            comboBoxAssunto.Items.Add(treino.Configuracao.Assunto.Nome);
            comboBoxAssunto.SelectedIndex = contador;
            comboBoxCategoria.Items.Add(treino.Configuracao.Categoria.Nome);
            comboBoxCategoria.SelectedIndex = contador;
        }

        private void proximoTeste()
        {
            contador++;
            labelTestes.Text = string.Format("{0} / {1}", contador + 1, quantidadeTestes);
            textBoxTermo.Text = treino.Configuracao.Termos[contador].Nome;
            textBoxCorrespondencia.Text = treino.Configuracao.Termos[contador].Correspondencia;
            textBoxResposta.Text = treino.Respostas[contador];
            radioButtonAcerto.Checked = true;
        }

        private void buttonProximo_Click(object sender, EventArgs e)
        {
            try
            {
                treino.Assercoes.Add(radioButtonAcerto.Checked ? true : false);
                if ((contador + 1) < quantidadeTestes)
                {
                    proximoTeste();
                }
                else
                {
                    controleTreino.ValidarAssercoes(treino.Assercoes);
                    Historico historico = new Historico(treino);
                    historico.Acertos = controleTreino.CalcularAcertos(treino.Assercoes);
                    historico.Erros = controleTreino.CalcularErros(treino.Assercoes);

                    ControleHistorico controleHistorico = new ControleHistorico();
                    controleHistorico.Cadastrar(historico);
                    MessageBox.Show(controleHistorico.GerarRelatorio(historico), "RESULTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao Prosseguir com a Correção!\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}