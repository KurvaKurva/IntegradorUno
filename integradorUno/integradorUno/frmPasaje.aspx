<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="frmPasaje.aspx.cs" Inherits="integradorUno.frmPasaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Pasajes
    <asp:ListBox ID="lstPasajes" runat="server"></asp:ListBox>
    <br />
    Servicio<asp:DropDownList ID="ddlOmnibus" runat="server">
    </asp:DropDownList>
    <br />
    Origen<asp:DropDownList ID="ddlCiudadOrigen" runat="server">
    </asp:DropDownList>
    <br />
    Destino<asp:DropDownList ID="ddlCiudadDestino" runat="server">
    </asp:DropDownList>
    <br />
    Horario<asp:DropDownList ID="ddlHorario" runat="server">
    </asp:DropDownList>
    <br />
    Costo<asp:TextBox ID="txtCosto" runat="server"></asp:TextBox>
    <br />
    Fecha<asp:Calendar ID="clndFecha" runat="server"></asp:Calendar>
    <asp:Button ID="btnAceptar" runat="server" Text="Button" value="Aceptar" OnClick="btnAceptar_Click" />
    <br />
    <asp:ListBox ID="lstPasajesEntreRangos" runat="server"></asp:ListBox>
    <asp:Button ID="btnCargar" runat="server" OnClick="btnCargar_Click" Text="Cargar" />
    <br />
    <br />
    <asp:ListBox ID="lstTramos" runat="server"></asp:ListBox>
    <asp:Calendar ID="clndInicio" runat="server"></asp:Calendar>
    <asp:Calendar ID="clndFin" runat="server"></asp:Calendar>
    <br />
</asp:Content>
