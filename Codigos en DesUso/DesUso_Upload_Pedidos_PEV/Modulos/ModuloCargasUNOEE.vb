Module ModuloCargasUNOEE


    Public Sub CargasWSUNOEE(ByVal proceso As String, ByVal plano As String, ByRef objEnvio As EstructuraUploadModel, ByRef bitError As Boolean)


        Dim objWSUNOEE As New WSUNOEE.WSUNOEE
        Dim resultadoUNOEE As Short = 123
        Dim ds As New DataSet
        Dim strMensaje As String = ""

        If My.Settings.EnviarDatosUNOEE Then

            Dim strXML_UNOEE As String = ""

            strXML_UNOEE &= "<Importar>"
            strXML_UNOEE &= "<NombreConexion>" & My.Settings.strConexionSiesa & "</NombreConexion>" & Environment.NewLine
            'strXML_UNOEE &= "<NombreConexion>Real</NombreConexion>" & Environment.NewLine ' Conexion del servidor ATLAS
            strXML_UNOEE &= "<IdCia>" & objEnvio.cia & "</IdCia>" & Environment.NewLine
            strXML_UNOEE &= "<Usuario>" & My.Settings.strUsuarioSiesa & "</Usuario>" & Environment.NewLine
            strXML_UNOEE &= "<Clave>" & My.Settings.strClaveSiesa & "</Clave>" & Environment.NewLine
            strXML_UNOEE &= plano
            strXML_UNOEE &= "</Importar>" & Environment.NewLine

            Try

                objWSUNOEE.Timeout = 120000
                ds = objWSUNOEE.ImportarXML(strXML_UNOEE, resultadoUNOEE)

                Select Case resultadoUNOEE
                    Case 0
                        strMensaje = proceso & " : Importacion Exitosa " & vbNewLine
                    Case 1
                        strMensaje = proceso & " : Error : 1 - Error de datos al cargar la informacion a siesa a Siesa " & vbNewLine & vbNewLine & ds.GetXml().ToString()
                    Case 2
                        strMensaje = proceso & " : Error : 2 - El impodatos no envio algun parametro " & vbNewLine
                    Case 3
                        strMensaje = proceso & " : Error :  3 - El usuario o la contraseña que ingreso no son validos " & vbNewLine
                    Case 4
                        strMensaje = proceso & " : Error : 4 - La version del impodatos no se corresponde con la version del ERP o el impodatos esta en una maquina que no tiene cliente Siesa o el ERP esta inacesible o tiene los servicios caidos " & vbNewLine
                    Case 5
                        strMensaje = proceso & " : Error :  5 - La base de datos no existe o están ingresándole un parámetro erróneo a la hora de especificar la conexión. " & vbNewLine
                    Case 6
                        strMensaje = proceso & " : Error : 6 - El archivo que se está especificando en la ruta de los parámetros del .BAT no existe " & vbNewLine
                    Case 7
                        strMensaje = proceso & "  Error :  7 - El archivo que se está especificando en la ruta de los parámetros del .BAT no es valido " & vbNewLine
                    Case 8
                        strMensaje = proceso & " : Error : 8 - Hay un problema con la tabla en la base de datos donde se ingresaran los archivos " & vbNewLine
                    Case 9
                        strMensaje = proceso & " : Error :  9 - La compañía que se ingresó en los parámetros del .BAT no es valida " & vbNewLine
                    Case 10
                        strMensaje = proceso & " : Error : 10 - Error desconocido " & vbNewLine
                    Case 99
                        strMensaje = "Error : 99 - Error de tipo diferente a los anteriores, normalmente de permisos a nivel del ERP " & vbNewLine
                End Select

                'Dim detalle As String = "Datos Enviados : " & vbNewLine & strXML_UNOEE & vbNewLine & " Resultado : " & vbNewLine & ds.GetXml.ToString

                If resultadoUNOEE <> 0 Then
                    bitError = True
                    objEnvio.datosEnviadosUNOEE = strXML_UNOEE
                    objEnvio.resultadoLog = strMensaje
                End If

            Catch ex As Exception
                objEnvio.datosEnviadosUNOEE = strXML_UNOEE
                objEnvio.resultadoLog = CargasWSUNOEE_MetodoSuplente(proceso, strXML_UNOEE, bitError)
            End Try

        End If

        objWSUNOEE.Dispose()

    End Sub

    Public Function CargasWSUNOEE_MetodoSuplente(ByVal proceso As String, ByVal strXML_UNOEE As String, ByRef bitError As Boolean) As String


        Dim objWSUNOEE As New WSUNOEE.WSUNOEE
        Dim resultadoUNOEE As Short = 123
        Dim ds As New DataSet
        Dim strMensaje As String = ""

        If My.Settings.EnviarDatosUNOEE Then

            Try

                objWSUNOEE.Timeout = 120000
                objWSUNOEE.Url = "http://192.168.0.172/WSUNOEE/WSUNOEE.asmx" 'WebService de ATLAS
                ds = objWSUNOEE.ImportarXML(strXML_UNOEE, resultadoUNOEE)

                Select Case resultadoUNOEE
                    Case 0
                        strMensaje = proceso & " : Importacion Exitosa " & vbNewLine
                    Case 1
                        strMensaje = proceso & " : Error : 1 - Error de datos al cargar la informacion a siesa a Siesa " & vbNewLine & vbNewLine & ds.GetXml().ToString()
                    Case 2
                        strMensaje = proceso & " : Error : 2 - El impodatos no envio algun parametro " & vbNewLine
                    Case 3
                        strMensaje = proceso & " : Error :  3 - El usuario o la contraseña que ingreso no son validos " & vbNewLine
                    Case 4
                        strMensaje = proceso & " : Error : 4 - La version del impodatos no se corresponde con la version del ERP o el impodatos esta en una maquina que no tiene cliente Siesa o el ERP esta inacesible o tiene los servicios caidos " & vbNewLine
                    Case 5
                        strMensaje = proceso & " : Error :  5 - La base de datos no existe o están ingresándole un parámetro erróneo a la hora de especificar la conexión. " & vbNewLine
                    Case 6
                        strMensaje = proceso & " : Error : 6 - El archivo que se está especificando en la ruta de los parámetros del .BAT no existe " & vbNewLine
                    Case 7
                        strMensaje = proceso & "  Error :  7 - El archivo que se está especificando en la ruta de los parámetros del .BAT no es valido " & vbNewLine
                    Case 8
                        strMensaje = proceso & " : Error : 8 - Hay un problema con la tabla en la base de datos donde se ingresaran los archivos " & vbNewLine
                    Case 9
                        strMensaje = proceso & " : Error :  9 - La compañía que se ingresó en los parámetros del .BAT no es valida " & vbNewLine
                    Case 10
                        strMensaje = proceso & " : Error : 10 - Error desconocido " & vbNewLine
                    Case 99
                        strMensaje = "Error : 99 - Error de tipo diferente a los anteriores, normalmente de permisos a nivel del ERP " & vbNewLine
                End Select

                'Dim detalle As String = "Datos Enviados : " & vbNewLine & strXML_UNOEE & vbNewLine & " Resultado : " & vbNewLine & ds.GetXml.ToString

                If resultadoUNOEE <> 0 Then
                    bitError = True
                End If

            Catch ex As Exception
                bitError = True
            End Try

        End If

        objWSUNOEE.Dispose()

        Return strMensaje

    End Function

