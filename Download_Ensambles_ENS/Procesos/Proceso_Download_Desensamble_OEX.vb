Public Class Proceso_Download_Desensamble_OEX

    Dim obj_Estructura_Download As New clsModeloDownloadGenerico
    Public Sub ejecutarProceso_OEX()

        Dim dsPaquetes As New DataSet

        Try

            Dim ds As New DataSet

            '=============================================================================================================
            ''Paso 1 Consultado Datos sp_WMS_DOWNLOAD_Transferencias_TCO2
            Try
                ds = ModuloSQL.sp_WMS_DOWNLOAD_Ensambles_ENS_OEX()
            Catch ex As Exception
                obj_Estructura_Download.BitError = True
                ModuloSQL.A_Log_Download_OEX(True,, "2",, "DES",,,,,,,, "Error en Paso 1 Consultado Datos sp_WMS_DOWNLOAD_Transferencias_TCO2 - " & ex.Message)
            End Try
            '=============================================================================================================


            '=============================================================================================================
            ''Paso 2 insertando datos ION
            If obj_Estructura_Download.BitError = False Then
                Try
                    insercion_Datos_Principales_ION_OEX(ds)
                Catch ex As Exception
                    obj_Estructura_Download.BitError = True
                    ModuloSQL.A_Log_Download_OEX(True,, "2",, "DES",,,,,,,, "Error en Paso 2 insertando datos ION - " & ex.Message)
                End Try
            End If
            '=============================================================================================================

        Catch ex As Exception
            ModuloSQL.A_Log_Download_OEX(True,, "2",, "DES",,,,,,,, "A ocurrido una Excepcion - " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Envia los datos principales a ION limpiando previamente el registro a sobreescribir
    ''' </summary>
    Public Sub insercion_Datos_Principales_ION_OEX(ByRef ds As DataSet)

        Dim bitError As Boolean = False
        Dim id_KEY As String = ""
        Dim rowId As String = ""
        Dim cia As String = ""
        Dim co As String = ""
        Dim tipoDoc As String = ""
        Dim numDoc As String = ""

        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then

                Try

                    For Each registro As DataRow In ds.Tables(0).Rows

                        bitError = False
                        Dim dtDetalle As DataTable

                        '===================================================================================
                        'Filtrado pedido a insertar en ION
                        Try
                            id_KEY = registro.Item("externorderkey_key_doc").ToString
                            rowId = registro.Item("susr1_rowid_encab").ToString
                            cia = registro.Item("storerkey_id_cia").ToString
                            co = registro.Item("susr3_co_doc").ToString
                            tipoDoc = registro.Item("type_tip_doc").ToString
                            numDoc = registro.Item("f430_consec_docto").ToString

                            'Filtrar
                            Dim drDetalle() As DataRow = ds.Tables(1).Select("externorderkey_key_doc = '" & Trim(id_KEY) & "'")
                            dtDetalle = drDetalle.CopyToDataTable()

                        Catch ex As Exception
                            bitError = True
                            ModuloSQL.A_Log_Download_OEX(True, id_KEY, cia, co, tipoDoc, numDoc,,,,,, ds.GetXml(), "Error Filtrado pedido a insertar en ION - " & ex.Message)
                        End Try
                        '===================================================================================


                        '===================================================================================
                        'Limpiar registro ION
                        If bitError = False Then
                            Try
                                sp_WMS_ION_Limpiar_ORDERS(id_KEY)
                            Catch ex As Exception
                                bitError = True
                                ModuloSQL.A_Log_Download_OEX(True, id_KEY, cia, co, tipoDoc, numDoc,,,,,, ds.GetXml(), "Error al Limpiar registro ION - " & ex.Message)
                            End Try
                        End If
                        '===================================================================================

                        '===================================================================================
                        'Enviar datos ION enviar_OEX_ION_PEV
                        If bitError = False Then
                            Try
                                Dim obj_ION As New clsEnviarDatos_ION
                                obj_ION.enviar_OEX_ION_DES(dtDetalle, cia, co, tipoDoc, numDoc, rowId)
                                ModuloSQL.A_Log_Download_OEX(True, id_KEY, cia, co, tipoDoc, numDoc,,,,,, ds.GetXml(), "Proceso Terminado Correctamente")
                            Catch ex As Exception
                                bitError = True
                                ModuloSQL.A_Log_Download_OEX(True, id_KEY, cia, co, tipoDoc, numDoc,,,,,, ds.GetXml(), "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
                            End Try
                        End If
                        '===================================================================================

                    Next

                Catch ex As Exception
                    obj_Estructura_Download.BitError = True
                    ModuloSQL.A_Log_Download_OEX(True, id_KEY, cia, co, tipoDoc, numDoc, rowId,,,,,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
                End Try

            End If

        End If

    End Sub



End Class
