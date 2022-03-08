
Imports System.Data

Partial Class Pages_Upload_Validar_TEB
    Inherits System.Web.UI.Page

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim ds As New DataSet
        Dim numTransaccionWMS As String = "-1"

        If txtBuscar.Text.Trim.Length > 0 Then
            numTransaccionWMS = txtBuscar.Text
        End If

        Try
            Dim objSQL As New Upload_TEB_SQL
            ds = objSQL.sp_WMS_Validar_Upload_TEB(numTransaccionWMS)

            dgvDatosSiesa.DataSource = ds
            dgvDatosWMS.DataSource = ds
            dgvDatosLog.DataSource = ds


            dgvDatosSiesa.DataMember = ds.Tables(0).ToString
            dgvDatosWMS.DataMember = ds.Tables(1).ToString
            dgvDatosLog.DataMember = ds.Tables(2).ToString


            dgvDatosSiesa.EditIndex = -1
            dgvDatosWMS.EditIndex = -1
            dgvDatosLog.EditIndex = -1

            dgvDatosSiesa.DataBind()
            dgvDatosWMS.DataBind()
            dgvDatosLog.DataBind()


        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

    End Sub
End Class
