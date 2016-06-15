namespace SistemaApoioEstudo.PL.FormsHistorico
{
    partial class FormHistorico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelHistoricoMain = new System.Windows.Forms.Label();
            this.labelAssuntos = new System.Windows.Forms.Label();
            this.comboBoxAssuntos = new System.Windows.Forms.ComboBox();
            this.labelCategorias = new System.Windows.Forms.Label();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.dataGridViewHistoricos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcertos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTestes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelHistoricos = new System.Windows.Forms.Label();
            this.labelLinha = new System.Windows.Forms.Label();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoricos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHistoricoMain
            // 
            this.labelHistoricoMain.AutoSize = true;
            this.labelHistoricoMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHistoricoMain.Location = new System.Drawing.Point(241, 9);
            this.labelHistoricoMain.Name = "labelHistoricoMain";
            this.labelHistoricoMain.Size = new System.Drawing.Size(98, 18);
            this.labelHistoricoMain.TabIndex = 0;
            this.labelHistoricoMain.Text = "HISTÓRICO";
            // 
            // labelAssuntos
            // 
            this.labelAssuntos.AutoSize = true;
            this.labelAssuntos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssuntos.Location = new System.Drawing.Point(42, 55);
            this.labelAssuntos.Name = "labelAssuntos";
            this.labelAssuntos.Size = new System.Drawing.Size(88, 18);
            this.labelAssuntos.TabIndex = 1;
            this.labelAssuntos.Text = "Assunto:";
            // 
            // comboBoxAssuntos
            // 
            this.comboBoxAssuntos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssuntos.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAssuntos.FormattingEnabled = true;
            this.comboBoxAssuntos.Location = new System.Drawing.Point(136, 54);
            this.comboBoxAssuntos.Name = "comboBoxAssuntos";
            this.comboBoxAssuntos.Size = new System.Drawing.Size(263, 24);
            this.comboBoxAssuntos.TabIndex = 2;
            this.comboBoxAssuntos.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssuntos_SelectedIndexChanged);
            // 
            // labelCategorias
            // 
            this.labelCategorias.AutoSize = true;
            this.labelCategorias.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategorias.Location = new System.Drawing.Point(22, 85);
            this.labelCategorias.Name = "labelCategorias";
            this.labelCategorias.Size = new System.Drawing.Size(108, 18);
            this.labelCategorias.TabIndex = 3;
            this.labelCategorias.Text = "Categoria:";
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(136, 84);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(423, 24);
            this.comboBoxCategorias.TabIndex = 4;
            this.comboBoxCategorias.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategorias_SelectedIndexChanged);
            // 
            // dataGridViewHistoricos
            // 
            this.dataGridViewHistoricos.AllowUserToAddRows = false;
            this.dataGridViewHistoricos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewHistoricos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHistoricos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewHistoricos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoricos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colData,
            this.colTempo,
            this.colAcertos,
            this.colTestes});
            this.dataGridViewHistoricos.Location = new System.Drawing.Point(136, 133);
            this.dataGridViewHistoricos.MultiSelect = false;
            this.dataGridViewHistoricos.Name = "dataGridViewHistoricos";
            this.dataGridViewHistoricos.ReadOnly = true;
            this.dataGridViewHistoricos.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.dataGridViewHistoricos.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewHistoricos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewHistoricos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewHistoricos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistoricos.Size = new System.Drawing.Size(423, 150);
            this.dataGridViewHistoricos.TabIndex = 7;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colId.DefaultCellStyle = dataGridViewCellStyle3;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colData
            // 
            this.colData.DataPropertyName = "Data";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colData.DefaultCellStyle = dataGridViewCellStyle4;
            this.colData.HeaderText = "DATA";
            this.colData.MaxInputLength = 300;
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 115;
            // 
            // colTempo
            // 
            this.colTempo.DataPropertyName = "Tempo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTempo.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTempo.HeaderText = "TEMPO";
            this.colTempo.Name = "colTempo";
            this.colTempo.ReadOnly = true;
            this.colTempo.Width = 115;
            // 
            // colAcertos
            // 
            this.colAcertos.DataPropertyName = "Acertos";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAcertos.DefaultCellStyle = dataGridViewCellStyle6;
            this.colAcertos.HeaderText = "ACERTOS";
            this.colAcertos.Name = "colAcertos";
            this.colAcertos.ReadOnly = true;
            // 
            // colTestes
            // 
            this.colTestes.DataPropertyName = "Testes";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTestes.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTestes.HeaderText = "TESTES";
            this.colTestes.Name = "colTestes";
            this.colTestes.ReadOnly = true;
            // 
            // labelHistoricos
            // 
            this.labelHistoricos.AutoSize = true;
            this.labelHistoricos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHistoricos.Location = new System.Drawing.Point(12, 133);
            this.labelHistoricos.Name = "labelHistoricos";
            this.labelHistoricos.Size = new System.Drawing.Size(118, 18);
            this.labelHistoricos.TabIndex = 6;
            this.labelHistoricos.Text = "Históricos:";
            // 
            // labelLinha
            // 
            this.labelLinha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLinha.Location = new System.Drawing.Point(12, 119);
            this.labelLinha.Name = "labelLinha";
            this.labelLinha.Size = new System.Drawing.Size(547, 3);
            this.labelLinha.TabIndex = 5;
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.AutoSize = true;
            this.buttonExcluir.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluir.Location = new System.Drawing.Point(329, 313);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(108, 28);
            this.buttonExcluir.TabIndex = 9;
            this.buttonExcluir.Text = "EXCLUIR";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(451, 313);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 10;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonConsultar
            // 
            this.buttonConsultar.AutoSize = true;
            this.buttonConsultar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConsultar.Location = new System.Drawing.Point(207, 313);
            this.buttonConsultar.Name = "buttonConsultar";
            this.buttonConsultar.Size = new System.Drawing.Size(108, 28);
            this.buttonConsultar.TabIndex = 8;
            this.buttonConsultar.Text = "CONSULTAR";
            this.buttonConsultar.UseVisualStyleBackColor = true;
            this.buttonConsultar.Click += new System.EventHandler(this.buttonConsultar_Click);
            // 
            // FormHistorico
            // 
            this.AcceptButton = this.buttonConsultar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(571, 353);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonConsultar);
            this.Controls.Add(this.labelLinha);
            this.Controls.Add(this.dataGridViewHistoricos);
            this.Controls.Add(this.labelHistoricos);
            this.Controls.Add(this.labelHistoricoMain);
            this.Controls.Add(this.labelAssuntos);
            this.Controls.Add(this.comboBoxAssuntos);
            this.Controls.Add(this.labelCategorias);
            this.Controls.Add(this.comboBoxCategorias);
            this.Name = "FormHistorico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HISTÓRICO";
            this.Shown += new System.EventHandler(this.FormHistorico_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoricos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHistoricoMain;
        private System.Windows.Forms.Label labelAssuntos;
        private System.Windows.Forms.ComboBox comboBoxAssuntos;
        private System.Windows.Forms.Label labelCategorias;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.DataGridView dataGridViewHistoricos;
        private System.Windows.Forms.Label labelHistoricos;
        private System.Windows.Forms.Label labelLinha;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonConsultar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcertos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTestes;
    }
}