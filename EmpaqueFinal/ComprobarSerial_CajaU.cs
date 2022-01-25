using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpaqueFinal
{
    public partial class ComprobarSerial_CajaU : Form
    {
        readonly ModeloOrden modeloorden = new ModeloOrden();
        readonly Orden orden = new Orden();
        readonly Conexion con = new Conexion();

        //private readonly DataTable dt = new DataTable();
        readonly System.Drawing.Image imagen1 = EmpaqueFinal.Properties.Resources.great;
        readonly System.Drawing.Image imagen2 = EmpaqueFinal.Properties.Resources.bad;

        public ComprobarSerial_CajaU()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            int comprobardb = 0;
            int existeSerial = 0;

            double VerificarOrden = orden.Ordenes;

            int id_orden = int.Parse(orden.ReturnValue("select id_orden from tb_Orden where orden= " + VerificarOrden));

            String comprobarPrueba = orden.ReturnValue("select TOP 1 p.Nbr from tb_ModeloOrden mo right join tb_Test p on mo.Serialnumber = p.SerNum where Serialnumber = '" + txt_serial.Text + "'");

            comprobardb = int.Parse(modeloorden.ReturnValue("select id_modeloOrden from tb_ModeloOrden where Serialnumber = '" + txt_serial.Text + "' and id_orden = " + id_orden));

            int TotalComprobar = int.Parse(orden.ReturnValue("select (c1.Total - c2.TotalCheck) as Result from (select count(id_modeloOrden) as Total from tb_ModeloOrden where id_orden = " + id_orden + ") as c1, (select count(checked) as TotalCheck from tb_ModeloOrden where id_orden = " + id_orden + ") as c2"));
            //VJ300237380
            existeSerial = int.Parse(modeloorden.ReturnValue("select count(*) from tb_Test t where SerNum = '" + txt_serial.Text + "'"));

            try
            {
                if ((con.Existe("select COUNT(*) from tb_ModeloOrden where Serialnumber = '" + txt_serial.Text + "' and id_orden = " + id_orden)))
                {
                    if (TotalComprobar > 0)
                    {
                        if (comprobarPrueba == "PASO" || existeSerial == 0)
                        {
                            lbl_prueba.Text = comprobarPrueba;
                            orden.Crud("update tb_modeloOrden set checked = 1 where Serialnumber = '" + txt_serial.Text + "' and id_orden = " + id_orden);
                            ComprobarSerial_CajaU_Load(sender, e);

                            if (comprobardb > 0)
                            {
                                if (txt_serial.Text == txt_caja.Text)
                                {
                                    pictureBox1.Image = imagen1;
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                                else
                                {
                                    pictureBox1.Image = imagen2;
                                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encuentro ese Serial Number!");
                            }
                            txt_caja.Text = "";
                            txt_serial.Text = "";
                        }
                        else
                        {

                            lbl_prueba.Text = comprobarPrueba;
                            lbl_prueba.BackColor = Color.Red;
                            MessageBox.Show("No paso la prueba!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se han comprobado todos las cajas!");
                    }
                }
                else { MessageBox.Show("No existe en la orden actual!"); }

            }
            catch (Exception EX)
            {

                //MessageBox.Show("Comprube que todo los datos sean correctos!", "Error!");
                MessageBox.Show(EX.ToString(), "Error!");
            }


        }

        private void ComprobarSerial_CajaU_Load(object sender, EventArgs e)
        {
            lbl_orden1.Text = orden.Ordenes.ToString();
            lbl_orden2.Text = orden.Ordenes.ToString();

            int id_orden = int.Parse(orden.ReturnValue("select id_orden from tb_Orden where orden= " + orden.Ordenes));

            try
            {
                dataGridView1.DataSource = modeloorden.LlenarDG("select mo.scanmodem, mo.scansim, mo.Serialnumber, mo.checked from tb_modeloOrden mo where id_Orden = " + id_orden).Tables[0];
                dataGridView2.DataSource = modeloorden.LlenarDG("select c.caja, mo.Serialnumber from tb_ModeloOrden mo, tb_caja c where mo.id_caja = c.id_caja and checked = 1 and id_orden = " + id_orden).Tables[0];
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.Columns["Caja"].DefaultCellStyle.BackColor = Color.AliceBlue;

                if (!modeloorden.Existe("select * from tb_CajaVerificar where id_orden = " + id_orden))
                    modeloorden.Crud("insert into tb_CajaVerificar(id_caja, id_orden, serialnumberComprobar) select c.id_caja, mo.id_orden, mo.Serialnumber from tb_ModeloOrden mo, tb_caja c where mo.id_caja = c.id_caja and id_orden = " + id_orden);

                dg_Validador.DataSource = modeloorden.LlenarDG("select c.caja, mo.serialnumber AS Serial from tb_CajaVerificar mo, tb_caja c where mo.id_caja = c.id_caja and id_orden = " + id_orden).Tables[0];
                dg_Validador.AutoGenerateColumns = false;
                dg_Validador.Columns["Caja"].DefaultCellStyle.BackColor = Color.AliceBlue;

            }
            catch (Exception)
            {throw;}

            lbl_count1.Text = con.ReturnValue("select COUNT(*) from tb_ModeloOrden where Serialnumber is not null and checked = 1 and id_orden = " + id_orden);
            lbl_count2.Text = con.ReturnValue("select COUNT(*) from tb_CajaVerificar where serialnumber is not null and id_orden = " + id_orden);

        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dataGridView2[column, row];
            DataGridViewCell cell2 = dataGridView2[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();

        }

        bool IsTheSameCellValue2(int column, int row)
        {
            DataGridViewCell cell1 = dg_Validador[column, row];
            DataGridViewCell cell2 = dg_Validador[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();

        }


        private void ComprobarSerial_CajaU_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dataGridView2.AdvancedCellBorderStyle.Top;
            }
        }

        private void DataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void Dg_Validador_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue2(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dg_Validador.AdvancedCellBorderStyle.Top;
            }
        }

        private void Dg_Validador_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue2(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void Btn_validar_Click(object sender, EventArgs e)
        {
            string searchValue = txt_validar.Text;
            int rows = dg_Validador.Rows.Count - 1;
            int current = 0;
            int currentrow = dg_Validador.Rows[rows].Cells.Count + 1;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            int ExisteSerial = int.Parse(modeloorden.ReturnValue("select COUNT(*) from tb_ModeloOrden where Serialnumber = '" + txt_validar.Text + "' and checked is null"));
            if (ExisteSerial == 0)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Equals(searchValue))
                        {
                            row.Selected = true;
                            current = row.Cells.Count;
                            currentrow = row.Index;
                            break;
                        }
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

            try
            {

                if (ExisteSerial == 0)
                {
                    string SerialInserted = dataGridView2.Rows[dg_Validador.Rows[rows].Cells.Count + 1].Cells[current - 1].Value.ToString();
                    modeloorden.Crud("update tb_CajaVerificar set serialnumber = '" + txt_validar.Text + "' where serialnumberComprobar = '" + SerialInserted + "'");
                    ComprobarSerial_CajaU_Load(sender, e);
                    dg_Validador.Rows[current + 1].Cells[current - 1].Selected = true;
                    dataGridView2.Rows[current + 1].Cells[current - 1].Selected = true;
                    pictureBox2.Image = imagen1;
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("No se encontro el Serial Number: " + txt_validar.Text, "ERROR!");
                    pictureBox2.Image = imagen2;
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Btn_aceptar_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

        private void Btn_validar_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
        }

    }
}
