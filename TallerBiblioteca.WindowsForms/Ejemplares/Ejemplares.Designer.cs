
namespace TallerBiblioteca.WindowsForms
{
    partial class Ejemplares
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
            this.btnAltaEjemplar = new System.Windows.Forms.Button();
            this.btnEliminarEjemplar = new System.Windows.Forms.Button();
            this.btnBuscarEjemplar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAltaEjemplar
            // 
            this.btnAltaEjemplar.Location = new System.Drawing.Point(233, 70);
            this.btnAltaEjemplar.Name = "btnAltaEjemplar";
            this.btnAltaEjemplar.Size = new System.Drawing.Size(150, 41);
            this.btnAltaEjemplar.TabIndex = 0;
            this.btnAltaEjemplar.Text = "Dar de alta ejemplar";
            this.btnAltaEjemplar.UseVisualStyleBackColor = true;
            this.btnAltaEjemplar.Click += new System.EventHandler(this.btnAltaEjemplar_Click);
            // 
            // btnEliminarEjemplar
            // 
            this.btnEliminarEjemplar.Location = new System.Drawing.Point(233, 172);
            this.btnEliminarEjemplar.Name = "btnEliminarEjemplar";
            this.btnEliminarEjemplar.Size = new System.Drawing.Size(150, 41);
            this.btnEliminarEjemplar.TabIndex = 2;
            this.btnEliminarEjemplar.Text = "Dar de baja ejemplar";
            this.btnEliminarEjemplar.UseVisualStyleBackColor = true;
            this.btnEliminarEjemplar.Click += new System.EventHandler(this.btnEliminarEjemplar_Click);
            // 
            // btnBuscarEjemplar
            // 
            this.btnBuscarEjemplar.Location = new System.Drawing.Point(233, 290);
            this.btnBuscarEjemplar.Name = "btnBuscarEjemplar";
            this.btnBuscarEjemplar.Size = new System.Drawing.Size(150, 41);
            this.btnBuscarEjemplar.TabIndex = 3;
            this.btnBuscarEjemplar.Text = "Buscar ejemplar";
            this.btnBuscarEjemplar.UseVisualStyleBackColor = true;
            this.btnBuscarEjemplar.Click += new System.EventHandler(this.btnBuscarEjemplar_Click);
            // 
            // Ejemplares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBuscarEjemplar);
            this.Controls.Add(this.btnEliminarEjemplar);
            this.Controls.Add(this.btnAltaEjemplar);
            this.Name = "Ejemplares";
            this.Size = new System.Drawing.Size(623, 395);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAltaEjemplar;
        private System.Windows.Forms.Button btnEliminarEjemplar;
        private System.Windows.Forms.Button btnBuscarEjemplar;
    }
}
