using System;
using System.Windows.Forms;
using EmpresaConstruccion.Models;

namespace EmpresaConstruccion
{
    public partial class DestinoForm : Form
    {
        public Destino Destino { get; private set; }
        public DestinoForm() : this(null) { }
        public DestinoForm(Destino destino)
        {
            InitializeComponent();
            if (destino != null)
            {
                txtNombre.Text = destino.Nombre;
                txtTipo.Text = destino.Tipo;
                numDemanda.Value = destino.Demanda;
                txtUbicacion.Text = destino.Ubicacion;
                Destino = destino;
            }
            else
            {
                Destino = new Destino();
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Destino.Nombre = txtNombre.Text;
            Destino.Tipo = txtTipo.Text;
            Destino.Demanda = (int)numDemanda.Value;
            Destino.Ubicacion = txtUbicacion.Text;
            DialogResult = DialogResult.OK;
        }
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblDemanda;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.NumericUpDown numDemanda;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Button btnAceptar;
        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblDemanda = new System.Windows.Forms.Label();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.numDemanda = new System.Windows.Forms.NumericUpDown();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDemanda)).BeginInit();
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
            // lblDemanda
            this.lblDemanda.AutoSize = true;
            this.lblDemanda.Location = new System.Drawing.Point(20, 100);
            this.lblDemanda.Name = "lblDemanda";
            this.lblDemanda.Size = new System.Drawing.Size(70, 20);
            this.lblDemanda.Text = "Demanda";
            // numDemanda
            this.numDemanda.Location = new System.Drawing.Point(120, 97);
            this.numDemanda.Maximum = 1000000;
            this.numDemanda.Size = new System.Drawing.Size(200, 27);
            // lblUbicacion
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(20, 140);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(74, 20);
            this.lblUbicacion.Text = "Ubicación";
            // txtUbicacion
            this.txtUbicacion.Location = new System.Drawing.Point(120, 137);
            this.txtUbicacion.Size = new System.Drawing.Size(200, 27);
            // btnAceptar
            this.btnAceptar.Location = new System.Drawing.Point(120, 180);
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // DestinoForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblDemanda);
            this.Controls.Add(this.numDemanda);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.btnAceptar);
            this.Name = "DestinoForm";
            this.Text = "Destino";
            ((System.ComponentModel.ISupportInitialize)(this.numDemanda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}