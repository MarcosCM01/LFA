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
            this.lblTFLN = new System.Windows.Forms.Label();
            this.lblTFollow = new System.Windows.Forms.Label();
            this.lblTET = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.dataGV_FLN = new System.Windows.Forms.DataGridView();
            this.dataGVFollow = new System.Windows.Forms.DataGridView();
            this.dataGVET = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_FLN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVFollow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVET)).BeginInit();
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
            this.txbRuta.Location = new System.Drawing.Point(227, 18);
            this.txbRuta.Name = "txbRuta";
            this.txbRuta.Size = new System.Drawing.Size(478, 22);
            this.txbRuta.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(850, 37);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(323, 25);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Lenguajes formales y automatas";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1229, 21);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnAnalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalizar.Location = new System.Drawing.Point(17, 65);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(165, 44);
            this.btnAnalizar.TabIndex = 4;
            this.btnAnalizar.Text = "Analizar Archivo";
            this.btnAnalizar.UseVisualStyleBackColor = false;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // txbExpresion
            // 
            this.txbExpresion.BackColor = System.Drawing.SystemColors.Info;
            this.txbExpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbExpresion.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txbExpresion.Location = new System.Drawing.Point(12, 158);
            this.txbExpresion.Name = "txbExpresion";
            this.txbExpresion.Size = new System.Drawing.Size(1501, 22);
            this.txbExpresion.TabIndex = 5;
            // 
            // lbl_TituloER
            // 
            this.lbl_TituloER.AutoSize = true;
            this.lbl_TituloER.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TituloER.Location = new System.Drawing.Point(581, 111);
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
            this.lbl_MostrarR.Location = new System.Drawing.Point(223, 86);
            this.lbl_MostrarR.Name = "lbl_MostrarR";
            this.lbl_MostrarR.Size = new System.Drawing.Size(0, 20);
            this.lbl_MostrarR.TabIndex = 7;
            // 
            // lblTFLN
            // 
            this.lblTFLN.AutoSize = true;
            this.lblTFLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFLN.Location = new System.Drawing.Point(13, 206);
            this.lblTFLN.Name = "lblTFLN";
            this.lblTFLN.Size = new System.Drawing.Size(269, 24);
            this.lblTFLN.TabIndex = 8;
            this.lblTFLN.Text = "Tabla 1: First, Last, Nullable";
            // 
            // lblTFollow
            // 
            this.lblTFollow.AutoSize = true;
            this.lblTFollow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFollow.Location = new System.Drawing.Point(658, 206);
            this.lblTFollow.Name = "lblTFollow";
            this.lblTFollow.Size = new System.Drawing.Size(153, 24);
            this.lblTFollow.TabIndex = 9;
            this.lblTFollow.Text = "Tabla 2: Follow";
            // 
            // lblTET
            // 
            this.lblTET.AutoSize = true;
            this.lblTET.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTET.Location = new System.Drawing.Point(1019, 206);
            this.lblTET.Name = "lblTET";
            this.lblTET.Size = new System.Drawing.Size(299, 24);
            this.lblTET.TabIndex = 10;
            this.lblTET.Text = "Tabla 3: Estados y transiciones";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutor.ForeColor = System.Drawing.Color.Maroon;
            this.lblAutor.Location = new System.Drawing.Point(850, 9);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(242, 25);
            this.lblAutor.TabIndex = 11;
            this.lblAutor.Text = "Autor: Marcos Calderon";
            // 
            // dataGV_FLN
            // 
            this.dataGV_FLN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_FLN.Location = new System.Drawing.Point(17, 233);
            this.dataGV_FLN.Name = "dataGV_FLN";
            this.dataGV_FLN.RowHeadersWidth = 51;
            this.dataGV_FLN.RowTemplate.Height = 24;
            this.dataGV_FLN.Size = new System.Drawing.Size(489, 338);
            this.dataGV_FLN.TabIndex = 12;
            // 
            // dataGVFollow
            // 
            this.dataGVFollow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVFollow.Location = new System.Drawing.Point(541, 233);
            this.dataGVFollow.Name = "dataGVFollow";
            this.dataGVFollow.RowHeadersWidth = 51;
            this.dataGVFollow.RowTemplate.Height = 24;
            this.dataGVFollow.Size = new System.Drawing.Size(363, 338);
            this.dataGVFollow.TabIndex = 13;
            // 
            // dataGVET
            // 
            this.dataGVET.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGVET.Location = new System.Drawing.Point(943, 233);
            this.dataGVET.Name = "dataGVET";
            this.dataGVET.RowHeadersWidth = 51;
            this.dataGVET.RowTemplate.Height = 24;
            this.dataGVET.Size = new System.Drawing.Size(570, 338);
            this.dataGVET.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1582, 603);
            this.Controls.Add(this.dataGVET);
            this.Controls.Add(this.dataGVFollow);
            this.Controls.Add(this.dataGV_FLN);
            this.Controls.Add(this.lblAutor);
            this.Controls.Add(this.lblTET);
            this.Controls.Add(this.lblTFollow);
            this.Controls.Add(this.lblTFLN);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_FLN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVFollow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGVET)).EndInit();
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
        private System.Windows.Forms.Label lblTFLN;
        private System.Windows.Forms.Label lblTFollow;
        private System.Windows.Forms.Label lblTET;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.DataGridView dataGV_FLN;
        private System.Windows.Forms.DataGridView dataGVFollow;
        private System.Windows.Forms.DataGridView dataGVET;
    }
}

