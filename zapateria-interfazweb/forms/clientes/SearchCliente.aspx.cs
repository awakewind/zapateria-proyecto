using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zapateria_interfazweb.forms.clientes
{
    public partial class SearchCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["busqueda"] != null)
            {
                string searchQuery = Request.QueryString["busqueda"].Trim();

                if (searchQuery != "")
                {
                    serviciozapateriaw.zapateriawsSoapClient appService = new serviciozapateriaw.zapateriawsSoapClient();
                    var clienteList = appService.getClienteByField(searchQuery);

                    foreach (var element in clienteList)
                    {
                        this.gridBody.InnerHtml += "<div class='grid-body-row'>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.NomCliente1 + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.ApeCliente1 + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.TelCliente1 + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>";
                        this.gridBody.InnerHtml += "        <a href='UpdateCliente.aspx?object_id=" + element.Id_cliente + "'>Editar</a>";
                        this.gridBody.InnerHtml += "    </div>";
                        this.gridBody.InnerHtml += "</div>";
                    }
                }
            }

        }

        protected void executeSearch(object sender, EventArgs e)
        {
            string searchParam = txbx_parametro.Text;
            string targetUrl = Request.Url.GetLeftPart(UriPartial.Path);

            Response.Redirect(targetUrl + "?busqueda=" + searchParam);
        }
    }
}