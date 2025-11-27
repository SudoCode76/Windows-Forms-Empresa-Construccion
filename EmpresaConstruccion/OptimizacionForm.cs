using System;
using System.Text;
using System.Windows.Forms;
using EmpresaConstruccion.Services;
using EmpresaConstruccion.Data;

namespace EmpresaConstruccion
{
    public partial class OptimizacionForm : Form
    {
        private string _connectionString;
        public OptimizacionForm(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.Text = "Optimización de Transporte";
            this.ClientSize = new System.Drawing.Size(700, 500);
            var panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, BackColor = System.Drawing.Color.White };
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            var btnCalcular = new Button { Text = "Calcular Modelos", Height = 45, Dock = DockStyle.Fill, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(44, 130, 201), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point) };
            var txtResultados = new TextBox { Multiline = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Fill, ReadOnly = true, Font = new System.Drawing.Font("Consolas", 11F), BackColor = System.Drawing.Color.FromArgb(250, 250, 250), ForeColor = System.Drawing.Color.FromArgb(30, 34, 45) };
            btnCalcular.Click += (s, e) => MostrarResultados(txtResultados);
            panel.Controls.Add(btnCalcular, 0, 0);
            panel.Controls.Add(txtResultados, 0, 1);
            this.Controls.Add(panel);
        }
        private void MostrarResultados(TextBox txtResultados)
        {
            var solver = new TransporteSolver(_connectionString);
            var consulta = new ConsultaRepository(_connectionString);
            var sb = new StringBuilder();
            var (oferta, demanda) = solver.CalcularOfertaDemandaTotal();
            sb.AppendLine($"Oferta total: {oferta}");
            sb.AppendLine($"Demanda total: {demanda}");
            sb.AppendLine();
            // Aquí se aplica el método de la Esquina Noroeste para calcular la asignación inicial
            var (asigNw, costoNw) = solver.MetodoEsquinaNoroeste();
            sb.AppendLine($"Método Esquina Noroeste - Costo total: {costoNw}");
            sb.AppendLine(MatrizToString(asigNw));
            sb.AppendLine();
            // Aquí se aplica el método de la Esquina Noroeste para calcular la asignación inicial
            var (asigVogel, costoVogel) = solver.MetodoVogel();
            sb.AppendLine($"Método de Vogel - Costo total: {costoVogel}");
            sb.AppendLine(MatrizToString(asigVogel));
            sb.AppendLine();
            sb.AppendLine($"Comparación: Noroeste = {costoNw}, Vogel = {costoVogel}");
            sb.AppendLine();
            sb.AppendLine($"Costo total real de distribución (según registros): {consulta.ObtenerCostoTotalDistribucion()}");
            sb.AppendLine();
            sb.AppendLine("Rutas más económicas:");
            foreach (var ruta in consulta.ObtenerRutasMasEconomicas())
                sb.AppendLine($"{ruta.Origen} ? {ruta.Destino}: {ruta.Costo}");
            sb.AppendLine();
            sb.AppendLine("Orígenes:");
            foreach (var o in consulta.ObtenerInfoOrigenes())
                sb.AppendLine($"{o.Nombre} - Capacidad: {o.CapacidadProduccion}, Ubicación: {o.Ubicacion}");
            sb.AppendLine();
            sb.AppendLine("Destinos:");
            foreach (var d in consulta.ObtenerInfoDestinos())
                sb.AppendLine($"{d.Nombre} - Demanda: {d.Demanda}, Ubicación: {d.Ubicacion}");
            txtResultados.Text = sb.ToString();
        }
        private string MatrizToString(int[,] matriz)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                    sb.Append(matriz[i, j].ToString().PadLeft(5));
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
