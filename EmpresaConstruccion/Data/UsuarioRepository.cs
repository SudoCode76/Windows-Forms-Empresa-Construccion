using Npgsql;

namespace EmpresaConstruccion.Data
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;
        public UsuarioRepository(string connectionString) { _connectionString = connectionString; }

        public bool ValidarUsuario(string usuario, string password)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM usuario WHERE usuario=@usuario AND password=@password", conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", password);
                    var result = cmd.ExecuteScalar();
                    return result != null && (long)result > 0;
                }
            }
        }
    }
}
