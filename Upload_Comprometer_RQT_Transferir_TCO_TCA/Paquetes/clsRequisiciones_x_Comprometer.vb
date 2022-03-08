﻿
Public Class clsRequisiciones_x_Comprometer


    Public Sub comprometer(ByVal objEnvio As EstructuraUploadModel)

        Dim dsDatosGT As New DataSet
        Dim strXML_GT As String = ""
        Dim plano As String = ""
        Dim resultadoConsumoGT As String = ""

        Dim bitError As Boolean = False

        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If bitError = False Then
            If objEnvio.dtDetalle.Rows.Count Then
                Try

                    strXML_GT &= "<MyDataSet>"

                    strXML_GT &= "<Inicial>" & Environment.NewLine
                    strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>" & Environment.NewLine
                    strXML_GT &= "</Inicial>" & Environment.NewLine

                    For Each registro As DataRow In objEnvio.dtDetalle.Rows

                        If IsNumeric(registro.Item("CantidadCompromiso").ToString) Then
                            strXML_GT &= "<Compromisos>" & Environment.NewLine
                            strXML_GT &= "<f441_nro_registro>" & registro.Item("f471_nro_registro").ToString & "</f441_nro_registro>" & Environment.NewLine
                            strXML_GT &= "<F_CIA>" & registro.Item("F_CIA").ToString & "</F_CIA>" & Environment.NewLine
                            strXML_GT &= "<f440_id_co>" & registro.Item("f440_id_co_req_int").ToString & "</f440_id_co>" & Environment.NewLine
                            strXML_GT &= "<f440_id_tipo_docto>" & registro.Item("f440_id_tipo_docto_req_int").ToString & "</f440_id_tipo_docto>" & Environment.NewLine
                            strXML_GT &= "<f440_consec_docto>" & registro.Item("f350_consec_docto").ToString & "</f440_consec_docto>" & Environment.NewLine
                            strXML_GT &= "<f441_referencia_item>" & registro.Item("SKU").ToString & "</f441_referencia_item>" & Environment.NewLine
                            strXML_GT &= "<f441_id_bodega>" & registro.Item("Bodega_Origen").ToString & "</f441_id_bodega>" & Environment.NewLine
                            strXML_GT &= "<f441_id_ubicación_aux></f441_id_ubicación_aux>" & Environment.NewLine
                            strXML_GT &= "<f441_id_unidad_medida>" & registro.Item("f120_id_unidad_inventario").ToString & "</f441_id_unidad_medida>" & Environment.NewLine
                            strXML_GT &= "<f441_id_bodega_ent>" & registro.Item("Bodega_Destino").ToString & "</f441_id_bodega_ent>" & Environment.NewLine
                            strXML_GT &= "<f441_id_ubicación_aux_ent></f441_id_ubicación_aux_ent>" & Environment.NewLine
                            strXML_GT &= "<f441_cant_base>" & registro.Item("CantidadCompromiso").ToString & "</f441_cant_base>" & Environment.NewLine
                            strXML_GT &= "<f441_cant_por_remisionar_base>" & CInt(registro.Item("CantidadCompromiso").ToString) & "</f441_cant_por_remisionar_base>" & Environment.NewLine
                            strXML_GT &= "</Compromisos>" & Environment.NewLine
                        End If

                    Next

                    strXML_GT &= "<Final>" & Environment.NewLine
                    strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>" & Environment.NewLine
                    strXML_GT &= "</Final>" & Environment.NewLine

                    strXML_GT &= "</MyDataSet>" & Environment.NewLine

                Catch ex As Exception
                    bitError = True
                    objEnvio.datosEnviadosExcepcion = strXML_GT
                    objEnvio.resultadoLog = "Error al armar el xml de GT comprometerPedidos " & ex.Message
                End Try
            Else
                bitError = True
                objEnvio.datosEnviadosExcepcion = strXML_GT
                objEnvio.resultadoLog = "No hay datos para armar XML de GT comprometerPedidos"
            End If

        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If bitError = False Then
            Try
                dsDatosGT = convertirXML_to_DataSet(strXML_GT)
            Catch ex As Exception
                bitError = True
                objEnvio.datosEnviadosExcepcion = strXML_GT
                objEnvio.resultadoLog = "Error al convertir el XML de GT en dataset comprometerPedidos " & ex.Message
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If bitError = False Then
            Try
                'plano = ConsumoGT(78946, "WMS_REQUISICION_COMPROMISOS_RQT", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

                plano = ConsumoGT(110436, "WMS_REQUISICION_COMPROMISOS_RQT", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

                If (resultadoConsumoGT <> "Se genero el plano correctamente") Then
                    bitError = True
                    objEnvio.datosEnviadosGT = dsDatosGT.GetXml
                    objEnvio.resultadoLog = "Error al consumir GTIntegration comprometerPedidos " & resultadoConsumoGT
                End If

            Catch ex As Exception
                bitError = True
                objEnvio.datosEnviadosGT = dsDatosGT.GetXml
                objEnvio.resultadoLog = "Error al consumir GTIntegration comprometerPedidos " & ex.Message
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Consumiendo UNOEE
        If bitError = False Then
            Try
                CargasWSUNOEE("Compromiso : " + objEnvio.paquete, plano, objEnvio, bitError)
            Catch ex As Exception
                bitError = True
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Consultando Remision
        'If bitError = False And resultadoUNOEE = 0 Then
        If bitError = False Then
            Try
                System.Threading.Thread.Sleep(1000) ' Espera 2 Segundos
                Dim objTransferencia As New clsRequisiciones_x_Transferir
                objTransferencia.transferir(objEnvio)
            Catch ex As Exception
                objEnvio.bitError = True
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Registrar Log
        Try

            ModuloSQL.sp_A_Registrar_Log_Upload_Comprometer_Transferir_RQT(objEnvio.bitError,
                                                                                       objEnvio.cia,
                                                                                       objEnvio.co,
                                                                                       objEnvio.tipoDoc,
                                                                                       objEnvio.numDoc,
                                                                                       objEnvio.RowId,
                                                                                       objEnvio.OEX,
                                                                                       objEnvio.datosEnviadosGT,
                                                                                       objEnvio.datosEnviadosUNOEE,
                                                                                       objEnvio.datosEnviadosExcepcion,
                                                                                       objEnvio.resultadoLog)

        Catch ex As Exception
            objEnvio.resultadoLog = ex.Message
        End Try
        '//////////////////////////////////////////////////////////////////////////////////////////////////

    End Sub


End Class
