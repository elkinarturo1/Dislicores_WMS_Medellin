Imports System.Data
Imports Microsoft.VisualBasic

Public Class Proceso_Download_RQV


    Public Sub ejecutarProceso(ByRef bitError As Boolean, ByRef resultado As String, Optional externorderkey_key_doc As String = "-1")

        Dim objSQL As New Download_RQV_SQL
        Dim dspaquetes As New DataSet
        Dim dsTerceros As New DataSet
        Dim dsSkus As New DataSet
        Dim obj_Estructura_Download As New clsModeloDownloadGenerico


        Try

            obj_Estructura_Download.dsPaquetes = objSQL.sp_WMS_DOWNLOAD_Requisiciones_RQV_Interface_Agrup(externorderkey_key_doc)
            obj_Estructura_Download.DS_Datos_SQL = objSQL.sp_WMS_DOWNLOAD_Requisiciones_RQV_Interface(externorderkey_key_doc)

            insercion_Datos_Principales_ION(obj_Estructura_Download)

            If dspaquetes.Tables.Count > 0 Then
                If dspaquetes.Tables(0).Rows.Count > 0 Then

                    'dsSkus = objSQL.sp_WMS_DOWNLOAD_SKU_Pedidos_PEE()

                    'dsTerceros = ModuloSQL.sp_WMS_DOWNLOAD_Terceros_PEE()

                    obj_Estructura_Download.dsPaquetes = dspaquetes
                    'obj_Estructura_Download.DS_SKU_SQL = dsSkus
                    'obj_Estructura_Download.DS_Tercero_SQL = dsTerceros


                    'Paso 5
                    'Paso_5_insersion_Terceros_y_SKU_a_ION(obj_Estructura_Download)

                    'Paso 6
                    insercion_Datos_Principales_ION(obj_Estructura_Download)

                Else
                    bitError = True
                    resultado = "Todos los pedidos se encuentran en WMS"

                End If

            Else
                bitError = True
                resultado = "La consulta no trajo tablas"

            End If

        Catch ex As Exception
            bitError = True
            resultado = "Error : " & ex.Message
        End Try


    End Sub

    ''' <summary>
    ''' Envia los datos principales a ION limpiando previamente el registro a sobreescribir
    ''' </summary>
    Public Sub insercion_Datos_Principales_ION(ByRef obj_Estructura_Download As clsModeloDownloadGenerico)

        If obj_Estructura_Download.BitError = False Then
            If obj_Estructura_Download.dsPaquetes.Tables.Count > 0 Then
                If obj_Estructura_Download.dsPaquetes.Tables(0).Rows.Count > 0 Then

                    Try

                        For Each registro As DataRow In obj_Estructura_Download.dsPaquetes.Tables(0).Rows

                            Dim id_KEY As String = ""
                            Dim rowId As String = ""
                            Dim dtDetalle As DataTable

                            '===================================================================================
                            'Filtrado pedido a insertar en ION
                            Try
                                id_KEY = registro.Item("externorderkey_key_doc").ToString
                                rowId = registro.Item("susr1_rowid_encab").ToString

                                'Filtrar
                                Dim drDetalle() As DataRow = obj_Estructura_Download.DS_Datos_SQL.Tables(0).Select("externorderkey_key_doc = '" & Trim(id_KEY) & "'")
                                dtDetalle = drDetalle.CopyToDataTable()

                            Catch ex As Exception
                                sp_registrarLog_Download_WMS(, , rowId, id_KEY, "Paso 6 - insercion_Datos_Principales_ION Filtrado : " & obj_Estructura_Download.Proceso, "Fin", "Error", ex.Message)
                            End Try
                            '===================================================================================


                            '===================================================================================
                            'Limpiar registro ION

                            Try
                                sp_WMS_ION_Limpiar_ORDERS(id_KEY)
                            Catch ex As Exception
                                sp_registrarLog_Download_WMS(, , rowId, id_KEY, "Paso 6 - insercion_Datos_Principales_ION Limpiar Registro ION : " & obj_Estructura_Download.Proceso, "Fin", "Error", ex.Message)
                            End Try
                            '===================================================================================

                            '===================================================================================
                            'Limpiar registro ION
                            Try
                                Dim obj_ION As New clsEnviarDatos_ION
                                obj_ION.enviar_OEX_ION_RQV(dtDetalle)
                            Catch ex As Exception
                                sp_registrarLog_Download_WMS(, , rowId, id_KEY, "Paso 6 - insercion_Datos_Principales_ION Insercion Registro ION : " & obj_Estructura_Download.Proceso, "Fin", "Error", ex.Message)
                            End Try
                            '===================================================================================

                        Next

                        sp_registrarLog_Download_WMS(, , , , "Paso 6 - insercion_Datos_Principales_ION : " & obj_Estructura_Download.Proceso, "Fin", "OK")

                    Catch ex As Exception
                        obj_Estructura_Download.BitError = True
                        sp_registrarLog_Download_WMS(, , , , "Paso 6 - insercion_Datos_Principales_ION : " & obj_Estructura_Download.Proceso, "Fin", "Error Generico", ex.Message)
                    End Try

                End If

                sp_registrarLog_Download_WMS(, , , , "Paso 6 - insercion_Datos_Principales_ION - Sin Datos Para Enviar : " & obj_Estructura_Download.Proceso, "Fin", "OK")

            End If
        End If

    End Sub



    '''' <summary>
    '''' Este metodo se ejecuta en un hilo aparte y 
    '''' realiza un update directamente en la BD de Siesa
    '''' del campo de control segun el documento para que
    '''' los filtros de las consultas no traigan nuevamente
    '''' el documento a WMS
    '''' </summary>
    'Public Sub actualizacion_Campo_Control_Siesa()
    '    If obj_Estructura_Download.BitError = False Then
    '        Try
    '            Dim AddThread1 As Threading.Thread
    '            Dim objValidacion As New clsValidaciones
    '            AddThread1 = New Threading.Thread(AddressOf objValidacion.validar_Pedidos_WMS)
    '            AddThread1.Start()
    '        Catch ex As Exception
    '            sp_registrarLog_Download_WMS(, , , , "Paso 7 - actualizacion_Campo_Control_Siesa ", "Fin", "Error Generico", ex.Message)
    '        End Try
    '    End If
    'End Sub


End Class
