using EmpresaConstruccion.Data;
using EmpresaConstruccion.Models;
using Npgsql;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EmpresaConstruccion
{
    public partial class Form1 : Form
    {
        // Cadena de conexión a PostgreSQL local
        private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=76452510;Database=distribucion_materiales;";

        private OrigenRepository origenRepo;
        private DestinoRepository destinoRepo;
        private ProductoRepository productoRepo;

        public Form1()
        {
            InitializeComponent();
            origenRepo = new OrigenRepository(connectionString);
            destinoRepo = new DestinoRepository(connectionString);
            productoRepo = new ProductoRepository(connectionString);
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvOrigenes.DataSource = origenRepo.GetAll();
            dgvDestinos.DataSource = destinoRepo.GetAll();
            dgvProductos.DataSource = productoRepo.GetAll();
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

        private void btnAgregarOrigen_Click(object sender, EventArgs e)
        {
            var form = new OrigenForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                origenRepo.Add(form.Origen);
                CargarDatos();
            }
        }

        private void btnEditarOrigen_Click(object sender, EventArgs e)
        {
            if (dgvOrigenes.CurrentRow?.DataBoundItem is Origen origen)
            {
                var form = new OrigenForm(origen);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    origenRepo.Update(form.Origen);
                    CargarDatos();
                }
            }
        }

        private void btnEliminarOrigen_Click(object sender, EventArgs e)
        {
            if (dgvOrigenes.CurrentRow?.DataBoundItem is Origen origen)
            {
                origenRepo.Delete(origen.IdOrigen);
                CargarDatos();
            }
        }

        private void btnAgregarDestino_Click(object sender, EventArgs e)
        {
            var form = new DestinoForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                destinoRepo.Add(form.Destino);
                CargarDatos();
            }
        }

        private void btnEditarDestino_Click(object sender, EventArgs e)
        {
            if (dgvDestinos.CurrentRow?.DataBoundItem is Destino destino)
            {
                var form = new DestinoForm(destino);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    destinoRepo.Update(form.Destino);
                    CargarDatos();
                }
            }
        }

        private void btnEliminarDestino_Click(object sender, EventArgs e)
        {
            if (dgvDestinos.CurrentRow?.DataBoundItem is Destino destino)
            {
                destinoRepo.Delete(destino.IdDestino);
                CargarDatos();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            var form = new ProductoForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                productoRepo.Add(form.Producto);
                CargarDatos();
            }
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is Producto producto)
            {
                var form = new ProductoForm(producto);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    productoRepo.Update(form.Producto);
                    CargarDatos();
                }
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is Producto producto)
            {
                productoRepo.Delete(producto.IdProducto);
                CargarDatos();
            }
        }

        private void menuDatosGenerales_Click(object sender, EventArgs e)
        {
            var form = new DatosGeneralesForm(connectionString);
            form.ShowDialog();
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
    }
}
