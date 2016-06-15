namespace SistemaApoioEstudo.PL.FormsHistorico
{
    partial class FormHistoricoConsultar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelHistoricoMain = new System.Windows.Forms.Label();
            this.labelAssuntos = new System.Windows.Forms.Label();
            this.comboBoxAssuntos = new System.Windows.Forms.ComboBox();
            this.labelCategorias = new System.Windows.Forms.Label();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.dataGridViewTermos = new System.Windows.Forms.DataGridView();
            this.labelTermos = new System.Windows.Forms.Label();
            this.labelResposta = new System.Windows.Forms.Label();
            this.textBoxResposta = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.labelCorrespondencia = new System.Windows.Forms.Label();
            this.textBoxCorrespondencia = new System.Windows.Forms.TextBox();
            this.labelTermo = new System.Windows.Forms.Label();
            this.textBoxTermo = new System.Windows.Forms.TextBox();
            this.labelLinha = new System.Windows.Forms.Label();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorrespondencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResposta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTermos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHistoricoMain
            // 
            this.labelHistoricoMain.AutoSize = true;
            this.labelHistoricoMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHistoricoMain.Location = new System.Drawing.Point(217, 9);
            this.labelHistoricoMain.Name = "labelHistoricoMain";
            this.labelHistoricoMain.Size = new System.Drawing.Size(198, 18);
            this.labelHistoricoMain.TabIndex = 0;
            this.labelHistoricoMain.Text = "CONSULTAR HISTÓRICO";
            // 
            // labelAssuntos
            // 
            this.labelAssuntos.AutoSize = true;
            this.labelAssuntos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssuntos.Location = new System.Drawing.Point(32, 55);
            this.labelAssuntos.Name = "labelAssuntos";
            this.labelAssuntos.Size = new System.Drawing.Size(88, 18);
            this.labelAssuntos.TabIndex = 1;
            this.labelAssuntos.Text = "Assunto:";
            // 
            // comboBoxAssuntos
            // 
            this.comboBoxAssuntos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssuntos.Enabled = false;
            this.comboBoxAssuntos.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAssuntos.FormattingEnabled = true;
            this.comboBoxAssuntos.Location = new System.Drawing.Point(126, 54);
            this.comboBoxAssuntos.Name = "comboBoxAssuntos";
            this.comboBoxAssuntos.Size = new System.Drawing.Size(263, 24);
            this.comboBoxAssuntos.TabIndex = 2;
            // 
            // labelCategorias
            // 
            this.labelCategorias.AutoSize = true;
            this.labelCategorias.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategorias.Location = new System.Drawing.Point(12, 85);
            this.labelCategorias.Name = "labelCategorias";
            this.labelCategorias.Size = new System.Drawing.Size(108, 18);
            this.labelCategorias.TabIndex = 3;
            this.labelCategorias.Text = "Categoria:";
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.Enabled = false;
            this.comboBoxCategorias.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(126, 84);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(423, 24);
            this.comboBoxCategorias.TabIndex = 4;
            // 
            // dataGridViewTermos
            // 
            this.dataGridViewTermos.AllowUserToAddRows = false;
            this.dataGridViewTermos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTermos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTermos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTermos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTermos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNome,
            this.colCorrespondencia,
            this.colResposta,
            this.colResultado});
            this.dataGridViewTermos.Location = new System.Drawing.Point(126, 133);
            this.dataGridViewTermos.MultiSelect = false;
            this.dataGridViewTermos.Name = "dataGridViewTermos";
            this.dataGridViewTermos.ReadOnly = true;
            this.dataGridViewTermos.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dataGridViewTermos.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTermos.RowTemplate.ReadOnly = true;
            this.dataGridViewTermos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTermos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewTermos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTermos.Size = new System.Drawing.Size(488, 150);
            this.dataGridViewTermos.TabIndex = 7;
            this.dataGridViewTermos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTermos_RowEnter);
            // 
            // labelTermos
            // 
            this.labelTermos.AutoSize = true;
            this.labelTermos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermos.Location = new System.Drawing.Point(42, 133);
            this.labelTermos.Name = "labelTermos";
            this.labelTermos.Size = new System.Drawing.Size(78, 18);
            this.labelTermos.TabIndex = 6;
            this.labelTermos.Text = "Termos:";
            // 
            // labelResposta
            // 
            this.labelResposta.AutoSize = true;
            this.labelResposta.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResposta.Location = new System.Drawing.Point(12, 474);
            this.labelResposta.Name = "labelResposta";
            this.labelResposta.Size = new System.Drawing.Size(98, 18);
            this.labelResposta.TabIndex = 12;
            this.labelResposta.Text = "Resposta:";
            // 
            // textBoxResposta
            // 
            this.textBoxResposta.Enabled = false;
            this.textBoxResposta.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResposta.Location = new System.Drawing.Point(12, 495);
            this.textBoxResposta.Multiline = true;
            this.textBoxResposta.Name = "textBoxResposta";
            this.textBoxResposta.Size = new System.Drawing.Size(609, 70);
            this.textBoxResposta.TabIndex = 13;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(513, 595);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 14;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // labelCorrespondencia
            // 
            this.labelCorrespondencia.AutoSize = true;
            this.labelCorrespondencia.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorrespondencia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCorrespondencia.Location = new System.Drawing.Point(12, 380);
            this.labelCorrespondencia.Name = "labelCorrespondencia";
            this.labelCorrespondencia.Size = new System.Drawing.Size(168, 18);
            this.labelCorrespondencia.TabIndex = 10;
            this.labelCorrespondencia.Text = "Correspondência:";
            // 
            // textBoxCorrespondencia
            // 
            this.textBoxCorrespondencia.Enabled = false;
            this.textBoxCorrespondencia.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCorrespondencia.Location = new System.Drawing.Point(12, 401);
            this.textBoxCorrespondencia.Multiline = true;
            this.textBoxCorrespondencia.Name = "textBoxCorrespondencia";
            this.textBoxCorrespondencia.Size = new System.Drawing.Size(609, 70);
            this.textBoxCorrespondencia.TabIndex = 11;
            // 
            // labelTermo
            // 
            this.labelTermo.AutoSize = true;
            this.labelTermo.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTermo.Location = new System.Drawing.Point(12, 286);
            this.labelTermo.Name = "labelTermo";
            this.labelTermo.Size = new System.Drawing.Size(68, 18);
            this.labelTermo.TabIndex = 8;
            this.labelTermo.Text = "Termo:";
            // 
            // textBoxTermo
            // 
            this.textBoxTermo.Enabled = false;
            this.textBoxTermo.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTermo.Location = new System.Drawing.Point(12, 307);
            this.textBoxTermo.Multiline = true;
            this.textBoxTermo.Name = "textBoxTermo";
            this.textBoxTermo.Size = new System.Drawing.Size(609, 70);
            this.textBoxTermo.TabIndex = 9;
            // 
            // labelLinha
            // 
            this.labelLinha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLinha.Location = new System.Drawing.Point(12, 119);
            this.labelLinha.Name = "labelLinha";
            this.labelLinha.Size = new System.Drawing.Size(609, 3);
            this.labelLinha.TabIndex = 5;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "Nome";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNome.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNome.HeaderText = "TERMO";
            this.colNome.MaxInputLength = 300;
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 435;
            // 
            // colCorrespondencia
            // 
            this.colCorrespondencia.HeaderText = "CORRESPONDÊNCIA";
            this.colCorrespondencia.Name = "colCorrespondencia";
            this.colCorrespondencia.ReadOnly = true;
            this.colCorrespondencia.Visible = false;
            // 
            // colResposta
            // 
            this.colResposta.HeaderText = "RESPOSTA";
            this.colResposta.Name = "colResposta";
            this.colResposta.ReadOnly = true;
            this.colResposta.Visible = false;
            // 
            // colResultado
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colResultado.DefaultCellStyle = dataGridViewCellStyle4;
            this.colResultado.HeaderText = "O / X";
            this.colResultado.Name = "colResultado";
            this.colResultado.ReadOnly = true;
            this.colResultado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colResultado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colResultado.Width = 50;
            // 
            // FormHistoricoConsultar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(633, 635);
            this.Controls.Add(this.labelLinha);
            this.Controls.Add(this.labelResposta);
            this.Controls.Add(this.textBoxResposta);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelCorrespondencia);
            this.Controls.Add(this.textBoxCorrespondencia);
            this.Controls.Add(this.labelTermo);
            this.Controls.Add(this.textBoxTermo);
            this.Controls.Add(this.dataGridViewTermos);
            this.Controls.Add(this.labelTermos);
            this.Controls.Add(this.labelHistoricoMain);
            this.Controls.Add(this.labelAssuntos);
            this.Controls.Add(this.comboBoxAssuntos);
            this.Controls.Add(this.labelCategorias);
            this.Controls.Add(this.comboBoxCategorias);
            this.Name = "FormHistoricoConsultar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HISTÓRICO";
            this.Shown += new System.EventHandler(this.FormHistoricoConsultar_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTermos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHistoricoMain;
        private System.Windows.Forms.Label labelAssuntos;
        private System.Windows.Forms.ComboBox comboBoxAssuntos;
        private System.Windows.Forms.Label labelCategorias;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.DataGridView dataGridViewTermos;
        private System.Windows.Forms.Label labelTermos;
        private System.Windows.Forms.Label labelResposta;
        private System.Windows.Forms.TextBox textBoxResposta;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label labelCorrespondencia;
        private System.Windows.Forms.TextBox textBoxCorrespondencia;
        private System.Windows.Forms.Label labelTermo;
        private System.Windows.Forms.TextBox textBoxTermo;
        private System.Windows.Forms.Label labelLinha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorrespondencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResposta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResultado;
    }
}