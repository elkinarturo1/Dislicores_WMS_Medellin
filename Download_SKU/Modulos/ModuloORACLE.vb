Imports System.Data.Odbc

Module ModuloORACLE


    ''' <summary>
    ''' Ejecuta un SP generico sin parametros
    ''' </summary>
    ''' <param name="spOracle"></param>
    ''' <returns></returns>
    Public Function ejecutar_SP_Oracle(ByVal spOracle As String) As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("{call " & spOracle & "()}", conn)

        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure

        'Dim P1 As New OdbcParameter("p_RowIdPedido", ParameterDirection.Input)
        'P1.Value = RowIdPedido
        'comando.Parameters.Add(P1)


        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
        End Try

        Return ds

    End Function


    Public Function SP_Actualizacion_Datos_UNOEE_Oracle(ByVal spOracle As String, ByVal p_RowId As String) As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("{call " & spOracle & "(?)}", conn)

        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure

        Dim P1 As New OdbcParameter("p_RowId", ParameterDirection.Input)

        P1.Value = p_RowId

        'Añade los parametros al comando
        comando.Parameters.Add(P1)


        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
        End Try

        Return ds

    End Function

    Public Sub limpiar_Tabla_Oracle(ByVal nombreTabla As String)


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim comando As New OdbcCommand("delete from " & nombreTabla, conn)

        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure

        'Dim P1 As New OdbcParameter("p_RowIdPedido", ParameterDirection.Input)
        'P1.Value = RowIdPedido
        'comando.Parameters.Add(P1)


        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
        End Try

    End Sub


    Public Sub select_Tablas_Oracle(ByRef ds As DataSet, ByVal nombreTabla As String)


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim comando As New OdbcCommand("select * from " & nombreTabla, conn)

        comando.Connection = conn
        comando.CommandType = CommandType.Text

        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Sub consultarSesionesOracle(ByRef ds As DataSet)


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim comando As New OdbcCommand("SELECT TERMINAL, STATUS, SID, SERIAL# FROM  v$session WHERE (TERMINAL = 'EUCLIDES') AND(STATUS = 'INACTIVE')", conn)

        comando.Connection = conn
        comando.CommandType = CommandType.Text

        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function matarProcesosOracle(ByVal sid As String, ByVal serial As String) As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("alter system kill session '" + sid + "," + serial + "'", conn)

        comando.Connection = conn
        comando.CommandType = CommandType.Text

        'Dim P1 As New OdbcParameter("p_RowIdPedido", ParameterDirection.Input)
        'P1.Value = RowIdPedido
        'comando.Parameters.Add(P1)


        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
        End Try

        Return ds

    End Function



    Public Function DV_DOWNLOAD_CLIENTES() As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("select * from DV_DOWNLOAD_CLIENTES", conn)

        comando.Connection = conn
        comando.CommandType = CommandType.Text

        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function

    Public Function DV_DOWNLOAD_SKU() As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("select * from DV_DOWNLOAD_SKU", conn)

        comando.Connection = conn
        comando.CommandType = CommandType.Text

        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function


    'Public Function DSP_WMS_ACTUALIZAR_CARGUE_PEV(ByVal RowId As String) As DataSet


    '    Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
    '    Dim Adaptador As New OdbcDataAdapter
    '    Dim ds As New DataSet
    '    Dim comando As New OdbcCommand("{call DSP_WMS_ACTUALIZAR_CARGUE_PEV(?)}", conn)

    '    comando.Connection = conn
    '    comando.CommandType = CommandType.StoredProcedure

    '    Dim P1 As New OdbcParameter("p_RowId", ParameterDirection.Input)

    '    P1.Value = RowId

    '    'Añade los parametros al comando
    '    comando.Parameters.Add(P1)


    '    Try
    '        conn.Open()
    '        Adaptador.SelectCommand = comando
    '        comando.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        conn.Close()
    '    End Try

    '    Return ds

    'End Function

    'Public Function DSP_WMS_ACTUALIZAR_CARGUE_EDE(ByVal RowId As String) As DataSet


    '    Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
    '    Dim Adaptador As New OdbcDataAdapter
    '    Dim ds As New DataSet
    '    Dim comando As New OdbcCommand("{call DSP_WMS_ACTUALIZAR_CARGUE_EDE(?)}", conn)

    '    comando.Connection = conn
    '    comando.CommandType = CommandType.StoredProcedure

    '    Dim P1 As New OdbcParameter("p_RowId", ParameterDirection.Input)

    '    P1.Value = RowId

    '    'Añade los parametros al comando
    '    comando.Parameters.Add(P1)


    '    Try
    '        conn.Open()
    '        Adaptador.SelectCommand = comando
    '        comando.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        conn.Close()
    '    End Try

    '    Return ds

    'End Function

    'Public Function DSP_WMS_ACTUALIZAR_NOTAS_TCO(ByVal RowId As String) As DataSet


    '    Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
    '    Dim Adaptador As New OdbcDataAdapter
    '    Dim ds As New DataSet
    '    Dim comando As New OdbcCommand("{call DSP_WMS_ACTUALIZAR_NOTAS_TCO(?)}", conn)

    '    comando.Connection = conn
    '    comando.CommandType = CommandType.StoredProcedure

    '    Dim P1 As New OdbcParameter("p_RowId", ParameterDirection.Input)

    '    P1.Value = RowId

    '    'Añade los parametros al comando
    '    comando.Parameters.Add(P1)


    '    Try
    '        conn.Open()
    '        Adaptador.SelectCommand = comando
    '        comando.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        conn.Close()
    '    End Try

    '    Return ds

    'End Function


    Public Function DV_DOWNLOAD_PEDIDOS_AGRUP() As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("select * from DV_DOWNLOAD_PEDIDOS_AGRUP", conn)

        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conn
        comando.CommandType = CommandType.Text


        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return ds

    End Function

    Public Function DSP_DOWNLOAD_PEDIDOS() As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("{call DSP_DOWNLOAD_PEDIDOS(?)}", conn)

        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure
        comando.CommandTimeout = 0

        Dim P1 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
        comando.Parameters.Add(P1)

        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function

    Public Function DSP_DOWNLOAD_CLIENTES() As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("{call DSP_DOWNLOAD_CLIENTES(?)}", conn)

        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure
        comando.CommandTimeout = 0

        Dim P1 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
        comando.Parameters.Add(P1)

        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function

    Public Function DSP_DOWNLOAD_PEDIDOS_SKU() As DataSet


        Dim conn As New OdbcConnection(My.Settings.strConexionORACLE_GT)
        Dim Adaptador As New OdbcDataAdapter
        Dim ds As New DataSet
        Dim comando As New OdbcCommand("{call DSP_DOWNLOAD_PEDIDOS_SKU(?)}", conn)

        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure
        comando.CommandTimeout = 0

        Dim P1 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
        comando.Parameters.Add(P1)

        Try
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(ds)
        Catch ex As Exception
            Throw ex
        End Try

        Return ds

    End Function


End Module
