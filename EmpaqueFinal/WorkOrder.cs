using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpaqueFinal
{
    public partial class WorkOrder : Form
    {
        Orden orden = new Orden();
        public WorkOrder()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {

            try
            {
                orden.Ordenes = Convert.ToDouble(txt_orden.Text);
                if (txt_orden.Text == "")
                    throw new Exception();

                double regreso = double.Parse(orden.ReturnValue("select orden from tb_Orden where orden = " + orden.Ordenes));
                if (regreso > 0)
                {
                    ComprobarSerial_CajaU f1 = new ComprobarSerial_CajaU();
                    //Application.Run(f1);
                    this.Hide();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("No se encontro");
                    txt_orden.Text = "";
                }

                orden.Cerrar();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No existe ese registro", "ERROR!");
                //orden.Cerrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Inserte una orden");
            }
        }

        private void WorkOrder_Load(object sender, EventArgs e)
        {
            Application.Run(new ComprobarSerial_CajaU());
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Mantenimiento manto = new Mantenimiento();
            manto.Show();
        }
    }
}
