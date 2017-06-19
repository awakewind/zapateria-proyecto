<%@ Page Language="C#" AutoEventWireup="true" Title="Buscar Cliente" MasterPageFile="~/ZapatoMaster.Master" CodeBehind="SearchCliente.aspx.cs" Inherits="zapateria_interfazweb.forms.clientes.SearchCliente" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="MainContent" runat="server">

    <div class="form-container">
        <div class="form-header">
            <h2>Buscar Cliente</h2>
        </div>
        <div class="form-body">

            <div class="form-row">
                <div class="form-row-label">
                    <asp:Label AssociatedControlID="txbx_parametro" Text="Nombre / Apellido" runat="server"></asp:Label>
                </div>
                <div class="form-row-control">
                    <asp:TextBox ID="txbx_parametro" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-row-action">
                    <asp:Button ID="btn_executeSearch" Text="Buscar" runat="server" OnClick="executeSearch" />
                </div>
            </div>

           

                <% if (Request.QueryString["busqueda"] != null) { %>
                <div class="search-result">
                    <div class="result-grid">
                        <div class="grid-header">
                            <div class="header-cell">Nombre</div>
                            <div class="header-cell">Apellido</div>
                            <div class="header-cell">Telefono</div>
                            <div class="header-cell">Acción</div>
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