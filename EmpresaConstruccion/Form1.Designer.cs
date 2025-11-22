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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuOrigen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDestino = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTransporte = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuOrigen,
                this.menuDestino,
                this.menuProducto,
                this.menuTransporte,
                this.menuSalir
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 28);
            this.menuStrip.TabIndex = 100;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuOrigen
            // 
            this.menuOrigen.Name = "menuOrigen";
            this.menuOrigen.Size = new System.Drawing.Size(70, 24);
            this.menuOrigen.Text = "Orígenes";
            this.menuOrigen.Click += new System.EventHandler(this.menuOrigen_Click);
            // 
            // menuDestino
            // 
            this.menuDestino.Name = "menuDestino";
            this.menuDestino.Size = new System.Drawing.Size(74, 24);
            this.menuDestino.Text = "Destinos";
            this.menuDestino.Click += new System.EventHandler(this.menuDestino_Click);
            // 
            // menuProducto
            // 
            this.menuProducto.Name = "menuProducto";
            this.menuProducto.Size = new System.Drawing.Size(87, 24);
            this.menuProducto.Text = "Productos";
            this.menuProducto.Click += new System.EventHandler(this.menuProducto_Click);
            // 
            // menuTransporte
            // 
            this.menuTransporte.Name = "menuTransporte";
            this.menuTransporte.Size = new System.Drawing.Size(95, 24);
            this.menuTransporte.Text = "Transporte";
            this.menuTransporte.Click += new System.EventHandler(this.menuTransporte_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(52, 24);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "Empresa Constructora";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(150, 180);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.lblTitulo);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Empresa Constructora";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuOrigen;
        private System.Windows.Forms.ToolStripMenuItem menuDestino;
        private System.Windows.Forms.ToolStripMenuItem menuProducto;
        private System.Windows.Forms.ToolStripMenuItem menuTransporte;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.Label lblTitulo;
    }
}
