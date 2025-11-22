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
            this.menuTransporte = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOrigenes = new System.Windows.Forms.TabPage();
            this.tabDestinos = new System.Windows.Forms.TabPage();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.dgvOrigenes = new System.Windows.Forms.DataGridView();
            this.dgvDestinos = new System.Windows.Forms.DataGridView();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnAgregarOrigen = new System.Windows.Forms.Button();
            this.btnEditarOrigen = new System.Windows.Forms.Button();
            this.btnEliminarOrigen = new System.Windows.Forms.Button();
            this.btnAgregarDestino = new System.Windows.Forms.Button();
            this.btnEditarDestino = new System.Windows.Forms.Button();
            this.btnEliminarDestino = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnEditarProducto = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabOrigenes.SuspendLayout();
            this.tabDestinos.SuspendLayout();
            this.tabProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTransporte,
            this.menuSalir});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 28);
            this.menuStrip.TabIndex = 100;
            this.menuStrip.Text = "menuStrip";
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabOrigenes);
            this.tabControl.Controls.Add(this.tabDestinos);
            this.tabControl.Controls.Add(this.tabProductos);
            this.tabControl.Location = new System.Drawing.Point(12, 31);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 407);
            this.tabControl.TabIndex = 101;
            // 
            // tabOrigenes
            // 
            this.tabOrigenes.Controls.Add(this.dgvOrigenes);
            this.tabOrigenes.Controls.Add(this.btnAgregarOrigen);
            this.tabOrigenes.Controls.Add(this.btnEditarOrigen);
            this.tabOrigenes.Controls.Add(this.btnEliminarOrigen);
            this.tabOrigenes.Location = new System.Drawing.Point(4, 29);
            this.tabOrigenes.Name = "tabOrigenes";
            this.tabOrigenes.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrigenes.Size = new System.Drawing.Size(768, 374);
            this.tabOrigenes.TabIndex = 0;
            this.tabOrigenes.Text = "Órigenes";
            this.tabOrigenes.UseVisualStyleBackColor = true;
            // 
            // tabDestinos
            // 
            this.tabDestinos.Controls.Add(this.dgvDestinos);
            this.tabDestinos.Controls.Add(this.btnAgregarDestino);
            this.tabDestinos.Controls.Add(this.btnEditarDestino);
            this.tabDestinos.Controls.Add(this.btnEliminarDestino);
            this.tabDestinos.Location = new System.Drawing.Point(4, 29);
            this.tabDestinos.Name = "tabDestinos";
            this.tabDestinos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDestinos.Size = new System.Drawing.Size(768, 374);
            this.tabDestinos.TabIndex = 1;
            this.tabDestinos.Text = "Destinos";
            this.tabDestinos.UseVisualStyleBackColor = true;
            // 
            // tabProductos
            // 
            this.tabProductos.Controls.Add(this.dgvProductos);
            this.tabProductos.Controls.Add(this.btnAgregarProducto);
            this.tabProductos.Controls.Add(this.btnEditarProducto);
            this.tabProductos.Controls.Add(this.btnEliminarProducto);
            this.tabProductos.Location = new System.Drawing.Point(4, 29);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductos.Size = new System.Drawing.Size(768, 374);
            this.tabProductos.TabIndex = 2;
            this.tabProductos.Text = "Productos";
            this.tabProductos.UseVisualStyleBackColor = true;
            // 
            // dgvOrigenes
            // 
            this.dgvOrigenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrigenes.Location = new System.Drawing.Point(6, 6);
            this.dgvOrigenes.Name = "dgvOrigenes";
            this.dgvOrigenes.RowHeadersWidth = 51;
            this.dgvOrigenes.RowTemplate.Height = 29;
            this.dgvOrigenes.Size = new System.Drawing.Size(756, 311);
            this.dgvOrigenes.TabIndex = 0;
            // 
            // dgvDestinos
            // 
            this.dgvDestinos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDestinos.Location = new System.Drawing.Point(6, 6);
            this.dgvDestinos.Name = "dgvDestinos";
            this.dgvDestinos.RowHeadersWidth = 51;
            this.dgvDestinos.RowTemplate.Height = 29;
            this.dgvDestinos.Size = new System.Drawing.Size(756, 311);
            this.dgvDestinos.TabIndex = 1;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(6, 6);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 29;
            this.dgvProductos.Size = new System.Drawing.Size(756, 311);
            this.dgvProductos.TabIndex = 1;
            // 
            // btnAgregarOrigen
            // 
            this.btnAgregarOrigen.Location = new System.Drawing.Point(6, 323);
            this.btnAgregarOrigen.Name = "btnAgregarOrigen";
            this.btnAgregarOrigen.Size = new System.Drawing.Size(94, 29);
            this.btnAgregarOrigen.TabIndex = 1;
            this.btnAgregarOrigen.Text = "Agregar";
            this.btnAgregarOrigen.UseVisualStyleBackColor = true;
            // 
            // btnEditarOrigen
            // 
            this.btnEditarOrigen.Location = new System.Drawing.Point(106, 323);
            this.btnEditarOrigen.Name = "btnEditarOrigen";
            this.btnEditarOrigen.Size = new System.Drawing.Size(94, 29);
            this.btnEditarOrigen.TabIndex = 2;
            this.btnEditarOrigen.Text = "Editar";
            this.btnEditarOrigen.UseVisualStyleBackColor = true;
            // 
            // btnEliminarOrigen
            // 
            this.btnEliminarOrigen.Location = new System.Drawing.Point(206, 323);
            this.btnEliminarOrigen.Name = "btnEliminarOrigen";
            this.btnEliminarOrigen.Size = new System.Drawing.Size(94, 29);
            this.btnEliminarOrigen.TabIndex = 3;
            this.btnEliminarOrigen.Text = "Eliminar";
            this.btnEliminarOrigen.UseVisualStyleBackColor = true;
            // 
            // btnAgregarDestino
            // 
            this.btnAgregarDestino.Location = new System.Drawing.Point(6, 323);
            this.btnAgregarDestino.Name = "btnAgregarDestino";
            this.btnAgregarDestino.Size = new System.Drawing.Size(94, 29);
            this.btnAgregarDestino.TabIndex = 1;
            this.btnAgregarDestino.Text = "Agregar";
            this.btnAgregarDestino.UseVisualStyleBackColor = true;
            // 
            // btnEditarDestino
            // 
            this.btnEditarDestino.Location = new System.Drawing.Point(106, 323);
            this.btnEditarDestino.Name = "btnEditarDestino";
            this.btnEditarDestino.Size = new System.Drawing.Size(94, 29);
            this.btnEditarDestino.TabIndex = 2;
            this.btnEditarDestino.Text = "Editar";
            this.btnEditarDestino.UseVisualStyleBackColor = true;
            // 
            // btnEliminarDestino
            // 
            this.btnEliminarDestino.Location = new System.Drawing.Point(206, 323);
            this.btnEliminarDestino.Name = "btnEliminarDestino";
            this.btnEliminarDestino.Size = new System.Drawing.Size(94, 29);
            this.btnEliminarDestino.TabIndex = 3;
            this.btnEliminarDestino.Text = "Eliminar";
            this.btnEliminarDestino.UseVisualStyleBackColor = true;
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(6, 323);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(94, 29);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // btnEditarProducto
            // 
            this.btnEditarProducto.Location = new System.Drawing.Point(106, 323);
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.Size = new System.Drawing.Size(94, 29);
            this.btnEditarProducto.TabIndex = 2;
            this.btnEditarProducto.Text = "Editar";
            this.btnEditarProducto.UseVisualStyleBackColor = true;
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Location = new System.Drawing.Point(206, 323);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(94, 29);
            this.btnEliminarProducto.TabIndex = 3;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Empresa Construcción";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabOrigenes.ResumeLayout(false);
            this.tabDestinos.ResumeLayout(false);
            this.tabProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrigenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDestinos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuTransporte;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOrigenes;
        private System.Windows.Forms.TabPage tabDestinos;
        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.DataGridView dgvOrigenes;
        private System.Windows.Forms.DataGridView dgvDestinos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAgregarOrigen;
        private System.Windows.Forms.Button btnEditarOrigen;
        private System.Windows.Forms.Button btnEliminarOrigen;
        private System.Windows.Forms.Button btnAgregarDestino;
        private System.Windows.Forms.Button btnEditarDestino;
        private System.Windows.Forms.Button btnEliminarDestino;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEditarProducto;
        private System.Windows.Forms.Button btnEliminarProducto;
    }
}
