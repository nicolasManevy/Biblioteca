using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.Excepciones;
using TallerBiblioteca.Aplication.Common.Excepciones.Ejemplar;
using TallerBiblioteca.Aplication.Common.Excepciones.Prestamo;
using TallerBiblioteca.Domain.Common.Excepciones;

namespace TallerBiblioteca.WindowsForms
{
    public partial class RegistrarPrestamos : Form
    {
        readonly FachadaPrestamo fachada;
        readonly BuscarEjemplar buscarEjemplarForm;
        readonly BuscarUsuario buscarUsuarioForm;

        public RegistrarPrestamos(BuscarEjemplar pBuscarEjemplar,
                                  FachadaPrestamo pFachada,
                                  BuscarUsuario pBuscarUsuario)
        {
            InitializeComponent();
            buscarEjemplarForm = pBuscarEjemplar;
            buscarUsuarioForm = pBuscarUsuario;
            fachada = pFachada;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusUsuario_Click(object sender, EventArgs e)
        {
            buscarUsuarioForm.SetEsSeleccion(true);
            buscarUsuarioForm.ShowDialog();

            if (buscarUsuarioForm.SeleccionoElemento())
            {
                txtDNI.Text = buscarUsuarioForm.ObtenerElementoSeleccionado().Dni.ToString();
            }
        }

        private void btnBuscarEjemplar_Click(object sender, EventArgs e)
        {
            buscarEjemplarForm.SetEsSeleccion(true);
            buscarEjemplarForm.ShowDialog();

            if (buscarEjemplarForm.SeleccionoElemento())
            {
                numIdEjemplar.Value = buscarEjemplarForm.ObtenerElementoSeleccionado().Id;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Int32.TryParse(txtDNI.Text, out int dni))
            {
                MessageBox.Show("DNI no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                DateTime fechaVencimiento = fachada.PrestarEjemplar(dni, (int)numIdEjemplar.Value);
                MessageBox.Show("Prestamo registrado exitosamente.\n Fecha de vencimiento del prestamo: " + fechaVencimiento.ToString());
            }
            catch (ExcepcionEjemplarYaPrestado)
            {
                MessageBox.Show("El ejemplar ya esta prestado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionEjemplarNoExiste)
            {
                MessageBox.Show("El ejemplar no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExcepcionUsuarioNoExiste)
            {
                MessageBox.Show("El usuario NO existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (EjemplarEstaDadoDeBaja)
            {
                MessageBox.Show("El ejemplar esta dado de baja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
