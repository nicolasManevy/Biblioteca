using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TallerBiblioteca.WindowsForms;

namespace TallerBiblioteca.WindowsForms
{
    public partial class PrestamosYDevoluciones : UserControl
    {
        public PrestamosYDevoluciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<RegistrarDevolucion>())
            {
                form.ShowDialog();
            }
        }

        private void btnRegistroPrestamos_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<RegistrarPrestamos>())
            {
                form.ShowDialog();
            }
        }

        private void btnBuscarPrestamos_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<BuscarPrestamo>())
            {
                form.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
