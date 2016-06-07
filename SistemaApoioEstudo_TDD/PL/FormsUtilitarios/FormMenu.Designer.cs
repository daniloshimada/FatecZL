﻿namespace SistemaApoioEstudo.PL.FormsUtilitarios
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
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.buttonAssunto = new System.Windows.Forms.Button();
            this.buttonUsuario = new System.Windows.Forms.Button();
            this.buttonCategoria = new System.Windows.Forms.Button();
            this.buttonTermo = new System.Windows.Forms.Button();
            this.buttonConfiguracao = new System.Windows.Forms.Button();
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
            this.buttonCancelar.Location = new System.Drawing.Point(134, 191);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 7;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
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
            // buttonAssunto
            // 
            this.buttonAssunto.AutoSize = true;
            this.buttonAssunto.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssunto.Location = new System.Drawing.Point(134, 107);
            this.buttonAssunto.Name = "buttonAssunto";
            this.buttonAssunto.Size = new System.Drawing.Size(108, 28);
            this.buttonAssunto.TabIndex = 4;
            this.buttonAssunto.Text = "ASSUNTO";
            this.buttonAssunto.UseVisualStyleBackColor = true;
            this.buttonAssunto.Click += new System.EventHandler(this.buttonAssunto_Click);
            // 
            // buttonUsuario
            // 
            this.buttonUsuario.AutoSize = true;
            this.buttonUsuario.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUsuario.Location = new System.Drawing.Point(12, 107);
            this.buttonUsuario.Name = "buttonUsuario";
            this.buttonUsuario.Size = new System.Drawing.Size(108, 28);
            this.buttonUsuario.TabIndex = 3;
            this.buttonUsuario.Text = "USUÁRIO";
            this.buttonUsuario.UseVisualStyleBackColor = true;
            this.buttonUsuario.Click += new System.EventHandler(this.buttonUsuario_Click);
            // 
            // buttonCategoria
            // 
            this.buttonCategoria.AutoSize = true;
            this.buttonCategoria.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCategoria.Location = new System.Drawing.Point(12, 141);
            this.buttonCategoria.Name = "buttonCategoria";
            this.buttonCategoria.Size = new System.Drawing.Size(108, 28);
            this.buttonCategoria.TabIndex = 5;
            this.buttonCategoria.Text = "CATEGORIA";
            this.buttonCategoria.UseVisualStyleBackColor = true;
            this.buttonCategoria.Click += new System.EventHandler(this.buttonCategoria_Click);
            // 
            // buttonTermo
            // 
            this.buttonTermo.AutoSize = true;
            this.buttonTermo.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTermo.Location = new System.Drawing.Point(134, 141);
            this.buttonTermo.Name = "buttonTermo";
            this.buttonTermo.Size = new System.Drawing.Size(108, 28);
            this.buttonTermo.TabIndex = 6;
            this.buttonTermo.Text = "TERMO";
            this.buttonTermo.UseVisualStyleBackColor = true;
            this.buttonTermo.Click += new System.EventHandler(this.buttonTermo_Click);
            // 
            // buttonConfiguracao
            // 
            this.buttonConfiguracao.AutoSize = true;
            this.buttonConfiguracao.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonConfiguracao.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfiguracao.Location = new System.Drawing.Point(12, 191);
            this.buttonConfiguracao.Name = "buttonConfiguracao";
            this.buttonConfiguracao.Size = new System.Drawing.Size(114, 28);
            this.buttonConfiguracao.TabIndex = 8;
            this.buttonConfiguracao.Text = "CONFIGURAÇÃO";
            this.buttonConfiguracao.UseVisualStyleBackColor = true;
            this.buttonConfiguracao.Click += new System.EventHandler(this.buttonConfiguracao_Click);
            // 
            // FormMenu
            // 
            this.AcceptButton = this.buttonUsuario;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(254, 231);
            this.Controls.Add(this.buttonConfiguracao);
            this.Controls.Add(this.buttonTermo);
            this.Controls.Add(this.buttonCategoria);
            this.Controls.Add(this.buttonUsuario);
            this.Controls.Add(this.buttonAssunto);
            this.Controls.Add(this.labelMenuMain);
            this.Controls.Add(this.buttonCancelar);
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
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Button buttonAssunto;
        private System.Windows.Forms.Button buttonUsuario;
        private System.Windows.Forms.Button buttonCategoria;
        private System.Windows.Forms.Button buttonTermo;
        private System.Windows.Forms.Button buttonConfiguracao;
    }
}