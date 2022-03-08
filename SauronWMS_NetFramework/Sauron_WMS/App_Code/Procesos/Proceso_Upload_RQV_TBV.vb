Imports System.Data
Imports Microsoft.VisualBasic

Public Class Proceso_Upload_RQV_TBV

    Dim objSQL As New Upload_RQV_TBV_SQL

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
                dsDatosSQL = objSQL.sp_WMS_UPLOAD_Transferencia_TBV_Desde_RQV(bitError, resultado, paquete)
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

                        For Each registro As DataRow In dsDatosSQL.Tables(0).Rows

                            Dim fechaDoc As String = Now.Date.ToString("yyyyMMdd")

                            strXML_GT &= "<Documentos>"
                            strXML_GT &= "<f350_consec_docto>" & registro.Item("f350_consec_docto").ToString & "</f350_consec_docto>"
                            strXML_GT &= "<f350_fecha>" & fechaDoc & "</f350_fecha>"
                            strXML_GT &= "<f440_consec_docto_req_int>" & registro.Item("f440_consec_docto_req_int").ToString & "</f440_consec_docto_req_int>"
                            strXML_GT &= "</Documentos>"

                        Next

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
            plano = ModuloConsumosGT.ConsumoGT(bitError, resultado, 100312, "WMS_TRANSFERENCIA_TBV_SALIDA_RQV", cia, dsDatosGT)
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
