namespace SistemaApoioEstudo.PL.FormsAssunto
{
    partial class FormAssunto
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
            this.labelAssuntoMain = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.textBoxAssunto = new System.Windows.Forms.TextBox();
            this.comboBoxAssuntos = new System.Windows.Forms.ComboBox();
            this.labelAssunto = new System.Windows.Forms.Label();
            this.buttonAtualizar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.labelAssuntos = new System.Windows.Forms.Label();
            this.labelLinha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAssuntoMain
            // 
            this.labelAssuntoMain.AutoSize = true;
            this.labelAssuntoMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssuntoMain.Location = new System.Drawing.Point(210, 9);
            this.labelAssuntoMain.Name = "labelAssuntoMain";
            this.labelAssuntoMain.Size = new System.Drawing.Size(78, 18);
            this.labelAssuntoMain.TabIndex = 0;
            this.labelAssuntoMain.Text = "ASSUNTO";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(378, 156);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.AutoSize = true;
            this.buttonCadastrar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastrar.Location = new System.Drawing.Point(12, 156);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(108, 28);
            this.buttonCadastrar.TabIndex = 6;
            this.buttonCadastrar.Text = "CADASTRAR";
            this.buttonCadastrar.UseVisualStyleBackColor = true;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // textBoxAssunto
            // 
            this.textBoxAssunto.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAssunto.Location = new System.Drawing.Point(170, 103);
            this.textBoxAssunto.Name = "textBoxAssunto";
            this.textBoxAssunto.Size = new System.Drawing.Size(246, 23);
            this.textBoxAssunto.TabIndex = 5;
            // 
            // comboBoxAssuntos
            // 
            this.comboBoxAssuntos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssuntos.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAssuntos.FormattingEnabled = true;
            this.comboBoxAssuntos.Location = new System.Drawing.Point(170, 54);
            this.comboBoxAssuntos.Name = "comboBoxAssuntos";
            this.comboBoxAssuntos.Size = new System.Drawing.Size(263, 24);
            this.comboBoxAssuntos.TabIndex = 2;
            this.comboBoxAssuntos.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssuntos_SelectedIndexChanged);
            // 
            // labelAssunto
            // 
            this.labelAssunto.AutoSize = true;
            this.labelAssunto.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssunto.Location = new System.Drawing.Point(76, 104);
            this.labelAssunto.Name = "labelAssunto";
            this.labelAssunto.Size = new System.Drawing.Size(88, 18);
            this.labelAssunto.TabIndex = 4;
            this.labelAssunto.Text = "Assunto:";
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.AutoSize = true;
            this.buttonAtualizar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtualizar.Location = new System.Drawing.Point(134, 156);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(108, 28);
            this.buttonAtualizar.TabIndex = 7;
            this.buttonAtualizar.Text = "ATUALIZAR";
            this.buttonAtualizar.UseVisualStyleBackColor = true;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.AutoSize = true;
            this.buttonExcluir.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluir.Location = new System.Drawing.Point(256, 156);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(108, 28);
            this.buttonExcluir.TabIndex = 8;
            this.buttonExcluir.Text = "EXCLUIR";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // labelAssuntos
            // 
            this.labelAssuntos.AutoSize = true;
            this.labelAssuntos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssuntos.Location = new System.Drawing.Point(66, 55);
            this.labelAssuntos.Name = "labelAssuntos";
            this.labelAssuntos.Size = new System.Drawing.Size(98, 18);
            this.labelAssuntos.TabIndex = 1;
            this.labelAssuntos.Text = "Assuntos:";
            // 
            // labelLinha
            // 
            this.labelLinha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLinha.Location = new System.Drawing.Point(12, 89);
            this.labelLinha.Name = "labelLinha";
            this.labelLinha.Size = new System.Drawing.Size(474, 3);
            this.labelLinha.TabIndex = 3;
            // 
            // FormAssunto
            // 
            this.AcceptButton = this.buttonCadastrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(498, 196);
            this.Controls.Add(this.labelLinha);
            this.Controls.Add(this.labelAssuntos);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonAtualizar);
            this.Controls.Add(this.labelAssunto);
            this.Controls.Add(this.comboBoxAssuntos);
            this.Controls.Add(this.labelAssuntoMain);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.textBoxAssunto);
            this.Name = "FormAssunto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASSUNTO";
            this.Shown += new System.EventHandler(this.FormAssunto_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAssuntoMain;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.TextBox textBoxAssunto;
        private System.Windows.Forms.ComboBox comboBoxAssuntos;
        private System.Windows.Forms.Label labelAssunto;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Label labelAssuntos;
        private System.Windows.Forms.Label labelLinha;
    }
}