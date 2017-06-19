using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zapateria_interfazweb.forms.clientes
{
    public partial class AddCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveFormData(object sender, EventArgs e)
        {
            serviciozapateriaw.zapateriawsSoapClient appService = new serviciozapateriaw.zapateriawsSoapClient();

            int transactionResult = appService.agregarCliente(
                this.txbx_nombreCliente.Text,
                this.txbx_apellidoCliente.Text,
                this.txbx_telefonoCliente.Text,
                this.txbx_direccionCliente.Text
            );

            if (transactionResult == 1)
            {
                string targetUrl = Request.Url.GetLeftPart(UriPartial.Path);
                Response.Redirect(targetUrl + "?response=DataAdded");
            }
            else
            {
                string targetUrl = Request.Url.GetLeftPart(UriPartial.Path);
                Response.Redirect(targetUrl + "?response=Error");
            }
        }
    }
}