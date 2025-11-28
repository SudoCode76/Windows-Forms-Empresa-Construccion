using System.Windows.Forms;
using EmpresaConstruccion.Data;

namespace EmpresaConstruccion
{
    public partial class TransporteForm : Form
    {
        private RutaRepository rutaRepo;
        private DistribucionRepository distribucionRepo;
        private string _connectionString;

        public TransporteForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            rutaRepo = new RutaRepository(_connectionString);
            distribucionRepo = new DistribucionRepository(_connectionString);
            CargarDatos();
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRutas;
        private System.Windows.Forms.TabPage tabDistribucion;
        private System.Windows.Forms.DataGridView dgvRutas;
        private System.Windows.Forms.DataGridView dgvDistribucion;
        private System.Windows.Forms.Button btnAgregarRuta;
        private System.Windows.Forms.Button btnEditarRuta;
        private System.Windows.Forms.Button btnEliminarRuta;
        private System.Windows.Forms.Button btnAgregarDistribucion;
        private System.Windows.Forms.Button btnEditarDistribucion;
        private System.Windows.Forms.Button btnEliminarDistribucion;
        private void InitializeComponent()
        {
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Text = "Transporte y Distribución";
            this.ClientSize = new System.Drawing.Size(780, 400);
            var panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, BackColor = System.Drawing.Color.White };
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            var btnPanelRutas = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, BackColor = System.Drawing.Color.FromArgb(240, 244, 255) };
            var btnPanelDist = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, BackColor = System.Drawing.Color.FromArgb(240, 244, 255) };
            this.tabControl = new TabControl { Dock = DockStyle.Fill };
            this.tabRutas = new TabPage("Rutas");
            this.tabDistribucion = new TabPage("Distribución");
            this.dgvRutas = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White, BorderStyle = BorderStyle.None };
            this.dgvDistribucion = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, BackgroundColor = System.Drawing.Color.White, BorderStyle = BorderStyle.None };
            this.btnAgregarRuta = new Button { Text = "Agregar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(44, 130, 201), ForeColor = System.Drawing.Color.White };
            this.btnEditarRuta = new Button { Text = "Editar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(52, 152, 219), ForeColor = System.Drawing.Color.White };
            this.btnEliminarRuta = new Button { Text = "Eliminar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(231, 76, 60), ForeColor = System.Drawing.Color.White };
            this.btnAgregarDistribucion = new Button { Text = "Agregar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(44, 130, 201), ForeColor = System.Drawing.Color.White };
            this.btnEditarDistribucion = new Button { Text = "Editar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(52, 152, 219), ForeColor = System.Drawing.Color.White };
            this.btnEliminarDistribucion = new Button { Text = "Eliminar", Width = 100, Height = 40, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(231, 76, 60), ForeColor = System.Drawing.Color.White };
            btnPanelRutas.Controls.AddRange(new Control[] { btnAgregarRuta, btnEditarRuta, btnEliminarRuta });
            btnPanelDist.Controls.AddRange(new Control[] { btnAgregarDistribucion, btnEditarDistribucion, btnEliminarDistribucion });
            var rutasPanel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            rutasPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            rutasPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            rutasPanel.Controls.Add(dgvRutas, 0, 0);
            rutasPanel.Controls.Add(btnPanelRutas, 1, 0);
            var distPanel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1 };
            distPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            distPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            distPanel.Controls.Add(dgvDistribucion, 0, 0);
            distPanel.Controls.Add(btnPanelDist, 1, 0);
            tabRutas.Controls.Add(rutasPanel);
            tabDistribucion.Controls.Add(distPanel);
            tabControl.TabPages.AddRange(new[] { tabRutas, tabDistribucion });
            this.Controls.Add(tabControl);
            btnAgregarRuta.Click += btnAgregarRuta_Click;
            btnEditarRuta.Click += btnEditarRuta_Click;
            btnEliminarRuta.Click += btnEliminarRuta_Click;
            btnAgregarDistribucion.Click += btnAgregarDistribucion_Click;
            btnEditarDistribucion.Click += btnEditarDistribucion_Click;
            btnEliminarDistribucion.Click += btnEliminarDistribucion_Click;
        }

        private void CargarDatos()
        {
            // Obtener orígenes y destinos para mostrar nombres en vez de IDs
            var origenes = new EmpresaConstruccion.Data.OrigenRepository(_connectionString).GetAll();
            var destinosLista = new EmpresaConstruccion.Data.DestinoRepository(_connectionString).GetAll();
            var rutas = rutaRepo.GetAll();
            var rutasDisplay = rutas.Select(r => new {
                IdRuta = (int)r.GetType().GetProperty("IdRuta").GetValue(r),
                Origen = origenes.FirstOrDefault(o => o.IdOrigen == (int)r.GetType().GetProperty("IdOrigen").GetValue(r))?.Nombre,
                Destino = destinosLista.BuscarPorId((int)r.GetType().GetProperty("IdDestino").GetValue(r))?.Nombre,
                CostoTransporte = (decimal)r.GetType().GetProperty("CostoTransporte").GetValue(r),
                DistanciaKm = (decimal)r.GetType().GetProperty("DistanciaKm").GetValue(r),
                TiempoHoras = (decimal)r.GetType().GetProperty("TiempoHoras").GetValue(r),
                CapacidadRequerida = (int)r.GetType().GetProperty("CapacidadRequerida").GetValue(r)
            }).ToList();
            dgvRutas.DataSource = null;
            dgvRutas.DataSource = rutasDisplay;
            dgvRutas.ClearSelection();
            dgvDistribucion.DataSource = null;
            dgvDistribucion.DataSource = distribucionRepo.GetAll();
            dgvDistribucion.ClearSelection();
        }

        private void btnAgregarRuta_Click(object sender, EventArgs e)
        {
            var form = new RutaForm();
            form.CargarOrigenesYDestinos(_connectionString);
            if (form.ShowDialog() == DialogResult.OK)
            {
                rutaRepo.Add(form.IdOrigen, form.IdDestino, form.CostoTransporte, form.DistanciaKm, form.TiempoHoras, form.CapacidadRequerida);
                CargarDatos();
            }
        }
        private void btnEditarRuta_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow != null && dgvRutas.CurrentRow.DataBoundItem != null)
            {
                var r = dgvRutas.CurrentRow.DataBoundItem;
                int idRuta = (int)r.GetType().GetProperty("IdRuta").GetValue(r);
                int idOrigen = (int)r.GetType().GetProperty("IdOrigen").GetValue(r);
                int idDestino = (int)r.GetType().GetProperty("IdDestino").GetValue(r);
                decimal costo = (decimal)r.GetType().GetProperty("CostoTransporte").GetValue(r);
                decimal distancia = (decimal)r.GetType().GetProperty("DistanciaKm").GetValue(r);
                decimal tiempo = (decimal)r.GetType().GetProperty("TiempoHoras").GetValue(r);
                int capacidad = (int)r.GetType().GetProperty("CapacidadRequerida").GetValue(r);
                var form = new RutaForm();
                form.CargarOrigenesYDestinos(_connectionString);
                form.IdOrigen = idOrigen;
                form.IdDestino = idDestino;
                form.CostoTransporte = costo;
                form.DistanciaKm = distancia;
                form.TiempoHoras = tiempo;
                form.CapacidadRequerida = capacidad;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    rutaRepo.Update(idRuta, form.IdOrigen, form.IdDestino, form.CostoTransporte, form.DistanciaKm, form.TiempoHoras, form.CapacidadRequerida);
                    CargarDatos();
                }
            }
        }
        private void btnEliminarRuta_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow != null && dgvRutas.CurrentRow.DataBoundItem != null)
            {
                var r = dgvRutas.CurrentRow.DataBoundItem;
                int idRuta = (int)r.GetType().GetProperty("IdRuta").GetValue(r);
                rutaRepo.Delete(idRuta);
                CargarDatos();
            }
        }
        private void btnAgregarDistribucion_Click(object sender, EventArgs e)
        {
            var form = new DistribucionForm();
            form.CargarRutasYProductos(_connectionString);
            if (form.ShowDialog() == DialogResult.OK)
            {
                distribucionRepo.Add(form.IdRuta, form.IdProducto, form.CantidadEnviada);
                CargarDatos();
            }
        }
        private void btnEditarDistribucion_Click(object sender, EventArgs e)
        {
            if (dgvDistribucion.CurrentRow != null && dgvDistribucion.CurrentRow.DataBoundItem != null)
            {
                var d = dgvDistribucion.CurrentRow.DataBoundItem;
                int idDistribucion = (int)d.GetType().GetProperty("IdDistribucion").GetValue(d);
                int idRuta = (int)d.GetType().GetProperty("IdRuta").GetValue(d);
                int idProducto = (int)d.GetType().GetProperty("IdProducto").GetValue(d);
                int cantidad = (int)d.GetType().GetProperty("CantidadEnviada").GetValue(d);
                var form = new DistribucionForm();
                form.CargarRutasYProductos(_connectionString);
                form.IdRuta = idRuta;
                form.IdProducto = idProducto;
                form.CantidadEnviada = cantidad;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    distribucionRepo.Update(idDistribucion, form.IdRuta, form.IdProducto, form.CantidadEnviada);
                    CargarDatos();
                }
            }
        }
        private void btnEliminarDistribucion_Click(object sender, EventArgs e)
        {
            if (dgvDistribucion.CurrentRow != null && dgvDistribucion.CurrentRow.DataBoundItem != null)
            {
                var d = dgvDistribucion.CurrentRow.DataBoundItem;
                int idDistribucion = (int)d.GetType().GetProperty("IdDistribucion").GetValue(d);
                distribucionRepo.Delete(idDistribucion);
                CargarDatos();
            }
        }
    }
}