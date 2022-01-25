using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Status : Form
    {

        Orden orden = new Orden();
        public Status()
        {
            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
        {
            EjecutarSP(0);
            dataGridView1.DataSource = orden.LlenarDG("select orden, m.modelo,FechaOrden,cantidad, Restantes from tb_orden o, tb_Modelo m where FechaCierre is null and Restantes != 0 and o.id_modelo = m.id_modelo").Tables[0];
            dataGridView2.DataSource = orden.LlenarDG("select orden, m.modelo,FechaOrden,cantidad, Restantes from tb_orden o, tb_Modelo m where Restantes = 0 and o.id_modelo = m.id_modelo").Tables[0];
        }

        private void EjecutarSP(int id_orden)
        {
            Conexion con = new Conexion();

            try
            {
                con.Abrir();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("sp_EstatusOrdenes", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_orden", id_orden);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Cerrar();
            }
        }
    }
}
