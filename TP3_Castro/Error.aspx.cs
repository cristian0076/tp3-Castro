using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Castro
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Error"] != null)
            {
                lblError.Text = Session["Error"].ToString();
            }
        }

        protected void btnError_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}