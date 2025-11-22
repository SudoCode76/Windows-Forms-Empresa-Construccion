using Npgsql;
using System.Collections.Generic;

namespace EmpresaConstruccion.Data
{
    public class DistribucionRepository
    {
        private readonly string _connectionString;
        public DistribucionRepository(string connectionString) { _connectionString = connectionString; }
        public List<dynamic> GetAll()
        {
            var lista = new List<dynamic>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id_distribucion, id_ruta, id_producto, cantidad_enviada FROM distribucion", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new
                        {
                            IdDistribucion = reader.GetInt32(0),
                            IdRuta = reader.GetInt32(1),
                            IdProducto = reader.GetInt32(2),
                            CantidadEnviada = reader.GetInt32(3)
                        });
                    }
                }
            }
            return lista;
        }
        public void Add(int idRuta, int idProducto, int cantidad)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO distribucion (id_ruta, id_producto, cantidad_enviada) VALUES (@id_ruta, @id_producto, @cantidad)", conn))
                {
                    cmd.Parameters.AddWithValue("@id_ruta", idRuta);
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(int idDistribucion, int idRuta, int idProducto, int cantidad)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE distribucion SET id_ruta=@id_ruta, id_producto=@id_producto, cantidad_enviada=@cantidad WHERE id_distribucion=@id_distribucion", conn))
                {
                    cmd.Parameters.AddWithValue("@id_distribucion", idDistribucion);
                    cmd.Parameters.AddWithValue("@id_ruta", idRuta);
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int idDistribucion)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM distribucion WHERE id_distribucion=@id_distribucion", conn))
                {
                    cmd.Parameters.AddWithValue("@id_distribucion", idDistribucion);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}