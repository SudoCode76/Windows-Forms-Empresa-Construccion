using System;
using System.Windows.Forms;
using EmpresaConstruccion.Models;

namespace EmpresaConstruccion
{
    public partial class OrigenForm : Form
    {
        public Origen Origen { get; private set; }
        public OrigenForm() : this(null) { }
        public OrigenForm(Origen origen)
        {
            InitializeComponent();
            if (origen != null)
            {
                txtNombre.Text = origen.Nombre;
                txtTipo.Text = origen.Tipo;
                numCapacidad.Value = origen.CapacidadProduccion;
                txtUbicacion.Text = origen.Ubicacion;
                Origen = origen;
            }
            else
            {
                Origen = new Origen();
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Origen.Nombre = txtNombre.Text;
            Origen.Tipo = txtTipo.Text;
            Origen.CapacidadProduccion = (int)numCapacidad.Value;
            Origen.Ubicacion = txtUbicacion.Text;
            DialogResult = DialogResult.OK;
        }
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.NumericUpDown numCapacidad;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Button btnAceptar;
        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.numCapacidad = new System.Windows.Forms.NumericUpDown();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 20);
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 17);
            this.txtNombre.Size = new System.Drawing.Size(200, 27);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 60);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(39, 20);
            this.lblTipo.Text = "Tipo";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(120, 57);
            this.txtTipo.Size = new System.Drawing.Size(200, 27);
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Location = new System.Drawing.Point(20, 100);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(81, 20);
            this.lblCapacidad.Text = "Capacidad";
            // 
            // numCapacidad
            // 
            this.numCapacidad.Location = new System.Drawing.Point(120, 97);
            this.numCapacidad.Maximum = 1000000;
            this.numCapacidad.Size = new System.Drawing.Size(200, 27);
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(20, 140);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(74, 20);
            this.lblUbicacion.Text = "Ubicación";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(120, 137);
            this.txtUbicacion.Size = new System.Drawing.Size(200, 27);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(120, 180);
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // OrigenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.numCapacidad);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.btnAceptar);
            this.Name = "OrigenForm";
            this.Text = "Origen";
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}