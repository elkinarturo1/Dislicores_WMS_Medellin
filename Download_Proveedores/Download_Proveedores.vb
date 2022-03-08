Public Class Download_Proveedores
    Private Sub Download_Proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dsPaquetes As New DataSet
        Dim bitError As Boolean = False

        '=============================================================================================================
        'Paso 1 Consultando paquetes sp_WMS_DOWNLOAD_Receptores
        Try
            dsPaquetes = ModuloSQL.sp_WMS_DOWNLOAD_Proveedores()
        Catch ex As Exception
            bitError = True
            ModuloSQL.sp_WMS_DOWNLOAD_Proveedores(True, , , dsPaquetes.GetXml(), "Se ha presentado una excepcion en Paso 1 Consultando paquetes sp_WMS_DOWNLOAD_Receptores : " & ex.Message)
        End Try
        '=============================================================================================================


        '=============================================================================================================
        'Paso 2 enviando datos a WMS enviar_STORER_ION
        If bitError = False Then
            Try
                Dim objEnviarDatosION As New clsEnviarDatos_ION
                objEnviarDatosION.enviar_STORER_ION(dsPaquetes)
            Catch ex As Exception
                bitError = True
                ModuloSQL.sp_WMS_DOWNLOAD_Proveedores(True, , , dsPaquetes.GetXml(), "Se ha presentado una excepcion en Paso 2 enviando datos a WMS enviar_STORER_ION : " & ex.Message)
            End Try
        End If
        '=============================================================================================================

        Me.Close()

    End Sub
End Class