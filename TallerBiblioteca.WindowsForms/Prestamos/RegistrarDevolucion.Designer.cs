
namespace TallerBiblioteca.WindowsForms
{
    partial class RegistrarDevolucion
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxMalEstado = new System.Windows.Forms.CheckBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numIdEjemplar = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numIdEjemplar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(282, 57);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(71, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ejemplar a devolver";
            // 
            // checkBoxMalEstado
            // 
            this.checkBoxMalEstado.AutoSize = true;
            this.checkBoxMalEstado.Location = new System.Drawing.Point(15, 107);
            this.checkBoxMalEstado.Name = "checkBoxMalEstado";
            this.checkBoxMalEstado.Size = new System.Drawing.Size(159, 17);
            this.checkBoxMalEstado.TabIndex = 4;
            this.checkBoxMalEstado.Text = "Se encontro en MAL estado";
            this.checkBoxMalEstado.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(84, 168);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(71, 23);
            this.btnDevolver.TabIndex = 5;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(249, 168);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(71, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(115, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID del ejemplar";
            // 
            // numIdEjemplar
            // 
            this.numIdEjemplar.Location = new System.Drawing.Point(118, 60);
            this.numIdEjemplar.Name = "numIdEjemplar";
            this.numIdEjemplar.Size = new System.Drawing.Size(137, 20);
            this.numIdEjemplar.TabIndex = 8;
            // 
            // RegistrarDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 201);
            this.Controls.Add(this.numIdEjemplar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.checkBoxMalEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Name = "RegistrarDevolucion";
            this.Text = "RegistrarDevolucion";
            ((System.ComponentModel.ISupportInitialize)(this.numIdEjemplar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxMalEstado;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numIdEjemplar;
    }
}