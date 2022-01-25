using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace CrearEtiquetas
{
    public partial class Form1 : Form
    {
        Conexion con = new Conexion();
        ModeloOrden modeloorden = new ModeloOrden();
        Orden orden = new Orden();
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_generar_Click(object sender, EventArgs e)
        {
            double VerificarOrden = orden.Ordenes;
            int id_orden = int.Parse(orden.ReturnValue("select id_orden from tb_Orden where orden= " + VerificarOrden));
            int comprobardb = 0;
            comprobardb = int.Parse(modeloorden.ReturnValue("select id_modeloOrden from tb_ModeloOrden where Serialnumber = '" + txt_serial.Text + "' and id_orden = " + id_orden));
            String comprobarPrueba = orden.ReturnValue("select TOP 1 p.Nbr from tb_ModeloOrden mo right join tb_Test p on mo.Serialnumber = p.SerNum where Serialnumber = '" + txt_serial.Text + "' order by id_prueba desc");


            try
            {
                //if ((con.Existe("select COUNT(*) from tb_ModeloOrden where Serialnumber = '" + txt_serial.Text + "' and id_orden = " + id_orden)))
                //{
                    if (comprobarPrueba == "PASO")
                    {
                        lbl_prueba.Text = "PASS";
                        lbl_prueba.ForeColor = Color.Green;

                        if (comprobardb > 0)
                        {
                            System.Drawing.Image imagen1 = CrearEtiquetas.Properties.Resources.logo2;
                            // instantiate a writer object
                            var barcodeWriter = new BarcodeWriter();

                            // set the barcode format
                            barcodeWriter.Format = BarcodeFormat.CODE_128;

                            // write text and generate a 2-D barcode as a bitmap
                            //pictureBox1.Image = imagen1;
                            pictureBox1.Image = barcodeWriter.Write(txt_serial.Text);
                            
                            pictureBox1.BorderStyle = BorderStyle.None;

                        }

                        else
                        {
                            MessageBox.Show("No se encuentro ese Serial Number!");
                        }
                        txt_serial.Text = "";
                    }
                    else
                    {

                        lbl_prueba.Text = "FAIL";
                        lbl_prueba.ForeColor = Color.Red;
                        MessageBox.Show("No paso la prueba!");
                    }

                //}
                //else { MessageBox.Show("No existe en la orden actual!"); }

            }
            catch (Exception)
            {

                MessageBox.Show("Comprube que todo los datos sean correctos!", "Error!");
            }


            //// instantiate a writer object
            //var barcodeWriter = new BarcodeWriter();

            //// set the barcode format
            //barcodeWriter.Format = BarcodeFormat.CODE_128;

            //// write text and generate a 2-D barcode as a bitmap
            //pictureBox1.Image = barcodeWriter.Write(txt_serial.Text);
            //pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Title = "Save Dialog";
                //save.Filter = "Bitmap Images (*.bmp)|*.bmp|All files(*.*)|*.*";
                //save.Filter = "Images (*.bmp)|*.bmp;*.png;*.jpg";
                save.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files(*.gif) | *.gif | All files(*.*) | *.* ";
                save.FilterIndex = 4;
                save.RestoreDirectory = true;
                if (save.ShowDialog(this) == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height))
                    {
                        pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height ));
                        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bmp.Save(save.FileName);

                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_orden.Text = orden.Ordenes.ToString();

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Mantenimiento manto = new Mantenimiento();
            manto.Show();
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(bm,0,0);
            bm.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
