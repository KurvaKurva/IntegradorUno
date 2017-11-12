

<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="frmTramos.aspx.cs" Inherits="integradorUno.frmTramos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />        
        <asp:Button ID="btnModPanel" runat="server" Text="Modificar" OnClick="btnModPanel_Click" />
        <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" />
        <asp:ListBox ID="lstTramos" runat="server" OnSelectedIndexChanged="lstTramos_SelectedIndexChanged"></asp:ListBox>
        <br />
       
        <div>
            <asp:Panel ID="pnlAlta" runat="server">
            GUARDAR TRAMO<br />
            Ciudad destino<asp:DropDownList ID="ddlCiudadDestino" runat="server">
            </asp:DropDownList>
            <br />
            Ciudad origen<asp:DropDownList ID="ddlCiudadOrigen" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="Cantidad de Kilometros"></asp:Label>
            <asp:TextBox ID="txtCantKilometros" runat="server"></asp:TextBox>
            <br />
            <asp:RegularExpressionValidator ID="vldCantKilometrosSoloNum" runat="server" ErrorMessage="Solo puede ingresar números." ControlToValidate="txtCantKilometros" ValidationExpression="^[0-9]*" ValidationGroup="Alta"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="vldCantKilometros" runat="server" ControlToValidate="txtCantKilometros" ErrorMessage="Debe ingresar un valor." ValidationGroup="Alta"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Precio Base"></asp:Label>
            <asp:TextBox ID="txtPrecioBase" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="vldCosto" runat="server" ControlToValidate="txtPrecioBase" ErrorMessage="Debe ingresar un valor." ValidationGroup="Alta"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
            <br />
                </asp:Panel>
            <br />
            <asp:Panel ID="pnlMod" runat="server" Visible="False">
            MODIFICAR<br />
            <asp:Label ID="Label3" runat="server" Text="Cantidad de Kilometros"></asp:Label>
            <asp:TextBox ID="txtModCantKilometros" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Precio Base"></asp:Label>
            <asp:TextBox ID="txtModPrecioBase" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
            </asp:Panel>
            </div>
        

        <asp:Panel ID="pnlBaja" runat="server" Visible="False">
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </asp:Panel>
        

</asp:Content>