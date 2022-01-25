namespace MWTrace_beta
{
    class Sim : Conexion
    {
        int id_sim;
        string sim;
        int digitos;
        public int Id_sim { get => id_sim; set => id_sim = value; }
        public string Sims { get => sim; set => sim = value; }
        public int Digitos { get => digitos; set => digitos = value; }
    }
}
