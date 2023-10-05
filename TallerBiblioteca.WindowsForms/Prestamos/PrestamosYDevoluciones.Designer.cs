
namespace TallerBiblioteca.WindowsForms
{
    partial class PrestamosYDevoluciones
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegistroPrestamos = new System.Windows.Forms.Button();
            this.btnRegistroDevoluciones = new System.Windows.Forms.Button();
            this.btnBuscarPrestamos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistroPrestamos
            // 
            this.btnRegistroPrestamos.Location = new System.Drawing.Point(66, 63);
            this.btnRegistroPrestamos.Name = "btnRegistroPrestamos";
            this.btnRegistroPrestamos.Size = new System.Drawing.Size(180, 35);
            this.btnRegistroPrestamos.TabIndex = 0;
            this.btnRegistroPrestamos.Text = "Registrar prestamos";
            this.btnRegistroPrestamos.UseVisualStyleBackColor = true;
            this.btnRegistroPrestamos.Click += new System.EventHandler(this.btnRegistroPrestamos_Click);
            // 
            // btnRegistroDevoluciones
            // 
            this.btnRegistroDevoluciones.Location = new System.Drawing.Point(66, 138);
            this.btnRegistroDevoluciones.Name = "btnRegistroDevoluciones";
            this.btnRegistroDevoluciones.Size = new System.Drawing.Size(180, 35);
            this.btnRegistroDevoluciones.TabIndex = 1;
            this.btnRegistroDevoluciones.Text = "Registrar devoluciones";
            this.btnRegistroDevoluciones.UseVisualStyleBackColor = true;
            this.btnRegistroDevoluciones.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscarPrestamos
            // 
            this.btnBuscarPrestamos.Location = new System.Drawing.Point(356, 97);
            this.btnBuscarPrestamos.Name = "btnBuscarPrestamos";
            this.btnBuscarPrestamos.Size = new System.Drawing.Size(180, 35);
            this.btnBuscarPrestamos.TabIndex = 2;
            this.btnBuscarPrestamos.Text = "Buscar prestamos";
            this.btnBuscarPrestamos.UseVisualStyleBackColor = true;
            this.btnBuscarPrestamos.Click += new System.EventHandler(this.btnBuscarPrestamos_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRegistroPrestamos);
            this.panel1.Controls.Add(this.btnBuscarPrestamos);
            this.panel1.Controls.Add(this.btnRegistroDevoluciones);
            this.panel1.Location = new System.Drawing.Point(21, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 242);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "REGISTROS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "BUSQUEDAS";
            // 
            // PrestamosYDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "PrestamosYDevoluciones";
            this.Size = new System.Drawing.Size(623, 395);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistroPrestamos;
        private System.Windows.Forms.Button btnRegistroDevoluciones;
        private System.Windows.Forms.Button btnBuscarPrestamos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
