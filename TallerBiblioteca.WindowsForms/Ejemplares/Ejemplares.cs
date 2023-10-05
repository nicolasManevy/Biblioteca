using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TallerBiblioteca.WindowsForms;

namespace TallerBiblioteca.WindowsForms
{
    public partial class Ejemplares : UserControl
    {
        public Ejemplares()
        {
            InitializeComponent();
        }

        private void btnAltaEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<DarDeAltaEjemplar>())
            {
                form.ShowDialog();
            }
        }

        private void btnEliminarEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<EliminarEjemplares>())
            {
                form.ShowDialog();
            }
        }

        private void btnEditarEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<EditarEjemplar>())
            {
                form.ShowDialog();
            }
        }

        private void btnBuscarEjemplar_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<BuscarEjemplar>())
            {
                form.ShowDialog();
            }
        }
    }
}