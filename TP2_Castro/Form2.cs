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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            Cargar_Art();


        }
        private void Cargar_Art()
        {
            NegocioArticulo Negocio = new NegocioArticulo();
            List<Articulo> lista;

            try
            {
                lista = Negocio.listar();
                dgvListaArticulos.DataSource = lista;
                OrdenarColumnas();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }


        private void OrdenarColumnas()
        {

            dgvListaArticulos.Columns["Codigo"].DisplayIndex = 0;
            dgvListaArticulos.Columns["nombre"].DisplayIndex = 1;
            dgvListaArticulos.Columns["Descripcion"].DisplayIndex = 2;
            dgvListaArticulos.Columns["Marca"].DisplayIndex = 3;
            dgvListaArticulos.Columns["Precio"].DisplayIndex = 5;

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void DgvListaArticulos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }

}
