<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Download_Procesos_en_Cola_ION.aspx.vb" Inherits="Pages_Download_Procesos_en_Cola_ION" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:Button ID="btnBuscar" class="login100-form-btn" runat="server" Text="Buscar" BackColor="#3435cc" />

     <asp:Label ID="lblMensaje" runat="server" Text="..."></asp:Label>

    <asp:GridView ID="dgvDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataSourceID="odsDatos">
        <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

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

    <asp:ObjectDataSource ID="odsDatos" runat="server" SelectMethod="sp_WMS_Validar_Procesos_en_Cola" TypeName="Download_Procesos_en_Cola_ION_SQL"></asp:ObjectDataSource>

</asp:Content>

