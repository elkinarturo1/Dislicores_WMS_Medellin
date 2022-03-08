
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click

        Dim objSQL As New clsAutenticacionSQL
        Dim autenticado As Boolean = False

        'Variables de session
        Session("autenticado") = False


        Try
            autenticado = objSQL.sp_Autenticacion(txtUtuario.Text, txtClave.Text)

            If autenticado Then
                Session("autenticado") = autenticado
                Response.Redirect("Pages/Principal.aspx")
            Else
                lblMensaje.Text = "Las credenciales no son validas"
            End If

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

    End Sub

End Class
