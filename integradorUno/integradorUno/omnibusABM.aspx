<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="omnibusABM.aspx.cs" Inherits="integradorUno.omnibusABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Button ID="btnModPanel" runat="server" Text="Modificar" OnClick="btnModPanel_Click" class="btn btn-default" />
    <asp:Button ID="btnEliminarPnl" runat="server" OnClick="btnEliminarPnl_Click" Text="Baja" class="btn btn-default" />
Ciudad actual

    <asp:DropDownList ID="ddlCiudad" runat="server" Width="200px">
    </asp:DropDownList>
    <br />
    <asp:ListBox ID="lstOmnibus" runat="server" Width="800px"></asp:ListBox>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Capacidad"></asp:Label>
    <br />
    <asp:TextBox ID="txtCapacidad" runat="server" Width="200px"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Matricula"></asp:Label>
    <br />
    <asp:TextBox ID="txtMatricula" runat="server" Width="200px"></asp:TextBox>
    <br />
    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" class="btn btn-success"/>
    <br />
    <asp:Panel ID="pnlEliminar" runat="server" Visible="False">
        ELIMINAR<br />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-danger"/>
</asp:Panel>
 
    <br />
    <br />

    <asp:Panel ID="pnlMod" runat="server" Visible="False">
        MODIFICAR<br />
        <asp:Label ID="lblCapacidad" runat="server" Text="Capacidad"></asp:Label>
        <br />
        <asp:TextBox ID="txtModCapacidad" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Label ID="lblMatricula" runat="server" Text="Matricula"></asp:Label>
        <br />
        <asp:TextBox ID="txtModMatricula" runat="server" Width="200px"></asp:TextBox>
        <br />
        <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" class="btn btn-success" />
    </asp:Panel>

</asp:Content>
