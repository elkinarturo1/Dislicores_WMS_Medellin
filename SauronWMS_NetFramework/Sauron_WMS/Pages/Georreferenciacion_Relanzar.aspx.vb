
Partial Class Pages_Georreferenciacion_Relanzar
    Inherits System.Web.UI.Page


    Protected Sub btnRelanzar_Click(sender As Object, e As EventArgs) Handles btnRelanzar.Click

        Dim objGeo As New Georreferenciacion_SQL
        Dim resultado As String = ""

        Try

            If ((txtidTercero.Text.Trim = "") Or (txtidSucursal.Text.Trim = "")) Then
                resultado = "Debe enviar un idtercero y una sucursal"
            Else
                resultado = objGeo.sp_Cliente_Relanzar(txtidTercero.Text, txtidSucursal.Text)
            End If

        Catch ex As Exception
            resultado = "Error : " & ex.Message
        End Try

        lblMensaje.Text = resultado

    End Sub
End Class
