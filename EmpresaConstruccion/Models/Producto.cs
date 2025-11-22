namespace EmpresaConstruccion.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; }
        public string UnidadMedida { get; set; }
        public int CantidadDisponible { get; set; }
    }
}