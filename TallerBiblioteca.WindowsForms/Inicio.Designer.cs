
namespace TallerBiblioteca.WindowsForms
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.panelNavegacion = new System.Windows.Forms.Panel();
            this.panelCuerpo = new System.Windows.Forms.Panel();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnPrestamosYDevoluciones = new System.Windows.Forms.Button();
            this.btnEdiciones = new System.Windows.Forms.Button();
            this.btnPrestamosProxVencer = new System.Windows.Forms.Button();
            this.btnEjemplares = new System.Windows.Forms.Button();
            this.panelNavegacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.Controls.Add(this.btnEjemplares);
            this.panelNavegacion.Controls.Add(this.btnPrestamosProxVencer);
            this.panelNavegacion.Controls.Add(this.btnEdiciones);
            this.panelNavegacion.Controls.Add(this.btnPrestamosYDevoluciones);
            this.panelNavegacion.Controls.Add(this.btnUsuarios);
            this.panelNavegacion.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavegacion.Location = new System.Drawing.Point(0, 0);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(174, 457);
            this.panelNavegacion.TabIndex = 1;
            // 
            // panelCuerpo
            // 
            this.panelCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCuerpo.Location = new System.Drawing.Point(174, 0);
            this.panelCuerpo.Name = "panelCuerpo";
            this.panelCuerpo.Size = new System.Drawing.Size(734, 457);
            this.panelCuerpo.TabIndex = 2;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(16, 24);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(149, 34);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnPrestamosYDevoluciones
            // 
            this.btnPrestamosYDevoluciones.Location = new System.Drawing.Point(12, 115);
            this.btnPrestamosYDevoluciones.Name = "btnPrestamosYDevoluciones";
            this.btnPrestamosYDevoluciones.Size = new System.Drawing.Size(149, 34);
            this.btnPrestamosYDevoluciones.TabIndex = 8;
            this.btnPrestamosYDevoluciones.Text = "Préstamos y devoluciones";
            this.btnPrestamosYDevoluciones.UseVisualStyleBackColor = true;
            this.btnPrestamosYDevoluciones.Click += new System.EventHandler(this.btnPrestamosYDevoluciones_Click);
            // 
            // btnEdiciones
            // 
            this.btnEdiciones.Location = new System.Drawing.Point(12, 206);
            this.btnEdiciones.Name = "btnEdiciones";
            this.btnEdiciones.Size = new System.Drawing.Size(149, 34);
            this.btnEdiciones.TabIndex = 9;
            this.btnEdiciones.Text = "Ediciones";
            this.btnEdiciones.UseVisualStyleBackColor = true;
            this.btnEdiciones.Click += new System.EventHandler(this.btnEdiciones_Click);
            // 
            // btnPrestamosProxVencer
            // 
            this.btnPrestamosProxVencer.Location = new System.Drawing.Point(12, 297);
            this.btnPrestamosProxVencer.Name = "btnPrestamosProxVencer";
            this.btnPrestamosProxVencer.Size = new System.Drawing.Size(149, 34);
            this.btnPrestamosProxVencer.TabIndex = 10;
            this.btnPrestamosProxVencer.Text = "Préstamos proximos a vencer";
            this.btnPrestamosProxVencer.UseVisualStyleBackColor = true;
            this.btnPrestamosProxVencer.Click += new System.EventHandler(this.btnPrestamosProxVencer_Click);
            // 
            // btnEjemplares
            // 
            this.btnEjemplares.Location = new System.Drawing.Point(12, 388);
            this.btnEjemplares.Name = "btnEjemplares";
            this.btnEjemplares.Size = new System.Drawing.Size(149, 34);
            this.btnEjemplares.TabIndex = 11;
            this.btnEjemplares.Text = "Ejemplares";
            this.btnEjemplares.UseVisualStyleBackColor = true;
            this.btnEjemplares.Click += new System.EventHandler(this.btnEjemplares_Click);
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(908, 457);
            this.Controls.Add(this.panelCuerpo);
            this.Controls.Add(this.panelNavegacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Usuario";
            this.Text = "Usuario Biblioteca";
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.panelNavegacion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelNavegacion;
        private System.Windows.Forms.Panel panelCuerpo;
        private System.Windows.Forms.Button btnEdiciones;
        private System.Windows.Forms.Button btnPrestamosYDevoluciones;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnEjemplares;
        private System.Windows.Forms.Button btnPrestamosProxVencer;
    }
}