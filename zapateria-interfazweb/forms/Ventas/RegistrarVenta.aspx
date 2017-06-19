<%@ Page Title="" Language="C#" MasterPageFile="~/ZapatoMaster.Master" AutoEventWireup="true" CodeBehind="RegistrarVenta.aspx.cs" Inherits="zapateria_interfazweb.RegistrarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:TextBox ID="txtcodEmple" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtcodDepa" runat="server" Visible="false"></asp:TextBox>
    <div class="container">
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12 text-center">
            <div id="banner">
                <h1>
                    Registro <strong>Para</strong> Ventas</h1>
                <h5>
                    <strong>Zapateria.</strong></h5>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset>
                        <legend>Registrar venta. <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Cliente" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                  <asp:DropDownList ID="cmbCliente" runat="server" CssClass="form-control ddl">
                                </asp:DropDownList>    
                            </div>
                        </div>
                           <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Producto" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="cmbProducto" runat="server" CssClass="form-control ddl">
                                </asp:DropDownList>    
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" runat="server" Text="Cantidad de producto" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="txtcantproducto" runat="server"  CssClass="form-control" TextMode="Number" ></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <asp:Label ID="Label4" runat="server" Text="Total a pagar" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="txttotalpagar" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <asp:Label ID="Label5" runat="server" Text="Empleado" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList ID="cmbEmpleado" runat="server" CssClass="form-control ddl">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="btnfinalizar" runat="server" CssClass="btn btn-primary" Text="Finalizar venta" OnClick="btnfinalizar_Click" />
                                  <asp:Button ID="btnagregar" runat="server" CssClass="btn btn-primary" Text="Agregar productos" OnClick="btnagregar_Click" />                              
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
