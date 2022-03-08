Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clsAutenticacionSQL

    Public Function sp_Autenticacion(ByVal codigo As String, ByVal clave As String) As Boolean

        Dim strConexion As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionSauron").ToString

        Dim sqlConexion As New SqlConnection(strConexion)
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim sqlAdaptador As SqlDataAdapter = New SqlDataAdapter
        Dim ds As New DataSet

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_Autenticacion"

            sqlComando.Parameters.AddWithValue("@codigo", codigo)
            sqlComando.Parameters.AddWithValue("@clave", clave)

            sqlAdaptador.SelectCommand = sqlComando


            sqlAdaptador.Fill(ds)

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Function

End Class
