using Npgsql;
using System.Collections.Generic;

namespace EmpresaConstruccion.Data
{
    public class OrigenRepository
    {
        private readonly string _connectionString;

        public OrigenRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Models.Origen> GetAll()
        {
            var lista = new List<Models.Origen>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id_origen, nombre, tipo, capacidad_produccion, ubicacion FROM origen", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Models.Origen
                        {
                            IdOrigen = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Tipo = reader.IsDBNull(2) ? null : reader.GetString(2),
                            CapacidadProduccion = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            Ubicacion = reader.IsDBNull(4) ? null : reader.GetString(4)
                        });
                    }
                }
            }
            return lista;
        }

        public void Add(Models.Origen origen)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO origen (nombre, tipo, capacidad_produccion, ubicacion) VALUES (@nombre, @tipo, @capacidad, @ubicacion)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", origen.Nombre);
                    cmd.Parameters.AddWithValue("@tipo", (object)origen.Tipo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@capacidad", origen.CapacidadProduccion);
                    cmd.Parameters.AddWithValue("@ubicacion", (object)origen.Ubicacion ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Models.Origen origen)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE origen SET nombre=@nombre, tipo=@tipo, capacidad_produccion=@capacidad, ubicacion=@ubicacion WHERE id_origen=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", origen.Nombre);
                    cmd.Parameters.AddWithValue("@tipo", (object)origen.Tipo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@capacidad", origen.CapacidadProduccion);
                    cmd.Parameters.AddWithValue("@ubicacion", (object)origen.Ubicacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", origen.IdOrigen);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idOrigen)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM origen WHERE id_origen=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idOrigen);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}