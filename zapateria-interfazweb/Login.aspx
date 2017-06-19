<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="zapateria_interfazweb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Zapateria</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
</head>
<body>
    
    <form id="form1" runat="server">

    <div >
            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" >
            <div class="registrationform">
                <div class="form-horizontal">
                    <fieldset style="position: center">
                        <legend>Iniciar sesión. <i class="fa fa-pencil pull-right"></i></legend>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Nombre de usuario" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Contraseña" CssClass="col-lg-2 control-label"></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Ingresar" OnClick="btnRegistrar_Click" />
                                                                
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>

    </div>
    <div>
         <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.backstretch.js" type="text/javascript"></script>
    <script type="text/javascript">
        'use strict';
        $.backstretch(
        [
            "img/34.jpg",
            "img/44.jpg"
            
            
        ],

        {
            duration: 7500,
            fade: 1500
        }
    );
    </script>
       
    </div>

    </form>
</body>
</html>
