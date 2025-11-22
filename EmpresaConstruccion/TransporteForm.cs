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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRutas = new System.Windows.Forms.TabPage();
            this.tabDistribucion = new System.Windows.Forms.TabPage();
            this.dgvRutas = new System.Windows.Forms.DataGridView();
            this.dgvDistribucion = new System.Windows.Forms.DataGridView();
            this.btnAgregarRuta = new System.Windows.Forms.Button();
            this.btnEditarRuta = new System.Windows.Forms.Button();
            this.btnEliminarRuta = new System.Windows.Forms.Button();
            this.btnAgregarDistribucion = new System.Windows.Forms.Button();
            this.btnEditarDistribucion = new System.Windows.Forms.Button();
            this.btnEliminarDistribucion = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabRutas.SuspendLayout();
            this.tabDistribucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribucion)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabRutas);
            this.tabControl.Controls.Add(this.tabDistribucion);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 380);
            // 
            // tabRutas
            // 
            this.tabRutas.Controls.Add(this.dgvRutas);
            this.tabRutas.Controls.Add(this.btnAgregarRuta);
            this.tabRutas.Controls.Add(this.btnEditarRuta);
            this.tabRutas.Controls.Add(this.btnEliminarRuta);
            this.tabRutas.Location = new System.Drawing.Point(4, 29);
            this.tabRutas.Name = "tabRutas";
            this.tabRutas.Padding = new System.Windows.Forms.Padding(3);
            this.tabRutas.Size = new System.Drawing.Size(752, 347);
            this.tabRutas.Text = "Rutas";
            this.tabRutas.UseVisualStyleBackColor = true;
            // 
            // dgvRutas
            // 
            this.dgvRutas.Location = new System.Drawing.Point(10, 10);
            this.dgvRutas.Size = new System.Drawing.Size(600, 280);
            this.dgvRutas.Name = "dgvRutas";
            this.dgvRutas.TabIndex = 0;
            // 
            // btnAgregarRuta
            // 
            this.btnAgregarRuta.Location = new System.Drawing.Point(630, 10);
            this.btnAgregarRuta.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarRuta.Text = "Agregar";
            this.btnAgregarRuta.Click += new System.EventHandler(this.btnAgregarRuta_Click);
            // 
            // btnEditarRuta
            // 
            this.btnEditarRuta.Location = new System.Drawing.Point(630, 50);
            this.btnEditarRuta.Size = new System.Drawing.Size(100, 30);
            this.btnEditarRuta.Text = "Editar";
            this.btnEditarRuta.Click += new System.EventHandler(this.btnEditarRuta_Click);
            // 
            // btnEliminarRuta
            // 
            this.btnEliminarRuta.Location = new System.Drawing.Point(630, 90);
            this.btnEliminarRuta.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarRuta.Text = "Eliminar";
            this.btnEliminarRuta.Click += new System.EventHandler(this.btnEliminarRuta_Click);
            // 
            // tabDistribucion
            // 
            this.tabDistribucion.Controls.Add(this.dgvDistribucion);
            this.tabDistribucion.Controls.Add(this.btnAgregarDistribucion);
            this.tabDistribucion.Controls.Add(this.btnEditarDistribucion);
            this.tabDistribucion.Controls.Add(this.btnEliminarDistribucion);
            this.tabDistribucion.Location = new System.Drawing.Point(4, 29);
            this.tabDistribucion.Name = "tabDistribucion";
            this.tabDistribucion.Padding = new System.Windows.Forms.Padding(3);
            this.tabDistribucion.Size = new System.Drawing.Size(752, 347);
            this.tabDistribucion.Text = "Distribución";
            this.tabDistribucion.UseVisualStyleBackColor = true;
            // 
            // dgvDistribucion
            // 
            this.dgvDistribucion.Location = new System.Drawing.Point(10, 10);
            this.dgvDistribucion.Size = new System.Drawing.Size(600, 280);
            this.dgvDistribucion.Name = "dgvDistribucion";
            this.dgvDistribucion.TabIndex = 0;
            // 
            // btnAgregarDistribucion
            // 
            this.btnAgregarDistribucion.Location = new System.Drawing.Point(630, 10);
            this.btnAgregarDistribucion.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarDistribucion.Text = "Agregar";
            this.btnAgregarDistribucion.Click += new System.EventHandler(this.btnAgregarDistribucion_Click);
            // 
            // btnEditarDistribucion
            // 
            this.btnEditarDistribucion.Location = new System.Drawing.Point(630, 50);
            this.btnEditarDistribucion.Size = new System.Drawing.Size(100, 30);
            this.btnEditarDistribucion.Text = "Editar";
            this.btnEditarDistribucion.Click += new System.EventHandler(this.btnEditarDistribucion_Click);
            // 
            // btnEliminarDistribucion
            // 
            this.btnEliminarDistribucion.Location = new System.Drawing.Point(630, 90);
            this.btnEliminarDistribucion.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarDistribucion.Text = "Eliminar";
            this.btnEliminarDistribucion.Click += new System.EventHandler(this.btnEliminarDistribucion_Click);
            // 
            // TransporteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 400);
            this.Controls.Add(this.tabControl);
            this.Name = "TransporteForm";
            this.Text = "Transporte y Distribución";
            this.tabControl.ResumeLayout(false);
            this.tabRutas.ResumeLayout(false);
            this.tabDistribucion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRutas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDistribucion)).EndInit();
            this.ResumeLayout(false);
        }

        private void CargarDatos()
        {
            dgvRutas.DataSource = rutaRepo.GetAll();
            dgvDistribucion.DataSource = distribucionRepo.GetAll();
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