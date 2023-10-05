using System.Windows.Forms;
using TallerBiblioteca.Aplication.Common.IO.Edicion;

namespace TallerBiblioteca.WindowsForms.Ediciones
{
    public partial class DatosEdicion : UserControl
    {
        public DatosEdicion()
        {
            InitializeComponent();
        }

        public void LimpiarCampos()
        {
            txtISBNEdicion.Text = "";
            txtTitulo.Text = "";
            numAñoEdicion.Value = 0;
            numNumeroPaginas.Value = 0;
            txtPortada.Text = "";
            txtAutores.Text = "";
            txtDescripcion.Text = "";
            txtDatosAdicionales.Text = "";
            txtEditorial.Text = "";

            pbPortada.Image = null;
        }

        public void SetPuedeEditarLosCampos(bool puedeEditar)
        {
            txtISBNEdicion.Enabled = puedeEditar;
            txtTitulo.Enabled = puedeEditar;
            numAñoEdicion.Enabled = puedeEditar;
            numNumeroPaginas.Enabled = puedeEditar;
            txtPortada.Enabled = puedeEditar;
            txtAutores.Enabled = puedeEditar;
            txtDescripcion.Enabled = puedeEditar;
            txtDatosAdicionales.Enabled = puedeEditar;
            txtEditorial.Enabled = puedeEditar;
        }

        public void SetEdicion(DTOEdicion edicion)
        {
            txtISBNEdicion.Text = edicion.Isbn;
            txtTitulo.Text = edicion.Titulo;
            numAñoEdicion.Value = edicion.AñoEdicion;
            numNumeroPaginas.Value = edicion.NumeroPaginas;
            txtPortada.Text = edicion.Portada;
            txtAutores.Text = edicion.Autores;
            txtDescripcion.Text = edicion.Descripcion;
            txtDatosAdicionales.Text = edicion.DatosAdicionales;
            txtEditorial.Text = edicion.Publicacion;

            // Cargar portada
            if (edicion.Portada != null)
            {
                pbPortada.ImageLocation = edicion.Portada;
                pbPortada.LoadAsync();
            }
        }

        public DTOEdicion GetEdicion()
        {
            return new DTOEdicion()
            {
                Isbn = txtISBNEdicion.Text,
                Titulo = txtTitulo.Text,
                AñoEdicion = (int)numAñoEdicion.Value,
                NumeroPaginas = (int)numNumeroPaginas.Value,
                Portada = txtPortada.Text,
                Autores = txtAutores.Text,
                Descripcion = txtDescripcion.Text,
                DatosAdicionales = txtDatosAdicionales.Text,
                Publicacion = txtEditorial.Text
            };
        }
    }
}
