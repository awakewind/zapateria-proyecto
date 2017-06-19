using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zapateria_interfazweb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                serviciozapateriaw.zapateriawsSoapClient  ws = new serviciozapateriaw.zapateriawsSoapClient();
                String usuario  = this.txtUsuario .Text.Trim();
                String contraseña  = this.txtContraseña .Text.Trim();

                serviciozapateriaw .usuarios  usuario2   = ws.login(usuario , contraseña );

                if (usuario != null)
                {
                    this.Session["usuario"] = usuario;
                    this.Response.Redirect("/Default.aspx");
                }
                else
                {
                    this.Response.Redirect("/Login.aspx");
                }

            }
        }
    }
}