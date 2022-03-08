Imports System.Data
Imports System.Data.Odbc
Imports Microsoft.VisualBasic

Public Class ModificarCamposOrdenesCompra

    Public Function DSP_PEDIDOS_SELECT_OC(ByVal p_co As String,
                                         ByVal p_TipoDoc As String,
                                         ByVal p_NumDoc_Ini As String,
                                         ByVal p_NumDoc_Fin As String,
                                         ByVal p_fechaIni As Integer,
                                         ByVal p_fechaFin As Integer,
                                         ByVal p_ocini As String,
                                         ByVal p_ocfin As String) As DataSet


        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.AppSettings.Item("strOracleGT").ToString()
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call DSP_PEDIDOS_SELECT_OC(?,?,?,?,?,?,?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.CommandTimeout = 120
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("p_co", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("p_TipoDoc", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("p_NumDoc_Ini", ParameterDirection.Input)
            Dim P4 As New OdbcParameter("p_NumDoc_Fin", ParameterDirection.Input)
            Dim P5 As New OdbcParameter("p_fechaIni", ParameterDirection.Input)
            Dim P6 As New OdbcParameter("p_fechaFin", ParameterDirection.Input)
            Dim P7 As New OdbcParameter("p_ocini", ParameterDirection.Input)
            Dim P8 As New OdbcParameter("p_ocfin", ParameterDirection.Input)
            Dim P9 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)

            'Validacion de parametros y asignacion de los mismos
            If (p_co <> "") Then
                P1.Value = p_co
            End If

            If (p_TipoDoc <> "") Then
                P2.Value = p_TipoDoc
            End If

            If (p_NumDoc_Ini <> "") Then
                P3.Value = p_NumDoc_Ini
            End If

            If (p_NumDoc_Fin <> "") Then
                P4.Value = p_NumDoc_Fin
            End If

            If (p_fechaIni <> 0) Then
                P5.Value = p_fechaIni
            End If

            If (p_fechaFin <> 0) Then
                P6.Value = p_fechaFin
            End If

            If (p_ocini <> "") Then
                P7.Value = p_ocini
            End If

            If (p_ocfin <> "") Then
                P8.Value = p_ocfin
            End If

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)
            comando.Parameters.Add(P4)
            comando.Parameters.Add(P5)
            comando.Parameters.Add(P6)
            comando.Parameters.Add(P7)
            comando.Parameters.Add(P8)
            comando.Parameters.Add(P9)

            'asigna el comando con los parametro al dataadapter yrealiza la consulta
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            If dsResultado.Tables.Count = 1 Then
                Return dsResultado
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function DSP_REQUISICION_SELECT_OC(ByVal p_co As String,
                                         ByVal p_TipoDoc As String,
                                         ByVal p_NumDoc_Ini As String,
                                         ByVal p_NumDoc_Fin As String,
                                         ByVal p_fechaIni As Integer,
                                         ByVal p_fechaFin As Integer,
                                         ByVal p_ocini As String,
                                         ByVal p_ocfin As String) As DataSet


        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.AppSettings.Item("strOracleGT").ToString()
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call DSP_REQUISICION_SELECT_OC(?,?,?,?,?,?,?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.CommandTimeout = 120
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("p_co", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("p_TipoDoc", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("p_NumDoc_Ini", ParameterDirection.Input)
            Dim P4 As New OdbcParameter("p_NumDoc_Fin", ParameterDirection.Input)
            Dim P5 As New OdbcParameter("p_fechaIni", ParameterDirection.Input)
            Dim P6 As New OdbcParameter("p_fechaFin", ParameterDirection.Input)
            Dim P7 As New OdbcParameter("p_ocini", ParameterDirection.Input)
            Dim P8 As New OdbcParameter("p_ocfin", ParameterDirection.Input)
            Dim P9 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)

            'Validacion de parametros y asignacion de los mismos
            If (p_co <> "") Then
                P1.Value = p_co
            End If

            If (p_TipoDoc <> "") Then
                P2.Value = p_TipoDoc
            End If

            If (p_NumDoc_Ini <> "") Then
                P3.Value = p_NumDoc_Ini
            End If

            If (p_NumDoc_Fin <> "") Then
                P4.Value = p_NumDoc_Fin
            End If

            If (p_fechaIni <> 0) Then
                P5.Value = p_fechaIni
            End If

            If (p_fechaFin <> 0) Then
                P6.Value = p_fechaFin
            End If

            If (p_ocini <> "") Then
                P7.Value = p_ocini
            End If

            If (p_ocfin <> "") Then
                P8.Value = p_ocfin
            End If


            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)
            comando.Parameters.Add(P4)
            comando.Parameters.Add(P5)
            comando.Parameters.Add(P6)
            comando.Parameters.Add(P7)
            comando.Parameters.Add(P8)
            comando.Parameters.Add(P9)

            'asigna el comando con los parametro al dataadapter yrealiza la consulta
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            If dsResultado.Tables.Count = 1 Then
                Return dsResultado
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Public Function DSP_QUITAR_PUNTOS_PED(ByVal p_co As String,
                                         ByVal p_TipoDoc As String,
                                         ByVal p_NumDoc_Ini As String,
                                         ByVal p_NumDoc_Fin As String,
                                         ByVal p_fechaIni As Integer,
                                         ByVal p_fechaFin As Integer,
                                         ByVal p_ocini As String,
                                         ByVal p_ocfin As String) As DataSet


        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.AppSettings.Item("strOracleGT").ToString()
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)

        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call DSP_QUITAR_PUNTOS_PED(?,?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.CommandTimeout = 120
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("p_co", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("p_TipoDoc", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("p_NumDoc_Ini", ParameterDirection.Input)
            Dim P4 As New OdbcParameter("p_NumDoc_Fin", ParameterDirection.Input)
            'Dim P5 As New OdbcParameter("p_fechaIni", ParameterDirection.Input)
            'Dim P6 As New OdbcParameter("p_fechaFin", ParameterDirection.Input)
            'Dim P7 As New OdbcParameter("p_ocini", ParameterDirection.Input)
            'Dim P8 As New OdbcParameter("p_ocfin", ParameterDirection.Input)


            'Validacion de parametros y asignacion de los mismos
            If (p_co <> "") Then
                P1.Value = p_co
            End If

            If (p_TipoDoc <> "") Then
                P2.Value = p_TipoDoc
            End If

            If (p_NumDoc_Ini <> "") Then
                P3.Value = p_NumDoc_Ini
            End If

            If (p_NumDoc_Fin <> "") Then
                P4.Value = p_NumDoc_Fin
            End If

            'If (p_fechaIni <> 0) Then
            '    P5.Value = p_fechaIni
            'End If

            'If (p_fechaFin <> 0) Then
            '    P6.Value = p_fechaFin
            'End If

            'If (p_ocini <> "") Then
            '    P7.Value = p_ocini
            'End If

            'If (p_ocfin <> "") Then
            '    P8.Value = p_ocfin
            'End If

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)
            comando.Parameters.Add(P4)
            'comando.Parameters.Add(P5)
            'comando.Parameters.Add(P6)
            'comando.Parameters.Add(P7)
            'comando.Parameters.Add(P8)

            comando.Connection.Open()
            comando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            comando.Parameters.Clear()
            comando.Connection.Close()
        End Try

    End Function


    Public Function DSP_QUITAR_PUNTOS_REQ(ByVal p_co As String,
                                         ByVal p_TipoDoc As String,
                                         ByVal p_NumDoc_Ini As String,
                                         ByVal p_NumDoc_Fin As String,
                                         ByVal p_fechaIni As Integer,
                                         ByVal p_fechaFin As Integer,
                                         ByVal p_ocini As String,
                                         ByVal p_ocfin As String) As DataSet


        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.AppSettings.Item("strOracleGT").ToString()
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call DSP_QUITAR_PUNTOS_REQ(?,?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.CommandTimeout = 120
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("p_co", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("p_TipoDoc", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("p_NumDoc_Ini", ParameterDirection.Input)
            Dim P4 As New OdbcParameter("p_NumDoc_Fin", ParameterDirection.Input)
            'Dim P5 As New OdbcParameter("p_fechaIni", ParameterDirection.Input)
            'Dim P6 As New OdbcParameter("p_fechaFin", ParameterDirection.Input)
            'Dim P7 As New OdbcParameter("p_ocini", ParameterDirection.Input)
            'Dim P8 As New OdbcParameter("p_ocfin", ParameterDirection.Input)


            'Validacion de parametros y asignacion de los mismos
            If (p_co <> "") Then
                P1.Value = p_co
            End If

            If (p_TipoDoc <> "") Then
                P2.Value = p_TipoDoc
            End If

            If (p_NumDoc_Ini <> "") Then
                P3.Value = p_NumDoc_Ini
            End If

            If (p_NumDoc_Fin <> "") Then
                P4.Value = p_NumDoc_Fin
            End If

            'If (p_fechaIni <> 0) Then
            '    P5.Value = p_fechaIni
            'End If

            'If (p_fechaFin <> 0) Then
            '    P6.Value = p_fechaFin
            'End If

            'If (p_ocini <> "") Then
            '    P7.Value = p_ocini
            'End If

            'If (p_ocfin <> "") Then
            '    P8.Value = p_ocfin
            'End If

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)
            comando.Parameters.Add(P4)
            'comando.Parameters.Add(P5)
            'comando.Parameters.Add(P6)
            'comando.Parameters.Add(P7)
            'comando.Parameters.Add(P8)


            comando.Connection.Open()
            comando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            comando.Parameters.Clear()
            comando.Connection.Close()
        End Try

    End Function


End Class
