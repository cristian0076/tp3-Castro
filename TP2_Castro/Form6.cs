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
    public partial class Form6 : Form
    {
        public Form6()
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

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void Cargar_articulo(string codigo)
        {

            NegocioArticulo Negocio1 = new NegocioArticulo();
            Articulo articulo = new Articulo();
            new Categoria();
            new Marca();
            try
            {

                //dataGridView1.Show();

                //dataGridView2.Hide();
                articulo.codigo = codigo;
                Negocio1.BuscarPorArticulo(articulo);

                datagridview_clear(dataGridView1);
                dataGridView1.Rows.Add(articulo.codigo, articulo.nombre, articulo.descripcion, articulo.Marca.Id, articulo.Categoria.Id, articulo.imagen, articulo.precio);
                dataGridView1.Visible = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("El codigo ingresado es inexistente.", "Aviso");
            }




        }


        private void datagridview_clear(DataGridView grilla)
        {
            if (grilla.Rows.Count - 1 > 0)
            {
                for (int i = grilla.Rows.Count - 2; i >= 0; i--)
                {
                    grilla.Rows.RemoveAt(i);
                }
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Cargar_articulo(textBox6.Text);
            dataGridView1.Visible = true;
            textBox6.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();
            Articulo articulo = new Articulo();
            try
            {

                articulo.codigo = textBox6.Text;
                negocio.EliminarArticulo(articulo);
                MessageBox.Show("El articulo con codigo " + textBox6.Text + " Se elimino correctamente");
                textBox6.Enabled = true;
                dataGridView1.Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
       
        }

        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
