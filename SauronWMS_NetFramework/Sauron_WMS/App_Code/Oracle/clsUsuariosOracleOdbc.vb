Imports Microsoft.VisualBasic
Imports System.Data.Odbc.OdbcDataAdapter
Imports System.Data.Odbc
Imports System.Data
Imports System

Public Class clsUsuariosOracleOdbc

    Public Function SP_Pedidos_X_Cliente(ByVal P_idUsuario As String) As DataTable


        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_PEDIDOS_X_CLIENTE(?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("P_idUsuario", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)

            'Validacion de parametros y asignacion de los mismos
            If (P_idUsuario <> "") Then
                P1.Value = P_idUsuario
            End If


            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)


            'asigna el comando con los parametro al dataadapter yrealiza la consulta
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            If dsResultado.Tables.Count = 1 Then
                Return dsResultado.Tables(0)
            End If

        Catch ex As Exception
            Throw ex.InnerException
        End Try

    End Function

    Public Sub actualizarUsuario(ByVal P_IdUsurario As Integer, ByVal P_Clave As String, ByVal P_Direccion1 As String, _
                                 ByVal P_Direccion2 As String, ByVal P_Direccion3 As String, ByVal P_Telefono As String, _
                                 ByVal P_Contacto As String, ByVal P_IdDpto As String, ByVal P_DescDpto As String, _
                                 ByVal P_IdCiudad As String, ByVal P_DescCiudad As String)
        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_ACTUALIZAR_USUARIO(?,?,?,?,?,?,?,?,?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("P_IdUsurario", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("P_Clave", ParameterDirection.Input)
            ' Dim P3 As New odbcparameter("P_Correo",  ParameterDirection.Input)
            Dim P4 As New OdbcParameter("P_Direccion1", ParameterDirection.Input)
            Dim P5 As New OdbcParameter("P_Direccion2", ParameterDirection.Input)
            Dim P6 As New OdbcParameter("P_Direccion3", ParameterDirection.Input)
            Dim P7 As New OdbcParameter("P_Telefono", ParameterDirection.Input)
            Dim P8 As New OdbcParameter("P_Contacto", ParameterDirection.Input)
            Dim P9 As New OdbcParameter("P_IdDDpto", ParameterDirection.Input)
            Dim P10 As New OdbcParameter("P_DescDpto", ParameterDirection.Input)
            Dim P11 As New OdbcParameter("P_IdCiudad", ParameterDirection.Input)
            Dim P12 As New OdbcParameter("P_DescCiudad", ParameterDirection.Input)
            Dim P13 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)

            'Validacion de parametros y asignacion de los mismos

            P1.Value = P_IdUsurario

            P2.Value = P_Clave

            P4.Value = P_Direccion1

            P5.Value = P_Direccion2

            P6.Value = P_Direccion3

            P7.Value = P_Telefono

            P8.Value = P_Contacto

            P9.Value = P_IdDpto

            P10.Value = P_DescDpto

            P11.Value = P_IdCiudad

            P12.Value = P_DescCiudad

            ' P3.Value = P_Correo

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            'comando.Parameters.Add(P3)
            comando.Parameters.Add(P4)
            comando.Parameters.Add(P5)
            comando.Parameters.Add(P6)
            comando.Parameters.Add(P7)
            comando.Parameters.Add(P8)
            comando.Parameters.Add(P9)
            comando.Parameters.Add(P10)
            comando.Parameters.Add(P11)
            comando.Parameters.Add(P12)

            'asigna el comando con los parametros y la conexion al dataadpter
            conn.Open()
            Adaptador.SelectCommand = comando
            comando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex.InnerException
        Finally
            conn.Close()
        End Try

    End Sub

    Public Sub actualizarVendedor(ByVal P_IdUsurario As Integer, ByVal P_Cedula As String, _
                                  ByVal P_Nombres As String, ByVal P_Clave As String, _
                                  ByVal P_Correo As String, ByVal P_Telefono As String)

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_ACTUALIZAR_VENDEDOR(?,?,?,?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("P_IdUsurario", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("P_Cedula", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("P_Nombres", ParameterDirection.Input)
            Dim P4 As New OdbcParameter("P_Clave", ParameterDirection.Input)
            Dim P5 As New OdbcParameter("P_Correo", ParameterDirection.Input)
            Dim P6 As New OdbcParameter("P_Telefono", ParameterDirection.Input)
           

            'Validacion de parametros y asignacion de los mismos

            P1.Value = CInt(P_IdUsurario)

            P2.Value = P_Cedula

            P3.Value = P_Nombres

            P4.Value = P_Clave

            P5.Value = P_Correo

            P6.Value = P_Telefono
          
            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)
            comando.Parameters.Add(P4)
            comando.Parameters.Add(P5)
            comando.Parameters.Add(P6)

            'asigna el comando con los parametros y la conexion al dataadpter
            conn.Open()
            Adaptador.SelectCommand = comando
            comando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex.InnerException
        Finally
            conn.Close()
        End Try

    End Sub
    Public Sub eliminarEstadisticas(ByVal P_IdUsurario As Integer, ByVal P_idPerfil As Integer)

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_ELIMINAR_ESTADISTICAS(?,?)}", conn)


        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure

        'Intancia nuevo parametro para oracle e indica los argumentos
        Dim P1 As New OdbcParameter("P_IdUsurario", ParameterDirection.Input)
        Dim P2 As New OdbcParameter("P_idPerfil", ParameterDirection.Input)
        'Validacion de parametros y asignacion de los mismos
        If (P_IdUsurario <> 0) Then
            P1.Value = P_IdUsurario
        End If

        If (P_idPerfil <> 0) Then
            P2.Value = P_idPerfil
        End If

        'Añade los parametros al comando
        comando.Parameters.Add(P1)
        comando.Parameters.Add(P2)


        'asigna el comando con los parametros y la conexion al dataadpter
        conn.Open()
        Adaptador.SelectCommand = comando
        comando.ExecuteNonQuery()

        conn.Close()

    End Sub
    'Public Function eliminarPedidosUsuario(ByVal P_IdUsurario As Integer, ByVal P_idPerfil As Integer) As DataTable

    '    'String de conexion
    '    Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
    '    'Instancia de conexion con el String de conexion ya creado como parametro
    '    Dim conn As New OdbcConnection(oradb)
    '    'Intancia un nuevo dataadapter para oracle
    '    Dim Adaptador As New OdbcDataAdapter
    '    'Intancia un nuevo dataset
    '    Dim dsResultado As New DataSet
    '    'Intancia de comandos oracle
    '    Dim comando As New OdbcCommand("{call SP_ELIMINAR_PED_USER(?,?)}", conn)

    '    Try
    '        'Asignacion de Coneccion y Tipo de comando
    '        comando.Connection = conn
    '        comando.CommandType = CommandType.StoredProcedure

    '        'Intancia nuevo parametro para oracle e indica los argumentos
    '        Dim P1 As New OdbcParameter("P_IdUsurario", ParameterDirection.Input)
    '        Dim P2 As New OdbcParameter("P_idPerfil", ParameterDirection.Input)
    '        'Validacion de parametros y asignacion de los mismos
    '        If (P_IdUsurario <> 0) Then
    '            P1.Value = P_IdUsurario
    '        End If

    '        If (P_idPerfil <> 0) Then
    '            P2.Value = P_idPerfil
    '        End If

    '        'Añade los parametros al comando
    '        comando.Parameters.Add(P1)
    '        comando.Parameters.Add(P2)


    '        'asigna el comando con los parametros y la conexion al dataadpter
    '        'asigna el comando con los parametros y la conexion al dataadpter
    '        conn.Open()
    '        Adaptador.SelectCommand = comando
    '        Adaptador.Fill(dsResultado)

    '        Return dsResultado.Tables(0)

    '    Catch ex As Exception
    '        Throw ex.InnerException
    '    Finally
    '        conn.Close()
    '    End Try

    '    conn.Close()

    'End Function

    Public Sub eliminarPedidosUsuario(ByVal P_IdPedido As Integer)

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_ELIMINAR_PED_USER(?)}", conn)


        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure

        'Intancia nuevo parametro para oracle e indica los argumentos
        Dim P1 As New OdbcParameter("P_IdPedido", ParameterDirection.Input)

        'Validacion de parametros y asignacion de los mismos
        If (P_IdPedido <> 0) Then
            P1.Value = P_IdPedido
        End If

        'Añade los parametros al comando
        comando.Parameters.Add(P1)

        'asigna el comando con los parametros y la conexion al dataadpter
        conn.Open()
        Adaptador.SelectCommand = comando
        comando.ExecuteNonQuery()

        conn.Close()

    End Sub
    Public Sub eliminarUsuario(ByVal P_IdUsurario As Integer, ByVal P_idPerfil As Integer)

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_ELIMINAR_USUARIO(?,?)}", conn)


        'Asignacion de Coneccion y Tipo de comando
        comando.Connection = conn
        comando.CommandType = CommandType.StoredProcedure

        'Intancia nuevo parametro para oracle e indica los argumentos
        Dim P1 As New OdbcParameter("P_IdUsurario", ParameterDirection.Input)
        Dim P2 As New OdbcParameter("P_idPerfil", ParameterDirection.Input)
        'Validacion de parametros y asignacion de los mismos
        If (P_IdUsurario <> 0) Then
            P1.Value = P_IdUsurario
        End If

        If (P_idPerfil <> 0) Then
            P2.Value = P_idPerfil
        End If

        'Añade los parametros al comando
        comando.Parameters.Add(P1)
        comando.Parameters.Add(P2)


        'asigna el comando con los parametros y la conexion al dataadpter
        conn.Open()
        Adaptador.SelectCommand = comando
        comando.ExecuteNonQuery()

        conn.Close()

    End Sub

    Public Function seleccionarRazonSocial(ByVal P_IdUsurario As Integer, ByVal idPerfil As String) As DataTable

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_SELECT_RAZONSOCIAL(?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("P_IdUsurario", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("P_idPerfil", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
            If (P_IdUsurario <> 0) Then
                P1.Value = P_IdUsurario
            End If

            If (idPerfil <> "") Then
                P2.Value = idPerfil
            End If

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)


            'asigna el comando con los parametros y la conexion al dataadpter
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            Return dsResultado.Tables(0)

        Catch ex As Exception
            Throw ex.InnerException
        Finally
            conn.Close()
        End Try


    End Function


    Public Function SP_SELECT_USUARIO(ByVal P_nitProv As String, ByVal P_idPerfil As String) As DataTable

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_SELECT_USUARIO(?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            Dim P1 As New OdbcParameter("P_nitProv", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("P_idPerfil", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
            If (P_nitProv <> "0") Then
                P1.Value = P_nitProv
            End If
            If (P_idPerfil <> "0") Then
                P2.Value = P_idPerfil
            End If

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)

            'asigna el comando con los parametros y la conexion al dataadpter
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            Return dsResultado.Tables(0)

        Catch ex As Exception
            Throw ex.InnerException
        Finally
            conn.Close()
        End Try


    End Function

    Public Function SP_SELECT_USUARIOS(ByVal P_idPerfil As Integer, ByVal P_Nit As String) As DataTable

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_SELECT_USUARIOS(?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            Dim P1 As New OdbcParameter("P_idPerfil", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("P_Nit", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)

            If (P_idPerfil <> 0) Then
                P1.Value = P_idPerfil
            End If

            If (P_Nit <> "") Then
                P2.Value = P_Nit
            End If

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)

            'asigna el comando con los parametros y la conexion al dataadpter
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            Return dsResultado.Tables(0)

        Catch ex As Exception
            Throw ex.InnerException
        Finally
            conn.Close()
        End Try


    End Function


    Public Function SP_SELECT_VENDEDORES(ByVal P_idPerfil As Integer, ByVal P_Nit As String) As DataTable

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_SELECT_VENDEDORES(?,?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            Dim P1 As New OdbcParameter("P_idPerfil", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("P_Nit", ParameterDirection.Input)
            Dim P3 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)

            If (P_idPerfil <> 0) Then
                P1.Value = P_idPerfil
            End If

            If (P_Nit <> "") Then
                P2.Value = P_Nit
            End If

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)
            comando.Parameters.Add(P3)

            'asigna el comando con los parametros y la conexion al dataadpter
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            Return dsResultado.Tables(0)

        Catch ex As Exception
            Throw ex.InnerException
        Finally
            conn.Close()
        End Try


    End Function

    Public Function SP_SELECT_GT_DEPARTAMENTO() As DataTable

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_SELECT_GT_DEPARTAMENTO(?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            'Intancia nuevo parametro para oracle e indica los argumentos
            Dim P1 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)

            'Añade los parametros al comando
            comando.Parameters.Add(P1)

            'asigna el comando con los parametros y la conexion al dataadpter
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            Return dsResultado.Tables(0)

        Catch ex As Exception
            Throw ex.InnerException
        Finally
            conn.Close()
        End Try


    End Function


    Public Function SP_SELECT_GT_CIUDAD(ByVal P_IdDpto As String) As DataTable

        'String de conexion
        Dim oradb As String = System.Configuration.ConfigurationManager.ConnectionStrings.Item("ConnectionStringOracleODBC").ToString
        'Instancia de conexion con el String de conexion ya creado como parametro
        Dim conn As New OdbcConnection(oradb)
        'Intancia un nuevo dataadapter para oracle
        Dim Adaptador As New OdbcDataAdapter
        'Intancia un nuevo dataset
        Dim dsResultado As New DataSet
        'Intancia de comandos oracle
        Dim comando As New OdbcCommand("{call SP_SELECT_GT_CIUDAD(?,?)}", conn)

        Try
            'Asignacion de Coneccion y Tipo de comando
            comando.Connection = conn
            comando.CommandType = CommandType.StoredProcedure

            Dim P1 As New OdbcParameter("P_IdDpto", ParameterDirection.Input)
            Dim P2 As New OdbcParameter("P_CURSOR", ParameterDirection.Output)
            If (P_IdDpto <> "") Then
                P1.Value = CInt(P_IdDpto)
            End If

            'Añade los parametros al comando
            comando.Parameters.Add(P1)
            comando.Parameters.Add(P2)

            'asigna el comando con los parametros y la conexion al dataadpter
            conn.Open()
            Adaptador.SelectCommand = comando
            Adaptador.Fill(dsResultado)

            Return dsResultado.Tables(0)

        Catch ex As Exception
            Throw ex.InnerException
        Finally
            conn.Close()
        End Try


    End Function

End Class
