<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="frmHorarios.aspx.cs" Inherits="integradorUno.frmHorarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnPanelAlta" runat="server" Text="Alta" class="btn btn-default" OnClick="btnPanelAlta_Click" />
    <asp:Button ID="btnPanelMod" runat="server" Text="Modificar" class="btn btn-default" OnClick="btnPanelMod_Click" />
    <asp:Button ID="btnPanelEliminar" runat="server" Text="Baja" class="btn btn-default" OnClick="btnPanelEliminar_Click" />
    <br />
    HORARIOS<br />
    <asp:ListBox ID="lstHorarios" runat="server" Width="800px"></asp:ListBox>
    <asp:Panel ID="pnlAlta" runat="server">
        Tramo<br /> <asp:DropDownList ID="ddlTramo" runat="server" Width="200px">
    </asp:DropDownList>
    <br />
        Omnibus<br /> <asp:DropDownList ID="ddlOmnibus" runat="server" Width="200px">
    </asp:DropDownList>
    <br />
        Dias<br /> <asp:TextBox ID="txtDia" runat="server" Width="200px"></asp:TextBox>
    <br />
        Partida<br /> <asp:TextBox ID="txtPartida" runat="server" Width="200px"></asp:TextBox>
    
    <br />
        Llegada<br /> <asp:TextBox ID="txtLlegada" runat="server" Width="200px"></asp:TextBox>
    <br />
    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" class="btn btn-success"/>
    <br />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlModificar" runat="server" Visible="False">
           MODIFICAR<br />
           Dias<br /> <asp:TextBox ID="txtModDias" runat="server" Width="200px"></asp:TextBox>    
    <br />
           Partida<br /> <asp:TextBox ID="txtModPartida" runat="server" Width="200px"></asp:TextBox>
    <br />
           Llegada<br /> <asp:TextBox ID="txtModLlegada" runat="server" Width="200px"></asp:TextBox>
    <br />
    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" class="btn btn-success"/>
    </asp:Panel>
 
    <br />
    
    <asp:Panel ID="pnlBaja" runat="server" Visible="False">
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" class="btn btn-danger"/>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
