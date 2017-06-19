using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zapateria_interfazweb
{
    public partial class ReporteProductos : System.Web.UI.Page
    {
        serviciozapateriaw.zapateriawsSoapClient ws = new serviciozapateriaw.zapateriawsSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["nombre"] != null)
            {
                string nombreCliente = Request.QueryString["nombre"].Trim();

                if (nombreCliente != "")
                {
                    if (nombreCliente == "") nombreCliente = "null_datavalue";

                    var zapatos = ws.getAllZapato();
                    foreach (var element in zapatos)
                    {
                        this.gridBody.InnerHtml += "<div class='grid-body-row'>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.NomGaZapato1 + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.Estilos + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.Marcas + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.TallasDisponibles1 + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.CantidadDisponible1 + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.ColoresGama1 + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>" + element.Viajeros + "</div>";
                        this.gridBody.InnerHtml += "    <div class='body-cell'>";
                        this.gridBody.InnerHtml += "    </div>";
                        this.gridBody.InnerHtml += "</div>";
                    }
                }
            }
        }

        protected void executeSearch(object sender, EventArgs e)
        {
            string nombreCliente = txbx_nombreCliente .Text.Trim();
            string targetUrl = Request.Url.GetLeftPart(UriPartial.Path);

            Response.Redirect(targetUrl + "?nombre=" + nombreCliente);
        }
    }
}