using Npgsql;
using System;
using System.Collections.Generic;
using EmpresaConstruccion.Models;

namespace EmpresaConstruccion.Data
{
    public class ConsultaRepository
    {
        private readonly string _connectionString;
        public ConsultaRepository(string connectionString) { _connectionString = connectionString; }

        public decimal ObtenerCostoTotalDistribucion()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(@"SELECT SUM(d.cantidad_enviada * r.costo_transporte) FROM distribucion d JOIN ruta r ON d.id_ruta = r.id_ruta", conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public List<(string Origen, string Destino, decimal Costo)> ObtenerRutasMasEconomicas()
        {
            var lista = new List<(string, string, decimal)>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(@"SELECT o.nombre, d.nombre, r.costo_transporte FROM ruta r JOIN origen o ON r.id_origen = o.id_origen JOIN destino d ON r.id_destino = d.id_destino ORDER BY r.costo_transporte ASC", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add((reader.GetString(0), reader.GetString(1), reader.GetDecimal(2)));
                    }
                }
            }
            return lista;
        }

        public List<Origen> ObtenerInfoOrigenes()
        {
            return new OrigenRepository(_connectionString).GetAll();
        }
        public List<Destino> ObtenerInfoDestinos()
        {
            return new DestinoRepository(_connectionString).GetAll();
        }
    }
}
