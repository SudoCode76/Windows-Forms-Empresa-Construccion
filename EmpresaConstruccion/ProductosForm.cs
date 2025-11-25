using System.Windows.Forms;
using EmpresaConstruccion.Data;
using EmpresaConstruccion.Models;

namespace EmpresaConstruccion
{
    public partial class ProductosForm : Form
    {
        private ProductoRepository productoRepo;
        private DataGridView dgvProductos;
        private Button btnAgregar, btnEditar, btnEliminar;
        private string _connectionString;
        public ProductosForm(string connectionString)
        {
            _connectionString = connectionString;
            productoRepo = new ProductoRepository(_connectionString);
            InitializeComponent();
            CargarDatos();
        }
        private void InitializeComponent()
        {
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Text = "Gestión de Productos";
            this.ClientSize = new System.Drawing.Size(740, 280);
            var panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, BackColor = System.Drawing.Color.White };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, BackColor = System.Drawing.Color.FromArgb(240, 244, 255) };
            this.dgvProductos = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White, BorderStyle = BorderStyle.None };
            this.btnAgregar = new Button { Text = "Agregar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(44, 130, 201), ForeColor = System.Drawing.Color.White };
            this.btnEditar = new Button { Text = "Editar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(52, 152, 219), ForeColor = System.Drawing.Color.White };
            this.btnEliminar = new Button { Text = "Eliminar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(231, 76, 60), ForeColor = System.Drawing.Color.White };
            btnPanel.Controls.AddRange(new Control[] { btnAgregar, btnEditar, btnEliminar });
            panel.Controls.Add(dgvProductos, 0, 0);
            panel.Controls.Add(btnPanel, 1, 0);
            this.Controls.Add(panel);
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }
        private void CargarDatos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productoRepo.GetAll();
            dgvProductos.ClearSelection();
        }
        private void btnAgregar_Click(object sender, System.EventArgs e)
        {
            var form = new ProductoForm();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                productoRepo.Add(form.Producto);
                CargarDatos();
            }
        }
        private void btnEditar_Click(object sender, System.EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is Producto producto)
            {
                var productoCopia = new Producto
                {
                    IdProducto = producto.IdProducto,
                    Nombre = producto.Nombre,
                    TipoProducto = producto.TipoProducto,
                    UnidadMedida = producto.UnidadMedida,
                    CantidadDisponible = producto.CantidadDisponible
                };
                var form = new ProductoForm(productoCopia);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog(this);
                if (form.DialogResult == DialogResult.OK)
                {
                    productoRepo.Update(form.Producto);
                    CargarDatos();
                }
            }
        }
        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is Producto producto)
            {
                if (MessageBox.Show($"¿Seguro que desea eliminar el producto '{producto.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    productoRepo.Delete(producto.IdProducto);
                    CargarDatos();
                }
            }
        }
    }
}
