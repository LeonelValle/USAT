using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrearEtiquetas
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {

        }

        private void Btn_cargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            string lokasi = file.InitialDirectory;
            lokasi = @"C:\Users\leonel.valle\Desktop";
            file.Title = "Open Image File";
            file.Filter = "Image Files(*.jpg,*.png,*.tiff,*.bmp,*.gif,*.fmt)|*.jpg;*.png;*.tiff;*.bmp;*.gif;*.fmt" ;
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(file.FileName);
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }
    }
}
