
Imports System.Data

Partial Class Pages_Upload_OCP_ECP
    Inherits System.Web.UI.Page


    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim bitError As Boolean = False
        Dim resultado As String = ""

        Dim ds As New DataSet
        Dim numDoc As String = "-1"


        If txtNumDoc.Text.Trim.Length > 0 Then
            numDoc = txtNumDoc.Text
        End If


        Try
            Dim objSQL As New Upload_OCP_ECP_SQL
            'ds = objSQL.sp_WMS_UPLOAD_Entrada_ECP_desde_OCP_ws_Migrar_Blazor(bitError, resultado)

        Catch ex As Exception
            bitError = True
            resultado = ex.Message
        End Try


        If Not bitError Then
            Try
                If ds.Tables.Count > 0 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        dgvDatos.DataSource = ds
                        dgvDatos.DataMember = ds.Tables(0).ToString
                        dgvDatos.EditIndex = -1
                        dgvDatos.DataBind()
                    Else
                        resultado = "No hay documentos para enviar"
                    End If
                Else
                    resultado = "No hay tablas en la consulta"
                End If
            Catch ex As Exception
                bitError = True
                resultado = ex.Message
            End Try
        End If

        lblMensaje.Text = resultado

    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Dim bitError As Boolean = False
        Dim resultado As String = ""
        Dim proceso As New Proceso_Upload_OCP_ECP

        Try
            proceso.ejecutarProceso(bitError, resultado, 2, "001", "OCP", txtNumDoc.Text.Trim)
        Catch ex As Exception
            bitError = False
            resultado = ex.Message
        End Try

        lblMensaje.Text = resultado


    End Sub
End Class
