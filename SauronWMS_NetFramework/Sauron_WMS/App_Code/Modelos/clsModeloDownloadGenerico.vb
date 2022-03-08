Imports System.Data

Public Class clsModeloDownloadGenerico


    'Proceso en ejecicion
    Public Property Proceso As String

    'bit de control de errores
    Public Property BitError As Boolean = False

    'Resultado
    Public Property Resultado As String = ""

    'Objetos proceso de migracion y captura de datos ORACLE
    Public Property Tabla_Datos_ORACLE As String
    Public Property SP_Migracion_ORACLE As String

    'Fuente de datos ORACLE
    Public Property Vista_Tercero_ORACLE As String
    Public Property Vista_SKU_ORACLE As String

    'Tablas datos SQL
    Public Property Tabla_Datos_SQL As String
    Public Property Tabla_Tercero_SQL As String
    Public Property Tabla_SKU_SQL As String

    'Fuente de datos SQL Terceros y SQL
    Public Property Vista_DatosAgrup_SQL As String

    'Procedimientos Almacenados DOWNLOAD SQL
    Public Property SP_Datos_SQL As String
    Public Property SP_Terceros_SQL As String
    Public Property SP_SKU_SQL As String


    'Dataset de almacenamiento
    Public Property dsPaquetes As New DataSet
    Public Property dsDatos_Oracle As New DataSet
    Public Property dsTerceros_Oracle As New DataSet
    Public Property dsSKU_Oracle As New DataSet
    Public Property DS_Paquetes As New DataSet
    Public Property DS_Datos_SQL As New DataSet
    Public Property DS_Tercero_SQL As New DataSet
    Public Property DS_SKU_SQL As New DataSet

    Public Property dtPaquetes As New DataTable
    Public Property dtDetalles As New DataTable



End Class
