
Public Class clsRequisiciones_x_Transferir


    Public Sub transferir(ByVal objEnvio As EstructuraUploadModel)

        Dim dsDatosGT As New DataSet
        Dim strXML_GT As String = ""
        Dim plano As String = ""

        Dim bitError As Boolean = False

        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If bitError = False Then

            Try

                Dim fechaDoc As String = Now.Date.ToString("yyyyMMdd")

                strXML_GT &= "<MyDataSet>"

                strXML_GT &= "<Inicial>"
                strXML_GT &= "<F_CIA>002</F_CIA>"
                strXML_GT &= "</Inicial>"

                strXML_GT &= "<Documentos>"
                strXML_GT &= "<F_CIA>002</F_CIA>"
                strXML_GT &= "<F350_ID_CO>" & objEnvio.co & "</F350_ID_CO>"
                strXML_GT &= "<F350_ID_TIPO_DOCTO>" & objEnvio.tipoDoc & "</F350_ID_TIPO_DOCTO>"
                strXML_GT &= "<F350_CONSEC_DOCTO>" & objEnvio.numDoc & "</F350_CONSEC_DOCTO>"
                strXML_GT &= "<F350_FECHA>" & fechaDoc & "</F350_FECHA>"
                strXML_GT &= "<f440_id_co_req_int>" & objEnvio.f440_id_co_req_int & "</f440_id_co_req_int>"
                strXML_GT &= "<f440_id_tipo_docto_req_int>" & objEnvio.f440_id_tipo_docto_req_int & "</f440_id_tipo_docto_req_int>"
                strXML_GT &= "<f440_consec_docto_req_int>" & objEnvio.numDoc & "</f440_consec_docto_req_int>"
                strXML_GT &= "<f350_notas>" & objEnvio.OEX & "</f350_notas>"
                strXML_GT &= "<f450_docto_alterno>" & objEnvio.f450_docto_alterno & "</f450_docto_alterno>"
                strXML_GT &= "</Documentos>"

                strXML_GT &= "<Final>"
                strXML_GT &= "<F_CIA>002</F_CIA>"
                strXML_GT &= "</Final>"

                strXML_GT &= "</MyDataSet>"

            Catch ex As Exception
                bitError = True
                objEnvio.datosEnviadosExcepcion = strXML_GT
                objEnvio.resultadoLog = "Error al armar el xml de GT cargarRemision " & ex.Message
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If bitError = False Then
            Try
                dsDatosGT = convertirXML_to_DataSet(strXML_GT)
            Catch ex As Exception
                bitError = True
                objEnvio.datosEnviadosExcepcion = strXML_GT
                objEnvio.resultadoLog = "Error al convertir el XML de GT en dataset cargarRemision " & ex.Message
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        If bitError = False Then
            Try
                Dim resultadoConsumoGT As String = ""
                plano = ConsumoGT(110442, "TRASNFERENCIA_DESDE_REQUISICION_RQV_TBV", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

                If (resultadoConsumoGT <> "Se genero el plano correctamente") Then
                    bitError = True
                    objEnvio.datosEnviadosGT = dsDatosGT.GetXml
                    objEnvio.resultadoLog = "Error al consumir GTIntegration cargarRemision " & resultadoConsumoGT
                End If

            Catch ex As Exception
                bitError = True
                objEnvio.datosEnviadosGT = dsDatosGT.GetXml
                objEnvio.resultadoLog = "Error al consumir GTIntegration comprometerPedidos " & ex.Message
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Cargar Remision
        If bitError = False Then
            Try
                CargasWSUNOEE("Remision : " & objEnvio.paquete, plano, objEnvio, bitError)
            Catch ex As Exception
                Throw ex
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////

    End Sub


End Class
