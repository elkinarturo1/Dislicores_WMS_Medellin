
Imports System.Data

Partial Class Pages_Modificar_OC_Pedidos
    Inherits System.Web.UI.Page

    Private Sub Pages_Modificar_OC_Pedidos_Load(sender As Object, e As EventArgs) Handles Me.Load

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

        Dim strResultado As String = ""

        Try

            Dim objSQL As New ModificarCamposOrdenesCompra
            Dim ds As New DataSet

            Dim co As String = txtCO.Text
            Dim tipoDoc As String = txtTipoDoc.Text
            Dim numDocIni As String = txtNumDocIni.Text
            Dim numDocFin As String = txtNumDocFin.Text
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

            If Not IsNumeric(txtNumDocIni.Text) Then
                numDocIni = "1"
            End If

            If Not IsNumeric(txtNumDocFin.Text) Then
                numDocFin = "999999999"
            End If

            If Not IsNumeric(txtFechaIni.Text) Then
                fechaIni = Now.Date.ToString("yyyyMMdd")
            End If

            If Not IsNumeric(txtFechaFin.Text) Then
                fechaFin = Now.Date.ToString("yyyyMMdd")
            End If

            'If Trim(txtOcIni.Text.Length) < 1 Then
            '    ocIni = "-1"
            'End If

            'If Trim(txtOcFin.Text.Length) < 1 Then
            '    ocFin = "-1"
            'End If


            ds = objSQL.DSP_PEDIDOS_SELECT_OC(co, tipoDoc, numDocIni, numDocFin, fechaIni, fechaFin, ocIni, ocFin)

            dgvDatos.DataSource = ds
            dgvDatos.DataMember = ds.Tables(0).ToString
            dgvDatos.EditIndex = -1
            dgvDatos.DataBind()

        Catch ex As Exception
            strResultado = ex.Message
        End Try

        lblMensaje.Text = strResultado


    End Sub


    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click


        Dim objSQL As New ModificarCamposOrdenesCompra
        Dim ds As New DataSet

        Dim strResultado As String = ""

        Dim co As String = txtCO.Text
        Dim tipoDoc As String = txtTipoDoc.Text
        Dim numDocIni As String = txtNumDocIni.Text
        Dim numDocFin As String = txtNumDocFin.Text
        Dim fechaIni As String = txtFechaIni.Text
        Dim fechaFin As String = txtFechaFin.Text
        Dim ocIni As String = "-1"
        Dim ocFin As String = "-1"


        '==============================================================================================
        'Validaciones
        If (strResultado = "") Then
            Try



                If Trim(txtCO.Text.Length) < 1 Then
                    strResultado &= "Debe enviar el centro de operacion <br />"
                End If

                If Trim(txtTipoDoc.Text.Length) < 1 Then
                    strResultado &= "Debe enviar el tipo de documento <br />"
                End If

                If Not IsNumeric(txtNumDocIni.Text) Then
                    strResultado &= "Debe enviar el consecutivo inicial <br />"
                End If

                If Not IsNumeric(txtNumDocFin.Text) Then
                    strResultado &= "Debe enviar el consecutivo final <br />"
                End If

                'If Not IsNumeric(txtFechaIni.Text) Then
                '    strResultado &= "Debe enviar la fecha inicial <br />"
                'End If

                'If Not IsNumeric(txtFechaFin.Text) Then
                '    strResultado &= "Debe enviar la fecha final <br />"
                'End If

                'If Trim(txtOcIni.Text.Length) < 1 Then
                '    ocIni = "-1"
                'End If

                'If Trim(txtOcFin.Text.Length) < 1 Then
                '    ocFin = "-1"
                'End If


                'Dim ocIni As String = txtOcIni.Text
                'Dim ocFin As String = txtOcFin.Text


            Catch ex As Exception
                strResultado = "Error al realizar las validaciones " & ex.Message
            End Try
        End If
        '==============================================================================================

        '==============================================================================================
        'Quitar puntos
        If (strResultado = "") Then
            Try
                objSQL.DSP_QUITAR_PUNTOS_PED(co, tipoDoc, numDocIni, numDocFin, fechaIni, fechaFin, ocIni, ocFin)
            Catch ex As Exception
                strResultado = "Error al quitar los puntos " & ex.Message
            End Try
        End If
        '==============================================================================================


        '==============================================================================================
        'Actualizar consulta
        If (strResultado = "") Then
            Try
                ds = objSQL.DSP_PEDIDOS_SELECT_OC(co, tipoDoc, numDocIni, numDocFin, fechaIni, fechaFin, ocIni, ocFin)

                dgvDatos.DataSource = ds
                dgvDatos.DataMember = ds.Tables(0).ToString
                dgvDatos.EditIndex = -1
                dgvDatos.DataBind()
            Catch ex As Exception
                strResultado = "Error al actualizar la consulta " & ex.Message
            End Try
        End If
        '==============================================================================================

        If strResultado = "" Then
            lblMensaje.Text = "Proceso Terminado"
        Else
            lblMensaje.Text = strResultado
        End If

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
