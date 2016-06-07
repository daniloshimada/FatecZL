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
using SistemaApoioEstudo.PL.FormsConfiguracao;

namespace SistemaApoioEstudo.PL.FormsTreino
{
    public partial class FormTreino : Form
    {
        private Configuracao configuracao;

        public FormTreino(FormConfiguracao formConfiguracao, Configuracao configuracao)
        {
            InitializeComponent();
            formConfiguracao.Close();
            this.configuracao = configuracao;
        }
    }
}
