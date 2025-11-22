using System.Windows.Forms;
using EmpresaConstruccion.Data;
using EmpresaConstruccion.Models;

namespace EmpresaConstruccion
{
    public partial class DestinosForm : Form
    {
        private DestinoRepository destinoRepo;
        private DataGridView dgvDestinos;
        private Button btnAgregar, btnEditar, btnEliminar;
        private string _connectionString;
        public DestinosForm(string connectionString)
        {
            _connectionString = connectionString;
            destinoRepo = new DestinoRepository(_connectionString);
            InitializeComponent();
            CargarDatos();
        }
        private void InitializeComponent()
        {
            this.dgvDestinos = new DataGridView { Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(600, 250), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            this.btnAgregar = new Button { Text = "Agregar", Location = new System.Drawing.Point(620, 10), Size = new System.Drawing.Size(100, 30) };
            this.btnEditar = new Button { Text = "Editar", Location = new System.Drawing.Point(620, 50), Size = new System.Drawing.Size(100, 30) };
            this.btnEliminar = new Button { Text = "Eliminar", Location = new System.Drawing.Point(620, 90), Size = new System.Drawing.Size(100, 30) };
            this.Controls.AddRange(new Control[] { dgvDestinos, btnAgregar, btnEditar, btnEliminar });
            this.ClientSize = new System.Drawing.Size(740, 280);
            this.Text = "Gestión de Destinos";
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }
        private void CargarDatos()
        {
            dgvDestinos.DataSource = null;
            dgvDestinos.DataSource = destinoRepo.GetAll();
            dgvDestinos.ClearSelection();
        }
        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            var form = new DestinoForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                destinoRepo.Add(form.Destino);
                CargarDatos();
            }
        }
        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (dgvDestinos.CurrentRow != null && dgvDestinos.CurrentRow.DataBoundItem is Destino destino)
            {
                var destinoCopia = new Destino
                {
                    IdDestino = destino.IdDestino,
                    Nombre = destino.Nombre,
                    Tipo = destino.Tipo,
                    Demanda = destino.Demanda,
                    Ubicacion = destino.Ubicacion
                };
                var form = new DestinoForm(destinoCopia);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
                if (form.DialogResult == DialogResult.OK)
                {
                    destinoRepo.Update(form.Destino);
                    CargarDatos();
                }
            }
        }
        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (dgvDestinos.CurrentRow != null && dgvDestinos.CurrentRow.DataBoundItem is Destino destino)
            {
                if (MessageBox.Show($"¿Seguro que desea eliminar el destino '{destino.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    destinoRepo.Delete(destino.IdDestino);
                    CargarDatos();
                }
            }
        }
    }
}
