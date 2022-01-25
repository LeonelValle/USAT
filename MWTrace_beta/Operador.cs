namespace MWTrace_beta
{
    class Operador : Conexion
    {
        int id_operador;
        string nombre;
        static int numeroempleado;

        public int Id_operador { get => id_operador; set => id_operador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Numeroempleado { get => numeroempleado; set => numeroempleado = value; }
    }
}
