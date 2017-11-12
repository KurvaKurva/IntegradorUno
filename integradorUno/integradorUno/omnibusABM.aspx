<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="omnibusABM.aspx.cs" Inherits="integradorUno.omnibusABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnModPanel" runat="server" Text="Modificar" OnClick="btnModPanel_Click" />
    <asp:Button ID="btnEliminarPnl" runat="server" OnClick="btnEliminarPnl_Click" Text="Baja" />
Ciudad actual

    <asp:DropDownList ID="ddlCiudad" runat="server" Width="111px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Capacidad"></asp:Label>
    <asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox>
    <asp:ListBox ID="lstOmnibus" runat="server" Width="800px"></asp:ListBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Matricula"></asp:Label>
    <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Panel ID="pnlEliminar" runat="server" Visible="False">
        ELIMINAR<br />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
</asp:Panel>
 
    <br />
    <br />

    <asp:Panel ID="pnlMod" runat="server" Visible="False">
        MODIFICAR<br />
        <asp:Label ID="lblCapacidad" runat="server" Text="Capacidad"></asp:Label>
        <asp:TextBox ID="txtModCapacidad" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label>
        <asp:TextBox ID="txtModMatricula" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
    </asp:Panel>

</asp:Content>
