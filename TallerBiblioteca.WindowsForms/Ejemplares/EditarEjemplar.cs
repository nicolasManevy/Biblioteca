using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TallerBiblioteca.WindowsForms;

namespace TallerBiblioteca.WindowsForms
{
    public partial class EditarEjemplar : Form
    {

        public EditarEjemplar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarEdicion_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<BuscarEdicion>())
            {
                form.ShowDialog();
            }
        }

        private void btnCrearEdicion_Click(object sender, EventArgs e)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<CrearEdicion>())
            {
                form.ShowDialog();
            }
        }
    }
}
