using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EmpresaConstruccion.Data;
using EmpresaConstruccion.Models;

namespace EmpresaConstruccion.Services
{
    public class TransporteSolver
    {
        private readonly string _connectionString;
        public TransporteSolver(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 1. Obtener oferta y demanda total
        public (int ofertaTotal, int demandaTotal) CalcularOfertaDemandaTotal()
        {
            var origenes = new OrigenRepository(_connectionString).GetAll();
            var destinos = new DestinoRepository(_connectionString).GetAll();
            int oferta = origenes.Sum(o => o.CapacidadProduccion);
            int demanda = destinos.Sum(d => d.Demanda);
            return (oferta, demanda);
        }

        // 2. Generar matriz de costos (origen x destino)
        public decimal[,] GenerarMatrizCostos(out List<Origen> origenes, out List<Destino> destinos)
        {
            var origenesLocal = new OrigenRepository(_connectionString).GetAll();
            var destinosLocal = new DestinoRepository(_connectionString).GetAll();
            origenes = origenesLocal;
            destinos = destinosLocal;
            var rutas = new RutaRepository(_connectionString).GetAll();
            decimal[,] matriz = new decimal[origenes.Count, destinos.Count];
            for (int i = 0; i < origenes.Count; i++)
            {
                for (int j = 0; j < destinos.Count; j++)
                {
                    var ruta = rutas.FirstOrDefault(r => (int)r.GetType().GetProperty("IdOrigen").GetValue(r) == origenesLocal[i].IdOrigen && (int)r.GetType().GetProperty("IdDestino").GetValue(r) == destinosLocal[j].IdDestino);
                    matriz[i, j] = ruta != null ? (decimal)ruta.GetType().GetProperty("CostoTransporte").GetValue(ruta) : decimal.MaxValue;
                }
            }
            return matriz;
        }

        // 3. Método de la esquina Noroeste
        public (int[,], decimal) MetodoEsquinaNoroeste()
        {
            List<Origen> origenes;
            List<Destino> destinos;
            decimal[,] costos = GenerarMatrizCostos(out origenes, out destinos);
            int[] oferta = origenes.Select(o => o.CapacidadProduccion).ToArray();
            int[] demanda = destinos.Select(d => d.Demanda).ToArray();
            int[,] asignacion = new int[oferta.Length, demanda.Length];
            int i = 0, j = 0;
            while (i < oferta.Length && j < demanda.Length)
            {
                int cantidad = Math.Min(oferta[i], demanda[j]);
                asignacion[i, j] = cantidad;
                oferta[i] -= cantidad;
                demanda[j] -= cantidad;
                if (oferta[i] == 0) i++;
                else j++;
            }
            decimal costoTotal = 0;
            for (int x = 0; x < oferta.Length; x++)
                for (int y = 0; y < demanda.Length; y++)
                    if (costos[x, y] != decimal.MaxValue)
                        costoTotal += asignacion[x, y] * costos[x, y];
            return (asignacion, costoTotal);
        }

        // 4. Método de Vogel
        public (int[,], decimal) MetodoVogel()
        {
            List<Origen> origenes;
            List<Destino> destinos;
            decimal[,] costos = GenerarMatrizCostos(out origenes, out destinos);
            int m = origenes.Count, n = destinos.Count;
            int[] oferta = origenes.Select(o => o.CapacidadProduccion).ToArray();
            int[] demanda = destinos.Select(d => d.Demanda).ToArray();
            int[,] asignacion = new int[m, n];
            bool[] filaUsada = new bool[m];
            bool[] colUsada = new bool[n];
            while (filaUsada.Any(f => !f) && colUsada.Any(c => !c))
            {
                // Penalizaciones
                decimal[] penalFila = new decimal[m];
                decimal[] penalCol = new decimal[n];
                for (int i = 0; i < m; i++)
                {
                    if (filaUsada[i]) { penalFila[i] = -1; continue; }
                    var fila = Enumerable.Range(0, n).Where(j => !colUsada[j]).Select(j => costos[i, j]).OrderBy(x => x).ToArray();
                    penalFila[i] = fila.Length > 1 ? fila[1] - fila[0] : 0;
                }
                for (int j = 0; j < n; j++)
                {
                    if (colUsada[j]) { penalCol[j] = -1; continue; }
                    var col = Enumerable.Range(0, m).Where(i => !filaUsada[i]).Select(i => costos[i, j]).OrderBy(x => x).ToArray();
                    penalCol[j] = col.Length > 1 ? col[1] - col[0] : 0;
                }
                // Mayor penalización
                decimal maxPenal = Math.Max(penalFila.Max(), penalCol.Max());
                int idx, isFila;
                if (penalFila.Max() >= penalCol.Max())
                {
                    idx = Array.IndexOf(penalFila, maxPenal);
                    isFila = 1;
                }
                else
                {
                    idx = Array.IndexOf(penalCol, maxPenal);
                    isFila = 0;
                }
                // Buscar mínimo costo en la fila o columna
                int minI = -1, minJ = -1;
                decimal minCosto = decimal.MaxValue;
                if (isFila == 1)
                {
                    minI = idx;
                    for (int j = 0; j < n; j++)
                        if (!colUsada[j] && costos[minI, j] < minCosto)
                        { minCosto = costos[minI, j]; minJ = j; }
                }
                else
                {
                    minJ = idx;
                    for (int i = 0; i < m; i++)
                        if (!filaUsada[i] && costos[i, minJ] < minCosto)
                        { minCosto = costos[i, minJ]; minI = i; }
                }
                int cantidad = Math.Min(oferta[minI], demanda[minJ]);
                asignacion[minI, minJ] = cantidad;
                oferta[minI] -= cantidad;
                demanda[minJ] -= cantidad;
                if (oferta[minI] == 0) filaUsada[minI] = true;
                if (demanda[minJ] == 0) colUsada[minJ] = true;
            }
            decimal costoTotal = 0;
            for (int x = 0; x < m; x++)
                for (int y = 0; y < n; y++)
                    if (costos[x, y] != decimal.MaxValue)
                        costoTotal += asignacion[x, y] * costos[x, y];
            return (asignacion, costoTotal);
        }

        // 5. Runge-Kutta para aproximar una ecuación diferencial (ejemplo genérico)
        public double RungeKutta(Func<double, double, double> f, double x0, double y0, double h, int pasos)
        {
            double x = x0, y = y0;
            for (int i = 0; i < pasos; i++)
            {
                double k1 = h * f(x, y);
                double k2 = h * f(x + h / 2, y + k1 / 2);
                double k3 = h * f(x + h / 2, y + k2 / 2);
                double k4 = h * f(x + h, y + k3);
                y += (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                x += h;
            }
            return y;
        }
    }
}
