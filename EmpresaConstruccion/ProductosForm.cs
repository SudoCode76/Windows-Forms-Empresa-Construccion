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
            this.dgvProductos = new DataGridView { Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(600, 250), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            this.btnAgregar = new Button { Text = "Agregar", Location = new System.Drawing.Point(620, 10), Size = new System.Drawing.Size(100, 30) };
            this.btnEditar = new Button { Text = "Editar", Location = new System.Drawing.Point(620, 50), Size = new System.Drawing.Size(100, 30) };
            this.btnEliminar = new Button { Text = "Eliminar", Location = new System.Drawing.Point(620, 90), Size = new System.Drawing.Size(100, 30) };
            this.Controls.AddRange(new Control[] { dgvProductos, btnAgregar, btnEditar, btnEliminar });
            this.ClientSize = new System.Drawing.Size(740, 280);
            this.Text = "Gestión de Productos";
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
