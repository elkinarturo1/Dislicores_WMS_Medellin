Public Class clsDevoluciones_Notas_NV2_Desde_PDC


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
                    strXML_GT &= "<F350_ID_CO>" & registro.Item("F350_ID_CO").ToString & "</F350_ID_CO>"
                    strXML_GT &= "<F350_ID_TIPO_DOCTO>" & registro.Item("F350_ID_TIPO_DOCTO").ToString & "</F350_ID_TIPO_DOCTO>"
                    strXML_GT &= "<F350_CONSEC_DOCTO>" & registro.Item("F350_CONSEC_DOCTO").ToString & "</F350_CONSEC_DOCTO>"
                    strXML_GT &= "<F350_FECHA>" & fechaDoc & "</F350_FECHA>"
                    strXML_GT &= "<F350_ID_TERCERO>" & registro.Item("F350_ID_TERCERO").ToString & "</F350_ID_TERCERO>"
                    strXML_GT &= "<f461_id_sucursal_fact>" & registro.Item("f461_id_sucursal_fact").ToString & "</f461_id_sucursal_fact>"
                    strXML_GT &= "<f461_id_tipo_cli_fact>" & registro.Item("f461_id_tipo_cli_fact").ToString & "</f461_id_tipo_cli_fact>"
                    strXML_GT &= "<f461_id_co_fact>" & registro.Item("f461_id_co_fact").ToString & "</f461_id_co_fact>"
                    strXML_GT &= "<f461_id_tercero_rem>" & registro.Item("f461_id_tercero_rem").ToString & "</f461_id_tercero_rem>"
                    strXML_GT &= "<f461_id_sucursal_rem>" & registro.Item("f461_id_sucursal_rem").ToString & "</f461_id_sucursal_rem>"
                    strXML_GT &= "<f461_id_tercero_vendedor>" & registro.Item("f461_id_tercero_vendedor").ToString & "</f461_id_tercero_vendedor>"
                    strXML_GT &= "<f461_id_cond_pago>" & registro.Item("f461_id_cond_pago").ToString & "</f461_id_cond_pago>"
                    strXML_GT &= "<f461_notas>" & registro.Item("f461_notas").ToString & "</f461_notas>"
                    strXML_GT &= "</Documentos>"

                Next


                For Each registro As DataRow In objEnvio.dtMovimientos.Rows

                    strXML_GT &= "<Movimientos>"
                    strXML_GT &= "<F_CIA>" & registro.Item("F_CIA").ToString & "</F_CIA>"
                    strXML_GT &= "<f470_id_co>" & registro.Item("f470_id_co").ToString & "</f470_id_co>"
                    strXML_GT &= "<f470_id_tipo_docto>" & registro.Item("f470_id_tipo_docto").ToString & "</f470_id_tipo_docto>"
                    strXML_GT &= "<f470_consec_docto>" & registro.Item("f470_consec_docto").ToString & "</f470_consec_docto>"
                    strXML_GT &= "<f470_id_bodega>" & registro.Item("f470_id_bodega").ToString & "</f470_id_bodega>"
                    strXML_GT &= "<f470_id_motivo>" & registro.Item("f470_id_motivo").ToString & "</f470_id_motivo>"
                    strXML_GT &= "<f470_id_co_movto>" & registro.Item("f470_id_co_movto").ToString & "</f470_id_co_movto>"
                    strXML_GT &= "<f470_id_ccosto_movto>" & registro.Item("f470_id_ccosto_movto").ToString & "</f470_id_ccosto_movto>"
                    strXML_GT &= "<f470_id_lista_precio>" & registro.Item("f470_id_lista_precio").ToString & "</f470_id_lista_precio>"
                    strXML_GT &= "<f470_id_unidad_medida>" & registro.Item("f470_id_unidad_medida").ToString & "</f470_id_unidad_medida>"
                    strXML_GT &= "<f470_cant_base>" & registro.Item("f470_cant_base").ToString & "</f470_cant_base>"
                    strXML_GT &= "<f470_vlr_bruto>" & registro.Item("f470_vlr_bruto").ToString & "</f470_vlr_bruto>"
                    strXML_GT &= "<f470_referencia_item>" & registro.Item("SKU").ToString & "</f470_referencia_item>"
                    strXML_GT &= "<f470_id_un_movto>" & registro.Item("f470_id_un_movto").ToString & "</f470_id_un_movto>"
                    strXML_GT &= "</Movimientos>"

                Next



                For Each registro As DataRow In objEnvio.dtCxC.Rows

                    Dim fechaVencimiento As String = Date.Now.ToString("yyyyMMdd")

                    strXML_GT &= "<CxC>"
                    strXML_GT &= "<F_CIA>" & registro.Item("F_CIA").ToString & "</F_CIA>"
                    strXML_GT &= "<F350_ID_CO>" & registro.Item("F350_ID_CO").ToString & "</F350_ID_CO>"
                    strXML_GT &= "<F350_ID_TIPO_DOCTO>" & registro.Item("F350_ID_TIPO_DOCTO").ToString & "</F350_ID_TIPO_DOCTO>"
                    strXML_GT &= "<F350_CONSEC_DOCTO>" & registro.Item("F350_CONSEC_DOCTO").ToString & "</F350_CONSEC_DOCTO>"
                    strXML_GT &= "<F353_ID_TIPO_DOCTO_CRUCE>" & registro.Item("F350_ID_TIPO_DOCTO").ToString & "</F353_ID_TIPO_DOCTO_CRUCE>"
                    strXML_GT &= "<F353_CONSEC_DOCTO_CRUCE>" & registro.Item("F350_CONSEC_DOCTO").ToString & "</F353_CONSEC_DOCTO_CRUCE>"
                    'strXML_GT &= "<F353_ID_TIPO_DOCTO_CRUCE>" & registro.Item("F353_ID_TIPO_DOCTO_CRUCE").ToString & "</F353_ID_TIPO_DOCTO_CRUCE>"
                    'strXML_GT &= "<F353_CONSEC_DOCTO_CRUCE>" & registro.Item("F353_CONSEC_DOCTO_CRUCE").ToString & "</F353_CONSEC_DOCTO_CRUCE>"
                    strXML_GT &= "<F353_VLR_CRUCE>" & registro.Item("F353_VLR_CRUCE").ToString & "</F353_VLR_CRUCE>"
                    strXML_GT &= "<F353_FECHA_VCTO>" & fechaVencimiento & "</F353_FECHA_VCTO>"
                    strXML_GT &= "<F353_FECHA_DSCTO_PP>" & registro.Item("F353_FECHA_DSCTO_PP").ToString & "</F353_FECHA_DSCTO_PP>"
                    strXML_GT &= "</CxC>"

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
                plano = ConsumoGT(114935, "NOTA_NV2_DESDE_PDC_Celis", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

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
