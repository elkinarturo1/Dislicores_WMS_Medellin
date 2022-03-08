
Imports System.Data

Partial Class Pages_ModificarCampoOrdenesCompra
    Inherits System.Web.UI.Page

    Private Sub Pages_ModificarCampoOrdenesCompra_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim objSQL As New ModificarCamposOrdenesCompra
        Dim ds As New DataSet

        If Not IsPostBack Then

            Try

                Dim fecha As String = Now.Date.ToString("yyyyMMdd")

                ds = objSQL.DSP_PEDIDOS_SELECT_OC("001", "PEV", 1, 999999999, fecha, fecha, "-1", "-1")

                dgvDatos.DataSource = ds
                dgvDatos.DataMember = ds.Tables(0).ToString
                dgvDatos.EditIndex = -1
                dgvDatos.DataBind()

            Catch ex As Exception
                lblMensaje.Text = ex.Message
            End Try


        End If

    End Sub


    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim objSQL As New ModificarCamposOrdenesCompra
        Dim ds As New DataSet

        Dim co As String = txtCO.Text
        Dim tipoDoc As String = txtTipoDoc.Text
        Dim numDoc As String = txtNumDoc.Text
        Dim fechaIni As String = txtFechaIni.Text
        Dim fechaFin As String = txtFechaFin.Text
        Dim ocIni As String = "-1"
        Dim ocFin As String = "-1"

        'Dim ocIni As String = txtOcIni.Text
        'Dim ocFin As String = txtOcFin.Text

        If Trim(txtCO.Text.Length) < 1 Then
            co = "-1"
        End If

        If Trim(txtTipoDoc.Text.Length) < 1 Then
            tipoDoc = "-1"
        End If

        If Trim(txtNumDoc.Text.Length) < 1 Then
            numDoc = "-1"
        End If

        If Not IsNumeric(txtFechaIni.Text.Length) Then
            fechaIni = Now.Date.ToString("yyyyMMdd")
        End If

        If Not IsNumeric(txtFechaFin.Text.Length) Then
            fechaFin = Now.Date.ToString("yyyyMMdd")
        End If

        'If Trim(txtOcIni.Text.Length) < 1 Then
        '    ocIni = "-1"
        'End If

        'If Trim(txtOcFin.Text.Length) < 1 Then
        '    ocFin = "-1"
        'End If

        ds = objSQL.DSP_PEDIDOS_SELECT_OC(co, tipoDoc, numDoc, 999999999, fechaIni, fechaFin, ocIni, ocFin)

        dgvDatos.DataSource = ds
        dgvDatos.DataMember = ds.Tables(0).ToString
        dgvDatos.EditIndex = -1
        dgvDatos.DataBind()

        Try
            'ModuloSQL.ejecutar_sp_Download_SQL("sp_WMS_DOWNLOAD_Pedidos_PEE_Migrar")
            'ModuloSQL.ejecutar_sp_Download_SQL("sp_WMS_DOWNLOAD_SKU_Pedidos_Migrar")
            'ModuloSQL.ejecutar_sp_Download_SQL("sp_WMS_DOWNLOAD_Terceros_Pedidos_PEE_Migrar")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try



    End Sub


    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click


        'Dim bitError As Boolean = False
        'Dim resultado As String = "Proceso Terminado Correctamente"

        'Dim objProceso As New Proceso_Download_PEE

        'If Len(txtBuscar.Text.Trim) > 0 Then
        '    objProceso.ejecutarProceso(bitError, resultado, txtBuscar.Text.Trim)
        '    lblMensaje.Text = resultado
        'Else
        '    lblMensaje.Text = "Debe digitar un nit para enviar"
        'End If


    End Sub


    'Private Sub DescargarArchivo(ByVal fname As String)
    '    Dim fullpath = Path.GetFullPath(fname)
    '    Dim name = Path.GetFileName(fullpath)
    '    Dim type As String = "text/plain"

    '    Response.AppendHeader("content-disposition",
    '    "attachment; filename=" + name)

    '    Response.ContentType = type

    '    Response.WriteFile(fullpath)
    '    Response.End()

    'End Sub

End Class
