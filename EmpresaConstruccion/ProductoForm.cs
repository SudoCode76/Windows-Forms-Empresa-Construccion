using System;
using System.Windows.Forms;
using EmpresaConstruccion.Models;

namespace EmpresaConstruccion
{
    public partial class ProductoForm : Form
    {
        public Producto Producto { get; private set; }
        public ProductoForm() : this(null) { }
        public ProductoForm(Producto producto)
        {
            InitializeComponent();
            if (producto != null)
            {
                txtNombre.Text = producto.Nombre;
                txtTipo.Text = producto.TipoProducto;
                txtUnidad.Text = producto.UnidadMedida;
                numCantidad.Value = producto.CantidadDisponible;
                Producto = producto;
            }
            else
            {
                Producto = new Producto();
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto.Nombre = txtNombre.Text;
            Producto.TipoProducto = txtTipo.Text;
            Producto.UnidadMedida = txtUnidad.Text;
            Producto.CantidadDisponible = (int)numCantidad.Value;
            DialogResult = DialogResult.OK;
        }

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAceptar;
        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // lblNombre
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 20);
            this.lblNombre.Text = "Nombre";
            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(120, 17);
            this.txtNombre.Size = new System.Drawing.Size(200, 27);
            // lblTipo
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 60);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(39, 20);
            this.lblTipo.Text = "Tipo";
            // txtTipo
            this.txtTipo.Location = new System.Drawing.Point(120, 57);
            this.txtTipo.Size = new System.Drawing.Size(200, 27);
            // lblUnidad
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(20, 100);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(104, 20);
            this.lblUnidad.Text = "Unidad Medida";
            // txtUnidad
            this.txtUnidad.Location = new System.Drawing.Point(120, 97);
            this.txtUnidad.Size = new System.Drawing.Size(200, 27);
            // lblCantidad
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(20, 140);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(69, 20);
            this.lblCantidad.Text = "Cantidad";
            // numCantidad
            this.numCantidad.Location = new System.Drawing.Point(120, 137);
            this.numCantidad.Maximum = 1000000;
            this.numCantidad.Size = new System.Drawing.Size(200, 27);
            // btnAceptar
            this.btnAceptar.Location = new System.Drawing.Point(120, 180);
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // ProductoForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.txtUnidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnAceptar);
            this.Name = "ProductoForm";
            this.Text = "Producto";
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}