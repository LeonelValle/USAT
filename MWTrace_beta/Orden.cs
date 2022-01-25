using System;

namespace MWTrace_beta
{
    class Orden : Conexion
    {
        int id_orden;
        static double orden;
        int cantidad;
        int id_pcb;
        int id_modelo;
        int id_sim;
        DateTime fechaOrden;

        public int Id_orden { get => id_orden; set => id_orden = value; }
        public double Ordenes { get => orden; set => orden = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Id_pcb { get => id_pcb; set => id_pcb = value; }
        public int Id_modelo { get => id_modelo; set => id_modelo = value; }
        public DateTime FechaOrden { get => fechaOrden; set => fechaOrden = value; }
        public int Id_sim { get => id_sim; set => id_sim = value; }
    }
}
