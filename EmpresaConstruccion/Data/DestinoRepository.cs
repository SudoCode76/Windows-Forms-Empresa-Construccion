using Npgsql;
using System.Collections.Generic;

namespace EmpresaConstruccion.Data
{
    public class DestinoRepository
    {
        private readonly string _connectionString;

        public DestinoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Models.Destino> GetAll()
        {
            var lista = new List<Models.Destino>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id_destino, nombre, tipo, demanda, ubicacion FROM destino", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Models.Destino
                        {
                            IdDestino = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Tipo = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Demanda = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            Ubicacion = reader.IsDBNull(4) ? null : reader.GetString(4)
                        });
                    }
                }
            }
            return lista;
        }

        public void Add(Models.Destino destino)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO destino (nombre, tipo, demanda, ubicacion) VALUES (@nombre, @tipo, @demanda, @ubicacion)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", destino.Nombre);
                    cmd.Parameters.AddWithValue("@tipo", (object)destino.Tipo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@demanda", destino.Demanda);
                    cmd.Parameters.AddWithValue("@ubicacion", (object)destino.Ubicacion ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Models.Destino destino)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE destino SET nombre=@nombre, tipo=@tipo, demanda=@demanda, ubicacion=@ubicacion WHERE id_destino=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", destino.Nombre);
                    cmd.Parameters.AddWithValue("@tipo", (object)destino.Tipo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@demanda", destino.Demanda);
                    cmd.Parameters.AddWithValue("@ubicacion", (object)destino.Ubicacion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", destino.IdDestino);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idDestino)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM destino WHERE id_destino=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idDestino);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}