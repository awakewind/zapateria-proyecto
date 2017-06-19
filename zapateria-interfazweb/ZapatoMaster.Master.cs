using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zapateria_interfazweb
{
    public partial class ZapatoMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.Session["usuario"] == null)
            //{
            //    this.Response.Redirect("/Login.aspx");
            //}

            //serviciozapateriaw .usuarios  ua = (serviciozapateriaw.usuarios )this.Session["usuario"];
            //this.lblUsuario.Text = "Bienvenido: " + ua.Usuario;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            this.Session["usuario"] = null;
            this.Response.Redirect("/Default.aspx");
        }
    }
}