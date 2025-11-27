using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EmpresaConstruccion
{
    public partial class DashboardForm : Form
    {
        private Panel panelMenu;
        private Panel panelTop;
        private Panel panelContent;
        private Button btnOrigenes, btnDestinos, btnProductos, btnTransporte, btnOptimizacion, btnCerrarSesion, btnSalir;
        private Label lblTitulo, lblUsuario;
        private Form activeForm = null;
        private string _connectionString;
        private Label lblBienvenida;

        public DashboardForm(string connectionString, string usuario)
        {
            _connectionString = connectionString;
            InitializeComponent();
            lblUsuario.Text = $"Usuario: {usuario}";
        }

        private void InitializeComponent()
        {
            this.Text = "Empresa Constructora - Dashboard";
            this.MinimumSize = new Size(900, 600);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(245, 247, 250);
            // Panel lateral (menú)
            panelMenu = new Panel { Dock = DockStyle.Left, Width = 200, BackColor = Color.FromArgb(30, 34, 45) };
            btnOrigenes = CrearBotonMenu("Orígenes", BtnOrigenes_Click);
            btnDestinos = CrearBotonMenu("Destinos", BtnDestinos_Click);
            btnProductos = CrearBotonMenu("Productos", BtnProductos_Click);
            btnTransporte = CrearBotonMenu("Transporte", BtnTransporte_Click);
            btnOptimizacion = CrearBotonMenu("Optimización", BtnOptimizacion_Click);
            btnCerrarSesion = CrearBotonMenu("Cerrar Sesión", BtnCerrarSesion_Click, Color.FromArgb(52, 73, 94));
            btnSalir = CrearBotonMenu("Salir", BtnSalir_Click, Color.FromArgb(231, 76, 60));
            var menuLayout = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(0, 40, 0, 0), BackColor = Color.Transparent, AutoScroll = true };
            menuLayout.Controls.AddRange(new Control[] { btnOrigenes, btnDestinos, btnProductos, btnTransporte, btnOptimizacion, btnCerrarSesion, btnSalir });
            panelMenu.Controls.Add(menuLayout);
            // Panel superior
            panelTop = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(44, 130, 201) };
            lblTitulo = new Label { Text = "Empresa Constructora", ForeColor = Color.White, Font = new Font("Segoe UI", 20, FontStyle.Bold), AutoSize = true, Location = new Point(30, 10) };
            lblUsuario = new Label { Text = "Usuario: ", ForeColor = Color.White, Font = new Font("Segoe UI", 12, FontStyle.Regular), AutoSize = true, Location = new Point(600, 20), Anchor = AnchorStyles.Right };
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(lblUsuario);
            // Panel central
            panelContent = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(10) };
            lblBienvenida = new Label {
                Text = "JhaLiz Ingeniería & Construcción",
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 130, 201),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelContent.Controls.Add(lblBienvenida);
            panelContent.Resize += (s, e) => CentrarBienvenida();
            CentrarBienvenida();
            // Agregar paneles al formulario
            this.Controls.Add(panelContent);
            this.Controls.Add(panelTop);
            this.Controls.Add(panelMenu);
            // Drag window
            panelTop.MouseDown += (s, e) => { ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0); };
        }

        private void CentrarBienvenida()
        {
            if (lblBienvenida != null && panelContent != null)
            {
                lblBienvenida.Left = (panelContent.Width - lblBienvenida.Width) / 2;
                lblBienvenida.Top = (panelContent.Height - lblBienvenida.Height) / 2;
            }
        }

        private Button CrearBotonMenu(string texto, EventHandler click, Color? color = null)
        {
            var btn = new Button
            {
                Text = texto,
                Height = 48,
                Width = 180,
                FlatStyle = FlatStyle.Flat,
                BackColor = color ?? Color.FromArgb(44, 130, 201),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Margin = new Padding(10, 0, 10, 10),
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand,
                TabStop = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                UseVisualStyleBackColor = false,
                AutoSize = false,
                Name = "btn" + texto.Replace(" ", "")
            };
            btn.Click += click;
            return btn;
        }

        private void BtnOrigenes_Click(object sender, EventArgs e) => AbrirFormulario(new OrigenesForm(_connectionString));
        private void BtnDestinos_Click(object sender, EventArgs e) => AbrirFormulario(new DestinosForm(_connectionString));
        private void BtnProductos_Click(object sender, EventArgs e) => AbrirFormulario(new ProductosForm(_connectionString));
        private void BtnTransporte_Click(object sender, EventArgs e) => AbrirFormulario(new TransporteForm(_connectionString));
        private void BtnOptimizacion_Click(object sender, EventArgs e) => AbrirFormulario(new OptimizacionForm(_connectionString));
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var login = new LoginForm(_connectionString))
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
        private void AbrirFormulario(Form formHijo)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(formHijo);
            formHijo.BringToFront();
            formHijo.Show();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
    }
}
