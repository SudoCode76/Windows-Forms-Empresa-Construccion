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
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Text = "Gestión de Destinos";
            this.ClientSize = new System.Drawing.Size(740, 280);
            var panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, BackColor = System.Drawing.Color.White };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, BackColor = System.Drawing.Color.FromArgb(240, 244, 255) };
            this.dgvDestinos = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White, BorderStyle = BorderStyle.None };
            this.btnAgregar = new Button { Text = "Agregar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(44, 130, 201), ForeColor = System.Drawing.Color.White };
            this.btnEditar = new Button { Text = "Editar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(52, 152, 219), ForeColor = System.Drawing.Color.White };
            this.btnEliminar = new Button { Text = "Eliminar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(231, 76, 60), ForeColor = System.Drawing.Color.White };
            btnPanel.Controls.AddRange(new Control[] { btnAgregar, btnEditar, btnEliminar });
            panel.Controls.Add(dgvDestinos, 0, 0);
            panel.Controls.Add(btnPanel, 1, 0);
            this.Controls.Add(panel);
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
