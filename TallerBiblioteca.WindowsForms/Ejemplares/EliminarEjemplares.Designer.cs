
namespace TallerBiblioteca.WindowsForms
{
    partial class EliminarEjemplares
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
            this.btnSelecISBN = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.CodigoInv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDeAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaBaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelecISBN
            // 
            this.btnSelecISBN.Location = new System.Drawing.Point(438, 85);
            this.btnSelecISBN.Name = "btnSelecISBN";
            this.btnSelecISBN.Size = new System.Drawing.Size(70, 21);
            this.btnSelecISBN.TabIndex = 0;
            this.btnSelecISBN.Text = "Buscar";
            this.btnSelecISBN.UseVisualStyleBackColor = true;
            this.btnSelecISBN.Click += new System.EventHandler(this.btnSelecISBN_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoInv,
            this.Prestado,
            this.FechaDeAlta,
            this.FechaBaja});
            this.dataGridView1.Location = new System.Drawing.Point(178, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(443, 121);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(317, 86);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(100, 20);
            this.txtISBN.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ISBN:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(466, 294);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(279, 294);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // CodigoInv
            // 
            this.CodigoInv.HeaderText = "ID";
            this.CodigoInv.Name = "CodigoInv";
            this.CodigoInv.ReadOnly = true;
            // 
            // Prestado
            // 
            this.Prestado.HeaderText = "Prestado actualmente";
            this.Prestado.Name = "Prestado";
            this.Prestado.ReadOnly = true;
            // 
            // FechaDeAlta
            // 
            this.FechaDeAlta.HeaderText = "Fecha de alta";
            this.FechaDeAlta.Name = "FechaDeAlta";
            this.FechaDeAlta.ReadOnly = true;
            // 
            // FechaBaja
            // 
            this.FechaBaja.HeaderText = "Facha de baja";
            this.FechaBaja.Name = "FechaBaja";
            this.FechaBaja.ReadOnly = true;
            // 
            // EliminarEjemplares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSelecISBN);
            this.Name = "EliminarEjemplares";
            this.Text = "Dar de baja ejemplar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelecISBN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeAlta;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaBaja;
    }
}