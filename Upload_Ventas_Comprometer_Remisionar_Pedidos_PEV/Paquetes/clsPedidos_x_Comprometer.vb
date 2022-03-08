
Public Class clsPedidos_x_Comprometer


    Public Sub comprometerPedidos(ByVal objEnvio As EstructuraUploadModel)

        Dim objLog As New LogModel
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
                            strXML_GT &= "<F_CIA>" & registro.Item("f430_id_cia").ToString & "</F_CIA>" & Environment.NewLine
                            strXML_GT &= "<f430_id_co>" & registro.Item("f430_id_co").ToString & "</f430_id_co>" & Environment.NewLine
                            strXML_GT &= "<f430_id_tipo_docto>" & registro.Item("f430_id_tipo_docto").ToString & "</f430_id_tipo_docto>" & Environment.NewLine
                            strXML_GT &= "<f430_consec_docto>" & registro.Item("f430_consec_docto").ToString & "</f430_consec_docto>" & Environment.NewLine
                            strXML_GT &= "<f431_referencia_item>" & registro.Item("SKU").ToString & "</f431_referencia_item>" & Environment.NewLine
                            strXML_GT &= "<f431_id_bodega>" & registro.Item("Bodega").ToString & "</f431_id_bodega>" & Environment.NewLine
                            strXML_GT &= "<f431_id_unidad_medida>" & registro.Item("UnidadMedida").ToString & "</f431_id_unidad_medida>" & Environment.NewLine
                            strXML_GT &= "<f431_cant_base>" & registro.Item("CantidadCompromiso").ToString & "</f431_cant_base>" & Environment.NewLine
                            strXML_GT &= "<f431_nro_registro>" & registro.Item("OrdenInterno").ToString & "</f431_nro_registro>" & Environment.NewLine
                            strXML_GT &= "<f405_cant_por_remisionar_base>" & CInt(registro.Item("CantidadCompromiso").ToString) & "</f405_cant_por_remisionar_base>" & Environment.NewLine
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
                plano = ConsumoGT(77717, "WMS_PEDIDOS_COMPROMISOS", objEnvio.cia, dsDatosGT, resultadoConsumoGT)

                If (resultadoConsumoGT <> "Se genero el plano correctamente") Then
                    bitError = True
                    objEnvio.datosEnviados_GT = dsDatosGT.GetXml
                    objEnvio.resultadoLog = "Error al consumir GTIntegration comprometerPedidos " & resultadoConsumoGT
                End If

            Catch ex As Exception
                bitError = True
                objEnvio.datosEnviados_GT = dsDatosGT.GetXml
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
                Dim objRemision As New clsPedidos_x_Remisionar
                objRemision.cargarRemision(objEnvio)
            Catch ex As Exception
                objEnvio.bitError = True
            End Try
        End If
        '//////////////////////////////////////////////////////////////////////////////////////////////////


        '//////////////////////////////////////////////////////////////////////////////////////////////////
        'Registrar Log
        Try

            ModuloSQL.sp_A_Registrar_Log_Upload_WSUNOEE(objEnvio)

        Catch ex As Exception
            objEnvio.resultadoLog = ex.Message
        End Try
        '//////////////////////////////////////////////////////////////////////////////////////////////////

    End Sub


End Class