End Module


'Dim errorConsumo As Boolean = False
'Dim numIntento As Integer = 1

'Do While (errorConsumo = False)

'Try

'If ((numIntento = 1) Or (numIntento = 3)) Then
'    'Odiseo
'    objWSUNOEE.Url = "http://192.168.0.105/WSUNOEE/WSUNOEE.asmx"
'Else
'    'Euclides
'    objWSUNOEE.Url = "http://172.16.100.24/WSUNOEE/WSUNOEE.asmx"
'End If

'Odiseo
'    objWSUNOEE.Url = "http://192.168.0.105/WSUNOEE/WSUNOEE.asmx"

'    objWSUNOEE.Timeout = 18000000


'    sp_A_registrar_Log_Upload_Siesa(cia, co, tipoDoc, numDoc, "Consumo UNOEE", "Inicio", "XML", strXML_UNOEE)
'    ds = objWSUNOEE.ImportarXML(strXML_UNOEE, resultado)


'    Select Case resultado
'        Case 0
'            strMensaje = proceso & " : Importacion Exitosa " & vbNewLine
'        Case 1
'            strMensaje = proceso & " : Error : 1 - Error de datos al cargar la informacion a siesa a Siesa " & vbNewLine
'        Case 2
'            strMensaje = proceso & " : Error : 2 - El impodatos no envio algun parametro " & vbNewLine
'        Case 3
'            strMensaje = proceso & " : Error :  3 - El usuario o la contraseña que ingreso no son validos " & vbNewLine
'        Case 4
'            strMensaje = proceso & " : Error : 4 - La version del impodatos no se corresponde con la version del ERP o el impodatos esta en una maquina que no tiene cliente Siesa " & vbNewLine
'        Case 5
'            strMensaje = proceso & " : Error :  5 - La base de datos no existe o están ingresándole un parámetro erróneo a la hora de especificar la conexión. " & vbNewLine
'        Case 6
'            strMensaje = proceso & " : Error : 6 - El archivo que se está especificando en la ruta de los parámetros del .BAT no existe " & vbNewLine
'        Case 7
'            strMensaje = proceso & "  Error :  7 - El archivo que se está especificando en la ruta de los parámetros del .BAT no es valido " & vbNewLine
'        Case 8
'            strMensaje = proceso & " : Error : 8 - Hay un problema con la tabla en la base de datos donde se ingresaran los archivos " & vbNewLine
'        Case 9
'            strMensaje = proceso & " : Error :  9 - La compañía que se ingresó en los parámetros del .BAT no es valida " & vbNewLine
'        Case 10
'            strMensaje = proceso & " : Error : 10 - Error desconocido " & vbNewLine
'        Case 99
'            strMensaje = "Error : 99 - Error de tipo diferente a los anteriores, normalmente de permisos a nivel del ERP " & vbNewLine
'    End Select

'    sp_A_registrar_Log_Upload_Siesa(cia, co, tipoDoc, numDoc, "Consumo UNOEE", "Fin", strMensaje, ds.GetXml.ToString)

'Catch ex As Exception
'    sp_A_registrar_Log_Upload_Siesa(cia, co, tipoDoc, numDoc, "Consumo UNOEE", "Fin", "Remision Error", ex.Message)
'End Try

'    numIntento += 1

'    If (numIntento = 1) Then
'        errorConsumo = True
'    End If

'Loop