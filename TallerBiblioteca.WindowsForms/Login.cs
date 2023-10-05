using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using TallerBiblioteca.Aplication;
using TallerBiblioteca.WindowsForms;

namespace TallerBiblioteca.WindowsForms
{
    public partial class Login : Form
    {

        readonly FachadaUsuarios fachada;

        public Login(FachadaUsuarios pFachada)
        {
            InitializeComponent();
            fachada = pFachada;
        }

        private void botSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botCancelar_Click_1(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtUsuario.Focus();
            return;
        }

        private void botAceptar_Click_1(object sender, EventArgs e)
        {
            if (fachada.LoguearUsuario(txtUsuario.Text, txtContraseña.Text))
            {
                //MessageBox.Show("Logueado correctamente");

                string nombre = txtUsuario.Text;

                if (fachada.EsUsuarioAdmin(nombre))
                {
                    InformacionDelLogin.DNI = fachada.ObtenerUsuario(txtUsuario.Text).Dni;
                    txtUsuario.Clear();
                    txtContraseña.Clear();
                    this.Hide();
                    using (var form = Program.ServiceProvider.GetRequiredService<Inicio>())
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No pudo acceder porque no es administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var registrarUsuarioForm = Program.ServiceProvider.GetRequiredService<RegistrarUsuario>())
            {
                registrarUsuarioForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
