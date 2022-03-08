Public Class Download_Ensambles_ENS

    Dim obj_Estructura_Download As New clsModeloDownloadGenerico
    Private Sub Download_Ensambles_ENS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dsPaquetes As New DataSet
        Dim objASN As New Proceso_Download_Desensamble_ASN
        Dim objOEX As New Proceso_Download_Desensamble_OEX

        Try

            ModuloSQL.sp_WMS_DOWNLOAD_Ensambles_ENS_Migrar()

            objOEX.ejecutarProceso_OEX()
            objASN.ejecutarProceso_ASN()


        Catch ex As Exception
            ModuloSQL.sp_A_Registrar_Log_Download_ASN(True,, "2",, "DES",,,,,,,,, "A ocurrido una Excepcion - " & ex.Message)
        End Try

        Me.Close()
    End Sub
End Class