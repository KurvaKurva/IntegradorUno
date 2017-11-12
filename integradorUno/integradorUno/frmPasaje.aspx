<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="frmPasaje.aspx.cs" Inherits="integradorUno.frmPasaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnMostrar" runat="server" Text="Ver Total" OnClick="btnMostrar_Click" />
    <asp:Button ID="btnNuevoPasaje" runat="server" Text="Nuevo Pasaje" OnClick="btnNuevoPasaje_Click" />
    <br />
    Pasajes<br />
&nbsp;<asp:ListBox ID="lstPasajes" runat="server" Width="800px"></asp:ListBox>
    <br />  
    <asp:Panel ID="pnlPasajes" runat="server" Visible="False">
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
    <asp:RequiredFieldValidator ID="costoValidator" runat="server" ErrorMessage="Debe ingresar un valor." ControlToValidate="txtCosto" ValidationGroup="Alta"></asp:RequiredFieldValidator>
    <br />
    Horario<br />
    <asp:DropDownList ID="ddlHorario" runat="server">
    </asp:DropDownList>
    <br />
    Costo<br />
    <asp:TextBox ID="txtCosto" runat="server"></asp:TextBox>
    <br />
    Fecha<asp:Calendar ID="clndFecha" runat="server"></asp:Calendar>
          <br />
          <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" value="Aceptar" />
    </asp:Panel>
    <br />    
    <asp:GridView ID="gridPasajes" runat="server">
        <Columns>
            <asp:BoundField DataField="costo" HeaderText="Costo"/>
            <asp:BoundField DataField="fecha" HeaderText="fecha"/>
        </Columns>
    </asp:GridView>
    <asp:Panel ID="pnlTotalFacturado" runat="server" Visible="False">
        <asp:ListBox ID="lstPasajesEntreRangos" runat="server" Width="800px"></asp:ListBox>
        <br />
        <br />
        TRAMOS<br />
    <asp:ListBox ID="lstTramos" runat="server" Width="800px"></asp:ListBox>
        <br />
        FECHA INICIO<asp:Calendar ID="clndInicio" runat="server"></asp:Calendar>
        <br />
        FECHA FIN<asp:Calendar ID="clndFin" runat="server"></asp:Calendar>
        <br />
        <asp:Button ID="btnCargar" runat="server" OnClick="btnCargar_Click" Text="Cargar" />
    </asp:Panel>
    <br />
</asp:Content>
