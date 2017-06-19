using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zapateria_interfazweb.forms.clientes
{
    public partial class UpdateCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["object_id"] != null)
                {
                    serviciozapateriaw.zapateriawsSoapClient appService = new serviciozapateriaw.zapateriawsSoapClient();

                    int objectId = Convert.ToInt32(Request.QueryString["object_id"]);

                    var singleObjectInstance = appService.gatClientesById(objectId);

                    this.hddn_idCliente.Value = singleObjectInstance.Id_cliente.ToString();
                    this.txbx_nombreCliente.Text = singleObjectInstance.NomCliente1;
                    this.txbx_apellidoCliente.Text = singleObjectInstance.ApeCliente1;
                    this.txbx_telefonoCliente.Text = singleObjectInstance.TelCliente1;
                    this.txbx_direccionCliente.Text = singleObjectInstance.DireccionCliente1;
                }
            }
        }

        protected void updateFormData(object sender, EventArgs e)
        {
            serviciozapateriaw.zapateriawsSoapClient appService = new serviciozapateriaw.zapateriawsSoapClient();

            int transactionResult = appService.updateClientes(
                Convert.ToInt32(hddn_idCliente.Value),
                txbx_nombreCliente.Text,
                txbx_apellidoCliente.Text,
                txbx_telefonoCliente.Text,
                txbx_direccionCliente.Text
            );

            if (transactionResult == 1)
            {
                string targetUrl = Request.Url.GetLeftPart(UriPartial.Path);
                Response.Redirect(targetUrl + "?response=Updated");
            }
            else
            {
                string targetUrl = Request.Url.GetLeftPart(UriPartial.Path);
                Response.Redirect(targetUrl + "?response=Error");
            }
        }


        protected void deleteFormData(object sender, EventArgs e)
        {
            serviciozapateriaw.zapateriawsSoapClient appService = new serviciozapateriaw.zapateriawsSoapClient();

            int transactionResult = appService.deleteClientes(Convert.ToInt32(hddn_idCliente.Value));

            if (transactionResult == 1)
            {
                string targetUrl = Request.Url.GetLeftPart(UriPartial.Path);
                Response.Redirect(targetUrl + "?response=Deleted");
            }
            else
            {
                string targetUrl = Request.Url.GetLeftPart(UriPartial.Path);
                Response.Redirect(targetUrl + "?response=Error");
            }
        }
    }
}