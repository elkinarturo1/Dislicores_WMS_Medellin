
Imports System.Data

Partial Class Pages_Download_RQI
    Inherits System.Web.UI.Page

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim objSQL As New Download_RQI_SQL
        Dim ds As New DataSet

        Dim co As String = "-1"
        Dim numDoc As String = "-1"

        If txtCO.Text.Trim.Length > 0 Then
            co = txtCO.Text
        End If

        If txtNumDoc.Text.Trim.Length > 0 Then
            numDoc = txtNumDoc.Text
        End If

        Try

            ds = objSQL.sp_WMS_DOWNLOAD_Requisiciones_RQI(2, co, "RQI", numDoc)

            Session("ds") = ds

            If ds.Tables.Count > 0 Then
                If ds.Tables.Count > 1 Then
                    If ds.Tables(0).Rows.Count > 0 Then
                        dgvDatos.DataSource = ds
                        dgvDatos.DataMember = ds.Tables(0).ToString
                    Else
                        dgvDatos.DataSource = Nothing
                        lblMensaje.Text = "La consulta no trajo registros"
                    End If
                Else
                    dgvDatos.DataSource = Nothing
                    lblMensaje.Text = "La consulta no trajo detalle"
                End If
            Else
                dgvDatos.DataSource = Nothing
                lblMensaje.Text = "La consulta no trajo tablas"
            End If

            dgvDatos.EditIndex = -1
            dgvDatos.DataBind()

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Dim objProceso As New Proceso_Download_RQI
        Dim ds As New DataSet
        Dim dtPaquetes As New DataTable
        Dim dtDetalle As New DataTable
        Dim bitError As Boolean = False
        Dim resultado As String = "Proceso Terminado Correctamente"

        Try

            ds = Session("ds")

            objProceso.insercion_Datos_Principales_ION(ds, bitError, resultado)

        Catch ex As Exception
            resultado = "Ha ocurrido una excepcion " & ex.Message
        End Try

        lblMensaje.Text = resultado

    End Sub
End Class
