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
    public partial class VerCarrito : System.Web.UI.Page
    {
       public decimal precioTotal;
        int cantidad;

        protected void Page_Load(object sender, EventArgs e)
        {

        
                if (Session[Session.SessionID + "ArtCarrito"] != null)
                {
                    foreach (var item in (List<ArticulosEnCarrito>)Session[Session.SessionID + "ArtCarrito"])
                    {
                        precioTotal += Convert.ToDecimal(item.precio) * Convert.ToDecimal(item.cantidad);

                        cantidad = cantidad + item.cantidad;


                    }

                    lblPrecio.Text = "$" + precioTotal.ToString("G29");
                    lblcant.Text = "cant: " + cantidad;
                }
                else
                {
                    lblPrecio.Text = "$0";
                    lblcant.Text = "cant: 0";
                }


                GridCarrito.DataSource = Session[Session.SessionID + "ArtCarrito"];
                GridCarrito.DataBind();

                if (GridCarrito.Rows.Count == 0)
                {
                    btnComprar.Text = "NO HAY ARTICULOS PARA COMPRAR";
                }
                else
                {
                    btnComprar.Text = "COMPRAR " + lblPrecio.Text;
                }
           
          
        }

        protected void btActulizar_Click(object sender, EventArgs e)
        {
            List<ArticulosEnCarrito> ListaCarrito = new List<ArticulosEnCarrito>();
                Session.Add(Session.SessionID + "ArtCarrito", ListaCarrito);
                Response.Redirect("VerCarrito.aspx");
        }

        protected void btnAddArt_Click(object sender, EventArgs e)
        {

            //Your Code Here

        }

        protected void GridCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
                List<ArticulosEnCarrito> ListaCarrito = new List<ArticulosEnCarrito>();
                int index = Convert.ToInt32(e.CommandArgument);
                string itemCarrito = GridCarrito.Rows[index].Cells[1].Text;

                ListaCarrito = (List<ArticulosEnCarrito>)Session[Session.SessionID + "ArtCarrito"];

                foreach (var item in ListaCarrito)
                {
                    if (item.Nombre == itemCarrito)
                    {
                        if (item.cantidad == 1)
                        {
                            ListaCarrito.Remove(item);
                            Session.Add(Session.SessionID + "ArtCarrito", ListaCarrito);
                            Response.Redirect("VerCarrito.aspx");
                        }
                        else
                        {
                            if (item.cantidad > 1)
                            {
                                item.cantidad--;
                                Response.Redirect("VerCarrito.aspx");
                            }
                            else
                            {
                                ListaCarrito.Remove(item);
                                Session.Add(Session.SessionID + "ArtCarrito", ListaCarrito);
                                Response.Redirect("VerCarrito.aspx");

                            }
                        }
                    }
                }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            if (btnComprar.Text != "NO HAY ARTICULOS PARA COMPRAR") {
                Session.Add("Error", "Disculpe, en este momento el canal de pago no esta disponible, vuelva a intentar.");
                Response.Redirect("Error.aspx");
            }
        }
    }
}