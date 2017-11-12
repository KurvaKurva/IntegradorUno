<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="frmPasaje.aspx.cs" Inherits="integradorUno.frmPasaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Pasajes<br />
&nbsp;<asp:ListBox ID="lstPasajes" runat="server"></asp:ListBox>
    <br />
    Servicio<br />
    <asp:DropDownList ID="ddlOmnibus" runat="server">
    </asp:DropDownList>
    <br />
    Origen<br />
    <asp:DropDownList ID="ddlCiudadOrigen" runat="server">
    </asp:DropDownList>
    <br />
    Destino<br />
    <asp:DropDownList ID="ddlCiudadDestino" runat="server">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="costoValidator" runat="server" ErrorMessage="Debe ingresar un valor."></asp:RequiredFieldValidator>
    <br />
    Horario<br />
    <asp:DropDownList ID="ddlHorario" runat="server">
    </asp:DropDownList>
    <br />
    Costo<br />
    <asp:TextBox ID="txtCosto" runat="server"></asp:TextBox>
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
    <asp:GridView ID="gridPasajes" runat="server">
        <Columns>
            <asp:BoundField DataField="costo" HeaderText="Costo"/>
            <asp:BoundField DataField="fecha" HeaderText="fecha"/>
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
