Imports System.Data.SqlClient

Module ModuloSQL

    Public Function sp_WMS_UPLOAD_Transferencia_TBV_Desde_RQI() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Transferencia_TBV_Desde_RQI"
            sqlComando.CommandTimeout = 0

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


    Public Sub sp_A_Registrar_Log_Upload_Comprometer_Remisionar_Pedidos_PEV(ByVal bitResultado As Boolean,
                                                                             Optional cia As String = "Sin Datos",
                                                                             Optional co As String = "Sin Datos",
                                                                             Optional tipoDoc As String = "Sin Datos",
                                                                             Optional numDoc As String = "Sin Datos",
                                                                             Optional RowIdEnc As String = "Sin Datos",
                                                                             Optional OEX As String = "Sin Datos",
                                                                             Optional datosEnviadosGT As String = "Sin Datos",
                                                                             Optional datosEnviadosUNOEE As String = "Sin Datos",
                                                                             Optional datosEnviadosExcepcion As String = "Sin Datos",
                                                                             Optional detalleResultado As String = "Sin Datos")

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_A_Registrar_Log_Upload_Comprometer_Remisionar_Pedidos_PEV"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@bitResultado", bitResultado)
            sqlComando.Parameters.AddWithValue("@cia", cia)
            sqlComando.Parameters.AddWithValue("@co", co)
            sqlComando.Parameters.AddWithValue("@tipoDoc", tipoDoc)
            sqlComando.Parameters.AddWithValue("@numDoc", numDoc)
            sqlComando.Parameters.AddWithValue("@RowIdEnc", RowIdEnc)
            sqlComando.Parameters.AddWithValue("@OEX", OEX)
            sqlComando.Parameters.AddWithValue("@datosEnviadosGT", datosEnviadosGT)
            sqlComando.Parameters.AddWithValue("@datosEnviadosUNOEE", datosEnviadosUNOEE)
            sqlComando.Parameters.AddWithValue("@datosEnviadosExcepcion", datosEnviadosExcepcion)
            sqlComando.Parameters.AddWithValue("@detalleResultado", detalleResultado)

            sqlConexion.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub

    Public Function sp_WMS_UPLOAD_Comprometer_PEV_Agrupado() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Comprometer_PEV_Agrupado"
            sqlComando.CommandTimeout = 0

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


    Public Function sp_WMS_UPLOAD_Comprometer_PEV_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Comprometer_PEV_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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


    Public Function sp_WMS_UPLOAD_Facturar_FV2_Agrupado() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Facturar_FV2_Agrupado"
            sqlComando.CommandTimeout = 0

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

    Public Function sp_WMS_UPLOAD_Facturar_FV2_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Facturar_FV2_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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



    Public Function sp_WMS_Comprometer_PEV_Dislicores_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_Comprometer_PEV_Dislicores_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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

    Public Function sp_WMS_Comprometer_PEV_Dialsa_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_Comprometer_PEV_Dialsa_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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



    Public Function sp_Pedidos_x_Remisionar_REV_Paquetes() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_Pedidos_x_Remisionar_REV_Paquetes"
            sqlComando.CommandTimeout = 0

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

    Public Function sp_Pedidos_x_Remisionar_REV_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_Pedidos_x_Remisionar_REV_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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


    Public Sub sp_WMS_UPLOAD_Facturar_FV2_Migrar()

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Facturar_FV2_Migrar"
            sqlComando.CommandTimeout = 0

            sqlConexion.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub


    Public Function sp_WMS_Facturar_FV2_Dislicores_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_Facturar_FV2_Dislicores_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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


    Public Function sp_WMS_Facturar_FV2_Dialsa_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_Facturar_FV2_Dialsa_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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


    Public Function sp_WMS_UPLOAD_Devoluciones_NV2_Desde_PDC_Agrupado() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Devoluciones_NV2_Desde_PDC_Agrupado"
            sqlComando.CommandTimeout = 0

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

    Public Function sp_WMS_Devoluciones_NV2_Desde_PDC_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_Devoluciones_NV2_Desde_PDC_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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

    Public Sub sp_WMS_UPLOAD_Devoluciones_NV2_Desde_PDC_Migrar()

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Devoluciones_NV2_Desde_PDC_Migrar"
            sqlComando.CommandTimeout = 0

            sqlConexion.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub


    Public Function sp_WMS_UPLOAD_Devoluciones_NV2_Desde_EDE_Agrupado() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Devoluciones_NV2_Desde_EDE_Agrupado"
            sqlComando.CommandTimeout = 0

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

    Public Function sp_WMS_UPLOAD_Devoluciones_NV2_Desde_EDE_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Devoluciones_NV2_Desde_EDE_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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

    Public Sub sp_WMS_UPLOAD_Devoluciones_NV2_Desde_EDE_Migrar()

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Devoluciones_NV2_Desde_EDE_Migrar"
            sqlComando.CommandTimeout = 0

            sqlConexion.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub


    Public Sub sp_WMS_UPLOAD_Salida_TCO_desde_RQT_Migrar()

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Salida_TCO_desde_RQT_Migrar"
            sqlComando.CommandTimeout = 0

            sqlConexion.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub



    Public Sub sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_Migrar()

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_Migrar"
            sqlComando.CommandTimeout = 0

            sqlConexion.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub

    Public Function sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_Agrupado() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_Agrupado"
            sqlComando.CommandTimeout = 0

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

    Public Function sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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


    Public Sub sp_WMS_UPLOAD_Entrada_ECP_desde_OCP_Migrar()

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlComando As SqlCommand = New SqlCommand

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Entrada_ECP_desde_OCP_Migrar"
            sqlComando.CommandTimeout = 0

            sqlConexion.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub

    Public Function sp_WMS_UPLOAD_Entrada_ECP_desde_OCP_Agrupado() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Entrada_ECP_desde_OCP_Agrupado"
            sqlComando.CommandTimeout = 0

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

    Public Function sp_WMS_UPLOAD_Entrada_ECP_desde_OCP_Detalle(ByVal paquete As String) As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_WMS_UPLOAD_Entrada_ECP_desde_OCP_Detalle"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@paquete", paquete)

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



    Public Sub RegistrarLogMigracion(Optional ProcesoPrincipal As String = "",
                            Optional procesoSecundario As String = "",
                            Optional estado As String = "",
                            Optional resultado As String = "",
                            Optional resultadoDetalle As String = "")

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(My.Settings.strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_registrarLogMigraciones"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@ProcesoPrincipal", ProcesoPrincipal)
            sqlComando.Parameters.AddWithValue("@procesoSecundario", procesoSecundario)
            sqlComando.Parameters.AddWithValue("@estado", estado)
            sqlComando.Parameters.AddWithValue("@resultado", resultado)
            sqlComando.Parameters.AddWithValue("@resultadoDetalle", resultadoDetalle)

            sqlComando.Connection.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub

    Public Sub LimpiarTablasSQL(ByVal nombreTabla As String)

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        sp_A_registrar_Log_Upload_Siesa(,,,, "LimpiarTablasSQ", "Inicio")

        Try

            sqlConexion = New SqlConnection(My.Settings.strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.Text
            sqlComando.CommandText = "delete from " & nombreTabla
            sqlComando.CommandTimeout = 0

            sqlComando.Connection.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            sp_A_registrar_Log_Upload_Siesa(,,,, "LimpiarTablasSQ " & nombreTabla, "Fin", "Error", ex.Message)
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        sp_A_registrar_Log_Upload_Siesa(,,,, "LimpiarTablasSQ " & nombreTabla, "Fin", "OK")

    End Sub

    Public Sub Guardar_en_BD_x_BulkCopy(ByVal nombreTablaBulkCopy As String, ByVal Datos As DataTable)

        Dim sqlConexion As SqlConnection
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sp_A_registrar_Log_Upload_Siesa(,,,, "Copiando datos de Oracle a tablaSQL " & nombreTablaBulkCopy, "Inicio")

            sqlConexion = New SqlConnection(My.Settings.strConexionSQL)

            sqlConexion.Open()

            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(sqlConexion)
                bulkCopy.DestinationTableName = "dbo." & nombreTablaBulkCopy
                bulkCopy.WriteToServer(Datos)
            End Using

            Datos.Dispose()

        Catch ex As Exception
            sp_A_registrar_Log_Upload_Siesa(,,,, "Copiando datos de Oracle a tablaSQL " & nombreTablaBulkCopy, "Fin", "Error", ex.Message)
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

        sp_A_registrar_Log_Upload_Siesa(,,,, "Copiando datos de Oracle a tablaSQL " & nombreTablaBulkCopy, "Fin", "OK")

    End Sub


    Public Function consultarFuenteDatos() As DataSet

        Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
        Dim sqlAdaptador As New SqlDataAdapter
        Dim sqlComando As SqlCommand = New SqlCommand
        Dim ds As New DataSet

        Try
            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "V_WMS_RemisionDesdePedidos"
            sqlComando.CommandTimeout = 0

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

    Public Sub sp_A_registrar_Log_Upload_Siesa(Optional cia As String = "",
                                     Optional co As String = "",
                                     Optional tipoDoc As String = "",
                                     Optional numDoc As String = "",
                                     Optional proceso As String = "",
                                     Optional estado As String = "",
                                     Optional resultado As String = "",
                                     Optional resultadoDetalle As String = "")

        Dim sqlConexion As SqlConnection
        Dim sqlComando As SqlCommand = New SqlCommand

        Try

            sqlConexion = New SqlConnection(My.Settings.strConexionSQL)

            sqlComando.Connection = sqlConexion
            sqlComando.CommandType = CommandType.StoredProcedure
            sqlComando.CommandText = "sp_A_registrar_Log_Upload_Siesa"
            sqlComando.CommandTimeout = 0

            sqlComando.Parameters.AddWithValue("@cia", cia)
            sqlComando.Parameters.AddWithValue("@co", co)
            sqlComando.Parameters.AddWithValue("@tipoDoc", tipoDoc)
            sqlComando.Parameters.AddWithValue("@numDoc", numDoc)
            sqlComando.Parameters.AddWithValue("@proceso", proceso)
            sqlComando.Parameters.AddWithValue("@estado", estado)
            sqlComando.Parameters.AddWithValue("@resultado", resultado)
            sqlComando.Parameters.AddWithValue("@resultadoDetalle", resultadoDetalle)

            sqlComando.Connection.Open()
            sqlComando.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            sqlConexion.Close()
            sqlComando.Parameters.Clear()
            sqlComando.Connection.Close()
        End Try

    End Sub


End Module



'Dim cia, co, tipoDoc, numDoc As String

'Public Function capturarDatosPaquetes(ByVal idProceso As String) As DataSet

'    Dim dsDatos As New DataSet

'    Try

'        sp_A_registrar_Log_Upload_Siesa(,,,, "Consultando Paquetes en SQL proceso: " & idProceso, "Inicio")

'        Select Case idProceso

'            'Case "1"
'            '    dsDatos = sp_WMS_Comprometer_PEV_Dislicores_Agrupado()

'            'Case "2"
'            '    dsDatos = sp_WMS_Comprometer_PEV_Dialsa_Agrupado()

'            'Case "3"
'            '    dsDatos = sp_WMS_Facturar_FV2_Dislicores_Agrupado()

'            'Case "4"
'            '    dsDatos = sp_WMS_Facturar_FV2_Dialsa_Agrupado()


'            'Case "5"
'            '    dsDatos = sp_WMS_Entrada_ECP_desde_OCP_Agrupado()

'            'Case "6"
'            '    dsDatos = sp_WMS_Entrada_TCE_desde_TCO_Agrupado()


'        End Select

'        sp_A_registrar_Log_Upload_Siesa(, , , , "Consultando Paquetes en SQL proceso: " & idProceso, "Fin", "OK")

'    Catch ex As Exception
'        sp_A_registrar_Log_Upload_Siesa(, , , , "Consultando Paquetes en SQL proceso: " & idProceso, "Fin", "Error", ex.Message)
'        Throw ex
'    End Try

'    Return dsDatos


'End Function

'Public Function sp_WMS_Comprometer_PEV_Dislicores_Agrupado() As DataSet

'    Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
'    Dim sqlAdaptador As New SqlDataAdapter
'    Dim sqlComando As SqlCommand = New SqlCommand
'    Dim ds As New DataSet

'    Try
'        sqlComando.Connection = sqlConexion
'        sqlComando.CommandType = CommandType.StoredProcedure
'        sqlComando.CommandText = "sp_WMS_Comprometer_PEV_Dislicores_Agrupado"
'        sqlComando.CommandTimeout = 0

'        sqlConexion.Open()
'        sqlAdaptador.SelectCommand = sqlComando
'        sqlAdaptador.Fill(ds)


'    Catch ex As Exception
'        Throw ex
'    Finally
'        sqlConexion.Close()
'        sqlComando.Parameters.Clear()
'        sqlComando.Connection.Close()
'    End Try

'    Return ds

'End Function

'Public Function sp_WMS_Comprometer_PEV_Dialsa_Agrupado() As DataSet

'    Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
'    Dim sqlAdaptador As New SqlDataAdapter
'    Dim sqlComando As SqlCommand = New SqlCommand
'    Dim ds As New DataSet

'    Try
'        sqlComando.Connection = sqlConexion
'        sqlComando.CommandType = CommandType.StoredProcedure
'        sqlComando.CommandText = "sp_WMS_Comprometer_PEV_Dialsa_Agrupado"
'        sqlComando.CommandTimeout = 0

'        sqlConexion.Open()
'        sqlAdaptador.SelectCommand = sqlComando
'        sqlAdaptador.Fill(ds)


'    Catch ex As Exception
'        Throw ex
'    Finally
'        sqlConexion.Close()
'        sqlComando.Parameters.Clear()
'        sqlComando.Connection.Close()
'    End Try

'    Return ds

'End Function




'Public Function sp_WMS_Facturar_FV2_Dislicores_Agrupado() As DataSet

'    Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
'    Dim sqlAdaptador As New SqlDataAdapter
'    Dim sqlComando As SqlCommand = New SqlCommand
'    Dim ds As New DataSet

'    Try
'        sqlComando.Connection = sqlConexion
'        sqlComando.CommandType = CommandType.StoredProcedure
'        sqlComando.CommandText = "sp_WMS_Facturar_FV2_Dislicores_Agrupado"
'        sqlComando.CommandTimeout = 0

'        sqlConexion.Open()
'        sqlAdaptador.SelectCommand = sqlComando
'        sqlAdaptador.Fill(ds)


'    Catch ex As Exception
'        Throw ex
'    Finally
'        sqlConexion.Close()
'        sqlComando.Parameters.Clear()
'        sqlComando.Connection.Close()
'    End Try

'    Return ds

'End Function

'Public Function sp_WMS_Facturar_FV2_Dialsa_Agrupado() As DataSet

'    Dim sqlConexion As New SqlConnection(My.Settings.strConexionSQL)
'    Dim sqlAdaptador As New SqlDataAdapter
'    Dim sqlComando As SqlCommand = New SqlCommand
'    Dim ds As New DataSet

'    Try
'        sqlComando.Connection = sqlConexion
'        sqlComando.CommandType = CommandType.StoredProcedure
'        sqlComando.CommandText = "sp_WMS_Facturar_FV2_Dialsa_Agrupado"
'        sqlComando.CommandTimeout = 0

'        sqlConexion.Open()
'        sqlAdaptador.SelectCommand = sqlComando
'        sqlAdaptador.Fill(ds)


'    Catch ex As Exception
'        Throw ex
'    Finally
'        sqlConexion.Close()
'        sqlComando.Parameters.Clear()
'        sqlComando.Connection.Close()
'    End Try

'    Return ds

'End Function
