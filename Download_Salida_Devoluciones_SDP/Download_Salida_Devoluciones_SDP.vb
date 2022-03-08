Public Class Download_Salida_Devoluciones_SDP
    Private Sub Download_Salida_Devoluciones_SDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dsPaquetes As New DataSet
        Dim objOEX As New Proceso_Download_Desensamble_OEX

        Try

            ModuloSQL.sp_WMS_DOWNLOAD_Devoluciones_SDP_Migrar()
            objOEX.ejecutarProceso_OEX()

        Catch ex As Exception
            ModuloSQL.A_Log_Download_OEX(True,, "2",, "SDP",,,,,,,, "A ocurrido una Excepcion - " & ex.Message)
        End Try

        Me.Close()
    End Sub
End Class