Public Class EstructuraUploadModel

    Public Property paquete As String = " "
    Public Property cia As String = " "
    Public Property co As String = " "
    Public Property tipoDoc As String = " "
    Public Property numDoc As String = " "

    Public Property co_BodegaEntrada As String = " "
    Public Property F350_FECHA = " "
    Public Property f440_id_tipo_docto_req_int = " "
    Public Property f440_id_co_req_int = " "
    Public Property f350_notas = " "
    Public Property f450_docto_alterno = " "

    Public Property ASN As String = " "
    Public Property RowId As String = " "
    Public Property bitError As Boolean = False
    Public Property datosEnviadosGT As String = " "
    Public Property datosEnviadosUNOEE As String = " "
    Public Property datosEnviadosExcepcion As String = " "
    Public Property resultadoLog As String = " "

    Public dtDocumentos As DataTable
    Public dtDetalle As DataTable

End Class
