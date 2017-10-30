<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="omnibusABM.aspx.cs" Inherits="integradorUno.omnibusABM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DropDownList ID="ddlCiudad" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Capacidad"></asp:Label>
    <asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox>
    <asp:ListBox ID="lstOmnibus" runat="server"></asp:ListBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Matricula"></asp:Label>
    <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
    <br />

</asp:Content>
