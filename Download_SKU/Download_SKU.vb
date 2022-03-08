Public Class Download_SKU
    Private Sub Download_SKU_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dsPaquetes As New DataSet
        Dim bitError As Boolean = False

        '=============================================================================================================
        'Paso 1 Consultando paquetes sp_WMS_DOWNLOAD_SKU
        Try
            dsPaquetes = ModuloSQL.sp_WMS_DOWNLOAD_SKU()
        Catch ex As Exception
            bitError = True
            ModuloSQL.sp_A_Registrar_Log_Download_SKU(True, , dsPaquetes.GetXml(), "Se ha presentado una excepcion en Paso 1 Consultando paquetes sp_WMS_DOWNLOAD_SKU : " & ex.Message)
        End Try
        '=============================================================================================================


        '=============================================================================================================
        'Paso 2 enviando datos a WMS enviar_SKU_ION
        If bitError = False Then
            Try
                Dim objEnviarDatosION As New clsEnviarDatos_ION
                objEnviarDatosION.enviar_SKU_ION(dsPaquetes)
            Catch ex As Exception
                bitError = True
                ModuloSQL.sp_A_Registrar_Log_Download_SKU(True, , dsPaquetes.GetXml(), "Se ha presentado una excepcion en Paso 2 enviando datos a WMS enviar_SKU_ION : " & ex.Message)
            End Try
        End If
        '=============================================================================================================

        Me.Close()
    End Sub
End Class