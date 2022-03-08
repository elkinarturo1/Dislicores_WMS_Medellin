Imports System.Data
Imports System.Data.Odbc
Imports Microsoft.VisualBasic

Public Module ModuloORACLE

    Public Sub LimpiarTabla_PEE_Oracle()
        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("strConexionGT_ODBC").ToString

        'Instancia de conexion con el String de conexion ya creado como parametro System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("delete from TBL_DOWNLOAD_PEDIDOS_PEE", conn)


        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure

        Try
            comando.Connection.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DSP_DOWNLOAD_PEE_MIGRAR()
        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("strConexionGT_ODBC").ToString

        'Instancia de conexion con el String de conexion ya creado como parametro System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call DSP_DOWNLOAD_PEE_MIGRAR()}", conn)


        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure

        Try
            comando.Connection.Open()
            comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function DSP_DOWNLOAD_PEE(ByVal nit As String) As DataSet

        'String de conexion
        Dim strConexion As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("strConexionGT_ODBC").ToString

        'Instancia de conexion con el String de conexion ya creado como parametro System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        Dim conexion As New OdbcConnection(strConexion)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim ds As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call DSP_DOWNLOAD_PEE(?,?)}", conexion)

        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conexion
        comando.CommandType = CommandType.StoredProcedure

        'Instancia de parametros oracle
        'Dim P1 As New OdbcParameter("P_NitProv", ParameterDirection.Input)
        Dim P1 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
        Dim P2 As New OdbcParameter("p_nit", ParameterDirection.Input)

        If nit <> "" Then
            P2.Value = nit
        End If

        comando.Parameters.Add(P1)
        comando.Parameters.Add(P2)

        Try
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function

    Public Function selectPedidos(ByVal nit As String) As DataSet

        'String de conexion
        Dim strConexion As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("strConexionGT_ODBC").ToString

        'Instancia de conexion con el String de conexion ya creado como parametro System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        Dim conexion As New OdbcConnection(strConexion)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim ds As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("select * from TBL_DOWNLOAD_PEDIDOS_PEE", conexion)

        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conexion
        comando.CommandType = CommandType.Text

        'Instancia de parametros oracle
        'Dim P1 As New OdbcParameter("P_NitProv", ParameterDirection.Input)
        'Dim P1 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
        'Dim P2 As New OdbcParameter("p_nit", ParameterDirection.Input)

        'If nit <> "" Then
        '    P2.Value = nit
        'End If

        'comando.Parameters.Add(P1)
        'comando.Parameters.Add(P2)

        Try
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function

    Public Function selectTerceros() As DataSet

        'String de conexion
        Dim strConexion As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("strConexionGT_ODBC").ToString

        'Instancia de conexion con el String de conexion ya creado como parametro System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        Dim conexion As New OdbcConnection(strConexion)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim ds As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("select * from DV_DOWNLOAD_PEE_TERCEROS", conexion)

        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conexion
        comando.CommandType = CommandType.Text

        'Instancia de parametros oracle
        'Dim P1 As New OdbcParameter("P_NitProv", ParameterDirection.Input)
        'Dim P1 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
        'Dim P2 As New OdbcParameter("p_nit", ParameterDirection.Input)

        'If nit <> "" Then
        '    P2.Value = nit
        'End If

        'comando.Parameters.Add(P1)
        'comando.Parameters.Add(P2)

        Try
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function

    Public Function selectSkus() As DataSet

        'String de conexion
        Dim strConexion As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("strConexionGT_ODBC").ToString

        'Instancia de conexion con el String de conexion ya creado como parametro System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        Dim conexion As New OdbcConnection(strConexion)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim ds As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("select * from DV_DOWNLOAD_PEE_SKU", conexion)

        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conexion
        comando.CommandType = CommandType.Text

        'Instancia de parametros oracle
        'Dim P1 As New OdbcParameter("P_NitProv", ParameterDirection.Input)
        'Dim P1 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
        'Dim P2 As New OdbcParameter("p_nit", ParameterDirection.Input)

        'If nit <> "" Then
        '    P2.Value = nit
        'End If

        'comando.Parameters.Add(P1)
        'comando.Parameters.Add(P2)

        Try
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function

End Module
