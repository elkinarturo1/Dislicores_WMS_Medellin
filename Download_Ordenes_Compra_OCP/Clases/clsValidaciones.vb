Public Class clsValidaciones

    'Dim objProceso As String

    'Public Sub validar_Pedidos_WMS()

    '    objProceso = "clsValidaciones - validar_Pedidos_PEV_WMS"

    '    Try
    '        System.Threading.Thread.Sleep(50000)

    '        Dim ds As New DataSet
    '        select_Tablas_SQL(ds, "V_WMS_DOWNLOAD_VALIDAR_PEDIDOS_IDCARGUE")

    '        If ds.Tables.Count > 0 Then
    '            If ds.Tables(0).Rows.Count > 0 Then

    '                For Each registro As DataRow In ds.Tables(0).Rows

    '                    Dim idKEY As String = ""
    '                    Dim rowId As String = ""

    '                    Try

    '                        idKEY = registro.Item("externorderkey_key_doc").ToString
    '                        rowId = registro.Item("susr1_rowid_encab").ToString
    '                        SP_Actualizacion_Datos_UNOEE_Oracle("DSP_WMS_ACTUALIZAR_CARGUE_PEV", rowId)

    '                    Catch ex As Exception
    '                        sp_registrarLog_Download_WMS(, , rowId, idKEY, "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '                    End Try

    '                Next

    '            End If
    '        End If

    '    Catch ex As Exception
    '        sp_registrarLog_Download_WMS(, , , , "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '    End Try


    'End Sub

    'Public Sub validar_Devoluciones_EDE()

    '    objProceso = "clsValidaciones - validar_Pedidos_EDE_WMS"

    '    Try
    '        System.Threading.Thread.Sleep(120000)

    '        Dim ds As New DataSet
    '        select_Tablas_SQL(ds, "V_WMS_DOWNLOAD_VALIDAR_DEVOLUCIONES_EDE_IDCARGUE")

    '        If ds.Tables.Count > 0 Then
    '            If ds.Tables(0).Rows.Count > 0 Then

    '                For Each registro As DataRow In ds.Tables(0).Rows

    '                    Dim idKEY As String = ""
    '                    Dim rowId As String = ""

    '                    Try

    '                        idKEY = registro.Item("EXTERNRECEIPT_KEY").ToString
    '                        rowId = registro.Item("susr1_rowid_encab").ToString
    '                        SP_Actualizacion_Datos_UNOEE_Oracle("DSP_WMS_ACTUALIZAR_CARGUE_EDE", rowId)

    '                    Catch ex As Exception
    '                        sp_registrarLog_Download_WMS(, , rowId, idKEY, "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '                    End Try

    '                Next

    '            End If
    '        End If

    '    Catch ex As Exception
    '        sp_registrarLog_Download_WMS(, , , , "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '    End Try


    'End Sub

    'Public Sub validar_Pedidos_PDC_WMS()

    '    objProceso = "clsValidaciones - validar_Pedidos_PDC_WMS"

    '    Try
    '        System.Threading.Thread.Sleep(120000)

    '        Dim ds As New DataSet
    '        select_Tablas_SQL(ds, "V_WMS_DOWNLOAD_VALIDAR_DEVOLUCIONES_PDC_IDCARGUE")

    '        If ds.Tables.Count > 0 Then
    '            If ds.Tables(0).Rows.Count > 0 Then

    '                For Each registro As DataRow In ds.Tables(0).Rows

    '                    Dim idKEY As String = ""
    '                    Dim rowId As String = ""

    '                    Try

    '                        idKEY = registro.Item("externreceiptkey_key_doc").ToString
    '                        rowId = registro.Item("susr1_rowid_encab").ToString
    '                        SP_Actualizacion_Datos_UNOEE_Oracle("DSP_WMS_ACTUALIZAR_CARGUE_PDC", rowId)

    '                    Catch ex As Exception
    '                        sp_registrarLog_Download_WMS(, , rowId, idKEY, "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '                    End Try

    '                Next

    '            End If
    '        End If

    '    Catch ex As Exception
    '        sp_registrarLog_Download_WMS(, , , , "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '    End Try


    'End Sub

    'Public Sub validar_Ordenes_de_Compra_OCP()

    '    objProceso = "clsValidaciones - validar_Orden_de_Compra_OCP_WMS"

    '    Try
    '        System.Threading.Thread.Sleep(120000)

    '        Dim ds As New DataSet
    '        select_Tablas_SQL(ds, "V_WMS_DOWNLOAD_VALIDAR_ORDENES_COMPRA_NOTAS")

    '        If ds.Tables.Count > 0 Then
    '            If ds.Tables(0).Rows.Count > 0 Then

    '                For Each registro As DataRow In ds.Tables(0).Rows

    '                    Dim idKEY As String = ""
    '                    Dim rowId As String = ""

    '                    Try

    '                        idKEY = registro.Item("externpokey_key_docto").ToString
    '                        rowId = registro.Item("susr1_rowid_encab").ToString
    '                        SP_Actualizacion_Datos_UNOEE_Oracle("DSP_WMS_ACTUALIZAR_NOTAS_OCP", rowId)

    '                    Catch ex As Exception
    '                        sp_registrarLog_Download_WMS(, , rowId, idKEY, "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '                    End Try

    '                Next

    '            End If
    '        End If

    '    Catch ex As Exception
    '        sp_registrarLog_Download_WMS(, , , , "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '    End Try


    'End Sub

    'Public Sub validar_Transferencias_TCO()

    '    objProceso = "clsValidaciones - validar_Pedidos_TCO_WMS"

    '    Try
    '        System.Threading.Thread.Sleep(120000)

    '        Dim ds As New DataSet
    '        select_Tablas_SQL(ds, "V_WMS_DOWNLOAD_VALIDAR_TRANSFERENCIAS_TCO_NOTAS")

    '        If ds.Tables.Count > 0 Then
    '            If ds.Tables(0).Rows.Count > 0 Then

    '                For Each registro As DataRow In ds.Tables(0).Rows

    '                    Dim idKEY As String = ""
    '                    Dim rowId As String = ""

    '                    Try

    '                        idKEY = registro.Item("externreceiptkey_key_doc").ToString
    '                        rowId = registro.Item("susr1_rowid_encab").ToString
    '                        SP_Actualizacion_Datos_UNOEE_Oracle("DSP_WMS_ACTUALIZAR_NOTAS_TCO", rowId)

    '                    Catch ex As Exception
    '                        sp_registrarLog_Download_WMS(, , rowId, idKEY, "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '                    End Try

    '                Next

    '            End If
    '        End If

    '    Catch ex As Exception
    '        sp_registrarLog_Download_WMS(, , , , "Paso 7 - actualizacion_Campo_Control_Siesa : " & objProceso, "Fin", "Error Generico", ex.Message)
    '    End Try


    'End Sub



    ''Public Sub matarSessionesAbiertasOracle()

    ''    Try
    ''        Dim dsSessiones As New DataSet
    ''        consultarSesionesOracle(dsSessiones)

    ''        If dsSessiones.Tables.Count Then
    ''            If dsSessiones.Tables(0).Rows.Count Then

    ''                For Each registro As DataRow In dsSessiones.Tables(0).Rows

    ''                    Try
    ''                        Dim SID As String = registro.Item("SID").ToString()
    ''                        Dim SERIAL As String = registro.Item("SERIAL#").ToString()

    ''                        'matarProcesosOracle(SID, SERIAL)

    ''                    Catch ex As Exception
    ''                    End Try

    ''                Next

    ''            End If
    ''        End If

    ''    Catch ex As Exception
    ''    End Try

    ''End Sub

End Class
