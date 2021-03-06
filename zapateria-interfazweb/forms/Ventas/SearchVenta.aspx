﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ZapatoMaster.Master" AutoEventWireup="true" CodeBehind="SearchVenta.aspx.cs" Inherits="zapateria_interfazweb.forms.Ventas.SearchVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <div class="form-header">
            <h2>Buscar Producto</h2>
        </div>
        <div class="form-body">

            <div class="form-row">
                <div class="form-row-label">
                    <asp:Label AssociatedControlID="txbx_parametro" Text="Buscar nombre del producto" runat="server"></asp:Label>
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
                            <div class="header-cell">ventas</div>
                            <div class="header-cell">Producto</div>
                            <div class="header-cell">Empleado</div>
                            <div class="header-cell">Total</div>
                            <div class="header-cell">Cantidad</div>
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
