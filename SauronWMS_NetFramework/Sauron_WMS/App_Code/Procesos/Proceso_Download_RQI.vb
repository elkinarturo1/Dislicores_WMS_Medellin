Imports System.Data
Imports Microsoft.VisualBasic
Public Class Proceso_Download_RQI

    Dim obj_Estructura_Download As New clsModeloDownloadGenerico

    'Public Sub ejecutarProceso(ByVal obj_Estructura_Download As clsModeloDownloadGenerico, ByRef bitError As Boolean, ByRef resultado As String, Optional cia As Integer = -1, Optional co As String = "-1", Optional tipoDoc As String = "-1", Optional numDoc As Integer = -1)

    '    Dim objSQL As New Download_RQI_SQL
    '    Dim ds As New DataSet

    '    Try

    '        ds = objSQL.sp_WMS_DOWNLOAD_Requisiciones_RQI(cia, co, tipoDoc, numDoc)

    '        If ds.Tables.Count > 0 Then
    '            If ds.Tables(0).Rows.Count > 0 Then

    '                insercion_Datos_Principales_ION(ds)

    '            Else
    '                bitError = True
    '                resultado = "Todos los pedidos se encuentran en WMS"

    '            End If

    '        Else
    '            bitError = True
    '            resultado = "La consulta no trajo tablas"

    '        End If

    '    Catch ex As Exception
    '        bitError = True
    '        resultado = "Error : " & ex.Message
    '    End Try


    'End Sub


    ''' <summary>
    ''' Envia los datos principales a ION limpiando previamente el registro a sobreescribir
    ''' </summary>
    Public Sub insercion_Datos_Principales_ION(ByRef ds As DataSet, ByRef bitError As String, ByRef resultado As String)

        Dim id_KEY As String = ""
        Dim rowId As String = ""
        Dim cia As String = ""
        Dim co As String = ""
        Dim tipoDoc As String = ""
        Dim numDoc As String = ""

        If ds.Tables.Count > 0 Then
            If ds.Tables.Count > 1 Then
                If ds.Tables(0).Rows.Count > 0 Then

                    Try

                        For Each registro As DataRow In ds.Tables(0).Rows

                            Dim dtDetalle As DataTable

                            '===================================================================================
                            'Filtrado datos a insertar en ION
                            Try
                                id_KEY = registro.Item("externreceiptkey_key_doc").ToString
                                rowId = registro.Item("susr1_rowid_encab").ToString
                                cia = registro.Item("storerkey_id_cia").ToString
                                co = registro.Item("susr2_co_doc_org").ToString
                                tipoDoc = registro.Item("type_tip_doc").ToString
                                numDoc = registro.Item("susr3_consec_doc").ToString

                                'Filtrar
                                Dim drDetalle() As DataRow = ds.Tables(1).Select("externreceiptkey_key_doc = '" & Trim(id_KEY) & "'")
                                dtDetalle = drDetalle.CopyToDataTable()

                            Catch ex As Exception
                                bitError = True
                                resultado = "Error filtrando datos a insertar en ION - " & "externreceiptkey_key_doc = '" & Trim(id_KEY) & " - " & ex.Message
                            End Try
                            '===================================================================================


                            '===================================================================================
                            'Limpiar registro ION
                            If bitError = False Then
                                Try
                                    sp_WMS_ION_Limpiar_RECEIPT(id_KEY)
                                Catch ex As Exception
                                    bitError = True
                                    resultado = "Error al Limpiar registro en ION - " & ex.Message
                                End Try
                            End If
                            '===================================================================================

                            '===================================================================================
                            'Enviar datos a ION
                            If bitError = False Then
                                Try
                                    Dim obj_ION As New clsEnviarDatos_ION
                                    obj_ION.enviar_ASN_ION_RQI(dtDetalle)
                                Catch ex As Exception
                                    bitError = True
                                    resultado = "Error al Enviar datos a ION - " & ex.Message & " <br /> <br /> Datos Enviados : " & ds.GetXml()
                                End Try
                            End If
                            '===================================================================================

                        Next

                    Catch ex As Exception
                        bitError = True
                        resultado = "Ha ocurrido una excepcion al enviar datos a ION - " & ex.Message
                    End Try

                Else
                    bitError = True
                    resultado = "La consulta no trajo registros a enviar a ION, por favor verifique los filtros o no hay datos pendientes por enviar"
                End If

            Else
                bitError = True
                resultado = "La consulta no trajo detalle"
            End If
        Else
            bitError = True
            resultado = "La consulta no trajo todas tablas"
        End If


    End Sub

End Class
