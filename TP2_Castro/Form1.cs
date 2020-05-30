using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using System.Runtime.InteropServices;

namespace TP2_Castro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        [DllImport("User32.DLL",EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

      



        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Listado de articulos");
            comboBox1.Items.Add("Busqueda de articulos");
            comboBox1.Items.Add("Agregar articulos");
            comboBox1.Items.Add("Modificar articulos");
            comboBox1.Items.Add("Eliminar articulos");
            comboBox1.Items.Add("Ver detalle de articulos");
            this.Visible = true;
            NegocioUsuario negocio = new NegocioUsuario();
            int status;
            status = negocio.Validar();

            if(status == 1)
            {
                comboBox1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                txtuser.Visible = false;
                txtpass.Visible = false;
                btnlogin.Visible = false;
                label1.Visible = false;
                lineShape1.Visible = false;
                lineShape2.Visible = false;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion;
            seleccion = Convert.ToString(comboBox1.SelectedItem);

            if (seleccion == "Listado de articulos")
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
                this.Hide();
            }

            if (seleccion == "Busqueda de articulos")
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }

            if (seleccion == "Agregar articulos")
            {
                Form4 form4 = new Form4();

                form4.Show();
                this.Hide();
            }

            if (seleccion == "Modificar articulos")
            {
                Form5 form5 = new Form5();

                form5.Show();
                this.Hide();
            }

            if (seleccion == "Eliminar articulos")
            {
                Form6 form6 = new Form6();

                form6.Show();
                this.Hide();
            }

            if (seleccion == "Ver detalle de articulos")
            {
                Form7 form7 = new Form7();

                form7.Show();
                this.Hide();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            negocio.status(0);
            Application.Exit();
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            Usuario usuario = new Usuario();

            try
            {

                usuario.User = txtuser.Text;
                usuario.Clave = txtpass.Text;
                int habilitar;
                habilitar = negocio.Ingresar(usuario);


                if (habilitar == 1)
                {
                    negocio.status(1);
                    comboBox1.Visible = true;
                    label3.Visible = true;
                    label2.Visible = true;
                    txtuser.Visible = false;
                    txtpass.Visible = false;
                    btnlogin.Visible = false;
                    label1.Visible = false;
                    lineShape1.Visible = false;
                    lineShape2.Visible = false;
                }

                else
                {
                    MessageBox.Show("Datos incorrectos,Verifique por favor y vuelva a intentar.", "Aviso");
                    label2.Visible = false;
                    label3.Visible = false;
                    comboBox1.Visible = false;
                    txtuser.Visible = true;
                    txtpass.Visible = true;
                    btnlogin.Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        

        private void Txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void Txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void Txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "PASSWORD";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void Txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "PASSWORD")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void Btncerrar_Click(object sender, EventArgs e)
        {
            NegocioUsuario negocio = new NegocioUsuario();
            negocio.status(0);
            Application.Exit();
        }

        private void Btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }

}
