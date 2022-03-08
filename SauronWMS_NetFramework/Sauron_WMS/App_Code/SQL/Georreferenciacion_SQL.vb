Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Georreferenciacion_SQL

    Dim strConexionSQL As String = System.Configuration.ConfigurationManager.AppSettings.Item("strConexionGeorreferenciacion").ToString

    Public Function sp_log_Select(ByRef idTercero As String, ByRef idSucursal As String, ByRef proceso As String) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_log_Select"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@idTercero", idTercero)
            sqlComando.Parameters.AddWithValue("@idSucursal", idSucursal)
            sqlComando.Parameters.AddWithValue("@proceso", proceso)

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function


    Public Function sp_Control_Clientes(ByRef idTercero As String, ByRef idSucursal As String) As DataSet

        Dim ds As New DataSet
        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_Control_Clientes"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@idTercero", idTercero)
            sqlComando.Parameters.AddWithValue("@idSucursal", idSucursal)

            sqlConexion.Open()
            sqlAdaptador.SelectCommand = sqlComando
            sqlAdaptador.Fill(ds)

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return ds

    End Function



    Public Function sp_Cliente_Relanzar(ByRef idTercero As String, ByRef idSucursal As String) As String


        Dim sqlConexion As New SqlConnection(strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim strResultado As String = ""

        Try

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_Cliente_Relanzar"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@idTercero", idTercero)
            sqlComando.Parameters.AddWithValue("@idSucursal", idSucursal)

            sqlConexion.Open()
            sqlComando.ExecuteNonQuery()

            strResultado = "Proceso Ejecutado Correctamente"

        Catch ex As Exception
            strResultado = "Error : " & ex.Message
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        Return strResultado

    End Function


End Class
