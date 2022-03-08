<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Download_PEE.aspx.vb" Inherits="Pages_Download_PEE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblBuscar" runat="server" Text="Buscar"></asp:Label>
    <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
    <asp:Button class="login100-form-btn" ID="btnBuscar" runat="server" Text="Buscar" BackColor="#3435cc" AutoPostBack="true" />
    <asp:Button class="login100-form-btn" ID="btnEnviar" runat="server" Text="Enviar" BackColor="#3435cc" />

    <asp:Label ID="lblMensaje" runat="server" Text="..."></asp:Label>

    <asp:GridView ID="dgvDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" withe="500px"
        AllowSorting="true" AutoGenerateColumns="false" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
        PageSize="15" AllowPaging="true">
        <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

        <Columns>
            <asp:BoundField DataField="STORERKEY_id_cia" HeaderText="cia" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="TYPE_tip_doc" HeaderText="tipoDoc"></asp:BoundField>
            <asp:BoundField DataField="f430_consec_docto" HeaderText="numDoc"></asp:BoundField>
            <asp:BoundField DataField="EXTERNORDERKEY_key_doc" HeaderText="EXTERNORDERKEY_key_doc"></asp:BoundField>
            <asp:BoundField DataField="nit" HeaderText="nit" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="razon_social" HeaderText="razon_social"></asp:BoundField>
            <%--   <asp:BoundField DataField="id_tercero" HeaderText="id_tercero"></asp:BoundField>
            <asp:BoundField DataField="sku_referencia" HeaderText="sku_referencia"></asp:BoundField>
            <asp:BoundField DataField="originalqty_cantidad_ped" HeaderText="originalqty_cantidad_ped"></asp:BoundField>--%>
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


    <%--  <asp:ObjectDataSource ID="odsDatos" runat="server" SelectMethod="sp_WMS_DOWNLOAD_Pedidos_PEE_Detalle" TypeName="Download_PEE_SQL">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtBuscar" PropertyName="Text" DefaultValue="-1" Name="nit" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>--%>
</asp:Content>

