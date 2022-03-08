Public Class Download_Devoluciones_PDC

    Dim obj_Estructura_Download As New clsModeloDownloadGenerico
    Private Sub Download_Devoluciones_PDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dsPaquetes As New DataSet

        Try

            Dim ds As New DataSet

            '=============================================================================================================
            ''Paso 1 Consultado Datos sp_WMS_DOWNLOAD_Transferencias_TCO2
            Try
                ds = ModuloSQL.sp_WMS_DOWNLOAD_Devoluciones_PDC()
            Catch ex As Exception
                obj_Estructura_Download.BitError = True
                ModuloSQL.sp_A_Registrar_Log_Download_ASN(True,, "2",, "PDC",,,,,,,,, "Error en Paso 1 Consultado Datos sp_WMS_DOWNLOAD_Transferencias_TCO2 - " & ex.Message)
            End Try
            '=============================================================================================================


            '=============================================================================================================
            ''Paso 2 insertando datos ION
            If obj_Estructura_Download.BitError = False Then
                Try
                    insercion_Datos_Principales_ION(ds)
                Catch ex As Exception
                    obj_Estructura_Download.BitError = True
                    ModuloSQL.sp_A_Registrar_Log_Download_ASN(True,, "2",, "PDC",,,,,,,,, "Error en Paso 2 insertando datos ION - " & ex.Message)
                End Try
            End If
            '=============================================================================================================

        Catch ex As Exception
            ModuloSQL.sp_A_Registrar_Log_Download_ASN(True,, "2",, "PDC",,,,,,,,, "A ocurrido una Excepcion - " & ex.Message)
        End Try


        Me.Close()

    End Sub

    ''' <summary>
    ''' Envia los datos principales a ION limpiando previamente el registro a sobreescribir
    ''' </summary>
    Public Sub insercion_Datos_Principales_ION(ByRef ds As DataSet)

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
                            id_KEY = registro.Item("EXTERNRECEIPT_KEY").ToString
                            rowId = registro.Item("susr1_rowid_encab").ToString
                            cia = registro.Item("storerkey_id_cia").ToString
                            co = registro.Item("susr2_co_docto").ToString
                            tipoDoc = registro.Item("type_tipo_doc").ToString
                            numDoc = registro.Item("susr3_consec_docto").ToString

                            'Filtrar
                            Dim drDetalle() As DataRow = ds.Tables(1).Select("EXTERNRECEIPT_KEY = '" & Trim(id_KEY) & "'")
                            dtDetalle = drDetalle.CopyToDataTable()

                        Catch ex As Exception
                            bitError = True
                            ModuloSQL.sp_A_Registrar_Log_Download_ASN(True, id_KEY, cia, co, tipoDoc, numDoc,,,,,,, ds.GetXml(), "Error Filtrado pedido a insertar en ION - " & ex.Message)
                        End Try
                        '===================================================================================


                        '===================================================================================
                        'Limpiar registro ION
                        If bitError = False Then
                            Try
                                sp_WMS_ION_Limpiar_RECEIPT(id_KEY)
                            Catch ex As Exception
                                bitError = True
                                ModuloSQL.sp_A_Registrar_Log_Download_ASN(True, id_KEY, cia, co, tipoDoc, numDoc,,,,,,, ds.GetXml(), "Error al Limpiar registro ION - " & ex.Message)
                            End Try
                        End If
                        '===================================================================================

                        '===================================================================================
                        'Enviar datos ION enviar_OEX_ION_PEV
                        If bitError = False Then
                            Try
                                Dim obj_ION As New clsEnviarDatos_ION
                                obj_ION.enviar_ASN_ION_PDC(dtDetalle, cia, co, tipoDoc, numDoc, rowId)
                            Catch ex As Exception
                                bitError = True
                                ModuloSQL.sp_A_Registrar_Log_Download_ASN(True, id_KEY, cia, co, tipoDoc, numDoc,,,,,,, ds.GetXml(), "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
                            End Try
                        End If
                        '===================================================================================

                    Next

                Catch ex As Exception
                    obj_Estructura_Download.BitError = True
                    ModuloSQL.sp_A_Registrar_Log_Download_ASN(True, id_KEY, cia, co, tipoDoc, numDoc, rowId,,,,,,, "Error al Enviar datos ION enviar_OEX_ION_PEV - " & ex.Message)
                End Try

            End If

        End If

    End Sub


End Class