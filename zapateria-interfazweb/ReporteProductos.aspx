<%@ Page Title="" Language="C#" MasterPageFile="~/ZapatoMaster.Master" AutoEventWireup="true" CodeBehind="ReporteProductos.aspx.cs" Inherits="zapateria_interfazweb.ReporteProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="form-container">

        <div class="form-header">
            <div class="form-title">
                <h2>Cliente</h2>
            </div>
        </div>
        <div class="form-body">
            <div class="form-nav">
                <a href="Default.aspx">
                    <span class="material-icons">&#xE408;</span><!--
                 --><span>Regresar</span>
                </a>
            </div>

            <div class="form-box">
                <div class="form-row">
                    <div class="form-row-label">
                        <asp:Label AssociatedControlID="txbx_nombreCliente" runat="server" Text="Nombre"></asp:Label>
                    </div><!--
                 --><div class="form-row-control">
                        <asp:TextBox ID="txbx_nombreCliente" runat="server" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <!--
                 -->
                </div>
                <div class="form-row">
                    <div class="form-row-action">
                        <asp:Button runat="server" ID="btn_search" name="btn_searchData" Text="Buscar" onClick="executeSearch" />
                    </div>
                </div>
            </div>
            <% if (Request.QueryString["nombre"] != null) { %>
            <div class="search-result">
                <div class="result-grid">
                    <div class="grid-header">
                        <div class="header-cell">Nombre</div>
                        <div class="header-cell">Estilo</div>
                        <div class="header-cell">Marca</div>
                        <div class="header-cell">Tallas Disponibles</div>
                        <div class="header-cell">Cantidad disponibles</div>
                        <div class="header-cell">Colores gama</div>
                        <div class="header-cell">Viajeros</div>
                    </div>
                    <div class="grid-body" id="gridBody" runat="server">

                        <!-- Server code goes here -->

                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>

</asp:Content>
