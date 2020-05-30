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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        decimal precioTotal;
        int cantidad;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session[Session.SessionID + "ArtCarrito"] != null)
            {
                foreach (var item in (List<ArticulosEnCarrito>)Session[Session.SessionID + "ArtCarrito"])
                {
                    precioTotal +=  Convert.ToDecimal(item.precio)*Convert.ToDecimal(item.cantidad);

                    cantidad = cantidad + item.cantidad;

                  
                }

                lblPrecio.Text = "$" + precioTotal.ToString("G29");
                lblcant.Text = "cant: " + cantidad;
            }
            else {
                lblPrecio.Text = "$0";
                lblcant.Text = "cant: 0";
            }

            
        }
    }
}