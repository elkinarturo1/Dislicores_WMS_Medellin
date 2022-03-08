<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ModificarCampoOrdenesCompra.aspx.vb" Inherits="Pages_ModificarCampoOrdenesCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblBuscar" runat="server" Text="Co"></asp:Label>
    <asp:TextBox ID="txtCO" runat="server" Width ="60px"></asp:TextBox>

    <asp:Label ID="Label1" runat="server" Text="Tipo Doc"></asp:Label>
    <asp:TextBox ID="txtTipoDoc" runat="server" Width ="60px"></asp:TextBox>

    <asp:Label ID="Label2" runat="server" Text="NumDoc"></asp:Label>
    <asp:TextBox ID="txtNumDoc" runat="server" Width ="60px"></asp:TextBox>

    <asp:Label ID="Label3" runat="server" Text="Fecha Inicial" ></asp:Label>
    <asp:TextBox ID="txtFechaIni" runat="server" Width ="110px" Placeholder="YYYYMMDD"></asp:TextBox>

    <asp:Label ID="Label4" runat="server" Text="Fecha Fin"></asp:Label>   
    <asp:TextBox ID="txtFechaFin" runat="server" Width ="110px" Placeholder="YYYYMMDD"></asp:TextBox>

<%--     <asp:Label ID="Label5" runat="server" Text="OC Inicial"></asp:Label>
    <asp:TextBox ID="txtOcIni" runat="server" Width ="60px"></asp:TextBox>

     <asp:Label ID="Label6" runat="server" Text="OC Fin"></asp:Label>
    <asp:TextBox ID="txtOcFin" runat="server" Width ="60px"></asp:TextBox>--%>
  
    <asp:Button class="login100-form-btn" ID="btnBuscar" runat="server" Text="Buscar" BackColor="#3435cc" AutoPostBack="true" />
    <asp:Button class="login100-form-btn" ID="btnEnviar" runat="server" Text="Enviar" BackColor="#3435cc" />

    <asp:Label ID="lblMensaje" runat="server" Text="..."></asp:Label>

    <asp:GridView ID="dgvDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" withe="500px"
        AllowSorting="true" AutoGenerateColumns="false" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

        <Columns>
            <asp:BoundField DataField="f430_id_cia" HeaderText="f430_id_cia" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="f430_id_co" HeaderText="f430_id_co" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="f430_id_tipo_docto" HeaderText="f430_id_tipo_docto" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="f430_consec_docto" HeaderText="f430_consec_docto" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="f430_referencia" HeaderText="f430_referencia" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="f430_num_docto_referencia" HeaderText="f430_num_docto_referencia"></asp:BoundField>
            <asp:BoundField DataField="f430_id_fecha" HeaderText="f430_id_fecha"></asp:BoundField>
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


  <%--  <asp:ObjectDataSource ID="odsDatos" runat="server" SelectMethod="DSP_MODIFICAR_CAMPO_OC" TypeName="ModificarCamposOrdenesCompra">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtCO" PropertyName="Text" DefaultValue="-1" Name="p_co" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="txtTipoDoc" PropertyName="Text" DefaultValue="-1" Name="p_TipoDoc" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="txtNumDoc" PropertyName="Text" DefaultValue="-1" Name="p_NumDoc" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="txtFechaIni" PropertyName="Text" DefaultValue="01/01/2010" Name="p_fechaIni" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="txtFechaFin" PropertyName="Text" DefaultValue="01/01/3000" Name="p_fechaFin" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>--%>


</asp:Content>

