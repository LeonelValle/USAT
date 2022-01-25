using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Shipping : Form
    {
        Conexion con = new Conexion();
        ModeloOrden modeloOrden = new ModeloOrden();
        Pallette pallette = new Pallette();
        public Shipping()
        {
            InitializeComponent();
        }

        private void Shipping_Load(object sender, EventArgs e)
        {
            EjecutarSPCerrar();
            EjecutarSP();

            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowHeadersVisible = false; // set it to false if not needed
            this.dataGridView1.VirtualMode = true;
        }

        private void EjecutarSPCerrar()
        {
            try
            {
                con.Abrir();
                SqlCommand cmd = new SqlCommand("sp_BorrarTabla", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;
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
        private void EjecutarSP()
        {
            try
            {
                con.Abrir();
                SqlCommand cmd = new SqlCommand("sp_CrearTablaShipping", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;
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

        private void EjecutarSPShipping(int id_pallette)
        {
            try
            {
                con.Abrir();
                SqlCommand cmd = new SqlCommand("sp_Shipping", con.Con1);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_pallette", id_pallette);

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

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txt_pallette.Text)))
            {
                if (modeloOrden.Existe("select COUNT(*) from tb_pallette where pallette = '" + txt_pallette.Text + "' and pallette != '' "))
                {
                    if (!modeloOrden.Existe("select COUNT(*) from tb_Shipping where pallette = '" + txt_pallette.Text.Trim() + "' and pallette != '' "))
                    {
                        pallette.Id_pallette = int.Parse(pallette.ReturnID("select id_pallette from tb_Pallette where pallette = '" + txt_pallette.Text.Trim() + "'"));

                        EjecutarSPShipping(pallette.Id_pallette);

                        dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                        dataGridView1.RowHeadersVisible = false; // set it to false if not needed
                        this.dataGridView1.VirtualMode = true;

                        //dataGridView1.DataSource = modeloOrden.LlenarDG("select ensamble as Assambly, serialnumber as SerialNumber, mac as MAC_Address, imei as IMEI_Number, serialnumberCaja as Box_SerialNumber, macCaja as Box_MACAddress, imeiCaja as Box_IMEINumber, orden as WorkOrder, fecharegistro as Date_Register, shipping_date = GETDATE() ,caja as BoxID, turno as Shift, revision as Revision, numeroempleado as EMP_IDNUMBER from tb_Shipping").Tables[0];
                        dataGridView1.DataSource = modeloOrden.LlenarDG("select * from tb_Shipping").Tables[0];

                        //dataGridView1.DataSource = EjecutarSPTest(id_caja);

                        labelCount();
                        txt_pallette.Text = "";
                        this.txt_pallette.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Este pallette ya ha sido insertado!", "ERROR!");
                        txt_pallette.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("El pallette que se inserto no existe!", "ERROR!");
                    txt_pallette.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Inserte un pallette!", "ERROR!");
            }
        }

        private void labelCount()
        {
            lbl_total.Text = modeloOrden.ReturnValue("select COUNT(*) from tb_Shipping");
            //lbl_agregados.Text = modeloOrden.ReturnValue("select COUNT(*) from tb_ModeloOrden where id_caja = " + modeloOrden.Id_caja);
            lbl_cajas.Text = modeloOrden.ReturnValue("select  COUNT(distinct caja) from tb_Shipping");
        }
    }
}
