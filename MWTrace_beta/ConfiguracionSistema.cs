namespace MWTrace_beta
{
    class ConfiguracionSistema : Conexion
    {
        int id_cs;
        int consecutivo;
        string nomenclatura;
        int numerocaja;

        public int Id_cs { get => id_cs; set => id_cs = value; }
        public int Consecutivo { get => consecutivo; set => consecutivo = value; }
        public string Nomenclatura { get => nomenclatura; set => nomenclatura = value; }
        public int Numerocaja { get => numerocaja; set => numerocaja = value; }
    }
}
