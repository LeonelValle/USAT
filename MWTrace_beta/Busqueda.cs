using System;
using System.Data;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Busqueda : Form
    {
        ModeloOrden modeloorden = new ModeloOrden();
        DataSet res = new DataSet();
        DataView filtro;

        public Busqueda()
        {
            InitializeComponent();
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {
            FillDv();
            //try
            //{
            //    //this.filtro = modeloorden.Leer_Datos("select mo.Serialnumber, mo.scanmodem, mo.scansim, o.orden, mo.fecharegistro from tb_ModeloOrden mo, tb_Orden o where mo.id_orden = o.id_orden", "tb_ModeloOrden.scanmodem,tb_ModeloOrden.scansim,tb_Orden.orden,tb_caja.caja,tb_Pallette.pallette");
            //    this.filtro = modeloorden.Leer_Datos("select mo.Serialnumber, mo.scanmodem, mo.scansim, sm.Modelo ,o.orden, mo.fecharegistro, c.caja, p.pallette from tb_ModeloOrden mo join tb_Orden o on mo.id_orden = o.id_orden join tb_caja c on mo.id_caja = c.id_caja join tb_Pallette p on c.id_pallette = p.id_pallette join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden", "tb_ModeloOrden.id_modeloOrden, tb_ModeloOrden.scanmodem, tb_ModeloOrden.scansim , tb_ModeloOrden.fecharegistro, tb_ModeloOrden.id_orden , tb_Orden.orden, tb_caja.caja , tb_pallette.pellette, tb_pallette.id_pellette");
            //    this.dg_buscar.DataSource = filtro;
            //}
            //catch (System.Exception)
            //{
            //    MessageBox.Show("Base de datos no encontrada!");
            //}
        }

        private void Txt_buscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";
            string[] palabra_busqueda = this.txt_buscar.Text.Split(' ');

            foreach (string palabra in palabra_busqueda)
            {
                if (cb_filtro.Text == "Serial Number")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(Serialnumber LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (Serialnumber LIKE '%" + palabra + "%')";
                }

                if (cb_filtro.Text == "Scan Modem")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(scanmodem LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (scanmodem LIKE '%" + palabra + "%')";
                }

                if (cb_filtro.Text == "Scan Sim")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = "(scansim LIKE '%" + palabra + "%')";
                    else
                        salida_datos += " AND (scansim LIKE '%" + palabra + "%')";
                }

                if (cb_filtro.Text == "Orden")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(WorkOrder, System.String) LIKE '{0}'", palabra);
                    else
                        salida_datos += " AND (WorkOrder LIKE % '" + palabra + " %')";
                }
                if (cb_filtro.Text == "Caja")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(Box, System.String) LIKE '{0}'", palabra);
                    else
                        salida_datos += " AND (Box LIKE % '" + palabra + " %')";
                }
                if (cb_filtro.Text == "Pallette")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(pallette, System.String) LIKE '%{0}%'", palabra);
                    else
                        salida_datos += " AND (pallette LIKE % '" + palabra + " %')";
                }

                if (cb_filtro.Text == "Fecha")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(DateScan, System.String) LIKE '%{0}%'", palabra);
                    else
                        salida_datos += " AND (DateScan LIKE % '" + palabra + " %')";
                }
                this.filtro.RowFilter = salida_datos;
                //FillDv();
            }
        }

        private void FillDv()
        {
            try
            {
                //this.filtro = modeloorden.Leer_Datos("select mo.Serialnumber, mo.scanmodem, mo.scansim, sm.Modelo ,o.orden, mo.fecharegistro, c.caja, p.pallette from tb_ModeloOrden mo join tb_Orden o on mo.id_orden = o.id_orden join tb_caja c on mo.id_caja = c.id_caja join tb_Pallette p on c.id_pallette = p.id_pallette join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden", "tb_ModeloOrden.id_modeloOrden, tb_ModeloOrden.scanmodem, tb_ModeloOrden.scansim , tb_ModeloOrden.fecharegistro, tb_ModeloOrden.id_orden , tb_Orden.orden, tb_caja.caja , tb_pallette.pellette, tb_pallette.id_pellette");
                this.filtro = modeloorden.Leer_Datos("select m.modelo as Model, s.sim, mo.Serialnumber, mo.scanmodem, mo.scansim, o.orden as WorkOrder, mo.fecharegistro as DateScan,c.caja as Box, p.pallette, o.Revision as Rev, o.RevisionFirmware as Firmware, op.numeroempleado as Employee from tb_Operador op ,tb_ModeloOrden mo, tb_Orden o, tb_caja c, tb_Pallette p, tb_Modelo m, tb_SIM s where mo.id_orden = o.id_orden and mo.id_caja = c.id_caja and c.id_pallette = p.id_pallette and o.id_operador = op.id_operador and o.id_modelo = m.id_modelo and o.id_sim = s.id_sim", "tb_ModeloOrden.id_modeloOrden, tb_ModeloOrden.scanmodem, tb_ModeloOrden.scansim , tb_ModeloOrden.fecharegistro, tb_ModeloOrden.id_orden , tb_Orden.orden, tb_caja.caja , tb_pallette.pellette, tb_pallette.id_pellette");

                this.dg_buscar.DataSource = filtro;
            }
            catch (System.Exception)
            {
                MessageBox.Show("Base de datos no encontrada!");
            }
        }
    }
}
