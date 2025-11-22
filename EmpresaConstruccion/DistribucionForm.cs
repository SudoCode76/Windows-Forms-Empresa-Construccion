using System;
using System.Windows.Forms;
using System.ComponentModel;

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
        private System.Windows.Forms.NumericUpDown numRuta;
        private System.Windows.Forms.NumericUpDown numProducto;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Button btnAceptar;
        private void InitializeComponent()
        {
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.numRuta = new System.Windows.Forms.NumericUpDown();
            this.numProducto = new System.Windows.Forms.NumericUpDown();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // lblRuta
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(20, 20);
            this.lblRuta.Text = "Id Ruta";
            // numRuta
            this.numRuta.Location = new System.Drawing.Point(120, 17);
            this.numRuta.Maximum = 1000000;
            // lblProducto
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(20, 60);
            this.lblProducto.Text = "Id Producto";
            // numProducto
            this.numProducto.Location = new System.Drawing.Point(120, 57);
            this.numProducto.Maximum = 1000000;
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
            this.Controls.Add(this.numRuta);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.numProducto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.numCantidad);
            this.Controls.Add(this.btnAceptar);
            this.Name = "DistribucionForm";
            this.Text = "Distribución";
            ((System.ComponentModel.ISupportInitialize)(this.numRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        // Elimina las propiedades automáticas que usan controles en tiempo de diseño, usa métodos públicos para obtener/establecer valores.
        public int GetIdRuta() => (int)numRuta.Value;
        public void SetIdRuta(int value) => numRuta.Value = value;
        public int GetIdProducto() => (int)numProducto.Value;
        public void SetIdProducto(int value) => numProducto.Value = value;
        public int GetCantidadEnviada() => (int)numCantidad.Value;
        public void SetCantidadEnviada(int value) => numCantidad.Value = value;
    }
}