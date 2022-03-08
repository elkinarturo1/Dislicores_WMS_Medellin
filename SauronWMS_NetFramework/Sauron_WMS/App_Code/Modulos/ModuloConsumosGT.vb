Imports System.Data
Imports Microsoft.VisualBasic

Public Module ModuloConsumosGT

    Public Function ConsumoGT(ByRef bitError As Boolean, ByRef resultado As String, ByVal idDocumento As String, ByVal nombreDocumento As String, ByVal cia As String, ByVal dsDatosGT As DataSet) As String

        Dim plano As String = ""
        Dim objGT As New WSGT.wsGenerarPlano

        Try
            Dim rutaPlanos As String = "C:\inetpub\wwwroot\GTIntegrationDislicores\Planos\"
            plano = objGT.GenerarPlanoXML(idDocumento, nombreDocumento, 2, cia, "gt", "gt", dsDatosGT, rutaPlanos, resultado)

            If plano.Trim.Length = 0 Then
                bitError = True
            End If

        Catch ex As Exception
            bitError = True
            resultado = "Error Paso 4 Consumiendo GT : " & ex.Message
        Finally
            objGT.Dispose()
        End Try

        Return plano

    End Function

End Module
