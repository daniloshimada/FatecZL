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
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.comboBoxAssuntos = new System.Windows.Forms.ComboBox();
            this.labelCategorias = new System.Windows.Forms.Label();
            this.labelTermos = new System.Windows.Forms.Label();
            this.labelDicas = new System.Windows.Forms.Label();
            this.textBoxCategorias = new System.Windows.Forms.TextBox();
            this.textBoxTermos = new System.Windows.Forms.TextBox();
            this.textBoxDicas = new System.Windows.Forms.TextBox();
            this.labelAssunto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAssuntoMain
            // 
            this.labelAssuntoMain.AutoSize = true;
            this.labelAssuntoMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssuntoMain.Location = new System.Drawing.Point(180, 9);
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
            this.buttonCancelar.Location = new System.Drawing.Point(291, 224);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 12;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.AutoSize = true;
            this.buttonCadastrar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastrar.Location = new System.Drawing.Point(169, 224);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(108, 28);
            this.buttonCadastrar.TabIndex = 11;
            this.buttonCadastrar.Text = "CADASTRAR";
            this.buttonCadastrar.UseVisualStyleBackColor = true;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNome.Location = new System.Drawing.Point(136, 84);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(246, 23);
            this.textBoxNome.TabIndex = 4;
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(72, 85);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(58, 18);
            this.labelNome.TabIndex = 3;
            this.labelNome.Text = "Nome:";
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
            this.labelCategorias.Location = new System.Drawing.Point(12, 114);
            this.labelCategorias.Name = "labelCategorias";
            this.labelCategorias.Size = new System.Drawing.Size(118, 18);
            this.labelCategorias.TabIndex = 5;
            this.labelCategorias.Text = "Categorias:";
            // 
            // labelTermos
            // 
            this.labelTermos.AutoSize = true;
            this.labelTermos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTermos.Location = new System.Drawing.Point(52, 143);
            this.labelTermos.Name = "labelTermos";
            this.labelTermos.Size = new System.Drawing.Size(78, 18);
            this.labelTermos.TabIndex = 7;
            this.labelTermos.Text = "Termos:";
            // 
            // labelDicas
            // 
            this.labelDicas.AutoSize = true;
            this.labelDicas.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDicas.Location = new System.Drawing.Point(62, 172);
            this.labelDicas.Name = "labelDicas";
            this.labelDicas.Size = new System.Drawing.Size(68, 18);
            this.labelDicas.TabIndex = 9;
            this.labelDicas.Text = "Dicas:";
            // 
            // textBoxCategorias
            // 
            this.textBoxCategorias.Enabled = false;
            this.textBoxCategorias.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCategorias.Location = new System.Drawing.Point(136, 113);
            this.textBoxCategorias.Name = "textBoxCategorias";
            this.textBoxCategorias.Size = new System.Drawing.Size(31, 23);
            this.textBoxCategorias.TabIndex = 6;
            this.textBoxCategorias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxTermos
            // 
            this.textBoxTermos.Enabled = false;
            this.textBoxTermos.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTermos.Location = new System.Drawing.Point(136, 142);
            this.textBoxTermos.Name = "textBoxTermos";
            this.textBoxTermos.Size = new System.Drawing.Size(31, 23);
            this.textBoxTermos.TabIndex = 8;
            this.textBoxTermos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxDicas
            // 
            this.textBoxDicas.Enabled = false;
            this.textBoxDicas.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDicas.Location = new System.Drawing.Point(136, 171);
            this.textBoxDicas.Name = "textBoxDicas";
            this.textBoxDicas.Size = new System.Drawing.Size(31, 23);
            this.textBoxDicas.TabIndex = 10;
            this.textBoxDicas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelAssunto
            // 
            this.labelAssunto.AutoSize = true;
            this.labelAssunto.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssunto.Location = new System.Drawing.Point(42, 55);
            this.labelAssunto.Name = "labelAssunto";
            this.labelAssunto.Size = new System.Drawing.Size(88, 18);
            this.labelAssunto.TabIndex = 1;
            this.labelAssunto.Text = "Assunto:";
            // 
            // FormAssunto
            // 
            this.AcceptButton = this.buttonCadastrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(411, 264);
            this.Controls.Add(this.labelAssunto);
            this.Controls.Add(this.textBoxDicas);
            this.Controls.Add(this.textBoxTermos);
            this.Controls.Add(this.textBoxCategorias);
            this.Controls.Add(this.labelDicas);
            this.Controls.Add(this.labelTermos);
            this.Controls.Add(this.labelCategorias);
            this.Controls.Add(this.comboBoxAssuntos);
            this.Controls.Add(this.labelAssuntoMain);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
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
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.ComboBox comboBoxAssuntos;
        private System.Windows.Forms.Label labelCategorias;
        private System.Windows.Forms.Label labelTermos;
        private System.Windows.Forms.Label labelDicas;
        private System.Windows.Forms.TextBox textBoxCategorias;
        private System.Windows.Forms.TextBox textBoxTermos;
        private System.Windows.Forms.TextBox textBoxDicas;
        private System.Windows.Forms.Label labelAssunto;
    }
}