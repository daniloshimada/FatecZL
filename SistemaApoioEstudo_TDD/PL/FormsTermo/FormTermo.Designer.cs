namespace SistemaApoioEstudo.PL.FormsTermo
{
    partial class FormTermo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelLinha = new System.Windows.Forms.Label();
            this.labelAssuntos = new System.Windows.Forms.Label();
            this.comboBoxAssuntos = new System.Windows.Forms.ComboBox();
            this.labelCategorias = new System.Windows.Forms.Label();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonAtualizar = new System.Windows.Forms.Button();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.labelTermoMain = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.labelTermos = new System.Windows.Forms.Label();
            this.dataGridViewTermos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorrespondencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTermo = new System.Windows.Forms.Label();
            this.textBoxTermo = new System.Windows.Forms.TextBox();
            this.labelCorrespondencia = new System.Windows.Forms.Label();
            this.textBoxCorrespondencia = new System.Windows.Forms.TextBox();
            this.labelDica = new System.Windows.Forms.Label();
            this.textBoxDica = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTermos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLinha
            // 
            this.labelLinha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLinha.Location = new System.Drawing.Point(12, 275);
            this.labelLinha.Name = "labelLinha";
            this.labelLinha.Size = new System.Drawing.Size(609, 3);
            this.labelLinha.TabIndex = 7;
            // 
            // labelAssuntos
            // 
            this.labelAssuntos.AutoSize = true;
            this.labelAssuntos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssuntos.Location = new System.Drawing.Point(29, 55);
            this.labelAssuntos.Name = "labelAssuntos";
            this.labelAssuntos.Size = new System.Drawing.Size(98, 18);
            this.labelAssuntos.TabIndex = 1;
            this.labelAssuntos.Text = "Assuntos:";
            // 
            // comboBoxAssuntos
            // 
            this.comboBoxAssuntos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssuntos.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAssuntos.FormattingEnabled = true;
            this.comboBoxAssuntos.Location = new System.Drawing.Point(133, 54);
            this.comboBoxAssuntos.Name = "comboBoxAssuntos";
            this.comboBoxAssuntos.Size = new System.Drawing.Size(263, 24);
            this.comboBoxAssuntos.TabIndex = 2;
            this.comboBoxAssuntos.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssuntos_SelectedIndexChanged);
            // 
            // labelCategorias
            // 
            this.labelCategorias.AutoSize = true;
            this.labelCategorias.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategorias.Location = new System.Drawing.Point(9, 85);
            this.labelCategorias.Name = "labelCategorias";
            this.labelCategorias.Size = new System.Drawing.Size(118, 18);
            this.labelCategorias.TabIndex = 3;
            this.labelCategorias.Text = "Categorias:";
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.AutoSize = true;
            this.buttonExcluir.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluir.Location = new System.Drawing.Point(391, 545);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(108, 28);
            this.buttonExcluir.TabIndex = 16;
            this.buttonExcluir.Text = "EXCLUIR";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.AutoSize = true;
            this.buttonAtualizar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtualizar.Location = new System.Drawing.Point(269, 545);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(108, 28);
            this.buttonAtualizar.TabIndex = 15;
            this.buttonAtualizar.Text = "ATUALIZAR";
            this.buttonAtualizar.UseVisualStyleBackColor = true;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // comboBoxCategorias
            // 
            this.comboBoxCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategorias.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategorias.FormattingEnabled = true;
            this.comboBoxCategorias.Location = new System.Drawing.Point(133, 84);
            this.comboBoxCategorias.Name = "comboBoxCategorias";
            this.comboBoxCategorias.Size = new System.Drawing.Size(423, 24);
            this.comboBoxCategorias.TabIndex = 4;
            this.comboBoxCategorias.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategorias_SelectedIndexChanged);
            // 
            // labelTermoMain
            // 
            this.labelTermoMain.AutoSize = true;
            this.labelTermoMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermoMain.Location = new System.Drawing.Point(287, 9);
            this.labelTermoMain.Name = "labelTermoMain";
            this.labelTermoMain.Size = new System.Drawing.Size(58, 18);
            this.labelTermoMain.TabIndex = 0;
            this.labelTermoMain.Text = "TERMO";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(513, 545);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 17;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.AutoSize = true;
            this.buttonCadastrar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastrar.Location = new System.Drawing.Point(147, 545);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(108, 28);
            this.buttonCadastrar.TabIndex = 14;
            this.buttonCadastrar.Text = "CADASTRAR";
            this.buttonCadastrar.UseVisualStyleBackColor = true;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // labelTermos
            // 
            this.labelTermos.AutoSize = true;
            this.labelTermos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermos.Location = new System.Drawing.Point(49, 114);
            this.labelTermos.Name = "labelTermos";
            this.labelTermos.Size = new System.Drawing.Size(78, 18);
            this.labelTermos.TabIndex = 5;
            this.labelTermos.Text = "Termos:";
            // 
            // dataGridViewTermos
            // 
            this.dataGridViewTermos.AllowUserToAddRows = false;
            this.dataGridViewTermos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTermos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTermos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTermos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTermos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNome,
            this.colCorrespondencia,
            this.colDica});
            this.dataGridViewTermos.Location = new System.Drawing.Point(133, 114);
            this.dataGridViewTermos.MultiSelect = false;
            this.dataGridViewTermos.Name = "dataGridViewTermos";
            this.dataGridViewTermos.ReadOnly = true;
            this.dataGridViewTermos.RowHeadersVisible = false;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            this.dataGridViewTermos.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTermos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTermos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewTermos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTermos.Size = new System.Drawing.Size(488, 150);
            this.dataGridViewTermos.TabIndex = 6;
            this.dataGridViewTermos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTermos_RowEnter);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colId.DefaultCellStyle = dataGridViewCellStyle24;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colNome
            // 
            this.colNome.DataPropertyName = "Nome";
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNome.DefaultCellStyle = dataGridViewCellStyle25;
            this.colNome.HeaderText = "TERMO";
            this.colNome.MaxInputLength = 300;
            this.colNome.Name = "colNome";
            this.colNome.ReadOnly = true;
            this.colNome.Width = 485;
            // 
            // colCorrespondencia
            // 
            this.colCorrespondencia.DataPropertyName = "Correspondencia";
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCorrespondencia.DefaultCellStyle = dataGridViewCellStyle26;
            this.colCorrespondencia.HeaderText = "CORRESPONDÊNCIA";
            this.colCorrespondencia.Name = "colCorrespondencia";
            this.colCorrespondencia.ReadOnly = true;
            this.colCorrespondencia.Visible = false;
            // 
            // colDica
            // 
            this.colDica.DataPropertyName = "Dica";
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDica.DefaultCellStyle = dataGridViewCellStyle27;
            this.colDica.HeaderText = "DICA";
            this.colDica.Name = "colDica";
            this.colDica.ReadOnly = true;
            this.colDica.Visible = false;
            // 
            // labelTermo
            // 
            this.labelTermo.AutoSize = true;
            this.labelTermo.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermo.Location = new System.Drawing.Point(12, 286);
            this.labelTermo.Name = "labelTermo";
            this.labelTermo.Size = new System.Drawing.Size(68, 18);
            this.labelTermo.TabIndex = 8;
            this.labelTermo.Text = "Termo:";
            // 
            // textBoxTermo
            // 
            this.textBoxTermo.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTermo.Location = new System.Drawing.Point(12, 307);
            this.textBoxTermo.Multiline = true;
            this.textBoxTermo.Name = "textBoxTermo";
            this.textBoxTermo.Size = new System.Drawing.Size(609, 70);
            this.textBoxTermo.TabIndex = 9;
            // 
            // labelCorrespondencia
            // 
            this.labelCorrespondencia.AutoSize = true;
            this.labelCorrespondencia.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorrespondencia.Location = new System.Drawing.Point(12, 380);
            this.labelCorrespondencia.Name = "labelCorrespondencia";
            this.labelCorrespondencia.Size = new System.Drawing.Size(168, 18);
            this.labelCorrespondencia.TabIndex = 10;
            this.labelCorrespondencia.Text = "Correspondência:";
            // 
            // textBoxCorrespondencia
            // 
            this.textBoxCorrespondencia.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCorrespondencia.Location = new System.Drawing.Point(12, 401);
            this.textBoxCorrespondencia.Multiline = true;
            this.textBoxCorrespondencia.Name = "textBoxCorrespondencia";
            this.textBoxCorrespondencia.Size = new System.Drawing.Size(609, 70);
            this.textBoxCorrespondencia.TabIndex = 11;
            // 
            // labelDica
            // 
            this.labelDica.AutoSize = true;
            this.labelDica.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDica.Location = new System.Drawing.Point(69, 478);
            this.labelDica.Name = "labelDica";
            this.labelDica.Size = new System.Drawing.Size(58, 18);
            this.labelDica.TabIndex = 12;
            this.labelDica.Text = "Dica:";
            // 
            // textBoxDica
            // 
            this.textBoxDica.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDica.Location = new System.Drawing.Point(133, 477);
            this.textBoxDica.Multiline = true;
            this.textBoxDica.Name = "textBoxDica";
            this.textBoxDica.Size = new System.Drawing.Size(409, 38);
            this.textBoxDica.TabIndex = 13;
            // 
            // FormTermo
            // 
            this.AcceptButton = this.buttonCadastrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(633, 585);
            this.Controls.Add(this.labelDica);
            this.Controls.Add(this.textBoxDica);
            this.Controls.Add(this.labelCorrespondencia);
            this.Controls.Add(this.textBoxCorrespondencia);
            this.Controls.Add(this.labelTermo);
            this.Controls.Add(this.textBoxTermo);
            this.Controls.Add(this.dataGridViewTermos);
            this.Controls.Add(this.labelTermos);
            this.Controls.Add(this.labelLinha);
            this.Controls.Add(this.labelAssuntos);
            this.Controls.Add(this.comboBoxAssuntos);
            this.Controls.Add(this.labelCategorias);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonAtualizar);
            this.Controls.Add(this.comboBoxCategorias);
            this.Controls.Add(this.labelTermoMain);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCadastrar);
            this.Name = "FormTermo";
            this.Text = "TERMO";
            this.Shown += new System.EventHandler(this.FormTermo_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTermos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLinha;
        private System.Windows.Forms.Label labelAssuntos;
        private System.Windows.Forms.ComboBox comboBoxAssuntos;
        private System.Windows.Forms.Label labelCategorias;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.Label labelTermoMain;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.Label labelTermos;
        private System.Windows.Forms.DataGridView dataGridViewTermos;
        private System.Windows.Forms.Label labelTermo;
        private System.Windows.Forms.TextBox textBoxTermo;
        private System.Windows.Forms.Label labelCorrespondencia;
        private System.Windows.Forms.TextBox textBoxCorrespondencia;
        private System.Windows.Forms.Label labelDica;
        private System.Windows.Forms.TextBox textBoxDica;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorrespondencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDica;
    }
}