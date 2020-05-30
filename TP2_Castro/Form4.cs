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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void Form4_Load(object sender, EventArgs e)
        {



            List<Marca> lista = new List<Marca>();
            NegocioMarca negocio = new NegocioMarca();
            Marca marca = new Marca();
            lista = negocio.listar();

            List<Categoria> lista2 = new List<Categoria>();
            NegocioCategoria negocio2 = new NegocioCategoria();
            Categoria categoria = new Categoria();
            lista2 = negocio2.listar();


            foreach (Categoria item in lista2)
            {

                comboBox2.Items.Add(item.Descripcion);
            }


            foreach (Marca item in lista)
            {

                comboBox1.Items.Add(item.Descripcion);
            }



        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)

        {


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagenes | *.png;*.jpg;*.bmp;*.ico";

            string nombre;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nombre = openFileDialog1.FileName;
                textBox5.Text = nombre;
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();
            Articulo articulo = new Articulo();
            new Categoria();
            new Marca();

            string seleccion1;
            seleccion1 = Convert.ToString(comboBox1.SelectedItem);
            string seleccion2;
            seleccion2 = Convert.ToString(comboBox2.SelectedItem);
            int idmarca;
            int idCategoria;

            if (textBox1.Text == "")
            {
                MessageBox.Show("ingrese un codigo", "Aviso");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("ingrese un nombre", "Aviso");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("ingrese una descripcion", "Aviso");
                return;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("ingrese un precio", "Aviso");
                return;
            }

            if (seleccion1 == "")
            {
                MessageBox.Show("Seleccione una marca", "Aviso");
                return;
            }

            if (seleccion2 == "")
            {
                MessageBox.Show("Seleccione una categoria", "Aviso");
                return;
            }

            try
            {

                List<Marca> lista = new List<Marca>();
                NegocioMarca Negocio = new NegocioMarca();
                Marca marca = new Marca();
                lista = Negocio.listar();

                List<Categoria> lista2 = new List<Categoria>();
                NegocioCategoria negocio2 = new NegocioCategoria();
                Categoria categoria = new Categoria();
                lista2 = negocio2.listar();


                foreach (Categoria item in lista2)
                {

                    if (seleccion2 == item.Descripcion)
                    {
                        idCategoria = item.Id;
                        articulo.Categoria = new Categoria();
                        articulo.Categoria.Id = idCategoria;
                    }

                }


                foreach (Marca item in lista)
                {

                    if (seleccion1 == item.Descripcion)
                    {
                        idmarca = item.Id;
                        articulo.Marca = new Marca();

                        articulo.Marca.Id = idmarca;
                    }
                }



                articulo.codigo = textBox1.Text;
                articulo.nombre = textBox2.Text;
                articulo.descripcion = textBox3.Text;
                articulo.imagen = textBox5.Text;
                articulo.precio = Convert.ToDecimal(textBox4.Text);


                negocio.agregar(articulo);

                MessageBox.Show("El articulo se agrego correctamente", "Aviso");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
