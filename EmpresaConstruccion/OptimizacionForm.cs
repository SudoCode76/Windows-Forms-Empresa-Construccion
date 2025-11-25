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
            this.Text = "Optimización de Transporte";
            this.ClientSize = new System.Drawing.Size(700, 500);
            var btnCalcular = new Button { Text = "Calcular Modelos", Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(180, 40) };
            var txtResultados = new TextBox { Multiline = true, ScrollBars = ScrollBars.Vertical, Location = new System.Drawing.Point(20, 80), Size = new System.Drawing.Size(650, 380), ReadOnly = true };
            btnCalcular.Click += (s, e) => MostrarResultados(txtResultados);
            this.Controls.Add(btnCalcular);
            this.Controls.Add(txtResultados);
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
            var (asigNw, costoNw) = solver.MetodoEsquinaNoroeste();
            sb.AppendLine($"Método Esquina Noroeste - Costo total: {costoNw}");
            sb.AppendLine(MatrizToString(asigNw));
            sb.AppendLine();
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
