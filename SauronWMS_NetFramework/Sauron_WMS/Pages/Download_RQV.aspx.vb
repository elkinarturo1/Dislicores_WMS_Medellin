
Imports System.Data

Partial Class Pages_Download_RQV
    Inherits System.Web.UI.Page

    Private Sub Pages_Download_RQV_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Try
                ModuloSQL.ejecutar_sp_Download_SQL("sp_WMS_DOWNLOAD_Requisiciones_RQV_Migrar")
                'ModuloSQL.ejecutar_sp_Download_SQL("sp_WMS_DOWNLOAD_SKU_Pedidos_Migrar")
                'ModuloSQL.ejecutar_sp_Download_SQL("sp_WMS_DOWNLOAD_Terceros_Pedidos_PEE_Migrar")
            Catch ex As Exception
                lblMensaje.Text = ex.Message
            End Try


        End If

    End Sub



    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Dim bitError As Boolean = False
        Dim resultado As String = ""
        Dim proceso As New Proceso_Download_RQV

        Try
            proceso.ejecutarProceso(bitError, resultado, txtBuscar.Text.Trim)
        Catch ex As Exception
            bitError = False
            resultado = ex.Message
        End Try

        lblMensaje.Text = resultado

    End Sub



End Class
