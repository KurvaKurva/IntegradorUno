<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tramosss.aspx.cs" Inherits="integradorUno.tramosss" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:ListBox ID="lstTramos" runat="server" OnSelectedIndexChanged="lstTramos_SelectedIndexChanged"></asp:ListBox>
        <div>

            GUARDAR TRAMO<br />
            <asp:Label ID="Label1" runat="server" Text="Cantidad de Kilometros"></asp:Label>
            <asp:TextBox ID="txtCantKilometros" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Precio Base"></asp:Label>
            <asp:TextBox ID="txtPrecioBase" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
            <br />
            <br />
            MODIFICAR<br />
            <asp:Label ID="Label3" runat="server" Text="Cantidad de Kilometros"></asp:Label>
            <asp:TextBox ID="txtModCantKilometros" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Precio Base"></asp:Label>
            <asp:TextBox ID="txtModPrecioBase" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />

        </div>
    </form>
</body>
</html>
