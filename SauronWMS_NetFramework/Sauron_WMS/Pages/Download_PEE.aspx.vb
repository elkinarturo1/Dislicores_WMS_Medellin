
Imports System.Data
Imports System.IO

Partial Class Pages_Download_PEE
    Inherits System.Web.UI.Page

    Private Sub Pages_Download_PEE_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim objSQL As New Download_PEE_SQL
        Dim ds As New DataSet

        If Not IsPostBack Then

            Try

                ds = objSQL.sp_WMS_DOWNLOAD_Pedidos_PEE(-1)

                dgvDatos.DataSource = ds
                dgvDatos.DataMember = ds.Tables(0).ToString
                dgvDatos.EditIndex = -1
                dgvDatos.DataBind()

            Catch ex As Exception
                lblMensaje.Text = ex.Message
            End Try


        End If

    End Sub


    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim objSQL As New Download_PEE_SQL
        Dim ds As New DataSet

        Dim nit As String = "-1"

        If txtBuscar.Text.Trim.Length > 0 Then
            nit = txtBuscar.Text
        End If

        Try

            ds = objSQL.sp_WMS_DOWNLOAD_Pedidos_PEE(nit)

            Session("dtPaquetes") = ds.Tables(0)
            Session("dtDetalle") = ds.Tables(1)

            dgvDatos.DataSource = ds
            dgvDatos.DataMember = ds.Tables(0).ToString
            dgvDatos.EditIndex = -1
            dgvDatos.DataBind()

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

    End Sub


    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Dim objProceso As New Proceso_Download_PEE
        Dim obj_Estructura_Download As New clsModeloDownloadGenerico

        Dim dtPaquetes As New DataTable
        Dim dtDetalle As New DataTable
        Dim bitError As Boolean = False
        Dim resultado As String = "Proceso Terminado Correctamente"

        Try

            obj_Estructura_Download.dtPaquetes = Session("dtPaquetes")
            obj_Estructura_Download.dtDetalles = Session("dtDetalle")

            If obj_Estructura_Download.dtPaquetes.Rows.Count > 0 Then

                objProceso.insercion_Datos_Principales_ION(obj_Estructura_Download.dtPaquetes, obj_Estructura_Download.dtDetalles, obj_Estructura_Download.Proceso, obj_Estructura_Download.BitError)

            Else
                bitError = True
                resultado = "Todos los pedidos se encuentran en WMS"
            End If




            'If Len(txtBuscar.Text.Trim) > 0 Then
            '    objProceso.ejecutarProceso(obj_Estructura_Download, bitError, resultado, txtBuscar.Text.Trim)
            '    lblMensaje.Text = resultado
            'Else
            '    lblMensaje.Text = "Debe digitar un nit para enviar"
            'End If

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

        lblMensaje.Text = resultado

    End Sub


    Private Sub DescargarArchivo(ByVal fname As String)
        Dim fullpath = Path.GetFullPath(fname)
        Dim name = Path.GetFileName(fullpath)
        Dim type As String = "text/plain"

        Response.AppendHeader("content-disposition",
        "attachment; filename=" + name)

        Response.ContentType = type

        Response.WriteFile(fullpath)
        Response.End()

    End Sub


End Class
