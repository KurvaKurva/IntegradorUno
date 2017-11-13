

<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="frmTramos.aspx.cs" Inherits="integradorUno.frmTramos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" class="btn btn-default"/>        
        <asp:Button ID="btnModPanel" runat="server" Text="Modificar" OnClick="btnModPanel_Click" class="btn btn-default"/>
        <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" class="btn btn-default"/>
        <br />
        <asp:ListBox ID="lstTramos" runat="server" OnSelectedIndexChanged="lstTramos_SelectedIndexChanged" Width="800px"></asp:ListBox>
        <br />
       
        <div>
            <asp:Panel ID="pnlAlta" runat="server">
            GUARDAR TRAMO<br />
            Ciudad destino<br /> <asp:DropDownList ID="ddlCiudadDestino" runat="server" Width="200px">
            </asp:DropDownList>
            <br />
            Ciudad origen<br /> <asp:DropDownList ID="ddlCiudadOrigen" runat="server" Width="200px">
            </asp:DropDownList>
                <br />
            <asp:Label ID="Label1" runat="server" Text="Cantidad de Kilometros"></asp:Label>
                <br />
            <asp:TextBox ID="txtCantKilometros" runat="server" Width="200px"></asp:TextBox>
            <br />
            <asp:RegularExpressionValidator ID="vldCantKilometrosSoloNum" runat="server" ErrorMessage="Solo puede ingresar números." ControlToValidate="txtCantKilometros" ValidationExpression="^[0-9]*" ValidationGroup="Alta"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="vldCantKilometros" runat="server" ControlToValidate="txtCantKilometros" ErrorMessage="Debe ingresar un valor." ValidationGroup="Alta"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Precio Base"></asp:Label>
                <br />
            <asp:TextBox ID="txtPrecioBase" runat="server" Width="200px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="vldCosto" runat="server" ControlToValidate="txtPrecioBase" ErrorMessage="Debe ingresar un valor." ValidationGroup="Alta"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" class="btn btn-success"/>
            <br />
                </asp:Panel>
            <br />
            <asp:Panel ID="pnlMod" runat="server" Visible="False">
            MODIFICAR<br />
            <asp:Label ID="Label3" runat="server" Text="Cantidad de Kilometros"></asp:Label>
                <br />
            <asp:TextBox ID="txtModCantKilometros" runat="server" Width="200px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Precio Base"></asp:Label>
                <br />
            <asp:TextBox ID="txtModPrecioBase" runat="server" Width="200px"></asp:TextBox>
            <br />
            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar" class="btn btn-success" />
            </asp:Panel>
            </div>
        

<asp:Panel ID="pnlBaja" runat="server" Visible="False">
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" class="btn btn-danger"/>
</asp:Panel>
        

</asp:Content>