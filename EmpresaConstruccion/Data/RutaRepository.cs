using Npgsql;
using System.Collections.Generic;

namespace EmpresaConstruccion.Data
{
    public class RutaRepository
    {
        private readonly string _connectionString;
        public RutaRepository(string connectionString) { _connectionString = connectionString; }
        public List<dynamic> GetAll()
        {
            var lista = new List<dynamic>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id_ruta, id_origen, id_destino, costo_transporte, distancia_km, tiempo_horas, capacidad_requerida FROM ruta", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new
                        {
                            IdRuta = reader.GetInt32(0),
                            IdOrigen = reader.GetInt32(1),
                            IdDestino = reader.GetInt32(2),
                            CostoTransporte = reader.GetDecimal(3),
                            DistanciaKm = reader.GetDecimal(4),
                            TiempoHoras = reader.GetDecimal(5),
                            CapacidadRequerida = reader.GetInt32(6)
                        });
                    }
                }
            }
            return lista;
        }
        public void Add(int idOrigen, int idDestino, decimal costo, decimal distancia, decimal tiempo, int capacidad)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO ruta (id_origen, id_destino, costo_transporte, distancia_km, tiempo_horas, capacidad_requerida) VALUES (@id_origen, @id_destino, @costo, @distancia, @tiempo, @capacidad)", conn))
                {
                    cmd.Parameters.AddWithValue("@id_origen", idOrigen);
                    cmd.Parameters.AddWithValue("@id_destino", idDestino);
                    cmd.Parameters.AddWithValue("@costo", costo);
                    cmd.Parameters.AddWithValue("@distancia", distancia);
                    cmd.Parameters.AddWithValue("@tiempo", tiempo);
                    cmd.Parameters.AddWithValue("@capacidad", capacidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(int idRuta, int idOrigen, int idDestino, decimal costo, decimal distancia, decimal tiempo, int capacidad)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE ruta SET id_origen=@id_origen, id_destino=@id_destino, costo_transporte=@costo, distancia_km=@distancia, tiempo_horas=@tiempo, capacidad_requerida=@capacidad WHERE id_ruta=@id_ruta", conn))
                {
                    cmd.Parameters.AddWithValue("@id_ruta", idRuta);
                    cmd.Parameters.AddWithValue("@id_origen", idOrigen);
                    cmd.Parameters.AddWithValue("@id_destino", idDestino);
                    cmd.Parameters.AddWithValue("@costo", costo);
                    cmd.Parameters.AddWithValue("@distancia", distancia);
                    cmd.Parameters.AddWithValue("@tiempo", tiempo);
                    cmd.Parameters.AddWithValue("@capacidad", capacidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int idRuta)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM ruta WHERE id_ruta=@id_ruta", conn))
                {
                    cmd.Parameters.AddWithValue("@id_ruta", idRuta);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}