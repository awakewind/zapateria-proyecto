<%@ Page Language="C#" AutoEventWireup="true" Title="Agregar Cliente" MasterPageFile="~/ZapatoMaster.Master" CodeBehind="AddCliente.aspx.cs" Inherits="zapateria_interfazweb.forms.clientes.AddCliente" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="MainContent" runat="server">

    <div class="form-container">
        <div class="form-header">
            <h2>Agregar Cliente</h2>
        </div>
        <div class="form-body">

            <div class="form-row">
                <div class="form-row-label">
                    <asp:Label AssociatedControlID="txbx_nombreCliente" Text="Nombre" runat="server"></asp:Label>
                </div>
                <div class="form-row-control">
                    <asp:TextBox ID="txbx_nombreCliente" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-row-label">
                    <asp:Label AssociatedControlID="txbx_apellidoCliente" Text="Apellido" runat="server"></asp:Label>
                </div>
                <div class="form-row-control">
                    <asp:TextBox ID="txbx_apellidoCliente" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-row-label">
                    <asp:Label AssociatedControlID="txbx_telefonoCliente" Text="Telefono" runat="server"></asp:Label>
                </div>
                <div class="form-row-control">
                    <asp:TextBox ID="txbx_telefonoCliente" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-row-label">
                    <asp:Label AssociatedControlID="txbx_direccionCliente" Text="Direccion" runat="server"></asp:Label>
                </div>
                <div class="form-row-control">
                    <asp:TextBox ID="txbx_direccionCliente" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-row">
                <div class="form-row-action">
                    <asp:Button ID="btn_saveFormData" Text="Guardar" runat="server" OnClick="saveFormData" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>