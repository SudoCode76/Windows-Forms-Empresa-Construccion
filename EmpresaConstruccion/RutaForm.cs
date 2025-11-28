using System;
using System.ComponentModel;
using System.Windows.Forms;
using EmpresaConstruccion.Models;
using EmpresaConstruccion.Data;
using System.Collections.Generic;
using System.Linq;

namespace EmpresaConstruccion
{
    public partial class RutaForm : Form
    {
        public RutaForm()
        {
            InitializeComponent();
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int IdOrigen { get => GetIdOrigen(); set => SetIdOrigen(value); }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int IdDestino { get => GetIdDestino(); set => SetIdDestino(value); }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal CostoTransporte { get => GetCostoTransporte(); set => SetCostoTransporte(value); }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal DistanciaKm { get => GetDistanciaKm(); set => SetDistanciaKm(value); }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal TiempoHoras { get => GetTiempoHoras(); set => SetTiempoHoras(value); }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CapacidadRequerida { get => GetCapacidadRequerida(); set => SetCapacidadRequerida(value); }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblDistancia;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.NumericUpDown numCosto;
        private System.Windows.Forms.NumericUpDown numDistancia;
        private System.Windows.Forms.NumericUpDown numTiempo;
        private System.Windows.Forms.NumericUpDown numCapacidad;
        private System.Windows.Forms.Button btnAceptar;
        private void InitializeComponent()
        {
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblDistancia = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.cmbOrigen = new System.Windows.Forms.ComboBox();
            this.cmbDestino = new System.Windows.Forms.ComboBox();
            this.numCosto = new System.Windows.Forms.NumericUpDown();
            this.numDistancia = new System.Windows.Forms.NumericUpDown();
            this.numTiempo = new System.Windows.Forms.NumericUpDown();
            this.numCapacidad = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).BeginInit();
            this.SuspendLayout();
            // lblOrigen
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Location = new System.Drawing.Point(20, 20);
            this.lblOrigen.Text = "Origen";
            // cmbOrigen
            this.cmbOrigen.Location = new System.Drawing.Point(120, 17);
            this.cmbOrigen.Size = new System.Drawing.Size(200, 27);
            // lblDestino
            this.lblDestino.AutoSize = true;
            this.lblDestino.Location = new System.Drawing.Point(20, 60);
            this.lblDestino.Text = "Destino";
            // cmbDestino
            this.cmbDestino.Location = new System.Drawing.Point(120, 57);
            this.cmbDestino.Size = new System.Drawing.Size(200, 27);
            // lblCosto
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(20, 100);
            this.lblCosto.Text = "Costo";
            // numCosto
            this.numCosto.Location = new System.Drawing.Point(120, 97);
            this.numCosto.DecimalPlaces = 2;
            this.numCosto.Maximum = 1000000;
            // lblDistancia
            this.lblDistancia.AutoSize = true;
            this.lblDistancia.Location = new System.Drawing.Point(20, 140);
            this.lblDistancia.Text = "Distancia (km)";
            // numDistancia
            this.numDistancia.Location = new System.Drawing.Point(120, 137);
            this.numDistancia.DecimalPlaces = 2;
            this.numDistancia.Maximum = 1000000;
            // lblTiempo
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(20, 180);
            this.lblTiempo.Text = "Tiempo (h)";
            // numTiempo
            this.numTiempo.Location = new System.Drawing.Point(120, 177);
            this.numTiempo.DecimalPlaces = 2;
            this.numTiempo.Maximum = 1000000;
            // lblCapacidad
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Location = new System.Drawing.Point(20, 220);
            this.lblCapacidad.Text = "Capacidad";
            // numCapacidad
            this.numCapacidad.Location = new System.Drawing.Point(120, 217);
            this.numCapacidad.Maximum = 1000000;
            // btnAceptar
            this.btnAceptar.Location = new System.Drawing.Point(120, 260);
            this.btnAceptar.Size = new System.Drawing.Size(100, 30);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // RutaForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 310);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.cmbOrigen);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.cmbDestino);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.numCosto);
            this.Controls.Add(this.lblDistancia);
            this.Controls.Add(this.numDistancia);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.numTiempo);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.numCapacidad);
            this.Controls.Add(this.btnAceptar);
            this.Name = "RutaForm";
            this.Text = "Ruta";
            ((System.ComponentModel.ISupportInitialize)(this.numCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDistancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private List<Origen> origenes;
        private List<Destino> destinos;
        public void CargarOrigenesYDestinos(string connectionString)
        {
            var origenRepo = new OrigenRepository(connectionString);
            var destinoRepo = new DestinoRepository(connectionString);
            origenes = origenRepo.GetAll();
            var destinosLista = destinoRepo.GetAll();
            destinos = destinosLista.ToList();
            cmbOrigen.DataSource = origenes;
            cmbOrigen.DisplayMember = "Nombre";
            cmbOrigen.ValueMember = "IdOrigen";
            cmbDestino.DataSource = destinos;
            cmbDestino.DisplayMember = "Nombre";
            cmbDestino.ValueMember = "IdDestino";
        }
        public int GetIdOrigen() => cmbOrigen.SelectedValue != null ? (int)cmbOrigen.SelectedValue : 0;
        public void SetIdOrigen(int value) => cmbOrigen.SelectedValue = value;
        public int GetIdDestino() => cmbDestino.SelectedValue != null ? (int)cmbDestino.SelectedValue : 0;
        public void SetIdDestino(int value) => cmbDestino.SelectedValue = value;
        public decimal GetCostoTransporte() => numCosto.Value;
        public void SetCostoTransporte(decimal value) => numCosto.Value = value;
        public decimal GetDistanciaKm() => numDistancia.Value;
        public void SetDistanciaKm(decimal value) => numDistancia.Value = value;
        public decimal GetTiempoHoras() => numTiempo.Value;
        public void SetTiempoHoras(decimal value) => numTiempo.Value = value;
        public int GetCapacidadRequerida() => (int)numCapacidad.Value;
        public void SetCapacidadRequerida(int value) => numCapacidad.Value = value;
    }
}