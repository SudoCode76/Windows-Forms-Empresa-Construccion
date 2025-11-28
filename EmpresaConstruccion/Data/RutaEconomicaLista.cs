namespace EmpresaConstruccion.Data
{
    // Nodo para la lista enlazada manual de rutas económicas
    public class RutaEconomicaNodo
    {
        public string Origen;
        public string Destino;
        public decimal Costo;
        public RutaEconomicaNodo Siguiente;
        // Constructor del nodo
        public RutaEconomicaNodo(string origen, string destino, decimal costo)
        {
            Origen = origen;
            Destino = destino;
            Costo = costo;
            Siguiente = null;
        }
    }

    // Lista enlazada manual para rutas económicas
    public class RutaEconomicaLista
    {
        public RutaEconomicaNodo Cabeza;
        // Constructor de la lista enlazada
        public RutaEconomicaLista()
        {
            Cabeza = null;
        }
        // Agrega un nodo al final de la lista enlazada
        public void Agregar(string origen, string destino, decimal costo)
        {
            var nuevo = new RutaEconomicaNodo(origen, destino, costo);
            if (Cabeza == null)
                Cabeza = nuevo;
            else
            {
                var actual = Cabeza;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
        }
    }
}
