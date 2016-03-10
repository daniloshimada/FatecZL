namespace SistemaApoioEstudo.PL.FormsUtilitarios
{
    partial class FormMenu
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
            this.labelMenuMain = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonAlterar = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonAssunto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMenuMain
            // 
            this.labelMenuMain.AutoSize = true;
            this.labelMenuMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenuMain.Location = new System.Drawing.Point(103, 9);
            this.labelMenuMain.Name = "labelMenuMain";
            this.labelMenuMain.Size = new System.Drawing.Size(48, 18);
            this.labelMenuMain.TabIndex = 0;
            this.labelMenuMain.Text = "MENU";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(73, 191);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 6;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonAlterar
            // 
            this.buttonAlterar.AutoSize = true;
            this.buttonAlterar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlterar.Location = new System.Drawing.Point(12, 107);
            this.buttonAlterar.Name = "buttonAlterar";
            this.buttonAlterar.Size = new System.Drawing.Size(108, 28);
            this.buttonAlterar.TabIndex = 3;
            this.buttonAlterar.Text = "ALTERAR";
            this.buttonAlterar.UseVisualStyleBackColor = true;
            this.buttonAlterar.Click += new System.EventHandler(this.buttonAlterar_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Enabled = false;
            this.textBoxNome.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNome.Location = new System.Drawing.Point(96, 54);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(126, 23);
            this.textBoxNome.TabIndex = 2;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(32, 55);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(58, 18);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "Nome:";
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.AutoSize = true;
            this.buttonExcluir.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluir.Location = new System.Drawing.Point(12, 149);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(108, 28);
            this.buttonExcluir.TabIndex = 4;
            this.buttonExcluir.Text = "EXCLUIR";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonAssunto
            // 
            this.buttonAssunto.AutoSize = true;
            this.buttonAssunto.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssunto.Location = new System.Drawing.Point(134, 107);
            this.buttonAssunto.Name = "buttonAssunto";
            this.buttonAssunto.Size = new System.Drawing.Size(108, 28);
            this.buttonAssunto.TabIndex = 5;
            this.buttonAssunto.Text = "ASSUNTO";
            this.buttonAssunto.UseVisualStyleBackColor = true;
            this.buttonAssunto.Click += new System.EventHandler(this.buttonAssunto_Click);
            // 
            // FormMenu
            // 
            this.AcceptButton = this.buttonAlterar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(254, 231);
            this.Controls.Add(this.buttonAssunto);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.labelMenuMain);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAlterar);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMenu_FormClosing);
            this.Shown += new System.EventHandler(this.FormMenu_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMenuMain;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonAlterar;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonAssunto;
    }
}