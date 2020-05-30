using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
namespace TP3_Castro
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        public List<ArticulosEnCarrito> ListaCarrito = new List<ArticulosEnCarrito>();


        protected void Page_Load(object sender, EventArgs e)
        {
            NegocioArticulo negocio = new NegocioArticulo();

            List<Articulo> ListaArt;

            try
            {
                ListaArt = negocio.listar();

                var articuloSelect = Request.QueryString["idArt"];

                articulo = ListaArt.Find(J => J.codigo.ToString() == articuloSelect);
            }
         
                 catch (Exception ex)
            {
                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnAddCarrito_Click(object sender, EventArgs e)
        {
            ArticulosEnCarrito ArtCarrito = new ArticulosEnCarrito();
            Boolean flag_existe = false;
            Boolean flag_noPasar = false;


            if (lblNum.Text == "0") { }
            else
            {
                if (Session[Session.SessionID + "ArtCarrito"] != null)
                {

                    ListaCarrito = (List<ArticulosEnCarrito>)Session[Session.SessionID + "ArtCarrito"];
                }
                else
                {

                    ArtCarrito.Nombre = articulo.nombre;
                    ArtCarrito.descripcion = articulo.descripcion;
                    ArtCarrito.precio = articulo.precio.ToString("G29");
                    ArtCarrito.cantidad = Convert.ToInt32(lblNum.Text);
                    ListaCarrito.Add(ArtCarrito);
                    Session.Add(Session.SessionID + "ArtCarrito", ListaCarrito);
                    flag_noPasar = true;
                }

                if(flag_noPasar == false) { 
                foreach (var item in (List<ArticulosEnCarrito>)Session[Session.SessionID + "ArtCarrito"])
                {
                    if (item.Nombre == articulo.nombre)
                    {

                        if (lblNum.Text == "0")
                        {
                            item.cantidad++;
                        }
                        else
                        {

                            item.cantidad = item.cantidad + Convert.ToInt32(lblNum.Text);
                        }


                        flag_existe = true;
                    }
                }

                if (flag_existe == false)
                {

                    ArtCarrito.Nombre = articulo.nombre;
                    ArtCarrito.descripcion = articulo.descripcion;
                    ArtCarrito.precio = articulo.precio.ToString("G29");
                    if (lblNum.Text == "0")
                    {
                        ArtCarrito.cantidad = 1;
                    }
                    else
                    {
                        ArtCarrito.cantidad = Convert.ToInt32(lblNum.Text);
                    }

                    ListaCarrito.Add(ArtCarrito);
                    Session.Add(Session.SessionID + "ArtCarrito", ListaCarrito);
                }
                    }
                Response.Redirect("VerCarrito.aspx");
            }


        }

        protected void btnAddcant_Click(object sender, EventArgs e)
        {
            int num;
           num = Convert.ToInt32(lblNum.Text)+1;
            lblNum.Text = num.ToString();

        }

        protected void btnremovecant(object sender, EventArgs e)
        {
            int num;
            if (lblNum.Text != "0") {
                num = Convert.ToInt32(lblNum.Text) - 1;
                lblNum.Text = num.ToString();
            }
        }
    }
}