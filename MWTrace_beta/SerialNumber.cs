using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MWTrace_beta
{
    public partial class SerialNumber : Form
    {
        private readonly Conexion con = new Conexion();
        private readonly Orden orden = new Orden();

        public SerialNumber()
        {
            InitializeComponent();
        }

        public static Form IsFormAlreadyOpen(Type formType)
        {
            return Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.GetType() == formType);
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                orden.Ordenes = Convert.ToDouble(txt_serial.Text);
                if (txt_serial.Text == "")
                    throw new Exception();

                SqlCommand cmd = new SqlCommand("select orden from tb_Orden where orden = " + orden.Ordenes, con.Con1);
                con.Abrir();
                cmd.ExecuteNonQuery();
                double regreso = Convert.ToDouble(cmd.ExecuteScalar());
                if (regreso > 0)
                {
                    //this.Close();
                    //Ensamble_Etiquetado ee = new Ensamble_Etiquetado();
                    Identificar_Operador io = new Identificar_Operador();

                    Form Next;

                    if ((Next = IsFormAlreadyOpen(typeof(Reportes))) == null)
                    {
                        io.ShowDialog(this);
                        this.Close();
                    }

                    else
                    {
                        Next.WindowState = FormWindowState.Normal;
                        Next.BringToFront();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro");
                    txt_serial.Text = "";
                }

                con.Cerrar();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No existe ese registro", "ERROR!");
                con.Cerrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Inserte una orden");
            }

        }

        private void SerialNumber_Load(object sender, EventArgs e)
        {
            ActiveControl = txt_serial;
            txt_serial.Focus();
        }

        private void Txt_serial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_aceptar_Click(this, new EventArgs());
            }
        }
    }
}
