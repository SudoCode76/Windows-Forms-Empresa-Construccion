using EmpresaConstruccion.Data;
using Npgsql;
using System;
using System.Windows.Forms;

namespace EmpresaConstruccion
{
    public partial class Form1 : Form
    {
        // Cadena de conexión a PostgreSQL local
        private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=76452510;Database=distribucion_materiales;";

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            using (var login = new LoginForm(connectionString))
            {
                if (login.ShowDialog(this) != DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void ProbarConexion()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Conexión exitosa a PostgreSQL", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            ProbarConexion();
        }

        private void menuTransporte_Click(object sender, EventArgs e)
        {
            var form = new TransporteForm(connectionString);
            form.ShowDialog();
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuOrigen_Click(object sender, EventArgs e)
        {
            var form = new OrigenesForm(connectionString);
            form.ShowDialog();
        }

        private void menuDestino_Click(object sender, EventArgs e)
        {
            var form = new DestinosForm(connectionString);
            form.ShowDialog();
        }

        private void menuProducto_Click(object sender, EventArgs e)
        {
            var form = new ProductosForm(connectionString);
            form.ShowDialog();
        }

        private void menuOptimizacion_Click(object sender, EventArgs e)
        {
            var form = new OptimizacionForm(connectionString);
            form.ShowDialog();
        }
    }
}
