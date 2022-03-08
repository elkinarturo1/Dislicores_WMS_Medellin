Imports System
Imports System.Data
Imports Microsoft.VisualBasic

Public Module ModuloConsumoUNOEE

    Public Sub CargasWSUNOEE(ByRef bitError As Boolean, ByRef resultado As String, ByVal cia As String, ByVal plano As String)


        Dim objWSUNOEE As New WSUNOEE.WSUNOEE
        Dim resultadoConsumoUNOEE As Short = 123
        Dim ds As New DataSet
        Dim strXML_UNOEE As String = ""


        Try

            strXML_UNOEE &= "<Importar>"
            strXML_UNOEE &= "<NombreConexion>" & System.Configuration.ConfigurationManager.AppSettings.Item("ConexionUNOEE").ToString & "</NombreConexion>"
            strXML_UNOEE &= "<IdCia>" & cia & "</IdCia>"
            strXML_UNOEE &= "<Usuario>" & System.Configuration.ConfigurationManager.AppSettings.Item("UsuarioUNOEE").ToString & "</Usuario>"
            strXML_UNOEE &= "<Clave>" & System.Configuration.ConfigurationManager.AppSettings.Item("ClaveUNOEE").ToString & "</Clave>"
            strXML_UNOEE &= plano
            strXML_UNOEE &= "</Importar>"

            objWSUNOEE.Timeout = 180000
            ds = objWSUNOEE.ImportarXML(strXML_UNOEE, resultadoConsumoUNOEE)


            Select Case resultadoConsumoUNOEE
                Case 0
                    resultado = " Importacion Exitosa " & vbNewLine
                Case 1
                    resultado = " : Error : 1 - Error de datos al cargar la informacion a siesa a Siesa " & vbNewLine
                Case 2
                    resultado = " : Error : 2 - El impodatos no envio algun parametro " & vbNewLine
                Case 3
                    resultado = " : Error :  3 - El usuario o la contraseña que ingreso no son validos " & vbNewLine
                Case 4
                    resultado = " : Error : 4 - La version del impodatos no se corresponde con la version del ERP o el impodatos esta en una maquina que no tiene cliente Siesa " & vbNewLine
                Case 5
                    resultado = " : Error :  5 - La base de datos no existe o están ingresándole un parámetro erróneo a la hora de especificar la conexión. " & vbNewLine
                Case 6
                    resultado = " : Error : 6 - El archivo que se está especificando en la ruta de los parámetros del .BAT no existe " & vbNewLine
                Case 7
                    resultado = "  Error :  7 - El archivo que se está especificando en la ruta de los parámetros del .BAT no es valido " & vbNewLine
                Case 8
                    resultado = " : Error : 8 - Hay un problema con la tabla en la base de datos donde se ingresaran los archivos " & vbNewLine
                Case 9
                    resultado = " : Error :  9 - La compañía que se ingresó en los parámetros del .BAT no es valida " & vbNewLine
                Case 10
                    resultado = " : Error : 10 - Error desconocido " & vbNewLine
                Case 99
                    resultado = "Error : 99 - Error de tipo diferente a los anteriores, normalmente de permisos a nivel del ERP " & vbNewLine
            End Select

        Catch ex As Exception
            bitError = True
            resultado = "Error Consumiendo WSUNOEE " & ex.Message
        End Try



        'Dim errorConsumo As Boolean = False
        'Dim numIntento As Integer = 1

        'Do While (errorConsumo = False)

        '    Try

        '        'If ((numIntento = 1) Or (numIntento = 3)) Then
        '        '    'Odiseo
        '        '    objWSUNOEE.Url = "http://192.168.0.105/WSUNOEE/WSUNOEE.asmx"
        '        'Else
        '        '    'Euclides
        '        '    objWSUNOEE.Url = "http://172.16.100.24/WSUNOEE/WSUNOEE.asmx"
        '        'End If

        '        'Euclides
        '        objWSUNOEE.Url = "http://172.16.100.24/WSUNOEE/WSUNOEE.asmx"

        '        objWSUNOEE.Timeout = 18000000


        objWSUNOEE.Dispose()

    End Sub


End Module
