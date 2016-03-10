namespace SistemaApoioEstudo.PL.FormsUsuario
{
    partial class FormAtualizarUsuario
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
            this.labelNome = new System.Windows.Forms.Label();
            this.labelSenha = new System.Windows.Forms.Label();
            this.labelSenhaConfirmacao = new System.Windows.Forms.Label();
            this.buttonAtualizar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.textBoxSenhaConfirmacao = new System.Windows.Forms.TextBox();
            this.labelAtualizarMain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(46, 55);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(58, 18);
            this.labelNome.TabIndex = 1;
            this.labelNome.Text = "Nome:";
            // 
            // labelSenha
            // 
            this.labelSenha.AutoSize = true;
            this.labelSenha.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSenha.Location = new System.Drawing.Point(36, 84);
            this.labelSenha.Name = "labelSenha";
            this.labelSenha.Size = new System.Drawing.Size(68, 18);
            this.labelSenha.TabIndex = 3;
            this.labelSenha.Text = "Senha:";
            // 
            // labelSenhaConfirmacao
            // 
            this.labelSenhaConfirmacao.AutoSize = true;
            this.labelSenhaConfirmacao.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSenhaConfirmacao.Location = new System.Drawing.Point(18, 133);
            this.labelSenhaConfirmacao.Name = "labelSenhaConfirmacao";
            this.labelSenhaConfirmacao.Size = new System.Drawing.Size(178, 18);
            this.labelSenhaConfirmacao.TabIndex = 5;
            this.labelSenhaConfirmacao.Text = "Digite sua senha:";
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.AutoSize = true;
            this.buttonAtualizar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtualizar.Location = new System.Drawing.Point(12, 207);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(108, 28);
            this.buttonAtualizar.TabIndex = 7;
            this.buttonAtualizar.Text = "ATUALIZAR";
            this.buttonAtualizar.UseVisualStyleBackColor = true;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(134, 207);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNome.Location = new System.Drawing.Point(110, 54);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(126, 23);
            this.textBoxNome.TabIndex = 2;
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSenha.Location = new System.Drawing.Point(110, 83);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(86, 23);
            this.textBoxSenha.TabIndex = 4;
            this.textBoxSenha.UseSystemPasswordChar = true;
            // 
            // textBoxSenhaConfirmacao
            // 
            this.textBoxSenhaConfirmacao.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSenhaConfirmacao.Location = new System.Drawing.Point(110, 154);
            this.textBoxSenhaConfirmacao.Name = "textBoxSenhaConfirmacao";
            this.textBoxSenhaConfirmacao.Size = new System.Drawing.Size(86, 23);
            this.textBoxSenhaConfirmacao.TabIndex = 6;
            this.textBoxSenhaConfirmacao.UseSystemPasswordChar = true;
            // 
            // labelAtualizarMain
            // 
            this.labelAtualizarMain.AutoSize = true;
            this.labelAtualizarMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAtualizarMain.Location = new System.Drawing.Point(38, 9);
            this.labelAtualizarMain.Name = "labelAtualizarMain";
            this.labelAtualizarMain.Size = new System.Drawing.Size(178, 18);
            this.labelAtualizarMain.TabIndex = 0;
            this.labelAtualizarMain.Text = "ATUALIZAR USUÁRIO";
            // 
            // FormAtualizarUsuario
            // 
            this.AcceptButton = this.buttonAtualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(254, 247);
            this.Controls.Add(this.labelAtualizarMain);
            this.Controls.Add(this.textBoxSenhaConfirmacao);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAtualizar);
            this.Controls.Add(this.labelSenhaConfirmacao);
            this.Controls.Add(this.labelSenha);
            this.Controls.Add(this.labelNome);
            this.Name = "FormAtualizarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USUÁRIO";
            this.Shown += new System.EventHandler(this.FormAtualizarUsuario_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelSenha;
        private System.Windows.Forms.Label labelSenhaConfirmacao;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.TextBox textBoxSenhaConfirmacao;
        private System.Windows.Forms.Label labelAtualizarMain;
    }
}