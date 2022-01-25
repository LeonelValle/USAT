namespace MWTrace_beta
{
    class Caja : Conexion
    {
        int id_caja;
        int cajas;
        int id_pallete;

        public int Id_caja { get => id_caja; set => id_caja = value; }
        public int Cajas { get => cajas; set => cajas = value; }
        public int Id_pallete { get => id_pallete; set => id_pallete = value; }
    }
}
