using Npgsql;
using System.Collections.Generic;

namespace EmpresaConstruccion.Data
{
    public class ProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Models.Producto> GetAll()
        {
            var lista = new List<Models.Producto>();
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT id_producto, nombre, tipo_producto, unidad_medida, cantidad_disponible FROM producto", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Models.Producto
                        {
                            IdProducto = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            TipoProducto = reader.IsDBNull(2) ? null : reader.GetString(2),
                            UnidadMedida = reader.IsDBNull(3) ? null : reader.GetString(3),
                            CantidadDisponible = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                        });
                    }
                }
            }
            return lista;
        }

        public void Add(Models.Producto producto)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO producto (nombre, tipo_producto, unidad_medida, cantidad_disponible) VALUES (@nombre, @tipo, @unidad, @cantidad)", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@tipo", (object)producto.TipoProducto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@unidad", (object)producto.UnidadMedida ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidad", producto.CantidadDisponible);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Models.Producto producto)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE producto SET nombre=@nombre, tipo_producto=@tipo, unidad_medida=@unidad, cantidad_disponible=@cantidad WHERE id_producto=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@tipo", (object)producto.TipoProducto ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@unidad", (object)producto.UnidadMedida ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidad", producto.CantidadDisponible);
                    cmd.Parameters.AddWithValue("@id", producto.IdProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int idProducto)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM producto WHERE id_producto=@id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}