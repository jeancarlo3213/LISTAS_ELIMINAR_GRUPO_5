using LISTAS_ELIMINAR_GRUPO_5.Modelos;
using System.Collections;
namespace LISTAS_ELIMINAR_GRUPO_5.Services
{
    public class ListasEnlazadasSimples : IEnumerable
    {
        public Nodo PrimerNodo { get; set; }
        public Nodo UltimoNodo { get; set; }
        public ListasEnlazadasSimples() {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        public bool ListaVacia()
        {
            return PrimerNodo==null;
        }
        public string AgregarAlInicio (Nodo nuevonodo)
        {
            if (ListaVacia())
            {
                PrimerNodo=nuevonodo;
                UltimoNodo=nuevonodo;
            }
            else
            {
                nuevonodo.Referencia = PrimerNodo;
                PrimerNodo = nuevonodo;
            }
            return "(: NODO AGREGADO AL INICIO CON EXITO :) ";
        }
        public string AgregarAlFinal(Nodo nuevonodo)
        {
            if (ListaVacia())
            {
                PrimerNodo = nuevonodo;
                UltimoNodo = nuevonodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevonodo;
                UltimoNodo=nuevonodo;
            }
            return "(: NODO AGREGADO AL FINAL CON EXITO :)";
        }
        public string EliminarDespuesDeDatoX(object datoX)
        {
            if (PrimerNodo == null)
            {
                return "La lista está vacía.";
            }

            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null && !nodoActual.Informacion.Equals(datoX))
            {
                nodoActual = nodoActual.Referencia;
            }

            if (nodoActual == null || nodoActual.Referencia == null)
            {
                return "No se encontró el dato X o el nodo después de X en la lista.";
            }

            Nodo nodoASuprimir = nodoActual.Referencia;
            nodoActual.Referencia = nodoASuprimir.Referencia;

            // Si el nodo a suprimir era el último nodo, actualizamos UltimoNodo
            if (nodoASuprimir == UltimoNodo)
            {
                UltimoNodo = nodoActual;
            }

            nodoASuprimir = null; // Liberar memoria

            return "Se ha eliminado el nodo después de X.";
        }

        public string EliminarAntesdeunDatoX(string datoX)
        {
            if (PrimerNodo == null)
            {
                return "La lista está vacía, no se pueden realizar operaciones de eliminación.";
            }

            if (PrimerNodo.Informacion.Equals(datoX))
            {
                return "No se encuentra ningún nodo antes del dato X.";
            }

            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;

            while (nodoActual != null && !nodoActual.Referencia.Informacion.Equals(datoX))
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Referencia;
            }

            // Si llegamos al final de la lista sin encontrar el dato X
            if (nodoActual == null)
            {
                return "El dato X no se encontró en la lista.";
            }

            // Cuando encontramos el nodo con el dato X
            // Verificamos si el nodo anterior es nulo, es decir, si el nodo con el dato X es el primer nodo de la lista
            // Si es así, no hay un nodo antes de él para eliminar
            if (nodoAnterior != null)
            {
                nodoAnterior.Referencia = nodoActual.Referencia; // Eliminamos el nodo actual
            }

            return "Nodo eliminado antes del dato X.";
        }

        public string EliminarAlInicio()
        {
            if (PrimerNodo == null)
            {
                UltimoNodo = null;
                return ":( NO EXISTEN NODOS EN LA LISTA ):";
            }
            else
            {
                PrimerNodo = PrimerNodo.Referencia;
            }
            return "-- NODO ELIMINADO AL INICIO ---";
        }

        public string EliminarNodoAlFinal()
        {
            // Verificar si la lista está vacía
            if (ListaVacia())
            {
                return "La lista ya está vacía, no se puede eliminar ningún elemento.";
            }

            // Si la lista no está vacía, encontrar el penúltimo nodo
            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;

            while (nodoActual.Referencia != null)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Referencia;
            }

            // Cuando se llega al penúltimo nodo, eliminar la referencia al último nodo
            if (nodoAnterior != null)
            {
                nodoAnterior.Referencia = null;
                UltimoNodo = nodoAnterior; // Actualizar UltimoNodo para que apunte al penúltimo nodo
            }
            // Si el penúltimo nodo es null, significa que la lista solo tiene un nodo
            else
            {
                PrimerNodo = null; // En este caso, también actualizamos PrimerNodo a null
                UltimoNodo = null;
            }

            return "Se ha eliminado el nodo al final de la lista.";
        }
        public string EliminarEnPosicion(int posicion)
        {
            if (posicion < 0)
            {
                return "La posición debe ser un número positivo.";
            }

            if (PrimerNodo == null)
            {
                return "La lista está vacía, no se puede eliminar ningún elemento.";
            }

            if (posicion == 0)
            {
                Nodo nodoASuprimir = PrimerNodo;
                PrimerNodo = PrimerNodo.Referencia;
                nodoASuprimir = null;

                if (PrimerNodo == null)
                {
                    UltimoNodo = null; // Actualizar UltimoNodo si la lista quedó vacía
                }

                return "Se ha eliminado el nodo en la posición especificada.";
            }

            Nodo nodoActual = PrimerNodo;
            int contador = 1;
            Nodo nodoAnterior = null;

            while (nodoActual != null && contador < posicion)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Referencia;
                contador++;
            }

            if (nodoActual == null)
            {
                return "La posición especificada está más allá del final de la lista.";
            }

            nodoAnterior.Referencia = nodoActual.Referencia;

            // Si se eliminó el último nodo, actualizamos UltimoNodo
            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nodoAnterior;
            }

            nodoActual = null; // Liberar memoria

            return "Se ha eliminado el nodo en la posición especificada.";
        }

        public void OrdenarLista()
        {
            if (PrimerNodo == null || PrimerNodo.Referencia == null)
            {
                return; // La lista está vacía o solo tiene un elemento, no se necesita ordenar
            }

            bool intercambio = false;

            do
            {
                intercambio = false;
                Nodo nodoActual = PrimerNodo;
                Nodo nodoSiguiente = PrimerNodo.Referencia;

                while (nodoSiguiente != null)
                {
                    if (Convert.ToInt32(nodoActual.Informacion) > Convert.ToInt32(nodoSiguiente.Informacion))
                    {
                        // Intercambiar los valores de los nodos
                        object temp = nodoActual.Informacion;
                        nodoActual.Informacion = nodoSiguiente.Informacion;
                        nodoSiguiente.Informacion = temp;
                        intercambio = true;
                    }

                    nodoActual = nodoSiguiente;
                    nodoSiguiente = nodoSiguiente.Referencia;
                }
            }
            while (intercambio);
        }

        public IEnumerator GetEnumerator()
        {
            Nodo nodoauxiliar = PrimerNodo;
            while(nodoauxiliar != null)
            {
                yield return nodoauxiliar;
                nodoauxiliar = nodoauxiliar.Referencia;
            }
        }
    }
}
