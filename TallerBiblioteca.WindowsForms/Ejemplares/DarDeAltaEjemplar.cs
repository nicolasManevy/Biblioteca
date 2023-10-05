using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.Excepciones.Ediciones;
using TallerBiblioteca.Aplication.Common.IO.Edicion;
using TallerBiblioteca.Aplication.Common.IO.Ejemplar;
using TallerBiblioteca.WindowsForms.Utils;

namespace TallerBiblioteca.WindowsForms
{
    public partial class DarDeAltaEjemplar : Form
    {
        readonly FachadaEjemplar fachadaEjemplar;
        readonly FachadaEdicion fachadaEdicion;
        DTOEdicion edicion;
        public DarDeAltaEjemplar(
            FachadaEjemplar pFachada,
            FachadaEdicion fachadaEdicion)
        {
            InitializeComponent();
            fachadaEjemplar = pFachada;
            this.fachadaEdicion = fachadaEdicion;
        }

        private void btnBuscarObra_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarEdicion_Click(object sender, EventArgs e)
        {
            edicion = fachadaEdicion.BuscarEdicion(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));

            if (edicion != null)
            {
                MessageBox.Show("ISBN encontrado", "Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAceptar.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                fachadaEjemplar.AgregarEjemplar(new AgregarEjemplarDTO
                {
                    ISBNEdicion = edicion.Isbn,
                    CantidadEjemplares = (int)numericCantidad.Value,
                });
            }
            catch (ExcepcionEdicionNoExiste)
            {
                MessageBox.Show("No se encontro la edicion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Guardado correctamente", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DarDeAltaEjemplar_Load(object sender, EventArgs e)
        {

        }
    }
}
