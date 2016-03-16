namespace SistemaApoioEstudo.PL.FormsUsuario
{
    partial class FormExcluirUsuario
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
            this.labelExcluirMain = new System.Windows.Forms.Label();
            this.textBoxSenhaConfirmacao = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.labelSenhaConfirmacao = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelExcluirMain
            // 
            this.labelExcluirMain.AutoSize = true;
            this.labelExcluirMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExcluirMain.Location = new System.Drawing.Point(48, 9);
            this.labelExcluirMain.Name = "labelExcluirMain";
            this.labelExcluirMain.Size = new System.Drawing.Size(158, 18);
            this.labelExcluirMain.TabIndex = 0;
            this.labelExcluirMain.Text = "EXCLUIR USUÁRIO";
            // 
            // textBoxSenhaConfirmacao
            // 
            this.textBoxSenhaConfirmacao.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSenhaConfirmacao.Location = new System.Drawing.Point(96, 125);
            this.textBoxSenhaConfirmacao.Name = "textBoxSenhaConfirmacao";
            this.textBoxSenhaConfirmacao.Size = new System.Drawing.Size(86, 23);
            this.textBoxSenhaConfirmacao.TabIndex = 4;
            this.textBoxSenhaConfirmacao.UseSystemPasswordChar = true;
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
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(134, 178);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 6;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.AutoSize = true;
            this.buttonExcluir.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluir.Location = new System.Drawing.Point(12, 178);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(108, 28);
            this.buttonExcluir.TabIndex = 5;
            this.buttonExcluir.Text = "EXCLUIR";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // labelSenhaConfirmacao
            // 
            this.labelSenhaConfirmacao.AutoSize = true;
            this.labelSenhaConfirmacao.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSenhaConfirmacao.Location = new System.Drawing.Point(38, 104);
            this.labelSenhaConfirmacao.Name = "labelSenhaConfirmacao";
            this.labelSenhaConfirmacao.Size = new System.Drawing.Size(178, 18);
            this.labelSenhaConfirmacao.TabIndex = 3;
            this.labelSenhaConfirmacao.Text = "Digite sua senha:";
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
            // FormExcluirUsuario
            // 
            this.AcceptButton = this.buttonExcluir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(254, 218);
            this.Controls.Add(this.labelExcluirMain);
            this.Controls.Add(this.textBoxSenhaConfirmacao);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.labelSenhaConfirmacao);
            this.Controls.Add(this.labelNome);
            this.Name = "FormExcluirUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USUÁRIO";
            this.Shown += new System.EventHandler(this.FormExcluirUsuario_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExcluirMain;
        private System.Windows.Forms.TextBox textBoxSenhaConfirmacao;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Label labelSenhaConfirmacao;
        private System.Windows.Forms.Label labelNome;
    }
}