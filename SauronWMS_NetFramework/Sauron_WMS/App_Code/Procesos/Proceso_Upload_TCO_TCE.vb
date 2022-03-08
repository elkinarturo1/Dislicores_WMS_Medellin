Imports System.Data
Imports Microsoft.VisualBasic

Public Class Proceso_Upload_TCO_TCE

    Dim objSQL As New Upload_TCO_TCE_SQL

    Public Sub ejecutarProceso(ByRef bitError As Boolean, ByRef resultado As String, ByVal cia As String, ByVal co As String, ByVal tipoDoc As String, ByVal numDoc As String)

        Dim paquete As String = ""
        Dim strXML As String = ""
        Dim dsDatosSQL As New DataSet
        Dim dsDatosGT As New DataSet
        Dim strXML_GT As String = ""
        Dim plano As String = ""

        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 1 - Capturando Datos a enviar
        If bitError = False Then
            Try
                paquete = cia.Trim & "-" & co.Trim & "-" & tipoDoc.Trim & "-" & numDoc.Trim
                dsDatosSQL = objSQL.sp_WMS_UPLOAD_Entrada_TCE_desde_TCO_ws_Detalle_Blazor(bitError, resultado, paquete)
            Catch ex As Exception
                bitError = True
                resultado = "Error Paso 1 Capturando datos a enviar : " & ex.Message
            End Try
        End If
        '////////////////////////////////////////////////////////////////////////////////////////////////// 


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 2 - Armando XML
        If Not bitError Then
            If dsDatosSQL.Tables.Count > 0 Then
                If dsDatosSQL.Tables(0).Rows.Count Then
                    Try

                        strXML_GT &= "<MyDataSet>"

                        strXML_GT &= "<Inicial>"
                        strXML_GT &= "<F_CIA>" & cia & "</F_CIA>"
                        strXML_GT &= "</Inicial>"

                        For Each registro As DataRow In dsDatosSQL.Tables(0).Rows

                            Dim fechaDoc As String = Now.Date.ToString("yyyyMMdd")

                            strXML_GT &= "<Documentos>"
                            strXML_GT &= "<F_CIA>" & registro.Item("F_CIA").ToString & "</F_CIA>"
                            strXML_GT &= "<f350_id_co>001</f350_id_co>"
                            strXML_GT &= "<f350_id_tipo_docto>" & registro.Item("TipoDocEntrada").ToString & "</f350_id_tipo_docto>"
                            strXML_GT &= "<f350_consec_docto>" & registro.Item("f350_consec_docto").ToString & "</f350_consec_docto>"
                            strXML_GT &= "<f350_fecha>" & fechaDoc & "</f350_fecha>"
                            strXML_GT &= "<f350_notas>" & registro.Item("F350_NOTAS").ToString & "</f350_notas>"
                            strXML_GT &= "<f450_id_bodega_salida>" & registro.Item("idBodegaSalida").ToString & "</f450_id_bodega_salida>"
                            strXML_GT &= "<f450_id_bodega_entrada>" & registro.Item("idBodegaEntrada").ToString & "</f450_id_bodega_entrada>"
                            strXML_GT &= "<f450_docto_alterno>" & registro.Item("F450_DOCTO_ALTERNO").ToString & "</f450_docto_alterno>"
                            strXML_GT &= "<f350_id_co_base>" & registro.Item("co_BodegaSalida").ToString & "</f350_id_co_base>"
                            strXML_GT &= "<f350_id_tipo_docto_base>" & registro.Item("TipoDocSalida").ToString & "</f350_id_tipo_docto_base>"
                            strXML_GT &= "<f350_consec_docto_base>" & registro.Item("f350_consec_docto").ToString & "</f350_consec_docto_base>"
                            strXML_GT &= "</Documentos>"

                        Next

                        For Each registro As DataRow In dsDatosSQL.Tables(1).Rows

                            strXML_GT &= "<Movimientos>"
                            strXML_GT &= "<F_CIA>" & registro.Item("F_CIA").ToString & "</F_CIA>"
                            strXML_GT &= "<f470_id_co>001</f470_id_co>"
                            strXML_GT &= "<f470_id_tipo_docto>" & registro.Item("TipoDocEntrada").ToString & "</f470_id_tipo_docto>"
                            strXML_GT &= "<f470_consec_docto>" & registro.Item("f350_consec_docto").ToString & "</f470_consec_docto>"
                            strXML_GT &= "<f470_nro_registro>" & registro.Item("f471_nro_registro").ToString & "</f470_nro_registro>"
                            strXML_GT &= "<f470_id_bodega>" & registro.Item("idBodegaSalida").ToString & "</f470_id_bodega>"
                            strXML_GT &= "<f470_id_motivo>" & registro.Item("idMotivo").ToString & "</f470_id_motivo>"
                            strXML_GT &= "<f470_id_co_movto>" & registro.Item("co_BodegaEntrada").ToString & "</f470_id_co_movto>"
                            strXML_GT &= "<f470_id_unidad_medida>" & registro.Item("f120_id_unidad_inventario").ToString & "</f470_id_unidad_medida>"
                            strXML_GT &= "<f470_cant_base>" & registro.Item("Cantidad").ToString & "</f470_cant_base>"
                            strXML_GT &= "<f470_notas>" & registro.Item("F470_NOTAS").ToString & "</f470_notas>"
                            strXML_GT &= "<f470_referencia_item>" & registro.Item("SKU").ToString & "</f470_referencia_item>"
                            strXML_GT &= "<f470_id_un_movto>" & registro.Item("f470_id_un_movto").ToString & "</f470_id_un_movto>"
                            strXML_GT &= "</Movimientos>"

                        Next



                        strXML_GT &= "<Final>"
                        strXML_GT &= "<F_CIA>" & cia & "</F_CIA>"
                        strXML_GT &= "</Final>"

                        strXML_GT &= "</MyDataSet>"

                    Catch ex As Exception
                        bitError = True
                        resultado = "Error Paso 2 Capturando Armando XML" & ex.Message
                    End Try
                Else
                    bitError = True
                    resultado = "Error Paso 2 Capturando Armando XML No hay datos en la consulta para enviar"
                End If
            Else
                bitError = True
                resultado = "Error Paso 2 Capturando Armando XML No hay tablas en la consulta para enviar"
            End If
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 3 - Convirtiendo a DataSet
        If Not bitError Then
            dsDatosGT = convertirXML_to_DataSet(bitError, resultado, strXML_GT)
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 4 - Consumiendo GT
        If bitError = False Then
            plano = ModuloConsumosGT.ConsumoGT(bitError, resultado, 78935, "WMS_ENTRADA_DESDE_SALIDA_TCE", cia, dsDatosGT)
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Paso 5 - Convirtiendo a DataSet
        If bitError = False Then
            Try
                ModuloConsumoUNOEE.CargasWSUNOEE(bitError, resultado, cia, plano)
            Catch ex As Exception
                Throw ex
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////

    End Sub


End Class
