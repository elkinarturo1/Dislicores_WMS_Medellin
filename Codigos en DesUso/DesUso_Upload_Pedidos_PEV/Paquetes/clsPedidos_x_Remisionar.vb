
Public Class clsPedidos_x_Remisionar


    Public Sub cargarRemision(ByVal objEnvio As EstructuraUploadModel)

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
                strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>"
                strXML_GT &= "</Inicial>"

                strXML_GT &= "<Remision>"
                strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>"
                strXML_GT &= "<F350_ID_CO>" & objEnvio.co & "</F350_ID_CO>"
                strXML_GT &= "<F350_ID_TIPO_DOCTO>REV</F350_ID_TIPO_DOCTO>"
                strXML_GT &= "<F350_CONSEC_DOCTO>" & objEnvio.numDoc & "</F350_CONSEC_DOCTO>"
                strXML_GT &= "<F350_FECHA>" & fechaDoc & "</F350_FECHA>"
                strXML_GT &= "<F430_ID_TIPO_DOCTO>" & objEnvio.tipoDoc & "</F430_ID_TIPO_DOCTO>"
                strXML_GT &= "<F430_CONSEC_DOCTO>" & objEnvio.numDoc & "</F430_CONSEC_DOCTO>"
                strXML_GT &= "</Remision>"

                strXML_GT &= "<Final>"
                strXML_GT &= "<F_CIA>" & objEnvio.cia & "</F_CIA>"
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
                plano = ConsumoGT(77816, "WMS_REMISION_DESDE_PEDIDO_PEV", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

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
