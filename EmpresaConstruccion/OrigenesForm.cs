using System.Windows.Forms;
using EmpresaConstruccion.Data;
using EmpresaConstruccion.Models;

namespace EmpresaConstruccion
{
    public partial class OrigenesForm : Form
    {
        private OrigenRepository origenRepo;
        private DataGridView dgvOrigenes;
        private Button btnAgregar, btnEditar, btnEliminar;
        private string _connectionString;
        public OrigenesForm(string connectionString)
        {
            _connectionString = connectionString;
            origenRepo = new OrigenRepository(_connectionString);
            InitializeComponent();
            CargarDatos();
        }
        private void InitializeComponent()
        {
            this.dgvOrigenes = new DataGridView { Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(600, 250), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            this.btnAgregar = new Button { Text = "Agregar", Location = new System.Drawing.Point(620, 10), Size = new System.Drawing.Size(100, 30) };
            this.btnEditar = new Button { Text = "Editar", Location = new System.Drawing.Point(620, 50), Size = new System.Drawing.Size(100, 30) };
            this.btnEliminar = new Button { Text = "Eliminar", Location = new System.Drawing.Point(620, 90), Size = new System.Drawing.Size(100, 30) };
            this.Controls.AddRange(new Control[] { dgvOrigenes, btnAgregar, btnEditar, btnEliminar });
            this.ClientSize = new System.Drawing.Size(740, 280);
            this.Text = "Gestión de Orígenes";
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }
        private void CargarDatos()
        {
            dgvOrigenes.DataSource = null;
            dgvOrigenes.DataSource = origenRepo.GetAll();
            dgvOrigenes.ClearSelection();
        }
        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            var form = new OrigenForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                origenRepo.Add(form.Origen);
                CargarDatos();
            }
        }
        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (dgvOrigenes.CurrentRow != null && dgvOrigenes.CurrentRow.DataBoundItem is Origen origen)
            {
                var origenCopia = new Origen
                {
                    IdOrigen = origen.IdOrigen,
                    Nombre = origen.Nombre,
                    Tipo = origen.Tipo,
                    CapacidadProduccion = origen.CapacidadProduccion,
                    Ubicacion = origen.Ubicacion
                };
                var form = new OrigenForm(origenCopia);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
                if (form.DialogResult == DialogResult.OK)
                {
                    origenRepo.Update(form.Origen);
                    CargarDatos();
                }
            }
        }
        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (dgvOrigenes.CurrentRow != null && dgvOrigenes.CurrentRow.DataBoundItem is Origen origen)
            {
                if (MessageBox.Show($"¿Seguro que desea eliminar el origen '{origen.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    origenRepo.Delete(origen.IdOrigen);
                    CargarDatos();
                }
            }
        }
    }
}
