namespace MWTrace_beta
{
    class PCBModelo : Conexion
    {
        int id_PM;
        int id_pcb;
        int id_modelo;
        string descripcion;
        string nomenclatura;

        public int Id_PM { get => id_PM; set => id_PM = value; }
        public int Id_pcb { get => id_pcb; set => id_pcb = value; }
        public int Id_modelo { get => id_modelo; set => id_modelo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Nomenclatura { get => nomenclatura; set => nomenclatura = value; }
    }
}
