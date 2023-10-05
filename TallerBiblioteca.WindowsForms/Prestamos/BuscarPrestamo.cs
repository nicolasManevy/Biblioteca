using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;

namespace TallerBiblioteca.WindowsForms
{
    public partial class BuscarPrestamo : Form
    {
        readonly FachadaPrestamo fachada;

        public BuscarPrestamo(FachadaPrestamo pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void BuscarPrestamo_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusUsuario_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<BuscarUsuario>())
            {
                form.ShowDialog();
            }
        }

        private void btnEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<EliminarEjemplares>())
            {
                form.ShowDialog();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            var listaPrestamos = fachada.PrestamosEntreFechas((int)numericUpDown1.Value, dtFecha1.Value, dtFecha2.Value);
            foreach (var item in listaPrestamos)
            {
                dataGridView1.Rows.Add(item.FechaVencimiento,
                                       item.FechaDevolucion == null ? "-" : item.FechaDevolucion.ToString(),
                                       item.FechaPrestamo,
                                       item.Id,
                                       item.Nombre,
                                       item.IdEjemplar);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
