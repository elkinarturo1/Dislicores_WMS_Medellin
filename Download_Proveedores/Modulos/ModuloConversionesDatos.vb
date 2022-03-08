Imports System.IO
Imports System.Xml

Module ModuloConversionesDatos

    Public Function convertirXML_to_DataSet(ByVal strXML As String) As DataSet

        Dim ds As New DataSet

        Try
            'sp_registrarLogCargaDocumentoSiesa(cia, co, tipoDoc, numDoc, "Conviertiendo a DataSet", "Inicio")

            'Valida la estructura del XML convirtiendolo a DataSet
            Dim txtReader1 As TextReader = New StringReader(strXML)
            Dim reader1 As XmlReader = New XmlTextReader(txtReader1)
            ds.ReadXml(reader1)
            'sp_registrarLogCargaDocumentoSiesa(cia, co, tipoDoc, numDoc, "Conviertiendo a DataSet", "Fin", "OK")

        Catch ex As Exception
            'sp_registrarLogCargaDocumentoSiesa(cia, co, tipoDoc, numDoc, "Conviertiendo a DataSet", "Fin", "Error", ex.Message)
            Throw ex
        End Try

        Return ds

    End Function

End Module
