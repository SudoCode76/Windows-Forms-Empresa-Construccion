using System;
using System.Windows.Forms;
using EmpresaConstruccion.Data;
using Npgsql;

namespace EmpresaConstruccion
{
    public partial class LoginForm : Form
    {
        private string _connectionString;
        public bool Autenticado { get; private set; } = false;
        public LoginForm(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.Text = "Inicio de Sesión";
            this.ClientSize = new System.Drawing.Size(350, 220);
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            var lblUsuario = new Label { Text = "Usuario", Location = new System.Drawing.Point(40, 40), AutoSize = true };
            var txtUsuario = new TextBox { Name = "txtUsuario", Location = new System.Drawing.Point(120, 37), Width = 170 };
            var lblPassword = new Label { Text = "Contraseña", Location = new System.Drawing.Point(40, 90), AutoSize = true };
            var txtPassword = new TextBox { Name = "txtPassword", Location = new System.Drawing.Point(120, 87), Width = 170, UseSystemPasswordChar = true };
            var btnLogin = new Button { Text = "Ingresar", Location = new System.Drawing.Point(120, 140), Width = 170, Height = 35, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(44, 130, 201), ForeColor = System.Drawing.Color.White };
            btnLogin.Click += (s, e) => Login(txtUsuario.Text, txtPassword.Text);
            // Botón para testear conexión
            var btnTestConexion = new Button { Text = "Testear Conexión", Location = new System.Drawing.Point(120, 180), Width = 170, Height = 30, FlatStyle = FlatStyle.Flat, BackColor = System.Drawing.Color.FromArgb(52, 152, 219), ForeColor = System.Drawing.Color.White };
            btnTestConexion.Click += BtnTestConexion_Click;
            this.Controls.AddRange(new Control[] { lblUsuario, txtUsuario, lblPassword, txtPassword, btnLogin, btnTestConexion });
        }
        private void Login(string usuario, string password)
        {
            var repo = new UsuarioRepository(_connectionString);
            if (repo.ValidarUsuario(usuario, password))
            {
                Autenticado = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnTestConexion_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(_connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Conexión exitosa a la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
