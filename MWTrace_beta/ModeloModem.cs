namespace MWTrace_beta
{
    class ModeloModem : Conexion
    {
        int id_mm;
        string modelo;
        int numero;

        public int Id_mm { get => id_mm; set => id_mm = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Numero { get => numero; set => numero = value; }
    }
}
