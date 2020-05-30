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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            NegocioArticulo Negocio = new NegocioArticulo();
            Articulo articulo = new Articulo();
            try
            {
                textBox2.Text = "";
                //dataGridView1.Show();

                //dataGridView2.Hide();
                articulo.codigo = textBox1.Text;
                Negocio.BuscarPorArticulo(articulo);

                datagridview_clear(dataGridView1);
                dataGridView1.Rows.Add(articulo.codigo, articulo.nombre, articulo.descripcion, articulo.Marca.Id, articulo.Categoria.Id, articulo.imagen, articulo.precio);


            }
            catch (Exception ex)
            {

                MessageBox.Show("El codigo ingresado es inexistente.", "Aviso");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            NegocioArticulo Negocio = new NegocioArticulo();
            List<Articulo> lista;
            Articulo articulo = new Articulo();
            Articulo articulo2 = new Articulo();
            string descripcion;
            textBox1.Text = "";
            //dataGridView2.Show();
            //dataGridView1.Hide();
            try
            {
                descripcion = textBox2.Text;
                lista = Negocio.listarPorDescripcion(descripcion);
                comboBox1.DataSource = lista;

                datagridview_clear(dataGridView1);



                foreach (Articulo item in lista)
                {
                    articulo2 = new Articulo();
                    articulo2.codigo = item.codigo;
                    Negocio.BuscarPorArticulo(articulo2);



                    dataGridView1.Rows.Add(articulo2.codigo, articulo2.nombre, articulo2.descripcion, articulo2.Marca.Id, articulo2.Categoria.Id, articulo2.imagen, articulo2.precio);



                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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


   

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion;
            string descripcion;
            descripcion = textBox2.Text;
            List<Articulo> listado = new List<Articulo>();
            Articulo articulo2 = new Articulo();
            NegocioArticulo negocio = new NegocioArticulo();
            seleccion = Convert.ToString(comboBox1.SelectedItem);
            listado = negocio.listarPorDescripcion(descripcion);
            datagridview_clear(dataGridView1);


            foreach (Articulo item in listado)
            {

                articulo2.codigo = item.codigo;
                negocio.BuscarPorArticulo(articulo2);


                if (seleccion == articulo2.nombre)
                {

                    dataGridView1.Rows.Add(articulo2.codigo, articulo2.nombre, articulo2.descripcion, articulo2.Marca.Id, articulo2.Categoria.Id, articulo2.imagen, articulo2.precio);
                }

            }



        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
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
