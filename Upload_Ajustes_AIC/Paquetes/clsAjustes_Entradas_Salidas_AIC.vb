Public Class clsAjustes_Entradas_Salidas_AIC

    Public Sub enviarDatos(ByVal objEnvio As EstructuraUploadModel)


        Dim dsDatosGT As New DataSet
        Dim strXML_GT As String = ""
        Dim plano As String = ""


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If objEnvio.bitError = False Then

            Try

                Dim fechaDoc As String = Now.Date.ToString("yyyyMMdd")

                strXML_GT &= "<MyDataSet>" & Environment.NewLine

                strXML_GT &= "<Inicial>" & Environment.NewLine
                strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>" & Environment.NewLine
                strXML_GT &= "</Inicial>" & Environment.NewLine

                For Each registro As DataRow In objEnvio.dtDocumentos.Rows

                    strXML_GT &= "<Documentos>" & Environment.NewLine
                    strXML_GT &= "<F_CIA>" & registro.Item("F_CIA").ToString & "</F_CIA>" & Environment.NewLine
                    strXML_GT &= "<f350_id_co>" & registro.Item("f350_id_co").ToString & "</f350_id_co>" & Environment.NewLine
                    strXML_GT &= "<f350_id_tipo_docto>" & registro.Item("f350_id_tipo_docto").ToString & "</f350_id_tipo_docto>" & Environment.NewLine
                    strXML_GT &= "<f350_consec_docto>" & registro.Item("f350_consec_docto").ToString & "</f350_consec_docto>" & Environment.NewLine
                    'strXML_GT &= "<f350_consec_docto>3</f350_consec_docto>" & Environment.NewLine
                    strXML_GT &= "<f350_fecha>" & registro.Item("f350_fecha").ToString & "</f350_fecha>" & Environment.NewLine
                    strXML_GT &= "<f350_id_tercero>" & registro.Item("f350_id_tercero").ToString & "</f350_id_tercero>" & Environment.NewLine
                    strXML_GT &= "<f350_id_clase_docto>" & registro.Item("f350_id_clase_docto").ToString & "</f350_id_clase_docto>" & Environment.NewLine
                    strXML_GT &= "<f350_ind_estado>" & registro.Item("f350_ind_estado").ToString & "</f350_ind_estado>" & Environment.NewLine
                    strXML_GT &= "<f350_notas>" & registro.Item("f350_notas").ToString & "</f350_notas>" & Environment.NewLine
                    strXML_GT &= "<f450_id_concepto>" & registro.Item("f450_id_concepto").ToString & "</f450_id_concepto>" & Environment.NewLine
                    strXML_GT &= "<f450_docto_alterno>" & registro.Item("f450_docto_alterno").ToString & "</f450_docto_alterno>" & Environment.NewLine

                    strXML_GT &= "</Documentos>" & Environment.NewLine

                Next

                For Each registro As DataRow In objEnvio.dtDetalle.Rows

                    Dim cantidad As Integer = 0

                    cantidad = registro.Item("f470_cant_base").ToString

                    If cantidad < 0 Then
                        cantidad = cantidad * -1
                    End If

                    strXML_GT &= "<Movimientos>" & Environment.NewLine
                    strXML_GT &= "<F_CIA>" & registro.Item("F_CIA").ToString & "</F_CIA>" & Environment.NewLine
                    strXML_GT &= "<f470_id_co>" & registro.Item("f470_id_co").ToString & "</f470_id_co>" & Environment.NewLine
                    strXML_GT &= "<f470_id_tipo_docto>" & registro.Item("f470_id_tipo_docto").ToString & "</f470_id_tipo_docto>" & Environment.NewLine
                    strXML_GT &= "<f470_consec_docto>" & registro.Item("f470_consec_docto").ToString & "</f470_consec_docto>" & Environment.NewLine
                    'strXML_GT &= "<f470_consec_docto>3</f470_consec_docto>" & Environment.NewLine
                    strXML_GT &= "<f470_nro_registro>" & registro.Item("f470_nro_registro").ToString & "</f470_nro_registro>" & Environment.NewLine
                    strXML_GT &= "<f470_id_concepto>" & registro.Item("f470_id_concepto").ToString & "</f470_id_concepto>" & Environment.NewLine
                    strXML_GT &= "<f470_id_motivo>" & registro.Item("f470_id_motivo").ToString & "</f470_id_motivo>" & Environment.NewLine
                    strXML_GT &= "<f470_id_co_movto>" & registro.Item("f470_id_co_movto").ToString & "</f470_id_co_movto>" & Environment.NewLine
                    strXML_GT &= "<f470_id_unidad_medida>" & registro.Item("f470_id_unidad_medida").ToString & "</f470_id_unidad_medida>" & Environment.NewLine
                    strXML_GT &= "<f470_cant_base>" & cantidad & "</f470_cant_base>" & Environment.NewLine
                    strXML_GT &= "<f470_costo_prom_uni>" & registro.Item("f470_costo_prom_uni").ToString & "</f470_costo_prom_uni>" & Environment.NewLine
                    strXML_GT &= "<f470_notas>" & registro.Item("f470_notas").ToString & "</f470_notas>" & Environment.NewLine
                    strXML_GT &= "<f470_id_ccosto_movto></f470_id_ccosto_movto>" & Environment.NewLine
                    strXML_GT &= "<f470_id_ubicación_aux>" & registro.Item("f470_id_ubicación_aux").ToString & "</f470_id_ubicación_aux>" & Environment.NewLine
                    strXML_GT &= "<f470_id_ubicación_aux_ent>" & registro.Item("f470_id_ubicación_aux_ent").ToString & "</f470_id_ubicación_aux_ent>" & Environment.NewLine
                    strXML_GT &= "<f470_referencia_item>" & registro.Item("f470_referencia_item").ToString & "</f470_referencia_item>" & Environment.NewLine
                    strXML_GT &= "<f470_id_un_movto>" & registro.Item("f470_id_un_movto").ToString & "</f470_id_un_movto>" & Environment.NewLine
                    strXML_GT &= "<f470_id_bodega>" & registro.Item("f470_id_bodega").ToString & "</f470_id_bodega>" & Environment.NewLine
                    strXML_GT &= "</Movimientos>" & Environment.NewLine

                Next



                strXML_GT &= "<Final>" & Environment.NewLine
                strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>" & Environment.NewLine
                strXML_GT &= "</Final>" & Environment.NewLine

                strXML_GT &= "</MyDataSet>" & Environment.NewLine

            Catch ex As Exception
                objEnvio.bitError = True
                objEnvio.datosEnviadosExcepcion = strXML_GT
                objEnvio.resultadoLog = "Error al armar el xml de GT " & ex.Message
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If objEnvio.bitError = False Then
            Try
                dsDatosGT = convertirXML_to_DataSet(strXML_GT)
            Catch ex As Exception
                objEnvio.bitError = True
                objEnvio.datosEnviadosExcepcion = strXML_GT
                objEnvio.resultadoLog = "Error al convertir el XML de GT en dataset " & ex.Message
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If objEnvio.bitError = False Then
            Try
                Dim resultadoConsumoGT As String = ""
                plano = ConsumoGT(80691, "WMS_AJUSTES_ENTRADAS_SALIDAS_AIC", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

                If (resultadoConsumoGT <> "Se genero el plano correctamente") Then
                    objEnvio.bitError = True
                    objEnvio.datosEnviadosGT = dsDatosGT.GetXml
                    objEnvio.resultadoLog = "Error al consumir GTIntegration " & resultadoConsumoGT
                End If

            Catch ex As Exception
                objEnvio.bitError = True
                objEnvio.datosEnviadosGT = dsDatosGT.GetXml
                objEnvio.resultadoLog = "Error al consumir GTIntegration " & ex.Message
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Cargar UNOEE
        If objEnvio.bitError = False Then
            Try
                CargasWSUNOEE(objEnvio.paquete, plano, objEnvio)
            Catch ex As Exception
                Throw ex
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////



        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Registrar Log
        Try

            ModuloSQL.sp_A_Log_Upload_Ajustes_AIC(objEnvio.bitError,
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
