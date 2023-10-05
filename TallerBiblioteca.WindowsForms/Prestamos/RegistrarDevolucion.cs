using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.Excepciones.Prestamo;

namespace TallerBiblioteca.WindowsForms
{
    public partial class RegistrarDevolucion : Form
    {
        readonly FachadaPrestamo fachada;
        readonly BuscarEjemplar buscarEjemplarForm;

        public RegistrarDevolucion(FachadaPrestamo pFachada, BuscarEjemplar pBuscarEjemplarForm)
        {
            InitializeComponent();
            buscarEjemplarForm = pBuscarEjemplarForm;
            fachada = pFachada;
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                fachada.DevolverEjemplar((int)numIdEjemplar.Value, !checkBoxMalEstado.Checked);
                MessageBox.Show("Devuelto exitosamente");
            }
            catch (ExcepcionEjemplarNoEstaPrestado)
            {
                MessageBox.Show("Ejemplar no esta prestado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarEjemplarForm.SetEsSeleccion(true);
            buscarEjemplarForm.ShowDialog();

            if (buscarEjemplarForm.SeleccionoElemento())
            {
                numIdEjemplar.Value = buscarEjemplarForm.ObtenerElementoSeleccionado().Id;
            }
        }
    }
}
