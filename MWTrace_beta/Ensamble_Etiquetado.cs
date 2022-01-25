using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class Ensamble_Etiquetado : Form
    {
        private readonly Conexion con = new Conexion();
        private readonly Orden orden = new Orden();
        private readonly ModeloOrden modeloorden = new ModeloOrden();
        private readonly Operador operador = new Operador();
        private readonly Sim sim = new Sim();
        int contadorIMEI = 0;
        int contadorSIM = 0;

        public Ensamble_Etiquetado()
        {
            InitializeComponent();
        }

        private void Ensamble_Etiquetado_Load(object sender, EventArgs e)
        {
            //int id_orden = int.Parse(orden.ReturnValue("select id_orden from tb_Orden where orden = " + orden.Ordenes));

            //lbl_serial.Text = orden.Ordenes.ToString();

            //lbl_numeroempleado.Text = operador.Numeroempleado.ToString();

            //lbl_registrados.Text = modeloorden.ReturnValue("select COUNT(scanmodem) from tb_ModeloOrden where id_orden = " + id_orden);

            //lbl_revision.Text = orden.ReturnValue("select Revision from tb_Orden where id_orden = " + id_orden);

            //lbl_firmware.Text = orden.ReturnValue("select RevisionFirmware from tb_Orden where id_orden = " + id_orden);

            //orden.Cantidad = int.Parse(orden.ReturnValue("select cantidad from tb_Orden where id_orden = " + id_orden));

            //orden.Id_sim = int.Parse(orden.ReturnValue("select id_sim from tb_Orden where id_orden = " + id_orden));

            //sim.Digitos = int.Parse(orden.ReturnValue("select digitos from tb_Sim where id_sim = " + orden.Id_sim));


            try
            {
                LoadParameters();

                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false; // set it to false if not needed
                this.dataGridView1.VirtualMode = true;

                dataGridView1.DataSource = con.LlenarDG("select distinct mo.id_modeloOrden, mo.scanmodem as 'IMEI', mo.scansim as 'SIM', mo.Serialnumber , mo.fecharegistro as 'Scan Date', o.orden as 'Work Order', sm.Modelo as 'Model',c.caja as 'Box', p.pallette from tb_ModeloOrden mo inner join tb_Orden o on mo.id_orden = o.id_orden left join tb_caja c on mo.id_caja = c.id_caja left join tb_Pallette p on c.id_pallette = p.id_pallette left join tb_ScanModem sm on mo.id_modeloOrden = sm.id_modeloOrden where mo.id_orden = " + orden.Id_orden + " order by mo.id_modeloOrden asc ").Tables[0];
                this.dataGridView1.Columns[0].Visible = false;

                int nRowIndex = int.Parse(con.ReturnValue("select COUNT(*) from tb_ModeloOrden where scanmodem is not null and scansim is not null and id_orden = " + orden.Id_orden)) - 1;
                if (int.Parse(lbl_registrados.Text) == orden.Cantidad)
                {
                    DisableControls();
                    MessageBox.Show("Se completo la orden!", "¡Success!");

                }

                if (nRowIndex < 0)
                {
                    nRowIndex = 0;
                    dataGridView1.Rows[nRowIndex + 1].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = nRowIndex;
                    //dataGridView1.CurrentCell = dataGridView1.Rows[nRowIndex + 1].Cells[0];
                    dataGridView1.Refresh();


                }
                else
                {
                    dataGridView1.Rows[nRowIndex + 1].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = nRowIndex;
                    //dataGridView1.CurrentCell = dataGridView1.Rows[nRowIndex + 1].Cells[0];
                    dataGridView1.Refresh();

                    PaintCells();
                }
            }
            catch { MessageBox.Show("ERROR!", "no se encontro la base de datos!"); }
        }

        private void PaintCells()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (dataGridView1.Rows[row.Index].Cells[6].Value.ToString() == "")
                    break;

                dataGridView1.Rows[row.Index].Cells[6].Style.BackColor = Color.Purple;
                dataGridView1.Rows[row.Index].Cells[6].Style.ForeColor = Color.White;

            }
        }

        private void LoadParameters()
        {
            orden.Id_orden = int.Parse(orden.ReturnValue("select id_orden from tb_Orden where orden = " + orden.Ordenes));

            lbl_serial.Text = orden.Ordenes.ToString();

            lbl_numeroempleado.Text = operador.Numeroempleado.ToString();

            lbl_registrados.Text = modeloorden.ReturnValue("select COUNT(scanmodem) from tb_ModeloOrden where id_orden = " + orden.Id_orden);

            lbl_revision.Text = orden.ReturnValue("select Revision from tb_Orden where id_orden = " + orden.Id_orden);

            lbl_firmware.Text = orden.ReturnValue("select RevisionFirmware from tb_Orden where id_orden = " + orden.Id_orden);

            orden.Cantidad = int.Parse(orden.ReturnValue("select cantidad from tb_Orden where id_orden = " + orden.Id_orden));

            orden.Id_sim = int.Parse(orden.ReturnValue("select id_sim from tb_Orden where id_orden = " + orden.Id_orden));

            sim.Digitos = int.Parse(orden.ReturnValue("select digitos from tb_Sim where id_sim = " + orden.Id_sim));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //string ScanModem, ScanSim;
            int filled, count;
            count = int.Parse(orden.ReturnValue("select cantidad from tb_Orden where id_orden = " + orden.Id_orden));
            filled = int.Parse(modeloorden.ReturnValue("select COUNT(scanmodem) from tb_ModeloOrden where id_orden = " + orden.Id_orden));
            /*
            string imei15 = "";
            string[] imei = txt_imei.Text.Split(';');
            foreach (var item in imei)
            {
                imei15 = item.ToString();
                break;
            }
            */
            if (filled <= count)
            {
                //IF PARA SABER SI LOS TEXTBOX ESTAN VACIOS
                if (!(string.IsNullOrEmpty(txt_serial.Text)) && !(string.IsNullOrEmpty(txt_serial.Text)))
                {
                    //Validar que el IMEI sea de 36 caracteres de largo
                    if (txt_imei.TextLength == 36)
                    {
                        if (ImeiCorrect().Length == 15)
                        {
                            //Validar que LA SIM SEA DE 20 / 19 / 16
                            //if (txt_sim.TextLength == 20 || txt_sim.TextLength == 19 || txt_sim.TextLength == 16)
                            if (txt_sim.TextLength == sim.Digitos)
                            {
                                //Validar que las cajas y pallettes sean consecutivos y sean de la misma orden
                                int id_orden = int.Parse(orden.ReturnValue("select id_orden from tb_Orden where orden = " + orden.Ordenes));

                                int id_modeloOrden = int.Parse(modeloorden.ReturnValue("select TOP 1 id_modeloOrden from tb_ModeloOrden where id_orden = " + id_orden + " and (scanmodem IS NULL OR scansim IS NULL)"));

                                int regreso = int.Parse(modeloorden.ReturnValue("select * from tb_ModeloOrden where Serialnumber = '" + txt_serial.Text.ToUpper() + "' and id_modeloOrden = " + id_modeloOrden));

                                //IF PARA SABER SI YA SE LLENARON TODOS LOS REGISTROS Y GUSRDAR LA FECHA
                                //if (int.Parse(lbl_registrados.Text) < orden.Cantidad)
                                //{
                                //Son para saber si el ultimo registro se lleno
                                //ScanModem = modeloorden.ReturnValue("select scanmodem from tb_ModeloOrden where Serialnumber = (select TOP 1 Serialnumber from tb_ModeloOrden where id_orden = " + id_orden + " order by id_modeloOrden desc)");
                                //ScanSim = modeloorden.ReturnValue("select scansim from tb_ModeloOrden where Serialnumber = (select TOP 1 Serialnumber from tb_ModeloOrden where id_orden = " + id_orden + " order by id_modeloOrden desc)");
                                //IF PARA SABER SI YA SE LLENARON TODOS LOS REGISTROS Y GUSRDAR LA FECHA
                                //if (ScanModem == "0" || ScanSim == "0")
                                //{
                                //IF PARA SABER SI EL SERIAL ES EL QUE SIGUE O EXISTE 
                                if (regreso == 0)
                                {
                                    lbl_serialnumber.Text = "INCORRECTO";
                                    lbl_serialnumber.BackColor = System.Drawing.Color.Red;
                                    MessageBox.Show("No se encontro el SERIAL o no coiciden");
                                    txt_serial.Focus();
                                }
                                else
                                {
                                    //IF PARA SABER QUE EL MODEM NO ESTA REPETIDO
                                    if (!(modeloorden.Existe("select COUNT(*) from tb_ModeloOrden where scanmodem = '" + txt_imei.Text + "'")))
                                    {
                                        //IF PARA SABER QUE LA SIM NUMBER NO ESTA REPETIDO
                                        if (!modeloorden.Existe("select COUNT(*) from tb_ModeloOrden where scansim = '" + txt_sim.Text + "'"))
                                        {
                                            lbl_serialnumber.Text = "CORRECTO";
                                            lbl_serialnumber.BackColor = System.Drawing.Color.Green;

                                            //modeloorden.crud("update tb_ModeloOrden set scanmodem = '" + txt_imei.Text + "', scansim = '" + txt_sim.Text + "' , checked = 1 , fecharegistro = '" + DateTime.Now + "' where id_modeloOrden = (select TOP 1 id_modeloOrden from tb_ModeloOrden where id_orden = " + id_orden + "and (scanmodem IS NULL OR scansim IS NULL))");
                                            modeloorden.Crud("update tb_ModeloOrden set scanmodem = '" + txt_imei.Text + "', scansim = '" + txt_sim.Text + "' , fecharegistro = '" + DateTime.Now + "' where id_modeloOrden = (select TOP 1 id_modeloOrden from tb_ModeloOrden where id_orden = " + id_orden + " and (scanmodem IS NULL OR scansim IS NULL))");

                                            txt_imei.Text = "";
                                            txt_serial.Text = "";
                                            txt_sim.Text = "";

                                            txt_imei.Focus();
                                        }
                                        else
                                        {
                                            //select serialNumber from tb_ModeloOrden where scanmodem = 
                                            string SIMdupiclada = modeloorden.ReturnValue("select serialNumber from tb_ModeloOrden where scansim = '" + txt_sim.Text + "'");
                                            MessageBox.Show("El Sim Number ya existe\nEl cual pertenece al Serial " + SIMdupiclada);
                                            txt_sim.Text = "";
                                            txt_sim.Focus();
                                        }
                                    }
                                    else
                                    {
                                        string IMEIdupiclada = modeloorden.ReturnValue("select serialNumber from tb_ModeloOrden where scanmodem = '" + txt_imei.Text + "'");
                                        MessageBox.Show("El Modem/IMEI Number ya existe\nEl cual pertenece al Serial " + IMEIdupiclada);
                                        txt_imei.Text = "";
                                        txt_imei.Focus();
                                    }
                                }
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Orden Completada!");
                                //    orden.Crud("update tb_Orden set fechacierre = '" + DateTime.Now + "' where id_orden = " + id_orden);
                                //    this.Close();
                                //}
                                Ensamble_Etiquetado_Load(sender, e);
                                //}
                                //else
                                //{
                                //    MessageBox.Show("El IMIE debe de ser de 36 caracteres");
                                //    txt_imei.Focus();
                                //}
                            }
                            else
                            {
                                MessageBox.Show("El SIM debe de contener " + sim.Digitos + " caracteres");
                                txt_sim.Focus();
                            }
                        }
                        else
                        {
                            //MessageBox.Show("No dejes ningun campo vacio!", "ERROR!");
                            MessageBox.Show("El IMEI Number debe de ser de 15 caracteres antes del punto y coma.", "ERROR!");
                            txt_imei.Focus();
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No dejes ningun campo vacio!", "ERROR!");
                        MessageBox.Show("El IMEI Number debe de ser de 36 caracteres", "ERROR!");
                        txt_imei.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No dejes ningun campo vacio!", "ERROR!");
                    //MessageBox.Show("Orden completada!");
                    //orden.Crud("update tb_Orden set fechacierre = '" + DateTime.Now + "' where id_orden = " + orden.Id_orden);
                    ////this.Close();
                }
            }
            else
            {
                MessageBox.Show("Orden completada!");
                orden.Crud("update tb_Orden set fechacierre = '" + DateTime.Now + "' where id_orden = " + orden.Id_orden);
                //this.Close();
            }
        }

        private void Txt_imei_TextChanged_1(object sender, EventArgs e)
        {
            contadorIMEI = txt_imei.Text.Length;
            lbl_imei.Text = contadorIMEI.ToString();
        }

        private void Txt_sim_TextChanged(object sender, EventArgs e)
        {
            contadorSIM = txt_sim.Text.Length;
            lbl_sim.Text = contadorSIM.ToString();
        }

        private void Button1_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void DisableControls()
        {
            dataGridView1.Enabled = false;
            txt_imei.Enabled = false;
            txt_serial.Enabled = false;
            txt_sim.Enabled = false;
            button1.Enabled = false;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            //row.Index = dataGridView1_RowsAdded();
            //if (dataGridView1.Rows[row.Index].Cells[6].Value.ToString() == "")
            //    break;

            //dataGridView1.Rows[row.Index].Cells[6].Style.BackColor = Color.Purple;
            //dataGridView1.Rows[row.Index].Cells[6].Style.ForeColor = Color.White;
            //this.dataGridView1[e.RowIndex].Selected = true;
        }
        /// <summary>
        /// Metodo para verificar que el IMEI que hay 15 digitos antes del punto y coma.
        /// </summary>
        private string ImeiCorrect()
        {
            string imei15 = "";
            string[] imei = txt_imei.Text.Split(';');
            foreach (var item in imei)
            {
                imei15 = item.ToString();
                break;
            }

            return imei15;
        }
    }
}