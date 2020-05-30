using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using System.Globalization;
using System.Runtime.InteropServices;


namespace TP2_Castro
{



    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
          
    }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public string codigo_s;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string seleccion1;
            seleccion1 = Convert.ToString(comboBox1.SelectedIndex);

            if (seleccion1 == "0")
            {
                MessageBox.Show("El id no es un campo modificable.", "Aviso");
            }


        }

        private void Form5_Load(object sender, EventArgs e)
        {
           
            //Cargar_Columnas_Articulos();
            comboBox1.Text = "";
            List<Marca> lista = new List<Marca>();
            NegocioMarca negocio = new NegocioMarca();
            Marca marca = new Marca();
            lista = negocio.listar();
            
            List<Categoria> lista2 = new List<Categoria>();
            NegocioCategoria negocio2 = new NegocioCategoria();
            Categoria categoria = new Categoria();
            lista2 = negocio2.listar();
            Articulo articulo = new Articulo();
            NegocioArticulo negocio3 = new NegocioArticulo();
           

           
            foreach (Categoria item in lista2)
            {

                comboBox2.Items.Add(item.Descripcion);
            }


            foreach (Marca item in lista)
            {

                comboBox3.Items.Add(item.Descripcion);
            }


        }


        private void Cargar_Columnas_Articulos()
        {


            try
            {


                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection("data source=DESKTOP-C6O1D33\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi"))
                {
                    string query = "SELECT column_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='Articulos'";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }

             
                    
               comboBox1.ValueMember = "column_NAME";



                comboBox1.DataSource = dt;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void Button3_Click(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();
            Articulo articulo = new Articulo();
            new Categoria();
            new Marca();

            string seleccion1;
            seleccion1 = Convert.ToString(comboBox3.SelectedItem);
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
                NumberFormatInfo format = new NumberFormatInfo() { NumberDecimalSeparator = "," };
                articulo.precio = Convert.ToDecimal(textBox4.Text, format);

                negocio.ModificarArticulo(articulo, textBox6.Text);


                MessageBox.Show("El articulo se modifico correctamente", "Aviso");
                Cargar_Modificado(textBox1.Text);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
            
        }

 

        private void Button4_Click(object sender, EventArgs e)
        {

            NegocioArticulo Negocio1 = new NegocioArticulo();
            Articulo articulo = new Articulo();
            new Categoria();
            new Marca();
            try
            {
                
                //dataGridView1.Show();

                //dataGridView2.Hide();
                articulo.codigo = textBox6.Text;
                Negocio1.BuscarPorArticulo(articulo);

                datagridview_clear(dataGridView1);
                dataGridView1.Rows.Add(articulo.codigo, articulo.nombre, articulo.descripcion, articulo.Marca.Id, articulo.Categoria.Id, articulo.imagen, articulo.precio);
                textBox1.Text = articulo.codigo;
                textBox2.Text = articulo.nombre;
                textBox3.Text = articulo.descripcion;
                textBox4.Text = articulo.precio.ToString();
                textBox5.Text = articulo.imagen;
                comboBox3.SelectedIndex = articulo.Marca.Id-1;
                comboBox2.SelectedIndex = articulo.Categoria.Id-1;
                textBox6.Enabled = false;



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

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
      

        }

        private void ComboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Cargar_Modificado(string codigo)
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
              
            }
            catch (Exception ex)
            {

                MessageBox.Show("El codigo ingresado es inexistente.", "Aviso");
            }



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

        private void OpenFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
