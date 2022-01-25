using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Retrabajo : Form
    {
        private readonly ModeloOrden modeloorden = new ModeloOrden();
        private DataView filtro;
        private readonly Orden orden = new Orden();
        int contadorModem = 0, contadorSim = 0;
        //private readonly Conexion con = new Conexion();
        //private readonly BindingSource bindingsource1 = new BindingSource();
        //private readonly SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //private readonly DataSet res = new DataSet();

        public Retrabajo()
        {
            InitializeComponent();
        }

        private void Retrabajo_Load(object sender, EventArgs e)
        {
            try
            {
                //this.filtro = modeloorden.Leer_Datos("select mo.scanmodem, mo.scansim, mo.Serialnumber, mo.fecharegistro, o.orden, c.caja, p.pallette from tb_ModeloOrden mo inner join tb_Orden o on mo.id_orden = o.id_orden left join tb_caja c on mo.id_caja = c.id_caja left join tb_Pallette p on c.id_pallette = p.id_pallette", "tb_ModeloOrden, tb_Orden, tb_caja, tb_Pallette");
                this.filtro = modeloorden.Leer_Datos("select mo.Serialnumber, mo.scanmodem, mo.scansim, o.orden, mo.fecharegistro, mo.Problema ,c.caja, p.pallette from tb_ModeloOrden mo, tb_Orden o, tb_caja c, tb_Pallette p where mo.id_orden = o.id_orden and mo.id_caja = c.id_caja and c.id_pallette = p.id_pallette", "tb_ModeloOrden.id_modeloOrden, tb_ModeloOrden.scanmodem, tb_ModeloOrden.scansim , tb_ModeloOrden.fecharegistro, tb_ModeloOrden.id_orden , tb_Orden.orden, tb_caja.caja , tb_pallette.pellette, tb_pallette.id_pellette");
                this.dataGridView1.DataSource = filtro;
            }
            catch { MessageBox.Show("no se encontro la base de datos!", "ERROR!"); }
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            //IF PARA VALIDAR QUE NO ESTEN VACIOS LOS CAMPOS
            if (!(string.IsNullOrEmpty(txt_serial.Text)) && !(string.IsNullOrEmpty(txt_serial.Text)) && !(string.IsNullOrEmpty(txt_problema.Text)))
            {
                //Validar que el IMEI sea de 36 caracteres de largo
                if (txt_sacanmodem.TextLength == 36 && txt_scansim.TextLength == 20)
                {
                    if (!modeloorden.Existe("select count(*) from tb_ModeloOrden where scanmodem = '" + txt_sacanmodem.Text.Trim() + "'") && !modeloorden.Existe("select count(*) from tb_ModeloOrden where scansim = '" + txt_scansim .Text.Trim() + "'"))
                    {

                        modeloorden.Crud("update tb_ModeloOrden set scanmodem = '" + txt_sacanmodem.Text + "' , scansim = '" + txt_scansim.Text + "' , Problema = '" + txt_problema.Text + "' where Serialnumber = '" + txt_serial.Text + "'");
                        Retrabajo_Load(sender, e);
                        TextBoxToEmpty();
                    }
                    else
                        MessageBox.Show("Ya existe este registro!");
                }
                else
                { MessageBox.Show("El IMIE debe de ser de 36 caracteres y el SIM de 20"); }
            }
            else
            { MessageBox.Show("No dejes ningun campo vacio!", "ERROR!"); }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                var leer = orden.Leer("Select * from tb_ModeloOrden where Serialnumber = '" + txt_serial.Text.ToUpper() + "'");

                if (leer.Read() == true)
                {
                    txt_sacanmodem.Text = leer["scanmodem"].ToString();
                    txt_scansim.Text = leer["scansim"].ToString();
                }
                else
                {
                    txt_sacanmodem.Text = "";
                    txt_scansim.Text = "";
                }
                orden.Cerrar();
            }
            catch (System.InvalidOperationException)
            {
                orden.Cerrar();
                throw;
            }
        }

        private void Txt_sacanmodem_TextChanged(object sender, EventArgs e)
        {
            contadorModem = txt_sacanmodem.Text.Length;
            lbl_scanmodem.Text = contadorModem.ToString();
        }

        private void Txt_scansim_TextChanged(object sender, EventArgs e)
        {
            contadorSim = txt_scansim.Text.Length;
            lbl_scansim.Text = contadorSim.ToString();
        }

        private void Txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabra_busqueda = this.txt_buscar.Text.Split(' ');

            foreach (string palabra in palabra_busqueda)
            {
                if (cb_orden.Text == "Serial Number")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(Serialnumber LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (Serialnumber LIKE '%" + palabra + "%')";
                }

                if (cb_orden.Text == "Scan Modem")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(scanmodem LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (scanmodem LIKE '%" + palabra + "%')";
                }

                if (cb_orden.Text == "Scan Sim")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(scansim LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (scansim LIKE '%" + palabra + "%')";
                }

                if (cb_orden.Text == "Orden")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(orden, System.String) LIKE '{0}%'", palabra);
                    else
                        salida_datos += " AND (orden LIKE % '" + palabra + " %')";
                }
                if (cb_orden.Text == "Caja")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(caja, System.String) LIKE '{0}'", palabra);
                    else
                        salida_datos += " AND (caja LIKE % '" + palabra + " %')";
                }
                if (cb_orden.Text == "Pallette")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(pallette, System.String) LIKE '%{0}'", palabra);
                    else
                        salida_datos += " AND (pallette LIKE % '" + palabra + " %')";
                }

                this.filtro.RowFilter = salida_datos;
            }
        }

        private void TextBoxToEmpty()
        {
            txt_problema.Text = "";
            txt_sacanmodem.Text = "";
            txt_scansim.Text = "";
        }

    }
}
