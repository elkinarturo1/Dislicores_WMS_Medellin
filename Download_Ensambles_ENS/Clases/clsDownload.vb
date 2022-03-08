Public Class clsDownload

    'Dim objEnviarDatosION As New clsEnviarDatos_ION

    '''' <summary>
    '''' Realiza la consulta principal y lleva los datos a una tabla temporal en oracle,
    '''' la tabla temporal se limpia en cada ejecucion,
    '''' es necesario llevar los datos a una tabla para capturar posteriormente SKU y Terceros
    '''' </summary>
    'Public Sub Paso_1_migracion_Datos_a_TablasTemp_Oracle(ByRef objDownload As clsModeloDownloadGenerico)
    '    Try
    '        limpiar_Tabla_Oracle(objDownload.Tabla_Datos_ORACLE)
    '        ejecutar_SP_Oracle(objDownload.SP_Migracion_ORACLE)
    '        'sp_registrarLog_Download_WMS(, , , , "Paso 1 - migracion_Datos_a_TablasTemp_Oracle : " & objDownload.Proceso, "Fin", "OK")
    '    Catch ex As Exception
    '        objDownload.BitError = True
    '        sp_registrarLog_Download_WMS(, , , , "Paso 1 - migracion_Datos_a_TablasTemp_Oracle : " & objDownload.Proceso, "Fin", "Error", ex.Message)
    '    End Try
    'End Sub


    '''' <summary>
    '''' Consulta los datos de la tabla temporal en Oracle
    '''' y las vistas de SKU y Terceros en Oracle para
    '''' guardar los datos en memoria y llevalor a SQL
    '''' </summary>
    'Public Sub Paso_2_extraccion_Datos_TablasTemp_Oracle(ByRef objDownload As clsModeloDownloadGenerico)
    '    If objDownload.BitError = False Then
    '        Try

    '            select_Tablas_Oracle(objDownload.dsDatos_Oracle, objDownload.Tabla_Datos_ORACLE)
    '            select_Tablas_Oracle(objDownload.dsTerceros_Oracle, objDownload.Vista_Tercero_ORACLE)
    '            select_Tablas_Oracle(objDownload.dsSKU_Oracle, objDownload.Vista_SKU_ORACLE)

    '            'sp_registrarLog_Download_WMS(, , , , "Paso 2 - extraccion_Datos_TablasTemp_Oracle : " & objDownload.Proceso, "Fin", "OK")

    '        Catch ex As Exception
    '            objDownload.BitError = True
    '            'sp_registrarLog_Download_WMS(, , , , "Paso 2 - extraccion_Datos_TablasTemp_Oracle : " & objDownload.Proceso, "Fin", "Error", ex.Message)
    '        End Try
    '    End If
    'End Sub


    '''' <summary>
    '''' Copia los datos guardados en memoria y los lleva
    '''' a tablas temporales en SQL, las tablas temporales
    '''' se limpian en cada ejecucion
    '''' </summary>
    'Public Sub Paso_3_migracion_Datos_Oracle_a_SQL(ByRef objDownload As clsModeloDownloadGenerico)

    '    If objDownload.BitError = False Then
    '        Try
    '            '=================================================================================================
    '            'Datos principales
    '            If objDownload.BitError = False Then
    '                Try
    '                    If objDownload.dsDatos_Oracle.Tables.Count > 0 Then
    '                        If objDownload.dsDatos_Oracle.Tables(0).Rows.Count > 0 Then
    '                            limpiarTabla(objDownload.Tabla_Datos_SQL)
    '                            Guardar_en_BD_x_BulkCopy(objDownload.dsDatos_Oracle.Tables(0), objDownload.Tabla_Datos_SQL)
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    objDownload.BitError = True
    '                    'sp_registrarLog_Download_WMS(, , , , "Paso 3 - migracion_Datos_Oracle_a_SQL : " & objDownload.Proceso, "Fin", "Error en datos principales", ex.Message)
    '                End Try
    '            End If
    '            '=================================================================================================


    '            '=================================================================================================
    '            'Terceros
    '            If objDownload.BitError = False Then
    '                Try
    '                    If objDownload.dsTerceros_Oracle.Tables.Count > 0 Then
    '                        If objDownload.dsTerceros_Oracle.Tables(0).Rows.Count > 0 Then
    '                            limpiarTabla(objDownload.Tabla_Tercero_SQL)
    '                            Guardar_en_BD_x_BulkCopy(objDownload.dsTerceros_Oracle.Tables(0), objDownload.Tabla_Tercero_SQL)
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    objDownload.BitError = True
    '                    'sp_registrarLog_Download_WMS(, , , , "Paso 3 - migracion_Datos_Oracle_a_SQL : " & objDownload.Proceso, "Fin", "Error en Terceros", ex.Message)
    '                End Try
    '            End If
    '            '=================================================================================================


    '            '=================================================================================================
    '            'SKU
    '            If objDownload.BitError = False Then
    '                Try
    '                    If objDownload.dsSKU_Oracle.Tables.Count > 0 Then
    '                        If objDownload.dsSKU_Oracle.Tables(0).Rows.Count > 0 Then
    '                            limpiarTabla(objDownload.Tabla_SKU_SQL)
    '                            Guardar_en_BD_x_BulkCopy(objDownload.dsSKU_Oracle.Tables(0), objDownload.Tabla_SKU_SQL)
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    objDownload.BitError = True
    '                    'sp_registrarLog_Download_WMS(, , , , "Paso 3 - migracion_Datos_Oracle_a_SQL : " & objDownload.Proceso, "Fin", "Error en SKU", ex.Message)
    '                End Try
    '            End If
    '            '=================================================================================================

    '            'sp_registrarLog_Download_WMS(, , , , "Paso 3 - migracion_Datos_Oracle_a_SQL : " & objDownload.Proceso, "Fin", "OK")

    '        Catch ex As Exception
    '            objDownload.BitError = True
    '            'sp_registrarLog_Download_WMS(, , , , "Paso 3 - migracion_Datos_Oracle_a_SQL : " & objDownload.Proceso, "Fin", "Error Generico", ex.Message)
    '        End Try
    '    End If

    'End Sub


    '''' <summary>
    '''' La informacion traida de Oracle que se copió previamente en las tablas
    '''' temporales de SQL se compara con las tablas de WMS, para validar
    '''' que datos se enviaran y que datos no deben enviarse a WMS,
    '''' separando solamente la informacion a enviar
    '''' </summary>
    'Public Sub Paso_4_comparacion_DatosSQL_con_WMS_y_Captura__Datos_Pendientes_x_Enviar(ByRef objDownload As clsModeloDownloadGenerico)

    '    If objDownload.BitError = False Then

    '        Try

    '            '=================================================================================================
    '            'Datos Principales
    '            If objDownload.BitError = False Then
    '                Try
    '                    select_Tablas_SQL(objDownload.dsPaquetes, objDownload.Vista_DatosAgrup_SQL)
    '                    ejecutar_sp_Download_SQL(objDownload.DS_Datos_SQL, objDownload.SP_Datos_SQL)
    '                Catch ex As Exception
    '                    objDownload.BitError = True
    '                    'sp_registrarLog_Download_WMS(, , , , "Paso 4 - comparacion_DatosSQL_con_WMS_y_Captura__Datos_Pendientes_x_Enviar : " & objDownload.Proceso, "Fin", "Error Datos Principales", ex.Message)
    '                End Try
    '            End If
    '            '=================================================================================================


    '            '=================================================================================================
    '            'Terceros
    '            If objDownload.BitError = False Then
    '                Try
    '                    ejecutar_sp_Download_SQL(objDownload.DS_Tercero_SQL, objDownload.SP_Terceros_SQL)
    '                Catch ex As Exception
    '                    objDownload.BitError = True
    '                    'sp_registrarLog_Download_WMS(, , , , "Paso 4 - comparacion_DatosSQL_con_WMS_y_Captura__Datos_Pendientes_x_Enviar : " & objDownload.Proceso, "Fin", "Error Tercero", ex.Message)
    '                End Try
    '            End If
    '            '=================================================================================================


    '            '=================================================================================================
    '            'SKU
    '            If objDownload.BitError = False Then
    '                Try
    '                    ejecutar_sp_Download_SQL(objDownload.DS_Tercero_SQL, objDownload.SP_SKU_SQL)
    '                Catch ex As Exception
    '                    objDownload.BitError = True
    '                    'sp_registrarLog_Download_WMS(, , , , "Consulta de sku e enviar : " & objDownload.Proceso, "Fin", "Error SKU", ex.Message)
    '                End Try
    '            End If
    '            '=================================================================================================

    '            'sp_registrarLog_Download_WMS(, , , , "Paso 4 - comparacion_DatosSQL_con_WMS_y_Captura__Datos_Pendientes_x_Enviar : " & objDownload.Proceso, "Fin", "OK")

    '        Catch ex As Exception
    '            objDownload.BitError = True
    '            'sp_registrarLog_Download_WMS(, , , , "Paso 4 - comparacion_DatosSQL_con_WMS_y_Captura__Datos_Pendientes_x_Enviar : " & objDownload.Proceso, "Fin", "Error Generico", ex.Message)
    '        End Try

    '    End If
    'End Sub


    '''' <summary>
    '''' Se inserta la informacion seleccionada de
    '''' Terceros y SKU en las tablas de ION
    '''' limpiando previamente el registro a sobreescribir
    '''' </summary>
    'Public Sub Paso_5_insersion_Terceros_y_SKU_a_ION(ByRef objDownload As clsModeloDownloadGenerico)

    '    If objDownload.BitError = False Then
    '        Try

    '            '=================================================================================================
    '            'Terceros
    '            If objDownload.BitError = False Then
    '                Try
    '                    objEnviarDatosION.enviar_STORER_ION(objDownload.DS_Tercero_SQL)
    '                    System.Threading.Thread.Sleep(10000)
    '                Catch ex As Exception
    '                    objDownload.BitError = True
    '                    'sp_registrarLog_Download_WMS(, , , , "Paso 5 - insersion_Terceros_y_SKU_a_ION :  " & objDownload.Proceso, "Fin", "Error Terceros", ex.Message)
    '                End Try
    '            End If
    '            '=================================================================================================

    '            '=================================================================================================
    '            'SKU
    '            If objDownload.BitError = False Then
    '                Try
    '                    objEnviarDatosION.enviar_SKU_ION(objDownload.DS_SKU_SQL)
    '                    System.Threading.Thread.Sleep(10000)
    '                Catch ex As Exception
    '                    objDownload.BitError = True
    '                    'sp_registrarLog_Download_WMS(, , , , "Paso 5 - insersion_Terceros_y_SKU_a_ION :  " & objDownload.Proceso, "Fin", "Error SKU", ex.Message)
    '                End Try
    '            End If
    '            '=================================================================================================

    '            'sp_registrarLog_Download_WMS(, , , , "Paso 5 - insersion_Terceros_y_SKU_a_ION : " & objDownload.Proceso, "Fin", "OK")

    '        Catch ex As Exception
    '            objDownload.BitError = True
    '            'sp_registrarLog_Download_WMS(, , , , "Paso 5 - insersion_Terceros_y_SKU_a_ION ", "Fin", "Error Generico", ex.Message)
    '        End Try

    '    End If

    'End Sub


End Class
