using SistemaApoioEstudo.BLL.Controles;
using SistemaApoioEstudo.BLL.Entidades;
using SistemaApoioEstudo.PL.FormsUtilitarios;
using System;
using System.Windows.Forms;

namespace SistemaApoioEstudo.PL.FormsTreino
{
    public partial class FormTreino : Form
    {
        private FormMenu formMenu;
        private Treino treino;
        private ControleTreino controleTreino;
        private byte quantidadeTestes;
        private sbyte contador;

        public FormTreino(FormMenu formMenu, Configuracao configuracao)
        {
            InitializeComponent();
            this.formMenu = formMenu;
            treino = new Treino(configuracao);
            quantidadeTestes = (byte)treino.Configuracao.Termos.Count;
            contador = -1;
            controleTreino = new ControleTreino();
            controleTreino.ValidarConfiguracao(treino.Configuracao);
        }

        private void FormTreino_Shown(object sender, EventArgs e)
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
            textBoxResposta.Text = string.Empty;
            textBoxDica.Text = treino.Configuracao.Termos[contador].Dica;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte segundos = Convert.ToByte(labelSegundos.Text);
            if (segundos < 9)
            {
                labelSegundos.Text = "0" + (++segundos).ToString();
            }
            else if ((segundos > 8) && (segundos < 59))
            {
                labelSegundos.Text = (++segundos).ToString();
            }
            else if (segundos == 59)
            {
                labelSegundos.Text = "00";

                //Minutos
                byte minutos = Convert.ToByte(labelMinutos.Text);
                if (minutos < 9)
                {
                    labelMinutos.Text = "0" + (++minutos).ToString();
                }
                else if ((minutos > 8) && (minutos < 59))
                {
                    labelMinutos.Text = (++minutos).ToString();
                }
                else if (minutos == 59)
                {
                    labelMinutos.Text = "00";

                    //Horas
                    byte horas = Convert.ToByte(labelHoras.Text);
                    if (horas < 9)
                    {
                        labelHoras.Text = "0" + (++horas).ToString();
                    }
                    else if ((horas > 8) && (horas < 23))
                    {
                        labelHoras.Text = (++horas).ToString();
                    }
                }
            }
        }

        #region ...BUTTONS...
        private void buttonDica_Click(object sender, EventArgs e)
        {
            textBoxResposta.Focus();
            if (textBoxDica.Visible == false)
            {
                textBoxDica.Visible = true;
                return;
            }
            textBoxDica.Visible = false;
        }

        private void buttonProximo_Click(object sender, EventArgs e)
        {
            try
            {
                treino.Respostas.Add(textBoxResposta.Text);
                if ((contador + 1) < quantidadeTestes)
                {
                    proximoTeste();
                }
                else
                {
                    treino.Tempo = TimeSpan.Parse(string.Format("{0}:{1}:{2}", labelHoras.Text, labelMinutos.Text, labelSegundos.Text));
                    controleTreino.ValidarRespostas(treino.Respostas);
                    FormCorrecao formCorrecao = new FormCorrecao(treino);
                    formCorrecao.MdiParent = formMenu;
                    formCorrecao.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao Prosseguir com o Treino!\n" + ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBoxResposta.Focus();
                textBoxDica.Visible = false;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        } 
        #endregion
    }
}
