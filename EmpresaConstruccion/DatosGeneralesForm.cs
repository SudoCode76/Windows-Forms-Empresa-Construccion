using System.Windows.Forms;
using EmpresaConstruccion.Data;

namespace EmpresaConstruccion
{
    public partial class DatosGeneralesForm : Form
    {
        public DatosGeneralesForm(string connectionString)
        {
            InitializeComponent();
            // Aquí puedes reutilizar el TabControl y lógica CRUD de orígenes, destinos y productos
        }

        // Implementa InitializeComponent vacío para evitar error de compilación.
        private void InitializeComponent() { }
    }
}