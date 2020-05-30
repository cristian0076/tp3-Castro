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
    public partial class Index : System.Web.UI.Page
    {
       
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
            NegocioArticulo negocio = new NegocioArticulo();
            ListaArticulos = negocio.listar();

            List<Marca> lista = new List<Marca>();
            NegocioMarca negocio3 = new NegocioMarca();
            Marca marca = new Marca();
            lista = negocio3.listar();

            List<Categoria> lista2 = new List<Categoria>();
            NegocioCategoria negocio2 = new NegocioCategoria();
            Categoria categoria = new Categoria();
            lista2 = negocio2.listar();

            if (!Page.IsPostBack)
            {

                foreach (Categoria item in lista2)
                {

                    cboCategoria.Items.Add(item.Descripcion);
                }


                foreach (Marca item in lista)
                {

                    cboMarca.Items.Add(item.Descripcion);
                }
            }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion1;
            string seleccion2;
            seleccion1 = Convert.ToString(cboMarca.SelectedItem);
            seleccion2 = Convert.ToString(cboCategoria.SelectedItem);
            ListaArticulos = ListaArticulos.FindAll(J => J.Marca.Descripcion == seleccion1 && J.Categoria.Descripcion == seleccion2 );

        }

        protected void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion1;
            string seleccion2;
            seleccion1 = Convert.ToString(cboMarca.SelectedItem);
            seleccion2 = Convert.ToString(cboCategoria.SelectedItem);
            ListaArticulos = ListaArticulos.FindAll(J => J.Marca.Descripcion == seleccion1 && J.Categoria.Descripcion == seleccion2);
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}