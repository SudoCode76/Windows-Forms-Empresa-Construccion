using Npgsql;
using EmpresaConstruccion.Data;

namespace EmpresaConstruccion.Data
{
    public class DestinoRepository
    {
        private readonly string _connectionString;

        public DestinoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DestinoLista GetAll()
        {
            var lista = new DestinoLista();
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT id_destino, nombre, tipo, demanda, ubicacion FROM destino", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var destino = new Models.Destino
                            {
                                IdDestino = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Tipo = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Demanda = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                                Ubicacion = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };
                            lista.Agregar(destino);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener destinos.", ex);
            }
            return lista;
        }

        public void Add(Models.Destino destino)
        {
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException("Error al agregar destino.", ex);
            }
        }

        public void Update(Models.Destino destino)
        {
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException("Error al actualizar destino.", ex);
            }
        }

        public void Delete(int idDestino)
        {
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException("Error al eliminar destino.", ex);
            }
        }
    }
}