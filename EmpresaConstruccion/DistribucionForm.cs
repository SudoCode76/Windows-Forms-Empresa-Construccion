using System;
using System.Windows.Forms;
using System.ComponentModel;
using EmpresaConstruccion.Data;
using EmpresaConstruccion.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmpresaConstruccion
{
    public partial class DistribucionForm : Form
    {
        public DistribucionForm()
        {
            InitializeComponent();
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int IdRuta { get => GetIdRuta(); set => SetIdRuta(value); }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int IdProducto { get => GetIdProducto(); set => SetIdProducto(value); }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CantidadEnviada { get => GetCantidadEnviada(); set => SetCantidadEnviada(value); }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.ComboBox cmbRuta;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAceptar;
        private void InitializeComponent()
        {
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cmbRuta = new System.Windows.Forms.ComboBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // lblRuta
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(20, 20);
            this.lblRuta.Text = "Ruta";
            // cmbRuta
            this.cmbRuta.Location = new System.Drawing.Point(120, 17);
            this.cmbRuta.Size = new System.Drawing.Size(200, 27);
            // lblProducto
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(20, 60);
            this.lblProducto.Text = "Producto";
            // cmbProducto
            this.cmbProducto.Location = new System.Drawing.Point(120, 57);
            this.cmbProducto.Size = new System.Drawing.Size(200, 27);
            // lblCantidad
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(20, 100);
            this.lblCantidad.Text = "Cantidad";
            // numCantidad
            this.numCantidad.Location = new System.Drawing.Point(120, 97);
            this.numCantidad.Maximum = 1000000;
            // btnAceptar
            this.btnAceptar.Location = new System.Drawing.Point(120, 140);
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // DistribucionForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 190);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.cmbRuta);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnAceptar);
            this.Name = "DistribucionForm";
            this.Text = "Distribución";
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private List<dynamic> rutas;
        private List<Producto> productos;
        public void CargarRutasYProductos(string connectionString)
        {
            var rutaRepo = new RutaRepository(connectionString);
            var productoRepo = new ProductoRepository(connectionString);
            var origenRepo = new OrigenRepository(connectionString);
            var destinoRepo = new DestinoRepository(connectionString);
            rutas = rutaRepo.GetAll();
            productos = productoRepo.GetAll();
            var origenes = origenRepo.GetAll();
            var destinos = destinoRepo.GetAll();
            // Mostrar la ruta como "Origen ? Destino"
            var rutasDisplay = rutas.Select(r => new {
                IdRuta = (int)r.GetType().GetProperty("IdRuta").GetValue(r),
                NombreRuta = origenes.FirstOrDefault(o => o.IdOrigen == (int)r.GetType().GetProperty("IdOrigen").GetValue(r))?.Nombre +
                    " ? " +
                    destinos.FirstOrDefault(d => d.IdDestino == (int)r.GetType().GetProperty("IdDestino").GetValue(r))?.Nombre
            }).ToList();
            cmbRuta.DataSource = rutasDisplay;
            cmbRuta.DisplayMember = "NombreRuta";
            cmbRuta.ValueMember = "IdRuta";
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IdProducto";
        }
        public int GetIdRuta() => cmbRuta.SelectedValue != null ? (int)cmbRuta.SelectedValue : 0;
        public void SetIdRuta(int value) => cmbRuta.SelectedValue = value;
        public int GetIdProducto() => cmbProducto.SelectedValue != null ? (int)cmbProducto.SelectedValue : 0;
        public void SetIdProducto(int value) => cmbProducto.SelectedValue = value;
        public int GetCantidadEnviada() => (int)numCantidad.Value;
        public void SetCantidadEnviada(int value) => numCantidad.Value = value;
    }
}