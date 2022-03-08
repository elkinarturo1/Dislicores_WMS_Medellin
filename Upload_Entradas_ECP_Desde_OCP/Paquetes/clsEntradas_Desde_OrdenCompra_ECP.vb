
Public Class clsEntradas_Desde_OrdenCompra_ECP

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
                    strXML_GT &= "<F_CIA>" & registro.Item("f420_id_cia").ToString & "</F_CIA>"
                    strXML_GT &= "<f350_id_co>" & registro.Item("f420_id_co").ToString & "</f350_id_co>"
                    strXML_GT &= "<f350_id_tipo_docto>" & registro.Item("f420_id_tipo_docto").ToString & "</f350_id_tipo_docto>"
                    strXML_GT &= "<f350_consec_docto>" & registro.Item("f420_consec_docto").ToString & "</f350_consec_docto>"
                    strXML_GT &= "<f350_fecha>" & fechaDoc & "</f350_fecha>"
                    strXML_GT &= "<f350_id_tercero>" & registro.Item("f350_id_tercero").ToString & "</f350_id_tercero>"
                    strXML_GT &= "<f350_notas>" & registro.Item("f350_notas").ToString & "</f350_notas>"
                    strXML_GT &= "<f451_id_sucursal_prov>" & registro.Item("f451_id_sucursal_prov").ToString & "</f451_id_sucursal_prov>"
                    strXML_GT &= "<f451_id_tercero_comprador>" & registro.Item("f451_id_tercero_comprador").ToString & "</f451_id_tercero_comprador>"
                    strXML_GT &= "<f451_num_docto_referencia>" & objEnvio.ASN & "</f451_num_docto_referencia>"
                    strXML_GT &= "<f451_id_moneda_docto>" & registro.Item("f451_id_moneda_docto").ToString & "</f451_id_moneda_docto>"
                    strXML_GT &= "<f451_id_moneda_conv>" & registro.Item("f451_id_moneda_conv").ToString & "</f451_id_moneda_conv>"
                    strXML_GT &= "<f451_tasa_conv>" & CInt(registro.Item("f451_tasa_conv").ToString) & "</f451_tasa_conv>"
                    strXML_GT &= "<f451_tasa_local>" & CInt(registro.Item("f451_tasa_local").ToString) & "</f451_tasa_local>"
                    strXML_GT &= "<f420_id_co_docto>" & objEnvio.co & "</f420_id_co_docto>"
                    strXML_GT &= "<f420_id_tipo_docto>" & objEnvio.tipoDoc & "</f420_id_tipo_docto>"
                    strXML_GT &= "<f420_consec_docto>" & objEnvio.numDoc & "</f420_consec_docto>"
                    strXML_GT &= "</Documentos>"
                Next


                For Each registro As DataRow In objEnvio.dtMovimientos.Rows

                    strXML_GT &= "<Movimientos>"
                    strXML_GT &= "<F_CIA>" & registro.Item("f420_id_cia").ToString & "</F_CIA>"
                    strXML_GT &= "<f470_id_co>" & registro.Item("f420_id_co").ToString & "</f470_id_co>"
                    strXML_GT &= "<f470_id_tipo_docto>" & registro.Item("f420_id_tipo_docto").ToString & "</f470_id_tipo_docto>"
                    strXML_GT &= "<f470_consec_docto>" & registro.Item("f420_consec_docto").ToString & "</f470_consec_docto>"
                    strXML_GT &= "<NumRegistro>" & registro.Item("NumRegistro").ToString & "</NumRegistro>"
                    strXML_GT &= "<f470_id_bodega>" & registro.Item("f470_id_bodega").ToString & "</f470_id_bodega>"
                    strXML_GT &= "<f470_id_unidad_medida>" & registro.Item("f470_id_unidad_medida").ToString & "</f470_id_unidad_medida>"
                    strXML_GT &= "<f421_fecha_entrega>" & registro.Item("f421_fecha_entrega").ToString & "</f421_fecha_entrega>"
                    strXML_GT &= "<f470_cant_base>" & CInt(registro.Item("cantidad").ToString) & "</f470_cant_base>"
                    strXML_GT &= "<f470_referencia_item>" & registro.Item("f470_referencia_item").ToString & "</f470_referencia_item>"
                    strXML_GT &= "<f470_notas>" & Trim(registro.Item("ASN").ToString) & "</f470_notas>"
                    strXML_GT &= "<f470_id_ccosto_movto></f470_id_ccosto_movto>"
                    strXML_GT &= "</Movimientos>"
                Next


                For Each registro As DataRow In objEnvio.dtDescuentos.Rows
                    If CInt(registro.Item("f471_vlr_tot").ToString) > 0 Then
                        strXML_GT &= "<Descuentos>"
                        strXML_GT &= "<F_CIA>" & registro.Item("f420_id_cia").ToString & "</F_CIA>"
                        strXML_GT &= "<f471_id_co>" & registro.Item("f420_id_co").ToString & "</f471_id_co>"
                        strXML_GT &= "<f471_id_tipo_docto>" & registro.Item("f420_id_tipo_docto").ToString & "</f471_id_tipo_docto>"
                        strXML_GT &= "<f471_consec_docto>" & registro.Item("f420_consec_docto").ToString & "</f471_consec_docto>"
                        strXML_GT &= "<NumRegistro>" & registro.Item("NumRegistro").ToString & "</NumRegistro>"
                        strXML_GT &= "<f471_orden>" & "1" & "</f471_orden>"
                        strXML_GT &= "<f471_tasa>" & registro.Item("f471_tasa").ToString & "</f471_tasa>"
                        strXML_GT &= "<f471_vlr_tot>" & CInt(registro.Item("f471_vlr_tot").ToString) & "</f471_vlr_tot>"
                        strXML_GT &= "</Descuentos>"
                    End If
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
                plano = ConsumoGT(77709, "WMS_ENTRADA_DESDE_OC_ECP", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

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
