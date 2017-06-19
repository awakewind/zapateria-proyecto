<%@ Page Language="C#" AutoEventWireup="true" Title="Actualizar Cliente" MasterPageFile="~/ZapatoMaster.Master" CodeBehind="UpdateCliente.aspx.cs" Inherits="zapateria_interfazweb.forms.clientes.UpdateCliente" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="MainContent" runat="server">

    <div class="form-container">
        <div class="form-header">
            <h2>Agregar Cliente</h2>
        </div>
        <div class="form-body">

            <asp:HiddenField ID="hddn_idCliente" runat="server"/>

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
                    <asp:Button ID="btn_deleteFormData" Text="Borrar" runat="server" OnClick="deleteFormData" />
                    <asp:Button ID="btn_updateFormData" Text="Actualizar" runat="server" OnClick="updateFormData" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>