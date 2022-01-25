using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearEtiquetas
{
    class ModeloOrden : Conexion
    {
        int id_modeloOrden;
        string id_scanmodem;
        string id_scansim;
        String Serialnumber;
        int id_Orden;
        bool Checked;
        int id_caja;

        public int Id_modeloOrden { get => id_modeloOrden; set => id_modeloOrden = value; }
        public string Id_scanmodem { get => id_scanmodem; set => id_scanmodem = value; }
        public string Id_scansim { get => id_scansim; set => id_scansim = value; }
        public string Serialnumber1 { get => Serialnumber; set => Serialnumber = value; }
        public int Id_Orden { get => id_Orden; set => id_Orden = value; }
        public bool Checked1 { get => Checked; set => Checked = value; }
        public int Id_caja { get => id_caja; set => id_caja = value; }

        public List<ModeloOrden> GetModeloOrden(string comando)
        {
            List<ModeloOrden> ordenes = new List<ModeloOrden>();

            Abrir();
            using (var command = new SqlCommand(comando, Con1))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var MO = new ModeloOrden();
                        MO.Id_modeloOrden = int.Parse(reader["id_modeloOrden"].ToString());
                        MO.Id_Orden = int.Parse(reader["id_orden"].ToString());
                        MO.Serialnumber1 = reader["Serialnumber"].ToString();
                        MO.Id_caja = int.Parse(reader["id_caja"].ToString());
                        ordenes.Add(MO);
                    }
                }
            }

            return ordenes;
        }




    }
}
