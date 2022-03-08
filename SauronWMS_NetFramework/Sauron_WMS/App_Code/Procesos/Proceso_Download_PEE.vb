Imports System.Data
Imports Microsoft.VisualBasic

Public Class Proceso_Download_PEE

    Public Sub ejecutarProceso(ByVal obj_Estructura_Download As clsModeloDownloadGenerico, ByRef bitError As Boolean, ByRef resultado As String, Optional nit As String = "-1")

        Dim objSQL As New Download_PEE_SQL
        Dim dspaquetes As New DataSet

        'Dim obj_Estructura_Download As New clsModeloDownloadGenerico
        Dim dsDetalle As New DataSet


        Try


            dspaquetes = objSQL.sp_WMS_DOWNLOAD_Pedidos_PEE_Agrup(nit)
            dsDetalle = objSQL.sp_WMS_DOWNLOAD_Pedidos_PEE_Detalle(nit)


            If dspaquetes.Tables.Count > 0 Then
                If dspaquetes.Tables(0).Rows.Count > 0 Then

                    'obj_Estructura_Download.dtPaquetes = dspaquetes
                    'obj_Estructura_Download.DS_Datos_SQL = dsDetalle

                    'insercion_Datos_Principales_ION(dspaquetes, dsDetalle, obj_Estructura_Download.Proceso, obj_Estructura_Download.BitError)

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
    Public Sub insercion_Datos_Principales_ION(ByVal dtPaquetes As DataTable, ByVal dtDatos As DataTable, ByVal proceso As String, ByVal bitError As Boolean)

        If bitError = False Then
            If dtPaquetes.Rows.Count > 0 Then

                Try

                    For Each registro As DataRow In dtPaquetes.Rows

                        Dim id_KEY As String = ""
                        Dim rowId As String = ""
                        Dim dtDetalle As DataTable

                        '===================================================================================
                        'Filtrado pedido a insertar en ION
                        Try
                            id_KEY = registro.Item("externorderkey_key_doc").ToString
                            rowId = registro.Item("susr1_rowid_encab").ToString

                            'Filtrar
                            Dim drDetalle() As DataRow = dtDatos.Select("EXTERNORDERKEY_key_doc = '" & Trim(id_KEY) & "'")
                            dtDetalle = drDetalle.CopyToDataTable()

                        Catch ex As Exception
                            sp_registrarLog_Download_WMS(, , rowId, id_KEY, "Paso 6 - insercion_Datos_Principales_ION Filtrado : " & proceso, "Fin", "Error", ex.Message)
                        End Try
                        '===================================================================================


                        '===================================================================================
                        'Limpiar registro ION

                        Try
                            sp_WMS_ION_Limpiar_ORDERS(id_KEY)
                        Catch ex As Exception
                            sp_registrarLog_Download_WMS(, , rowId, id_KEY, "Paso 6 - insercion_Datos_Principales_ION Limpiar Registro ION : " & proceso, "Fin", "Error", ex.Message)
                        End Try
                        '===================================================================================

                        '===================================================================================
                        'Limpiar registro ION
                        Try
                            Dim obj_ION As New clsEnviarDatos_ION
                            obj_ION.enviar_OEX_ION_PEV(dtDetalle)
                        Catch ex As Exception
                            sp_registrarLog_Download_WMS(, , rowId, id_KEY, "Paso 6 - insercion_Datos_Principales_ION Insercion Registro ION : " & proceso, "Fin", "Error", ex.Message)
                        End Try
                        '===================================================================================

                    Next

                    sp_registrarLog_Download_WMS(, , , , "Paso 6 - insercion_Datos_Principales_ION : " & proceso, "Fin", "OK")

                Catch ex As Exception
                    bitError = True
                    sp_registrarLog_Download_WMS(, , , , "Paso 6 - insercion_Datos_Principales_ION : " & proceso, "Fin", "Error Generico", ex.Message)
                End Try

            End If

            sp_registrarLog_Download_WMS(, , , , "Paso 6 - insercion_Datos_Principales_ION - Sin Datos Para Enviar : " & proceso, "Fin", "OK")

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
