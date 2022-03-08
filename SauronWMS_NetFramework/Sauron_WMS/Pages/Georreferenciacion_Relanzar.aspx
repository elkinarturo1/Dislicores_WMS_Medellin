<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Georreferenciacion_Relanzar.aspx.vb" Inherits="Pages_Georreferenciacion_Relanzar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Label ID="lblidTercero" runat="server" Text="Nit"></asp:Label>
    <asp:TextBox ID="txtidTercero" runat="server"></asp:TextBox>

    <asp:Label ID="lblidSucursal" runat="server" Text="Sucursal"></asp:Label>
    <asp:TextBox ID="txtidSucursal" runat="server"></asp:TextBox>

    <asp:Button class="login100-form-btn" ID="btnBuscar" runat="server" Text="Buscar" BackColor="#3435cc" AutoPostBack="true" />

    <asp:Button class="login100-form-btn" ID="btnRelanzar" runat="server" Text="Relanzar" BackColor="#3435cc" AutoPostBack="true" />

    <asp:Label ID="lblMensaje" runat="server" Text="..."></asp:Label>

    <asp:GridView ID="dgvDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" withe="500px"
        AllowSorting="True" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
        PageSize="15" AllowPaging="True" DataSourceID="odsDatos">
        <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

        <Columns>
            <asp:BoundField DataField="idTercero" HeaderText="idTercero"></asp:BoundField>
            <asp:BoundField DataField="rowIdTercero" HeaderText="rowIdTercero"></asp:BoundField>
            <asp:BoundField DataField="idSucursal" HeaderText="idSucursal"></asp:BoundField>
            <asp:BoundField DataField="rowIdContacto" HeaderText="rowIdContacto"></asp:BoundField>
            <asp:BoundField DataField="direccion" HeaderText="direccion"></asp:BoundField>
        </Columns>

        <FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>
        <RowStyle BackColor="#EEEEEE" ForeColor="Black"></RowStyle>
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#0000A9"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#000065"></SortedDescendingHeaderStyle>
    </asp:GridView>

    <asp:ObjectDataSource ID="odsDatos" runat="server" SelectMethod="sp_Control_Clientes" TypeName="Georreferenciacion_SQL">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtidTercero" PropertyName="Text" DefaultValue="-1" Direction="InputOutput" Name="idTercero" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="txtidSucursal" PropertyName="Text" DefaultValue="-1" Direction="InputOutput" Name="idSucursal" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>


</asp:Content>

