<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="frmHorarios.aspx.cs" Inherits="integradorUno.frmHorarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    HORARIOS<asp:ListBox ID="lstHorarios" runat="server"></asp:ListBox>
    <br />
    TRAMO<asp:DropDownList ID="ddlTramo" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    OMNIBUS<asp:DropDownList ID="ddlOmnibus" runat="server">
    </asp:DropDownList>
    <br />
    DIAS<asp:TextBox ID="txtDia" runat="server"></asp:TextBox>
    <br />
    PARTIDA<asp:TextBox ID="txtPartida" runat="server"></asp:TextBox>
    <br />
    LLEGADA<asp:TextBox ID="txtLlegada" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
    <br />
    <br />
    <br />
    MODIFICAR<br />
    DIAS<asp:TextBox ID="txtModDias" runat="server"></asp:TextBox>
    <br />
    PARTIDA<asp:TextBox ID="txtModPartida" runat="server"></asp:TextBox>
    <br />
    LLEGADA<asp:TextBox ID="txtModLlegada" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
    <br />
    <br />
    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
    <br />
    <br />
</asp:Content>
