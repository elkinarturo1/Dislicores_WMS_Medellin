<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Georreferenciacion_Log.aspx.vb" Inherits="Pages_Georreferenciacion_Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblidTercero" runat="server" Text="Nit"></asp:Label>
    <asp:TextBox ID="txtidTercero" runat="server"></asp:TextBox>

    <asp:Label ID="lblidSucursal" runat="server" Text="Sucursal"></asp:Label>
    <asp:TextBox ID="txtidSucursal" runat="server"></asp:TextBox>

    <asp:Label ID="lblProceso" runat="server" Text="Proceso"></asp:Label>
    <asp:TextBox ID="txtProceso" runat="server"></asp:TextBox>

    <asp:Button class="login100-form-btn" ID="btnBuscar" runat="server" Text="Buscar" BackColor="#3435cc" AutoPostBack="true" />

    <asp:GridView ID="dgvDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" withe="500px"
        AllowSorting="true" AutoGenerateColumns="false" BorderWidth="1px" CellPadding="3" GridLines="Vertical"
        PageSize="15" AllowPaging="true" DataSourceID="odsDatos">
        <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

        <Columns>
            <asp:BoundField DataField="ts" HeaderText="ts" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="id"></asp:BoundField>
            <asp:BoundField DataField="idTercero" HeaderText="idTercero"></asp:BoundField>
            <asp:BoundField DataField="idSucursal" HeaderText="idSucursal"></asp:BoundField>
            <asp:BoundField DataField="proceso" HeaderText="proceso" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="rowIdTercero" HeaderText="rowIdTercero"></asp:BoundField>
            <asp:BoundField DataField="direccion" HeaderText="direccion"></asp:BoundField>
            <asp:BoundField DataField="codigoPostal" HeaderText="codigoPostal"></asp:BoundField>
            <asp:BoundField DataField="latitud" HeaderText="latitud"></asp:BoundField>
            <asp:BoundField DataField="longitud" HeaderText="longitud"></asp:BoundField>
            <asp:BoundField DataField="estrato" HeaderText="estrato"></asp:BoundField>
            <asp:BoundField DataField="barrio" HeaderText="barrio"></asp:BoundField>
            <asp:BoundField DataField="comunaLocalidad" HeaderText="comunaLocalidad"></asp:BoundField>
            <asp:BoundField DataField="Zona1" HeaderText="Zona1"></asp:BoundField>
            <asp:BoundField DataField="Zona2" HeaderText="Zona2"></asp:BoundField>
            <asp:BoundField DataField="Zona3" HeaderText="Zona3"></asp:BoundField>
            <asp:BoundField DataField="Zona4" HeaderText="Zona4"></asp:BoundField>
            <asp:BoundField DataField="resultadoSitiData" HeaderText="resultadoSitiData"></asp:BoundField>
            <asp:BoundField DataField="xml_GT" HeaderText="xml_GT"></asp:BoundField>
            <asp:BoundField DataField="resultado_GT" HeaderText="resultado_GT"></asp:BoundField>
            <asp:BoundField DataField="xml_UNOEE" HeaderText="xml_UNOEE"></asp:BoundField>
            <asp:BoundField DataField="resultado_UNOEE" HeaderText="resultado_UNOEE"></asp:BoundField>
            <asp:BoundField DataField="detalle" HeaderText="detalle"></asp:BoundField>
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

    <asp:ObjectDataSource ID="odsDatos" runat="server" SelectMethod="sp_log_Select" TypeName="Georreferenciacion_SQL">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtidTercero" PropertyName="Text" DefaultValue="-1" Direction="InputOutput" Name="idTercero" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="txtidSucursal" PropertyName="Text" DefaultValue="-1" Direction="InputOutput" Name="idSucursal" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="txtProceso" PropertyName="Text" DefaultValue="-1" Direction="InputOutput" Name="proceso" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

