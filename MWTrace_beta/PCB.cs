namespace MWTrace_beta
{
    class PCB : Conexion
    {
        int id_pcb;
        string pcb;

        public int Id_pcb { get => id_pcb; set => id_pcb = value; }
        public string Pcb { get => pcb; set => pcb = value; }
    }
}
