namespace SistemaApoioEstudo.PL.FormsConfiguracao
{
    partial class FormConfiguracao
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
            this.labelAssuntos = new System.Windows.Forms.Label();
            this.comboBoxAssuntos = new System.Windows.Forms.ComboBox();
            this.labelCategorias = new System.Windows.Forms.Label();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.labelTermos = new System.Windows.Forms.Label();
            this.textBoxTermos = new System.Windows.Forms.TextBox();
            this.labelConfiguracaoMain = new System.Windows.Forms.Label();
            this.buttonTreinar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAssuntos
            // 
            this.labelAssuntos.AutoSize = true;
            this.labelAssuntos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssuntos.Location = new System.Drawing.Point(34, 55);
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
            this.labelCategorias.Location = new System.Drawing.Point(12, 85);
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
            // labelTermos
            // 
            this.labelTermos.AutoSize = true;
            this.labelTermos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermos.Location = new System.Drawing.Point(52, 115);
            this.labelTermos.Name = "labelTermos";
            this.labelTermos.Size = new System.Drawing.Size(78, 18);
            this.labelTermos.TabIndex = 5;
            this.labelTermos.Text = "Termos:";
            // 
            // textBoxTermos
            // 
            this.textBoxTermos.Enabled = false;
            this.textBoxTermos.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTermos.Location = new System.Drawing.Point(136, 114);
            this.textBoxTermos.Name = "textBoxTermos";
            this.textBoxTermos.Size = new System.Drawing.Size(31, 23);
            this.textBoxTermos.TabIndex = 6;
            this.textBoxTermos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelConfiguracaoMain
            // 
            this.labelConfiguracaoMain.AutoSize = true;
            this.labelConfiguracaoMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfiguracaoMain.Location = new System.Drawing.Point(235, 9);
            this.labelConfiguracaoMain.Name = "labelConfiguracaoMain";
            this.labelConfiguracaoMain.Size = new System.Drawing.Size(128, 18);
            this.labelConfiguracaoMain.TabIndex = 0;
            this.labelConfiguracaoMain.Text = "CONFIGURAÇÃO";
            // 
            // buttonTreinar
            // 
            this.buttonTreinar.AutoSize = true;
            this.buttonTreinar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTreinar.Location = new System.Drawing.Point(329, 167);
            this.buttonTreinar.Name = "buttonTreinar";
            this.buttonTreinar.Size = new System.Drawing.Size(108, 28);
            this.buttonTreinar.TabIndex = 7;
            this.buttonTreinar.Text = "TREINAR";
            this.buttonTreinar.UseVisualStyleBackColor = true;
            this.buttonTreinar.Click += new System.EventHandler(this.buttonTreinar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(451, 167);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormConfiguracao
            // 
            this.AcceptButton = this.buttonTreinar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(571, 207);
            this.Controls.Add(this.buttonTreinar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.labelConfiguracaoMain);
            this.Controls.Add(this.textBoxTermos);
            this.Controls.Add(this.labelTermos);
            this.Controls.Add(this.labelAssuntos);
            this.Controls.Add(this.comboBoxAssuntos);
            this.Controls.Add(this.labelCategorias);
            this.Controls.Add(this.comboBoxCategorias);
            this.Name = "FormConfiguracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONFIGURAÇÃO";
            this.Shown += new System.EventHandler(this.FormConfiguracao_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAssuntos;
        private System.Windows.Forms.ComboBox comboBoxAssuntos;
        private System.Windows.Forms.Label labelCategorias;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.Label labelTermos;
        private System.Windows.Forms.TextBox textBoxTermos;
        private System.Windows.Forms.Label labelConfiguracaoMain;
        private System.Windows.Forms.Button buttonTreinar;
        private System.Windows.Forms.Button buttonCancelar;

    }
}