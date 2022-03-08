Public Class Download_Devoluciones_DNF
    Private Sub Download_Devoluciones_DNF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dsPaquetes As New DataSet
        Dim objASN As New Proceso_Download_Desensamble_ASN

        Try

            ModuloSQL.sp_WMS_DOWNLOAD_Devoluciones_DNF_Migrar()
            objASN.ejecutarProceso_ASN()

        Catch ex As Exception
            ModuloSQL.sp_A_Registrar_Log_Download_ASN(True,, "2",, "DNF",,,,,,,,, "A ocurrido una Excepcion - " & ex.Message)
        End Try

        Me.Close()

    End Sub
End Class