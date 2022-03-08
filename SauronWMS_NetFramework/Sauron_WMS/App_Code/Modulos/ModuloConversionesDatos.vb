Imports System.Data
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic

Public Module ModuloConversionesDatos

    Public Function convertirXML_to_DataSet(ByRef bitError As Boolean, ByRef resultado As String, ByVal strXML As String) As DataSet

        Dim ds As New DataSet

        Try
            'Valida la estructura del XML convirtiendolo a DataSet
            Dim txtReader1 As TextReader = New StringReader(strXML)
            Dim reader1 As XmlReader = New XmlTextReader(txtReader1)
            ds.ReadXml(reader1)
        Catch ex As Exception
            bitError = True
            resultado = "Error Convirtiendo a DataSet : " & ex.Message
        End Try

        Return ds

    End Function

End Module
