using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.WindowsForms;

namespace TallerBiblioteca.WindowsForms
{
    public partial class PrestamosProxVencer : UserControl
    {
        readonly FachadaPrestamo fachada;
        public PrestamosProxVencer(FachadaPrestamo pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void PrestamosProxVencer_Load(object sender, EventArgs e)
        {
            //esto lo realizamos para esperar a que este logeado es decir que no se ejecute en el diseñador
            if (InformacionDelLogin.DNI != null)
            {
                ActualizarPrestamos();
            }
        }

        private void ActualizarPrestamos()
        {
            this.dataGridView1.Rows.Clear();
            var prestamosAVencer = fachada.PrestamosProximosAVencer();
            foreach (var prestamo in prestamosAVencer)
            {
                this.dataGridView1.Rows.Add(
                    prestamo.FechaVencimiento,
                    prestamo.FechaPrestamo,
                    prestamo.Id,
                    prestamo.SolicitanteDNI);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            ActualizarPrestamos();
        }
    }
}
