namespace EmpresaConstruccion.Data
{
    // Nodo para la lista enlazada manual de destinos
    public class DestinoNodo
    {
        public Models.Destino Destino;
        public DestinoNodo Siguiente;
        // Constructor del nodo
        public DestinoNodo(Models.Destino destino)
        {
            Destino = destino;
            Siguiente = null;
        }
    }

    // Lista enlazada manual de destinos
    public class DestinoLista
    {
        public DestinoNodo Cabeza;
        // Constructor de la lista enlazada
        public DestinoLista()
        {
            Cabeza = null;
        }
        // Agrega un nodo al final de la lista
        public void Agregar(Models.Destino destino)
        {
            var nuevo = new DestinoNodo(destino);
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
        // Busca un destino por IdDestino en la lista enlazada
        public Models.Destino BuscarPorId(int id)
        {
            var actual = Cabeza;
            while (actual != null)
            {
                if (actual.Destino.IdDestino == id)
                    return actual.Destino;
                actual = actual.Siguiente;
            }
            return null;
        }
        // Suma la demanda de todos los destinos en la lista enlazada
        public int SumarDemanda()
        {
            int suma = 0;
            var actual = Cabeza;
            while (actual != null)
            {
                suma += actual.Destino.Demanda;
                actual = actual.Siguiente;
            }
            return suma;
        }
        // Convierte la lista enlazada manual a una lista estándar de C#
        public System.Collections.Generic.List<Models.Destino> ToList()
        {
            var list = new System.Collections.Generic.List<Models.Destino>();
            var actual = Cabeza;
            while (actual != null)
            {
                list.Add(actual.Destino);
                actual = actual.Siguiente;
            }
            return list;
        }
        // Permite recorrer la lista enlazada manual con foreach
        public System.Collections.Generic.IEnumerable<Models.Destino> Enumerar()
        {
            var actual = Cabeza;
            while (actual != null)
            {
                yield return actual.Destino;
                actual = actual.Siguiente;
            }
        }
    }
}
