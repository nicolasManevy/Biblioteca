using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.Aplication.Common.IO.Ejemplar;
using TallerBiblioteca.WindowsForms.Utils;

namespace TallerBiblioteca.WindowsForms
{
    public partial class EliminarEjemplares : Form
    {
        readonly FachadaEjemplar fachada;
        List<DatosEjemplarDTO> ejemplares;

        public EliminarEjemplares(FachadaEjemplar pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnSelcObra_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSelecISBN_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            actualizarListaEjemplares(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));
        }

        private void actualizarListaEjemplares(string isbn)
        {
            dataGridView1.Rows.Clear();
            try
            {
                ejemplares = fachada.ListarEjemplares(isbn);
                foreach (var item in ejemplares)
                {
                    dataGridView1.Rows.Add(item.Id, item.Prestado, item.FechaAlta, item.FechaBaja == DateTime.MinValue ? "-" : item.FechaBaja.ToString());
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No se encontro");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                for (int i = 0; i < selectedCellCount; i++)
                {
                    var ejemplar = ejemplares[dataGridView1.SelectedCells[i].RowIndex];
                    fachada.BajaEjemplar(ejemplar.Id);
                }

                actualizarListaEjemplares(FormateoUtiles.LimpiarGuionesISBN(txtISBN.Text));
            }
            else
            {
                MessageBox.Show("No seleccionaste");
            }
        }
    }
}
