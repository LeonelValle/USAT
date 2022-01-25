using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Form2 : Form
    {
        //private readonly Conexion con = new Conexion();
        //private readonly Orden orden = new Orden();
        private readonly ModeloOrden modeloorden = new ModeloOrden();
        private DataView filtro;
        public Form2()
        {
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.filtro = modeloorden.Leer_Datos("select m.modelo, s.sim, mo.Serialnumber, mo.scanmodem, mo.scansim, o.orden, mo.fecharegistro, mo.Problema ,c.caja, p.pallette, o.Revision, o.RevisionFirmware, op.numeroempleado from tb_Operador op ,tb_ModeloOrden mo, tb_Orden o, tb_caja c, tb_Pallette p, tb_Modelo m, tb_SIM s where mo.id_orden = o.id_orden and mo.id_caja = c.id_caja and c.id_pallette = p.id_pallette and o.id_operador = op.id_operador and o.id_modelo = m.id_modelo and o.id_sim = s.id_sim", "tb_ModeloOrden.id_modeloOrden, tb_ModeloOrden.scanmodem, tb_ModeloOrden.scansim , tb_ModeloOrden.fecharegistro, tb_ModeloOrden.id_orden , tb_Orden.orden, tb_caja.caja , tb_pallette.pellette, tb_pallette.id_pellette");
                this.dg_buscar.DataSource = filtro;
            }
            catch { MessageBox.Show("no se encontro la base de datos!", "ERROR!"); }

            /*
            //ReportDocument cryRpt = new ReportDocument();
            CrystalReport2 cryRpt = new CrystalReport2();
            //cryRpt.Load("~/CrystalReport2.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = orden.Ordenes;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@orden"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
            */

            //SqlConnection cnn;
            //string connectionString = null;


            //connectionString = "data source=SERVERNAME;initial catalog=DATABASENAME;user id=USERNAME;password=PASSWORD;";
            //cnn = new SqlConnection(connectionString);
            //string sql = null;
            //con.Abrir();
            //sql = "select distinct mo.id_modeloOrden, m.modelo,s.sim, mo.Serialnumber, mo.scanmodem, mo.scansim, mo.fecharegistro, o.orden, sm.Modelo as ModeloPCB, o.Revision, o.RevisionFirmware ,c.caja, p.pallette, op.numeroempleado from tb_ModeloOrden mo inner join tb_Orden o on mo.id_orden = o.id_orden left join tb_caja c on mo.id_caja = c.id_caja left join tb_Pallette p on c.id_pallette = p.id_pallette left join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden left join tb_Modelo m on m.id_modelo = o.id_modelo left join tb_SIM s on s.id_sim = o.id_sim left join tb_Operador op on op.id_operador = o.id_operador where mo.id_orden = 52 order by mo.id_modeloOrden asc ";
            //SqlDataAdapter dscmd = new SqlDataAdapter(sql, con.Con1);
            //DataSet1 ds = new DataSet1();
            //dscmd.Fill(ds, "tb_ModeloOrden");
            ////MessageBox.Show(ds.Tables[0].Rows.Count.ToString());
            //con.Cerrar();

            //CrystalReport5 objRpt = new CrystalReport5();
            //objRpt.SetDataSource(ds.Tables[1]);
            //crystalReportViewer1.ReportSource = objRpt;
            //crystalReportViewer1.Refresh();
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            if (dg_buscar.Rows.Count != 0)
            {

                //string sql = null;
                //con.Abrir();
                ////sql = this.filtro.;
                ////sql = "select distinct mo.id_modeloOrden, m.modelo,s.sim, mo.Serialnumber, mo.scanmodem, mo.scansim, mo.fecharegistro, o.orden, sm.Modelo as ModeloPCB, o.Revision, o.RevisionFirmware ,c.caja, p.pallette, op.numeroempleado from tb_ModeloOrden mo inner join tb_Orden o on mo.id_orden = o.id_orden left join tb_caja c on mo.id_caja = c.id_caja left join tb_Pallette p on c.id_pallette = p.id_pallette left join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden left join tb_Modelo m on m.id_modelo = o.id_modelo left join tb_SIM s on s.id_sim = o.id_sim left join tb_Operador op on op.id_operador = o.id_operador where mo.id_orden = 52 order by mo.id_modeloOrden asc ";
                //SqlDataAdapter dscmd = new SqlDataAdapter(sql, con.Con1);
                //DataSet1 ds = new DataSet1();
                ////dscmd.Fill(filtro.ToTable());
                ////MessageBox.Show(ds.Tables[0].Rows.Count.ToString());
                //con.Cerrar();

                //CrystalReport5 objRpt = new CrystalReport5();
                //objRpt.SetDataSource(ds.Tables[1]);
                //objRpt.SetDataSource(filtro);
                //crystalReportViewer1.ReportSource = objRpt;
                //crystalReportViewer1.Refresh();
                //crystalReportViewer1.ExportReport();
                
                //SaveToTxt(dg_buscar);
                SaveToCSV(dg_buscar);
            }
            else
            {
                MessageBox.Show("No hay ninguna orden cargada!", "ERROR!");
            }
        }

        private void SaveToTxt(DataGridView DGV)
        {
            SaveFileDialog dlGuardar = new SaveFileDialog();
            dlGuardar.Filter = "Text File|*.txt";
            dlGuardar.FileName = "";
            dlGuardar.Title = "Exportar a TXT";
            if (dlGuardar.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvMemoria = new StringBuilder();

                //para los títulos de las columnas, encabezado
                for (int i = 2; i < DGV.Columns.Count; i++)
                {
                    if (i == DGV.Columns.Count - 1)
                    {
                        csvMemoria.Append(String.Format("\"{0}\"",
                            DGV.Columns[i].HeaderText));
                    }
                    else
                    {
                        csvMemoria.Append(String.Format("\"{0}\",",
                            DGV.Columns[i].HeaderText));
                    }
                }

                csvMemoria.AppendLine();


                for (int m = 0; m < DGV.Rows.Count; m++)
                {
                    for (int n = 2; n < DGV.Columns.Count; n++)
                    {
                        //si es la última columna no poner el ;
                        if (n == DGV.Columns.Count - 1)
                        {
                            csvMemoria.Append(String.Format("\"{0}\"", DGV.Rows[m].Cells[n].Value));
                        }
                        else
                        {
                            csvMemoria.Append(String.Format("\"{0}\",", DGV.Rows[m].Cells[n].Value));
                        }

                    }
                    csvMemoria.AppendLine();
                }
                System.IO.StreamWriter sw =
                    new System.IO.StreamWriter(dlGuardar.FileName, false,
                       System.Text.Encoding.Default);
                sw.Write(csvMemoria.ToString());
                sw.Close();
            }
        }

        private void SaveToCSV(DataGridView DGV)
        {
            SaveFileDialog dlGuardar = new SaveFileDialog();
            dlGuardar.Filter = "Fichero CSV (*.csv)|*.csv";
            dlGuardar.FileName = "";
            dlGuardar.Title = "Exportar a CSV";
            if (dlGuardar.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvMemoria = new StringBuilder();

                //para los títulos de las columnas, encabezado
                for (int i = 2; i < DGV.Columns.Count - 6; i++)
                {
                    if (i == DGV.Columns.Count - 1)
                        csvMemoria.Append(String.Format("\"{0}\"", DGV.Columns[i].HeaderText));
                    else
                        csvMemoria.Append(String.Format("\"{0}\",", DGV.Columns[i].HeaderText));
                    //csvMemoria.AppendFormat(String.Format("\"{0}\",", DGV.Columns[i].HeaderText), String.Empty);
                }

                csvMemoria.AppendLine();


                for (int m = 0; m < DGV.Rows.Count - 1; m++)
                {
                    for (int n = 2; n < DGV.Columns.Count - 6; n++)
                    {
                        //si es la última columna no poner el ;
                        if (n == DGV.Columns.Count - 1)
                        {
                            csvMemoria.AppendFormat(string.Format("\"{0}\"", DGV.Rows[m].Cells[n].Value + "", string.Empty));
                        }
                        else
                        {
                            //if (n == 4)
                            //    csvMemoria.AppendFormat(string.Format("\"{0}\",", DGV.Rows[m].Cells[n].Value + ";", string.Empty));
                            //else
                                csvMemoria.AppendFormat(string.Format("\"{0}\",", DGV.Rows[m].Cells[n].Value + "", string.Empty));
                        }

                    }
                    csvMemoria.AppendLine();
                }

                
                //File.WriteAllText(dlGuardar.FileName.ToString(), csvMemoria.ToString(), System.Text.Encoding.Default);
                File.AppendAllText(dlGuardar.FileName.ToString(), csvMemoria.ToString());
                //sw.Close();
            }
        }


        private void txt_buscar_KeyUp(object sender, KeyEventArgs e)
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
                        salida_datos = string.Format("CONVERT(orden, System.String) LIKE '{0}%'", palabra);
                    else
                        salida_datos += " AND (orden LIKE % '" + palabra + " %')";
                }
                if (cb_filtro.Text == "Caja")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(caja, System.String) LIKE '{0}'", palabra);
                    else
                        salida_datos += " AND (caja LIKE % '" + palabra + " %')";
                }
                if (cb_filtro.Text == "Pallette")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(pallette, System.String) LIKE '%{0}'", palabra);
                    else
                        salida_datos += " AND (pallette LIKE % '" + palabra + " %')";
                }
                if (cb_filtro.Text == "Fecha Registro")
                {
                    if (salida_datos.Length == 0)
                        salida_datos = string.Format("CONVERT(fecharegistro, System.String) LIKE '%" + palabra + "%'");
                    else
                        salida_datos += " AND (fecharegistro LIKE % '" + palabra + " %')";
                }

                this.filtro.RowFilter = salida_datos;
            }
        }
    }
}
