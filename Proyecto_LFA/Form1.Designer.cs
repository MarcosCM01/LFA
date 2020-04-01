namespace Proyecto_LFA
{
    partial class Form1
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
            this.btnBuscador = new System.Windows.Forms.Button();
            this.txbRuta = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.txbExpresion = new System.Windows.Forms.TextBox();
            this.lbl_TituloER = new System.Windows.Forms.Label();
            this.lbl_MostrarR = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBuscador
            // 
            this.btnBuscador.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscador.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscador.Location = new System.Drawing.Point(12, 12);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(170, 32);
            this.btnBuscador.TabIndex = 0;
            this.btnBuscador.Text = "Seleccionar Archivo";
            this.btnBuscador.UseVisualStyleBackColor = false;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // txbRuta
            // 
            this.txbRuta.Location = new System.Drawing.Point(218, 22);
            this.txbRuta.Name = "txbRuta";
            this.txbRuta.Size = new System.Drawing.Size(220, 22);
            this.txbRuta.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(465, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(323, 25);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Lenguajes formales y automatas";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(675, 65);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAnalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalizar.Location = new System.Drawing.Point(17, 65);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(145, 23);
            this.btnAnalizar.TabIndex = 4;
            this.btnAnalizar.Text = "Analizar Archivo";
            this.btnAnalizar.UseVisualStyleBackColor = false;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // txbExpresion
            // 
            this.txbExpresion.BackColor = System.Drawing.SystemColors.Info;
            this.txbExpresion.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txbExpresion.Location = new System.Drawing.Point(12, 158);
            this.txbExpresion.Name = "txbExpresion";
            this.txbExpresion.Size = new System.Drawing.Size(759, 22);
            this.txbExpresion.TabIndex = 5;
            // 
            // lbl_TituloER
            // 
            this.lbl_TituloER.AutoSize = true;
            this.lbl_TituloER.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TituloER.Location = new System.Drawing.Point(13, 112);
            this.lbl_TituloER.Name = "lbl_TituloER";
            this.lbl_TituloER.Size = new System.Drawing.Size(286, 24);
            this.lbl_TituloER.TabIndex = 6;
            this.lbl_TituloER.Text = "Expresion regular del archivo";
            // 
            // lbl_MostrarR
            // 
            this.lbl_MostrarR.AutoSize = true;
            this.lbl_MostrarR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MostrarR.ForeColor = System.Drawing.Color.Red;
            this.lbl_MostrarR.Location = new System.Drawing.Point(214, 65);
            this.lbl_MostrarR.Name = "lbl_MostrarR";
            this.lbl_MostrarR.Size = new System.Drawing.Size(18, 20);
            this.lbl_MostrarR.TabIndex = 7;
            this.lbl_MostrarR.Text = "k";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_MostrarR);
            this.Controls.Add(this.lbl_TituloER);
            this.Controls.Add(this.txbExpresion);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txbRuta);
            this.Controls.Add(this.btnBuscador);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscador;
        private System.Windows.Forms.TextBox txbRuta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.TextBox txbExpresion;
        private System.Windows.Forms.Label lbl_TituloER;
        private System.Windows.Forms.Label lbl_MostrarR;
    }
}

