namespace EmpresaConstruccion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            menuOrigen = new ToolStripMenuItem();
            menuDestino = new ToolStripMenuItem();
            menuProducto = new ToolStripMenuItem();
            menuTransporte = new ToolStripMenuItem();
            menuOptimizacion = new ToolStripMenuItem();
            menuSalir = new ToolStripMenuItem();
            lblTitulo = new Label();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(30, 34, 45);
            menuStrip.Font = new Font("Segoe UI", 12F);
            menuStrip.ForeColor = Color.White;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { menuOrigen, menuDestino, menuProducto, menuTransporte, menuOptimizacion, menuSalir });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 36);
            menuStrip.TabIndex = 100;
            menuStrip.Text = "menuStrip";
            // 
            // menuOrigen
            // 
            menuOrigen.Name = "menuOrigen";
            menuOrigen.Size = new Size(104, 32);
            menuOrigen.Text = "Orígenes";
            menuOrigen.Click += menuOrigen_Click;
            // 
            // menuDestino
            // 
            menuDestino.Name = "menuDestino";
            menuDestino.Size = new Size(101, 32);
            menuDestino.Text = "Destinos";
            menuDestino.Click += menuDestino_Click;
            // 
            // menuProducto
            // 
            menuProducto.Name = "menuProducto";
            menuProducto.Size = new Size(115, 32);
            menuProducto.Text = "Productos";
            menuProducto.Click += menuProducto_Click;
            // 
            // menuTransporte
            // 
            menuTransporte.Name = "menuTransporte";
            menuTransporte.Size = new Size(118, 32);
            menuTransporte.Text = "Transporte";
            menuTransporte.Click += menuTransporte_Click;
            // 
            // menuOptimizacion
            // 
            menuOptimizacion.Name = "menuOptimizacion";
            menuOptimizacion.Size = new Size(143, 32);
            menuOptimizacion.Text = "Optimización";
            menuOptimizacion.Click += menuOptimizacion_Click;
            // 
            // menuSalir
            // 
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(64, 32);
            menuSalir.Text = "Salir";
            menuSalir.Click += menuSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.None;
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(44, 130, 201);
            lblTitulo.Location = new Point(80, 180);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(588, 72);
            lblTitulo.TabIndex = 101;
            lblTitulo.Text = "Empresa Constructora";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip);
            Controls.Add(lblTitulo);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(600, 400);
            Name = "Form1";
            Text = "Empresa Constructora";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuOrigen;
        private System.Windows.Forms.ToolStripMenuItem menuDestino;
        private System.Windows.Forms.ToolStripMenuItem menuProducto;
        private System.Windows.Forms.ToolStripMenuItem menuTransporte;
        private System.Windows.Forms.ToolStripMenuItem menuOptimizacion;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.Label lblTitulo;
    }
}
