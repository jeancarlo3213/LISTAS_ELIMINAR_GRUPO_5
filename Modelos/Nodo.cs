namespace LISTAS_ELIMINAR_GRUPO_5.Modelos
{
    public class Nodo
    {
        public Nodo Referencia { get; set; }
        public Object Informacion { get; set; }

        public Nodo() {
            Referencia = null;
            Informacion = null;
        }
        public Nodo (object informacion)
        {
            Informacion=informacion;
            Referencia = null;
        }
        public Nodo (Nodo referencia ,object informacion)
        {
            Referencia =referencia;
            Informacion =informacion;
        }
        public override string ToString()
        {
            return $"{Informacion}";
        }
    }
}
