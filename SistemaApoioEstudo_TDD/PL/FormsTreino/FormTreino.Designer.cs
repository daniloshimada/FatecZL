namespace SistemaApoioEstudo.PL.FormsTreino
{
    partial class FormTreino
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
            this.components = new System.ComponentModel.Container();
            this.labelAssunto = new System.Windows.Forms.Label();
            this.comboBoxAssunto = new System.Windows.Forms.ComboBox();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.comboBoxCategoria = new System.Windows.Forms.ComboBox();
            this.labelTreinoMain = new System.Windows.Forms.Label();
            this.textBoxDica = new System.Windows.Forms.TextBox();
            this.labelResposta = new System.Windows.Forms.Label();
            this.textBoxResposta = new System.Windows.Forms.TextBox();
            this.labelTermo = new System.Windows.Forms.Label();
            this.textBoxTermo = new System.Windows.Forms.TextBox();
            this.labelLinha = new System.Windows.Forms.Label();
            this.buttonDica = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonProximo = new System.Windows.Forms.Button();
            this.labelTestes = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelSegundos = new System.Windows.Forms.Label();
            this.labelMinutos = new System.Windows.Forms.Label();
            this.labelHoras = new System.Windows.Forms.Label();
            this.labelDoisPontos1 = new System.Windows.Forms.Label();
            this.labelDoisPontos2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAssunto
            // 
            this.labelAssunto.AutoSize = true;
            this.labelAssunto.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssunto.Location = new System.Drawing.Point(32, 55);
            this.labelAssunto.Name = "labelAssunto";
            this.labelAssunto.Size = new System.Drawing.Size(88, 18);
            this.labelAssunto.TabIndex = 1;
            this.labelAssunto.Text = "Assunto:";
            // 
            // comboBoxAssunto
            // 
            this.comboBoxAssunto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssunto.Enabled = false;
            this.comboBoxAssunto.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAssunto.FormattingEnabled = true;
            this.comboBoxAssunto.Location = new System.Drawing.Point(126, 54);
            this.comboBoxAssunto.Name = "comboBoxAssunto";
            this.comboBoxAssunto.Size = new System.Drawing.Size(263, 24);
            this.comboBoxAssunto.TabIndex = 2;
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategoria.Location = new System.Drawing.Point(12, 85);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(108, 18);
            this.labelCategoria.TabIndex = 3;
            this.labelCategoria.Text = "Categoria:";
            // 
            // comboBoxCategoria
            // 
            this.comboBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoria.Enabled = false;
            this.comboBoxCategoria.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCategoria.FormattingEnabled = true;
            this.comboBoxCategoria.Location = new System.Drawing.Point(126, 84);
            this.comboBoxCategoria.Name = "comboBoxCategoria";
            this.comboBoxCategoria.Size = new System.Drawing.Size(423, 24);
            this.comboBoxCategoria.TabIndex = 4;
            // 
            // labelTreinoMain
            // 
            this.labelTreinoMain.AutoSize = true;
            this.labelTreinoMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTreinoMain.Location = new System.Drawing.Point(282, 9);
            this.labelTreinoMain.Name = "labelTreinoMain";
            this.labelTreinoMain.Size = new System.Drawing.Size(68, 18);
            this.labelTreinoMain.TabIndex = 0;
            this.labelTreinoMain.Text = "TREINO";
            // 
            // textBoxDica
            // 
            this.textBoxDica.Enabled = false;
            this.textBoxDica.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDica.Location = new System.Drawing.Point(126, 337);
            this.textBoxDica.Multiline = true;
            this.textBoxDica.Name = "textBoxDica";
            this.textBoxDica.Size = new System.Drawing.Size(409, 38);
            this.textBoxDica.TabIndex = 17;
            this.textBoxDica.Visible = false;
            // 
            // labelResposta
            // 
            this.labelResposta.AutoSize = true;
            this.labelResposta.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResposta.Location = new System.Drawing.Point(12, 240);
            this.labelResposta.Name = "labelResposta";
            this.labelResposta.Size = new System.Drawing.Size(98, 18);
            this.labelResposta.TabIndex = 14;
            this.labelResposta.Text = "Resposta:";
            // 
            // textBoxResposta
            // 
            this.textBoxResposta.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResposta.Location = new System.Drawing.Point(12, 261);
            this.textBoxResposta.Multiline = true;
            this.textBoxResposta.Name = "textBoxResposta";
            this.textBoxResposta.Size = new System.Drawing.Size(609, 70);
            this.textBoxResposta.TabIndex = 15;
            // 
            // labelTermo
            // 
            this.labelTermo.AutoSize = true;
            this.labelTermo.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermo.Location = new System.Drawing.Point(12, 146);
            this.labelTermo.Name = "labelTermo";
            this.labelTermo.Size = new System.Drawing.Size(68, 18);
            this.labelTermo.TabIndex = 12;
            this.labelTermo.Text = "Termo:";
            // 
            // textBoxTermo
            // 
            this.textBoxTermo.Enabled = false;
            this.textBoxTermo.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTermo.Location = new System.Drawing.Point(12, 167);
            this.textBoxTermo.Multiline = true;
            this.textBoxTermo.Name = "textBoxTermo";
            this.textBoxTermo.Size = new System.Drawing.Size(609, 70);
            this.textBoxTermo.TabIndex = 13;
            // 
            // labelLinha
            // 
            this.labelLinha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLinha.Location = new System.Drawing.Point(12, 119);
            this.labelLinha.Name = "labelLinha";
            this.labelLinha.Size = new System.Drawing.Size(609, 3);
            this.labelLinha.TabIndex = 5;
            // 
            // buttonDica
            // 
            this.buttonDica.AutoSize = true;
            this.buttonDica.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDica.Location = new System.Drawing.Point(12, 347);
            this.buttonDica.Name = "buttonDica";
            this.buttonDica.Size = new System.Drawing.Size(108, 28);
            this.buttonDica.TabIndex = 16;
            this.buttonDica.Text = "DICA";
            this.buttonDica.UseVisualStyleBackColor = true;
            this.buttonDica.Click += new System.EventHandler(this.buttonDica_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(513, 405);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 19;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonProximo
            // 
            this.buttonProximo.AutoSize = true;
            this.buttonProximo.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProximo.Location = new System.Drawing.Point(391, 405);
            this.buttonProximo.Name = "buttonProximo";
            this.buttonProximo.Size = new System.Drawing.Size(108, 28);
            this.buttonProximo.TabIndex = 18;
            this.buttonProximo.Text = "PRÓXIMO";
            this.buttonProximo.UseVisualStyleBackColor = true;
            this.buttonProximo.Click += new System.EventHandler(this.buttonProximo_Click);
            // 
            // labelTestes
            // 
            this.labelTestes.AutoSize = true;
            this.labelTestes.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestes.ForeColor = System.Drawing.Color.Red;
            this.labelTestes.Location = new System.Drawing.Point(284, 143);
            this.labelTestes.Name = "labelTestes";
            this.labelTestes.Size = new System.Drawing.Size(65, 21);
            this.labelTestes.TabIndex = 6;
            this.labelTestes.Text = "1 / 3";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelSegundos
            // 
            this.labelSegundos.AutoSize = true;
            this.labelSegundos.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSegundos.ForeColor = System.Drawing.Color.Red;
            this.labelSegundos.Location = new System.Drawing.Point(589, 143);
            this.labelSegundos.Name = "labelSegundos";
            this.labelSegundos.Size = new System.Drawing.Size(32, 21);
            this.labelSegundos.TabIndex = 11;
            this.labelSegundos.Text = "00";
            // 
            // labelMinutos
            // 
            this.labelMinutos.AutoSize = true;
            this.labelMinutos.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinutos.ForeColor = System.Drawing.Color.Red;
            this.labelMinutos.Location = new System.Drawing.Point(540, 143);
            this.labelMinutos.Name = "labelMinutos";
            this.labelMinutos.Size = new System.Drawing.Size(32, 21);
            this.labelMinutos.TabIndex = 9;
            this.labelMinutos.Text = "00";
            // 
            // labelHoras
            // 
            this.labelHoras.AutoSize = true;
            this.labelHoras.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHoras.ForeColor = System.Drawing.Color.Red;
            this.labelHoras.Location = new System.Drawing.Point(491, 143);
            this.labelHoras.Name = "labelHoras";
            this.labelHoras.Size = new System.Drawing.Size(32, 21);
            this.labelHoras.TabIndex = 7;
            this.labelHoras.Text = "00";
            // 
            // labelDoisPontos1
            // 
            this.labelDoisPontos1.AutoSize = true;
            this.labelDoisPontos1.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDoisPontos1.ForeColor = System.Drawing.Color.Red;
            this.labelDoisPontos1.Location = new System.Drawing.Point(521, 143);
            this.labelDoisPontos1.Name = "labelDoisPontos1";
            this.labelDoisPontos1.Size = new System.Drawing.Size(21, 21);
            this.labelDoisPontos1.TabIndex = 8;
            this.labelDoisPontos1.Text = ":";
            // 
            // labelDoisPontos2
            // 
            this.labelDoisPontos2.AutoSize = true;
            this.labelDoisPontos2.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDoisPontos2.ForeColor = System.Drawing.Color.Red;
            this.labelDoisPontos2.Location = new System.Drawing.Point(570, 143);
            this.labelDoisPontos2.Name = "labelDoisPontos2";
            this.labelDoisPontos2.Size = new System.Drawing.Size(21, 21);
            this.labelDoisPontos2.TabIndex = 10;
            this.labelDoisPontos2.Text = ":";
            // 
            // FormTreino
            // 
            this.AcceptButton = this.buttonProximo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(633, 445);
            this.Controls.Add(this.labelDoisPontos2);
            this.Controls.Add(this.labelDoisPontos1);
            this.Controls.Add(this.labelHoras);
            this.Controls.Add(this.labelMinutos);
            this.Controls.Add(this.labelSegundos);
            this.Controls.Add(this.labelTestes);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonProximo);
            this.Controls.Add(this.buttonDica);
            this.Controls.Add(this.textBoxDica);
            this.Controls.Add(this.labelResposta);
            this.Controls.Add(this.textBoxResposta);
            this.Controls.Add(this.labelTermo);
            this.Controls.Add(this.textBoxTermo);
            this.Controls.Add(this.labelLinha);
            this.Controls.Add(this.labelTreinoMain);
            this.Controls.Add(this.labelAssunto);
            this.Controls.Add(this.comboBoxAssunto);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.comboBoxCategoria);
            this.Name = "FormTreino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TREINO";
            this.Shown += new System.EventHandler(this.FormTreino_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAssunto;
        private System.Windows.Forms.ComboBox comboBoxAssunto;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Label labelTreinoMain;
        private System.Windows.Forms.TextBox textBoxDica;
        private System.Windows.Forms.Label labelResposta;
        private System.Windows.Forms.TextBox textBoxResposta;
        private System.Windows.Forms.Label labelTermo;
        private System.Windows.Forms.TextBox textBoxTermo;
        private System.Windows.Forms.Label labelLinha;
        private System.Windows.Forms.Button buttonDica;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonProximo;
        private System.Windows.Forms.Label labelTestes;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelSegundos;
        private System.Windows.Forms.Label labelMinutos;
        private System.Windows.Forms.Label labelHoras;
        private System.Windows.Forms.Label labelDoisPontos1;
        private System.Windows.Forms.Label labelDoisPontos2;
    }
}