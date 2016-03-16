namespace SistemaApoioEstudo.PL.FormsCategoria
{
    partial class FormCategoria
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
            this.labelCategorias = new System.Windows.Forms.Label();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonAtualizar = new System.Windows.Forms.Button();
            this.comboBoxCategorias = new System.Windows.Forms.ComboBox();
            this.labelCategoriaMain = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.labelCategoria = new System.Windows.Forms.Label();
            this.textBoxCategoria = new System.Windows.Forms.TextBox();
            this.labelAssuntos = new System.Windows.Forms.Label();
            this.comboBoxAssuntos = new System.Windows.Forms.ComboBox();
            this.labelLinha = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCategorias
            // 
            this.labelCategorias.AutoSize = true;
            this.labelCategorias.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategorias.Location = new System.Drawing.Point(12, 85);
            this.labelCategorias.Name = "labelCategorias";
            this.labelCategorias.Size = new System.Drawing.Size(118, 18);
            this.labelCategorias.TabIndex = 3;
            this.labelCategorias.Text = "Categorias:";
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.AutoSize = true;
            this.buttonExcluir.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExcluir.Location = new System.Drawing.Point(292, 186);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(108, 28);
            this.buttonExcluir.TabIndex = 10;
            this.buttonExcluir.Text = "EXCLUIR";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonAtualizar
            // 
            this.buttonAtualizar.AutoSize = true;
            this.buttonAtualizar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAtualizar.Location = new System.Drawing.Point(170, 186);
            this.buttonAtualizar.Name = "buttonAtualizar";
            this.buttonAtualizar.Size = new System.Drawing.Size(108, 28);
            this.buttonAtualizar.TabIndex = 9;
            this.buttonAtualizar.Text = "ATUALIZAR";
            this.buttonAtualizar.UseVisualStyleBackColor = true;
            this.buttonAtualizar.Click += new System.EventHandler(this.buttonAtualizar_Click);
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
            // labelCategoriaMain
            // 
            this.labelCategoriaMain.AutoSize = true;
            this.labelCategoriaMain.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategoriaMain.Location = new System.Drawing.Point(236, 9);
            this.labelCategoriaMain.Name = "labelCategoriaMain";
            this.labelCategoriaMain.Size = new System.Drawing.Size(98, 18);
            this.labelCategoriaMain.TabIndex = 0;
            this.labelCategoriaMain.Text = "CATEGORIA";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.AutoSize = true;
            this.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(414, 186);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(108, 28);
            this.buttonCancelar.TabIndex = 11;
            this.buttonCancelar.Text = "CANCELAR";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.AutoSize = true;
            this.buttonCadastrar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCadastrar.Location = new System.Drawing.Point(48, 186);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Size = new System.Drawing.Size(108, 28);
            this.buttonCadastrar.TabIndex = 8;
            this.buttonCadastrar.Text = "CADASTRAR";
            this.buttonCadastrar.UseVisualStyleBackColor = true;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // labelCategoria
            // 
            this.labelCategoria.AutoSize = true;
            this.labelCategoria.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategoria.Location = new System.Drawing.Point(22, 134);
            this.labelCategoria.Name = "labelCategoria";
            this.labelCategoria.Size = new System.Drawing.Size(108, 18);
            this.labelCategoria.TabIndex = 6;
            this.labelCategoria.Text = "Categoria:";
            // 
            // textBoxCategoria
            // 
            this.textBoxCategoria.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCategoria.Location = new System.Drawing.Point(136, 133);
            this.textBoxCategoria.Name = "textBoxCategoria";
            this.textBoxCategoria.Size = new System.Drawing.Size(406, 23);
            this.textBoxCategoria.TabIndex = 7;
            // 
            // labelAssuntos
            // 
            this.labelAssuntos.AutoSize = true;
            this.labelAssuntos.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAssuntos.Location = new System.Drawing.Point(32, 55);
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
            this.comboBoxAssuntos.Location = new System.Drawing.Point(136, 54);
            this.comboBoxAssuntos.Name = "comboBoxAssuntos";
            this.comboBoxAssuntos.Size = new System.Drawing.Size(263, 24);
            this.comboBoxAssuntos.TabIndex = 2;
            this.comboBoxAssuntos.SelectedIndexChanged += new System.EventHandler(this.comboBoxAssuntos_SelectedIndexChanged);
            // 
            // labelLinha
            // 
            this.labelLinha.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLinha.Location = new System.Drawing.Point(15, 119);
            this.labelLinha.Name = "labelLinha";
            this.labelLinha.Size = new System.Drawing.Size(547, 3);
            this.labelLinha.TabIndex = 5;
            // 
            // FormCategoria
            // 
            this.AcceptButton = this.buttonCadastrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(571, 226);
            this.Controls.Add(this.labelLinha);
            this.Controls.Add(this.labelAssuntos);
            this.Controls.Add(this.comboBoxAssuntos);
            this.Controls.Add(this.labelCategoria);
            this.Controls.Add(this.textBoxCategoria);
            this.Controls.Add(this.labelCategorias);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonAtualizar);
            this.Controls.Add(this.comboBoxCategorias);
            this.Controls.Add(this.labelCategoriaMain);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCadastrar);
            this.Name = "FormCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CATEGORIA";
            this.Shown += new System.EventHandler(this.FormCategoria_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCategorias;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonAtualizar;
        private System.Windows.Forms.ComboBox comboBoxCategorias;
        private System.Windows.Forms.Label labelCategoriaMain;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.Label labelCategoria;
        private System.Windows.Forms.TextBox textBoxCategoria;
        private System.Windows.Forms.Label labelAssuntos;
        private System.Windows.Forms.ComboBox comboBoxAssuntos;
        private System.Windows.Forms.Label labelLinha;
    }
}