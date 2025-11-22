using System.Windows.Forms;
using EmpresaConstruccion.Data;
using EmpresaConstruccion.Models;
using System.Collections.Generic;

namespace EmpresaConstruccion
{
    public partial class DatosGeneralesForm : Form
    {
        private OrigenRepository origenRepo;
        private DestinoRepository destinoRepo;
        private ProductoRepository productoRepo;
        private TabControl tabControl;
        private TabPage tabOrigenes;
        private TabPage tabDestinos;
        private TabPage tabProductos;
        private DataGridView dgvOrigenes;
        private DataGridView dgvDestinos;
        private DataGridView dgvProductos;
        private Button btnAgregarOrigen, btnEditarOrigen, btnEliminarOrigen;
        private Button btnAgregarDestino, btnEditarDestino, btnEliminarDestino;
        private Button btnAgregarProducto, btnEditarProducto, btnEliminarProducto;
        private string _connectionString;

        public DatosGeneralesForm(string connectionString)
        {
            _connectionString = connectionString;
            origenRepo = new OrigenRepository(_connectionString);
            destinoRepo = new DestinoRepository(_connectionString);
            productoRepo = new ProductoRepository(_connectionString);
            InitializeComponent();
            CargarDatos();
        }

        private void InitializeComponent()
        {
            this.tabControl = new TabControl();
            this.tabOrigenes = new TabPage("Orígenes");
            this.tabDestinos = new TabPage("Destinos");
            this.tabProductos = new TabPage("Productos");
            this.dgvOrigenes = new DataGridView { Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(600, 250) };
            this.dgvDestinos = new DataGridView { Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(600, 250) };
            this.dgvProductos = new DataGridView { Location = new System.Drawing.Point(10, 10), Size = new System.Drawing.Size(600, 250) };
            this.btnAgregarOrigen = new Button { Text = "Agregar", Location = new System.Drawing.Point(620, 10), Size = new System.Drawing.Size(100, 30) };
            this.btnEditarOrigen = new Button { Text = "Editar", Location = new System.Drawing.Point(620, 50), Size = new System.Drawing.Size(100, 30) };
            this.btnEliminarOrigen = new Button { Text = "Eliminar", Location = new System.Drawing.Point(620, 90), Size = new System.Drawing.Size(100, 30) };
            this.btnAgregarDestino = new Button { Text = "Agregar", Location = new System.Drawing.Point(620, 10), Size = new System.Drawing.Size(100, 30) };
            this.btnEditarDestino = new Button { Text = "Editar", Location = new System.Drawing.Point(620, 50), Size = new System.Drawing.Size(100, 30) };
            this.btnEliminarDestino = new Button { Text = "Eliminar", Location = new System.Drawing.Point(620, 90), Size = new System.Drawing.Size(100, 30) };
            this.btnAgregarProducto = new Button { Text = "Agregar", Location = new System.Drawing.Point(620, 10), Size = new System.Drawing.Size(100, 30) };
            this.btnEditarProducto = new Button { Text = "Editar", Location = new System.Drawing.Point(620, 50), Size = new System.Drawing.Size(100, 30) };
            this.btnEliminarProducto = new Button { Text = "Eliminar", Location = new System.Drawing.Point(620, 90), Size = new System.Drawing.Size(100, 30) };
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Size = new System.Drawing.Size(740, 340);
            this.tabControl.TabPages.AddRange(new[] { tabOrigenes, tabDestinos, tabProductos });
            this.tabOrigenes.Controls.AddRange(new Control[] { dgvOrigenes, btnAgregarOrigen, btnEditarOrigen, btnEliminarOrigen });
            this.tabDestinos.Controls.AddRange(new Control[] { dgvDestinos, btnAgregarDestino, btnEditarDestino, btnEliminarDestino });
            this.tabProductos.Controls.AddRange(new Control[] { dgvProductos, btnAgregarProducto, btnEditarProducto, btnEliminarProducto });
            this.Controls.Add(tabControl);
            this.ClientSize = new System.Drawing.Size(780, 370);
            this.Text = "Datos Generales";
            btnAgregarOrigen.Click += btnAgregarOrigen_Click;
            btnEditarOrigen.Click += btnEditarOrigen_Click;
            btnEliminarOrigen.Click += btnEliminarOrigen_Click;
            btnAgregarDestino.Click += btnAgregarDestino_Click;
            btnEditarDestino.Click += btnEditarDestino_Click;
            btnEliminarDestino.Click += btnEliminarDestino_Click;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            btnEditarProducto.Click += btnEditarProducto_Click;
            btnEliminarProducto.Click += btnEliminarProducto_Click;
        }

        private void CargarDatos()
        {
            dgvOrigenes.DataSource = null;
            dgvOrigenes.DataSource = origenRepo.GetAll();
            dgvOrigenes.ClearSelection();
            dgvDestinos.DataSource = null;
            dgvDestinos.DataSource = destinoRepo.GetAll();
            dgvDestinos.ClearSelection();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productoRepo.GetAll();
            dgvProductos.ClearSelection();
            dgvOrigenes.ReadOnly = true;
            dgvDestinos.ReadOnly = true;
            dgvProductos.ReadOnly = true;
            dgvOrigenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDestinos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnAgregarOrigen_Click(object sender, System.EventArgs e)
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
        private void btnEditarOrigen_Click(object sender, System.EventArgs e)
        {
            if (dgvOrigenes.CurrentRow != null && dgvOrigenes.CurrentRow.DataBoundItem is Origen origen)
            {
                // Clonar el objeto para evitar modificar el DataSource directamente
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
        private void btnEliminarOrigen_Click(object sender, System.EventArgs e)
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
        private void btnAgregarDestino_Click(object sender, System.EventArgs e)
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
        private void btnEditarDestino_Click(object sender, System.EventArgs e)
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
        private void btnEliminarDestino_Click(object sender, System.EventArgs e)
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
        private void btnAgregarProducto_Click(object sender, System.EventArgs e)
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
        private void btnEditarProducto_Click(object sender, System.EventArgs e)
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
        private void btnEliminarProducto_Click(object sender, System.EventArgs e)
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