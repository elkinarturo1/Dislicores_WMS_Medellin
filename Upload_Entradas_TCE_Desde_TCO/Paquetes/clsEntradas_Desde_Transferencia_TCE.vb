
Public Class clsEntradas_Desde_Transferencia_TCE

    Public Sub enviarDatos(ByVal objEnvio As EstructuraUploadModel)

        Dim dsDatosGT As New DataSet
        Dim strXML_GT As String = ""
        Dim plano As String = ""


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If objEnvio.bitError = False Then

            Try

                strXML_GT &= "<MyDataSet>"

                strXML_GT &= "<Inicial>"
                strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>"
                strXML_GT &= "</Inicial>"

                For Each registro As DataRow In objEnvio.dtDocumentos.Rows

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

                For Each registro As DataRow In objEnvio.dtMovimientos.Rows

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
                strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>"
                strXML_GT &= "</Final>"

                strXML_GT &= "</MyDataSet>"

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
                plano = ConsumoGT(78935, "WMS_ENTRADA_DESDE_SALIDA_TCE", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

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


    End Sub


End Class
