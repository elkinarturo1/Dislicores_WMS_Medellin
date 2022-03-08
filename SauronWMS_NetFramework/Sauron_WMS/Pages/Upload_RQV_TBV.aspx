<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Upload_RQV_TBV.aspx.vb" Inherits="Pages_Upload_RQV_TBV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <asp:Label ID="lblBuscar" runat="server" Text="Buscar"></asp:Label>
    <asp:TextBox ID="txtNumDoc" runat="server"></asp:TextBox>
    <asp:Button class="login100-form-btn" ID="btnBuscar" runat="server" Text="Buscar" BackColor="#3435cc" />
    <asp:Button class="login100-form-btn" ID="btnEnviar" runat="server" Text="Enviar" BackColor="#3435cc" />

    <asp:Label ID="lblMensaje" runat="server" Text="..."></asp:Label>

    <br />

    <br />


    <asp:GridView ID="dgvDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="50" GridLines="Vertical"
        PageIndex="50" AllowPaging="true">
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
     

</asp:Content>

