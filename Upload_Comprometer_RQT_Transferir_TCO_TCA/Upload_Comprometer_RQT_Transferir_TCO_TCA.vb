Public Class Upload_Comprometer_RQT_Transferir_TCO_TCA
    Private Sub Upload_Comprometer_RQT_Transferir_TCO_TCA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dsDatos As New DataSet

        Try

            If (ModuloSQL.encender_apagar_Interface("Upload_Comprometer_RQT_Transferir_TCO_TCA")) Then

                '=====================================================================================================
                'Paso 1 Captura de Datos
                Try
                    Dim numordenExpedicion As Integer = -1
                    Dim numRequisicion As String = "-1"

                    'numordenExpedicion = -1
                    numRequisicion = "-1"

                    dsDatos = ModuloSQL.sp_WMS_UPLOAD_Transferencia_TCO_TCA_Desde_RQT(numordenExpedicion, numRequisicion)

                Catch ex As Exception
                    'objEnvio.bitError = True
                    'objEnvio.resultadoLog = "Paso 1 Error al capturar los datos : " & ex.Message
                End Try
                '=====================================================================================================


                '=====================================================================================================
                'Paso 2 Envio de Paquetes
                Dim arreglo As Array
                Dim contadorPaquetes As Integer = 0

                If dsDatos.Tables.Count > 0 Then
                    If dsDatos.Tables(0).Rows.Count > 0 Then
                        Try

                            For Each registro As DataRow In dsDatos.Tables(0).Rows

                                Dim objEnvio As New EstructuraUploadModel

                                Dim dtDetalle As DataTable

                                Try

                                    arreglo = registro.Item("paquete").ToString.Split("-")

                                    objEnvio.cia = arreglo(0)
                                    objEnvio.co = arreglo(1)
                                    objEnvio.tipoDoc = registro.Item("f350_id_tipo_docto").ToString
                                    objEnvio.numDoc = arreglo(3)
                                    objEnvio.RowId = registro.Item("f440_rowid").ToString
                                    objEnvio.OEX = registro.Item("OEX").ToString
                                    objEnvio.CO_Bodega_Salida = registro.Item("CO_Bodega_Salida").ToString
                                    objEnvio.F350_FECHA = registro.Item("f350_fecha").ToString
                                    objEnvio.f440_id_co_req_int = registro.Item("f440_id_co_req_int").ToString
                                    objEnvio.f350_notas = registro.Item("OEX").ToString
                                    objEnvio.f450_docto_alterno = registro.Item("f450_docto_alterno").ToString

                                    objEnvio.paquete = objEnvio.cia & "-" & objEnvio.co & "-" & objEnvio.tipoDoc & "-" & objEnvio.numDoc

                                    Dim drDetalle() As DataRow = dsDatos.Tables(1).Select("paquete = '" & Trim(objEnvio.paquete) & "'")
                                    objEnvio.dtDetalle = drDetalle.CopyToDataTable()

                                    Dim AddThread1 As Threading.Thread
                                    Dim objPaquete As New clsRequisiciones_x_Comprometer
                                    AddThread1 = New Threading.Thread(AddressOf objPaquete.comprometer)
                                    AddThread1.Start(objEnvio)

                                    System.Threading.Thread.Sleep(2000)

                                    'If contadorPaquetes = My.Settings.numeroPaquetesCorte Then
                                    '    System.Threading.Thread.Sleep(My.Settings.tiempoEsperaPaquete)
                                    'Else
                                    '    System.Threading.Thread.Sleep(500)
                                    'End If

                                Catch ex As Exception
                                End Try

                            Next

                        Catch ex As Exception
                            'objEnvio.bitError = True
                            'objEnvio.resultadoLog = "Paso 2 Error al capturar los paquetes : " & ex.Message
                        End Try
                    Else
                        'objEnvio.bitError = True
                        'objEnvio.resultadoLog = "Paso 2 No hay paquetes para enviar "
                    End If
                Else
                    'objEnvio.bitError = True
                    'objEnvio.resultadoLog = "Paso 2 No hay tablas en la consulta "
                End If
                '=====================================================================================================


                '//////////////////////////////////////////////////////////////////////////////////////////////////
                'Registrar Log
                'If objEnvio.bitError Then
                '    Try
                '        ModuloSQL.sp_A_Registrar_Log_Upload_Comprometer_Remisionar_Pedidos_PEV(objEnvio.bitError,, objEnvio.cia, objEnvio.co, objEnvio.tipoDoc, objEnvio.numDoc, objEnvio.OEX, objEnvio.RowId,,, objEnvio.resultadoLog)
                '    Catch ex As Exception
                '    End Try
                'End If
                '//////////////////////////////////////////////////////////////////////////////////////////////////

            End If

        Catch ex As Exception

        End Try

        Me.Close()


    End Sub
End Class