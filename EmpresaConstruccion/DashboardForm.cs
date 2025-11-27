using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using FontAwesome.Sharp;

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
        private FlowLayoutPanel menuLayout;
        private Panel[] menuItems;
        private Panel panelActivo = null;
        private Color colorActivo = Color.FromArgb(33, 150, 243); // Azul Material Design
        private Color colorNormal = Color.Transparent;
        private Color iconoActivo = Color.White;
        private Color iconoNormal = Color.White;

        public DashboardForm(string connectionString, string usuario)
        {
            _connectionString = connectionString;
            InitializeComponent();
            lblUsuario.Text = $"Usuario: {usuario}";
        }

        private void ResaltarMenu(Panel panel)
        {
            if (panelActivo != null)
            {
                panelActivo.BackColor = colorNormal;
                foreach (Control c in panelActivo.Controls)
                {
                    if (c is IconPictureBox icon) icon.IconColor = iconoNormal;
                    if (c is Label lbl) lbl.ForeColor = Color.White;
                    if (c is Label lbl2 && lbl2.Font.Bold) lbl2.ForeColor = Color.White;
                }
            }
            panel.BackColor = colorActivo;
            foreach (Control c in panel.Controls)
            {
                if (c is IconPictureBox icon) icon.IconColor = iconoActivo;
                if (c is Label lbl) lbl.ForeColor = Color.White;
                if (c is Label lbl2 && lbl2.Font.Bold) lbl2.ForeColor = Color.White;
            }
            panelActivo = panel;
        }

        private Panel CrearMenuItem(string texto, IconChar iconChar, EventHandler click)
        {
            var panel = new Panel { Height = 48, Width = 220, BackColor = colorNormal, Cursor = Cursors.Hand, Margin = new Padding(0, 0, 0, 0) };
            var icon = new IconPictureBox
            {
                IconChar = iconChar,
                IconColor = iconoNormal,
                IconSize = 32,
                Size = new Size(40, 40),
                Location = new Point(10, 4),
                BackColor = Color.Transparent
            };
            var label = new Label
            {
                Text = texto,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(55, 12),
                BackColor = Color.Transparent
            };
            panel.Controls.Add(icon);
            panel.Controls.Add(label);
            panel.Click += (s, e) => { click(s, e); ResaltarMenu(panel); };
            icon.Click += (s, e) => { click(s, e); ResaltarMenu(panel); };
            label.Click += (s, e) => { click(s, e); ResaltarMenu(panel); };
            return panel;
        }
        private void InitializeComponent()
        {
            this.Text = "Empresa Constructora - Dashboard";
            this.MinimumSize = new Size(900, 600);
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(245, 247, 250);
            // Panel lateral (menú)
            panelMenu = new Panel { Dock = DockStyle.Left, Width = 220, BackColor = Color.FromArgb(36, 41, 46) };
            menuLayout = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, Padding = new Padding(0, 20, 0, 0), BackColor = Color.Transparent, AutoScroll = true, WrapContents = false };
            // Menú hamburguesa y título
            var panelHeader = new Panel { Height = 48, Width = 220, BackColor = Color.Transparent };
            var iconMenu = new IconPictureBox
            {
                IconChar = IconChar.Bars,
                IconColor = Color.White,
                IconSize = 32,
                Size = new Size(40, 40),
                Location = new Point(10, 8),
                BackColor = Color.Transparent
            };
            var lblMenu = new Label { Text = "Menú", ForeColor = Color.White, Font = new Font("Segoe UI", 13, FontStyle.Bold), AutoSize = true, Location = new Point(55, 12), BackColor = Color.Transparent };
            panelHeader.Controls.Add(iconMenu);
            panelHeader.Controls.Add(lblMenu);
            menuLayout.Controls.Add(panelHeader);
            // Opciones del menú (Paneles, no Dock=Top)
            menuItems = new Panel[] {
                CrearMenuItem("Orígenes", IconChar.Home, BtnOrigenes_Click),
                CrearMenuItem("Destinos", IconChar.MapMarkerAlt, BtnDestinos_Click),
                CrearMenuItem("Productos", IconChar.Boxes, BtnProductos_Click),
                CrearMenuItem("Transporte", IconChar.Truck, BtnTransporte_Click),
                CrearMenuItem("Optimización", IconChar.ChartLine, BtnOptimizacion_Click),
                CrearMenuItem("Cerrar Sesión", IconChar.SignOutAlt, BtnCerrarSesion_Click),
                CrearMenuItem("Salir", IconChar.TimesCircle, BtnSalir_Click)
            };
            foreach (var item in menuItems)
            {
                item.Width = 220;
                menuLayout.Controls.Add(item);
            }
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
            // Resalta la opción de bienvenida al inicio
            ResaltarMenu(menuItems[0]);
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
