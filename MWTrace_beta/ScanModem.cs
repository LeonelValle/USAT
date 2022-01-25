namespace MWTrace_beta
{
    class ScanModem : Conexion
    {
        int id_Scanmodem;
        string scanmodem;
        string serialModem;
        string Modelo;
        int id_PM;

        public int Id_Scanmodem { get => id_Scanmodem; set => id_Scanmodem = value; }
        public string Scanmodem { get => scanmodem; set => scanmodem = value; }
        public string SerialModem { get => serialModem; set => serialModem = value; }
        public string Modelo1 { get => Modelo; set => Modelo = value; }
        public int Id_PM { get => id_PM; set => id_PM = value; }
    }
}
