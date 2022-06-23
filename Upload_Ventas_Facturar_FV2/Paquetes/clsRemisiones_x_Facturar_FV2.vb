
Public Class clsRemisiones_x_Facturar_FV2

    Public Sub enviarDatos(ByVal objEnvio As EstructuraUploadModel)

        Dim dsDatosGT As New DataSet
        Dim strXML_GT As String = ""
        Dim plano As String = ""


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If objEnvio.bitError = False Then

            Try

                Dim fechaDoc As String = Now.Date.ToString("yyyyMMdd")

                strXML_GT &= "<MyDataSet>"

                strXML_GT &= "<Inicial>"
                strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>"
                strXML_GT &= "</Inicial>"


                For Each registro As DataRow In objEnvio.dtDocumentos.Rows

                    strXML_GT &= "<DoctoVentasComercial>"
                    strXML_GT &= "<F_CIA>" & registro.Item("id_Cia_Rem").ToString & "</F_CIA>"
                    strXML_GT &= "<F350_ID_CO>" & registro.Item("id_CO_Rem").ToString & "</F350_ID_CO>"
                    strXML_GT &= "<F350_ID_TIPO_DOCTO>" & registro.Item("TipoDocFact").ToString & "</F350_ID_TIPO_DOCTO>"
                    strXML_GT &= "<F350_CONSEC_DOCTO>" & registro.Item("id_NumDoc_Rem").ToString & "</F350_CONSEC_DOCTO>"
                    strXML_GT &= "<F350_FECHA>" & fechaDoc & "</F350_FECHA>"
                    strXML_GT &= "<F350_ID_TERCERO>" & registro.Item("id_Tercero_Facturar").ToString & "</F350_ID_TERCERO>"
                    strXML_GT &= "<f461_id_sucursal_fact>" & registro.Item("id_Sucursal_Facturar").ToString & "</f461_id_sucursal_fact>"
                    strXML_GT &= "<f461_id_tercero_rem>" & registro.Item("id_Tercero_Remisionar").ToString & "</f461_id_tercero_rem>"
                    strXML_GT &= "<f461_id_sucursal_rem>" & registro.Item("id_Sucursal_Remisionar").ToString & "</f461_id_sucursal_rem>"
                    strXML_GT &= "<f461_id_tercero_vendedor>" & registro.Item("idTercero_vendedor").ToString & "</f461_id_tercero_vendedor>"
                    strXML_GT &= "<f461_num_docto_referencia>" & Trim(registro.Item("f460_num_docto_referencia").ToString.Replace(Chr(10), "").Replace(Chr(13), "")) & "</f461_num_docto_referencia>"
                    strXML_GT &= "<f461_id_tipo_cli_fact>" & registro.Item("f460_id_tipo_cli_fact").ToString & "</f461_id_tipo_cli_fact>"
                    strXML_GT &= "<f461_id_co_fact>" & registro.Item("f460_id_co_fact").ToString & "</f461_id_co_fact>"
                    strXML_GT &= "<f461_id_cond_pago>" & registro.Item("f460_id_cond_pago").ToString & "</f461_id_cond_pago>"
                    strXML_GT &= "<f461_notas>" & objEnvio.paquete & " - " & registro.Item("f430_Notas").ToString.Replace("&", "y").ToString.Replace(Chr(10), "").Replace(Chr(13), "") & "</f461_notas>"
                    strXML_GT &= "</DoctoVentasComercial>"

                Next


                For Each registro As DataRow In objEnvio.dtDetalle_Relacion_Doctos.Rows
                    strXML_GT &= "<RelacionDoctos>"
                    strXML_GT &= "<F_CIA>" & registro.Item("id_Cia_Rem").ToString & "</F_CIA>"
                    strXML_GT &= "<F350_ID_CO>" & registro.Item("id_CO_Rem").ToString & "</F350_ID_CO>"
                    strXML_GT &= "<F350_ID_TIPO_DOCTO>" & registro.Item("TipoDocFact").ToString & "</F350_ID_TIPO_DOCTO>"
                    strXML_GT &= "<F350_CONSEC_DOCTO>" & registro.Item("id_NumDoc_Rem").ToString & "</F350_CONSEC_DOCTO>"
                    strXML_GT &= "<F460_ID_CO>" & registro.Item("id_CO_Rem").ToString & "</F460_ID_CO>"
                    strXML_GT &= "<F460_ID_TIPO_DOCTO>" & registro.Item("id_TipoDoc_Rem").ToString & "</F460_ID_TIPO_DOCTO>"
                    strXML_GT &= "<F460_CONSEC_DOCTO>" & registro.Item("id_NumDoc_Rem").ToString & "</F460_CONSEC_DOCTO>"
                    strXML_GT &= "</RelacionDoctos>"
                Next


                For Each registro As DataRow In objEnvio.dtDetalle_CxC.Rows

                    Dim fechaVcto As String
                    Dim fechaDsctoPP As String

                    Dim diasVencimiento As String = registro.Item("f460_cond_pago_dias_vcto").ToString
                    Dim diasProntoPago As String = registro.Item("f460_cond_pago_dias_pp").ToString

                    fechaVcto = Now.Date.AddDays(diasVencimiento).ToString("yyyyMMdd")
                    fechaDsctoPP = Now.Date.AddDays(diasProntoPago).ToString("yyyyMMdd")

                    strXML_GT &= "<CuotasCxC>"
                    strXML_GT &= "<F_CIA>" & registro.Item("id_Cia_Rem").ToString & "</F_CIA>"
                    strXML_GT &= "<F350_ID_CO>" & registro.Item("id_CO_Rem").ToString & "</F350_ID_CO>"
                    strXML_GT &= "<F350_ID_TIPO_DOCTO>" & registro.Item("TipoDocFact").ToString & "</F350_ID_TIPO_DOCTO>"
                    strXML_GT &= "<F350_CONSEC_DOCTO>" & registro.Item("id_NumDoc_Rem").ToString & "</F350_CONSEC_DOCTO>"
                    strXML_GT &= "<F353_FECHA_VCTO>" & fechaVcto & "</F353_FECHA_VCTO>"
                    strXML_GT &= "<F353_FECHA_DSCTO_PP>" & fechaDsctoPP & "</F353_FECHA_DSCTO_PP>"
                    strXML_GT &= "</CuotasCxC>"

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
                'plano = ConsumoGT(77819, "WMS_FACTURA_DESDE_REMISION", objEnvio.cia, dsDatosGT, resultadoConsumoGT)
                plano = ConsumoGT(124629, "WMS_FACTURA_DESDE_REMISION", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

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
        'Cargar UNOEE
        If objEnvio.bitError = False Then
            Try
                If (objEnvio.entidadDinamica.Trim().Length() > 0) Then
                    objEnvio.entidadDinamica = objEnvio.entidadDinamica.PadRight(2000, " ")
                    plano = "<Datos>"
                    plano &= "<Linea>000000100000001002</Linea>"
                    plano &= $"<Linea>0000002075310020021001FV20020296205200000000000AdditionalDocumentReference   Additional Document Reference AdditionalDocumentReference   00000000000000000.0000000000{objEnvio.entidadDinamica}                                     G504_1  0000                                                                                                              </Linea>"
                    plano &= "<Linea>000000399990001002</Linea>"
                    plano &= "</Datos>"
                    CargasWSUNOEE(objEnvio.paquete, plano, objEnvio)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


    End Sub

    Public Function calcularFechaVencimiento(ByVal condicion As String) As String

        Dim fechaVencimiento As Date = Now.Date
        Dim strfechaVencimiento As String = ""

        Try
            If (condicion = "EFE") Then
                strfechaVencimiento = fechaVencimiento.AddDays(30).ToString("yyyyMMdd")
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Try
            If condicion = 30 Then
                fechaVencimiento = fechaVencimiento.AddDays(condicion)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return fechaVencimiento

    End Function


End Class
