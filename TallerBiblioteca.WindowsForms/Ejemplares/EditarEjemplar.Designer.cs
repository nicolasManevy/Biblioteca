
namespace TallerBiblioteca.WindowsForms
{
    partial class EditarEjemplar
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
            this.txtCodigoInventario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textEdicionISBN = new System.Windows.Forms.TextBox();
            this.btnBuscarEdicion = new System.Windows.Forms.Button();
            this.btnCrearEdicion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCodigoInventario
            // 
            this.txtCodigoInventario.Location = new System.Drawing.Point(145, 30);
            this.txtCodigoInventario.Name = "txtCodigoInventario";
            this.txtCodigoInventario.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoInventario.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ID:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(279, 149);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(64, 149);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "EDICION:";
            // 
            // textEdicionISBN
            // 
            this.textEdicionISBN.Location = new System.Drawing.Point(145, 56);
            this.textEdicionISBN.Name = "textEdicionISBN";
            this.textEdicionISBN.ReadOnly = true;
            this.textEdicionISBN.Size = new System.Drawing.Size(100, 20);
            this.textEdicionISBN.TabIndex = 11;
            // 
            // btnBuscarEdicion
            // 
            this.btnBuscarEdicion.Location = new System.Drawing.Point(279, 52);
            this.btnBuscarEdicion.Name = "btnBuscarEdicion";
            this.btnBuscarEdicion.Size = new System.Drawing.Size(88, 26);
            this.btnBuscarEdicion.TabIndex = 12;
            this.btnBuscarEdicion.Text = "Buscar edición";
            this.btnBuscarEdicion.UseVisualStyleBackColor = true;
            this.btnBuscarEdicion.Click += new System.EventHandler(this.btnBuscarEdicion_Click);
            // 
            // btnCrearEdicion
            // 
            this.btnCrearEdicion.Location = new System.Drawing.Point(386, 52);
            this.btnCrearEdicion.Name = "btnCrearEdicion";
            this.btnCrearEdicion.Size = new System.Drawing.Size(83, 26);
            this.btnCrearEdicion.TabIndex = 13;
            this.btnCrearEdicion.Text = "Crear edición";
            this.btnCrearEdicion.UseVisualStyleBackColor = true;
            this.btnCrearEdicion.Click += new System.EventHandler(this.btnCrearEdicion_Click);
            // 
            // EditarEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 224);
            this.Controls.Add(this.btnCrearEdicion);
            this.Controls.Add(this.btnBuscarEdicion);
            this.Controls.Add(this.textEdicionISBN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCodigoInventario);
            this.Controls.Add(this.label2);
            this.Name = "EditarEjemplar";
            this.Text = "EditarEjemplar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodigoInventario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEdicionISBN;
        private System.Windows.Forms.Button btnBuscarEdicion;
        private System.Windows.Forms.Button btnCrearEdicion;
    }
}