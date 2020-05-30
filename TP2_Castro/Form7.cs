using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;
using Negocio;

namespace TP2_Castro
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public string ubicacion;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            List<Articulo> lista = new List<Articulo>();
            NegocioArticulo negocio = new NegocioArticulo();
            Marca marca = new Marca();
            lista = negocio.ArticuloDetalle();

         

            foreach (Articulo item in lista)
            {
               
                dataGridView1.Rows.Add(item.codigo, item.nombre, item.descripcion, item.Marca.Descripcion, item.Categoria.Descripcion,  item.precio, item.imagen);

            }


           





        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (ubicacion == "")
            {
                MessageBox.Show("Debe seleccionar un Articulo de la grilla que contenga una imagen","Aviso");
                return;
            }
            try
            {
                pictureBox1.ImageLocation = ubicacion;
                pictureBox1.Load(ubicacion);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
               
            }
            
        }

        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form previewForm = new Form()
            {
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.None
            };
            PictureBox picture = new PictureBox()
            {
                Image = pictureBox1.Image,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            picture.Click += picture_Click;
            previewForm.Controls.Add(picture);
            previewForm.ShowDialog();
        }

        private void picture_Click(object sender, EventArgs e)
        {
            ((Control)sender).FindForm().Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ubicacion = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["imagen"].Value.ToString();
        }

        private void Form7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

      

        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
