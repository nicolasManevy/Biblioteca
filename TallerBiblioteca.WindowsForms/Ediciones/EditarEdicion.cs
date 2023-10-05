using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.IO.Edicion;
using TallerBiblioteca.Aplication.LibrosRemotos;
using TallerBiblioteca.WindowsForms.Utils;

namespace TallerBiblioteca.WindowsForms.Ediciones
{
    public partial class EditarEdicion : Form
    {
        readonly IServicioEdicionRemota serviciosEdicion;
        readonly FachadaEdicion fachada;

        public EditarEdicion(FachadaEdicion pFachada,
                             IServicioEdicionRemota pServiciosEdicion)
        {
            InitializeComponent();

            fachada = pFachada;
            serviciosEdicion = pServiciosEdicion;
        }

        public void SetEdicionAEditar(DTOEdicion pEdicion)
        {
            ucEdicion1.SetEdicion(pEdicion);
        }

        private async void btnBuscarMetadatos_Click(object sender, EventArgs e)
        {
            ucEdicion1.SetPuedeEditarLosCampos(false);

            var edicion = ucEdicion1.GetEdicion();
            string isbn = FormateoUtiles.LimpiarGuionesISBN(edicion.Isbn);

            DTOEdicion edicionRemota = await serviciosEdicion.BuscarPorISBNAsync(isbn);

            if (edicionRemota != null)
            {
                ucEdicion1.SetEdicion(edicionRemota);
            }
            else
            {
                MessageBox.Show($"No se encontraron metadatos para el ISBN {isbn}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }

            ucEdicion1.SetPuedeEditarLosCampos(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var edicion = ucEdicion1.GetEdicion();
                fachada.ModificarEdicion(edicion);
                MessageBox.Show("Se edito correctamente", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
