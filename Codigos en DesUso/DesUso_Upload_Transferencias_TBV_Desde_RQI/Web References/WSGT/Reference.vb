﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
'
Namespace WSGT
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="wsGenerarPlanoSoap", [Namespace]:="http://generictransfer.com/")>  _
    Partial Public Class wsGenerarPlano
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private GenerarPlanoXMLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private ImportarDatosXMLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private ImportarDatosDSOperationCompleted As System.Threading.SendOrPostCallback
        
        Private ImportarDatosTablasXMLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private ImportarDatosTablasDSOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.Upload_Transferencias_TBV_Desde_RQI.My.MySettings.Default.Upload_Transferencias_TBV_Desde_RQI_WSGT_wsGenerarPlano
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event GenerarPlanoXMLCompleted As GenerarPlanoXMLCompletedEventHandler
        
        '''<remarks/>
        Public Event ImportarDatosXMLCompleted As ImportarDatosXMLCompletedEventHandler
        
        '''<remarks/>
        Public Event ImportarDatosDSCompleted As ImportarDatosDSCompletedEventHandler
        
        '''<remarks/>
        Public Event ImportarDatosTablasXMLCompleted As ImportarDatosTablasXMLCompletedEventHandler
        
        '''<remarks/>
        Public Event ImportarDatosTablasDSCompleted As ImportarDatosTablasDSCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/GenerarPlanoXML", RequestNamespace:="http://generictransfer.com/", ResponseNamespace:="http://generictransfer.com/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GenerarPlanoXML(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByRef Path As String, ByRef strResultado As String) As String
            Dim results() As Object = Me.Invoke("GenerarPlanoXML", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, Path, strResultado})
            Path = CType(results(1),String)
            strResultado = CType(results(2),String)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GenerarPlanoXMLAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByVal Path As String, ByVal strResultado As String)
            Me.GenerarPlanoXMLAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, Path, strResultado, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GenerarPlanoXMLAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByVal Path As String, ByVal strResultado As String, ByVal userState As Object)
            If (Me.GenerarPlanoXMLOperationCompleted Is Nothing) Then
                Me.GenerarPlanoXMLOperationCompleted = AddressOf Me.OnGenerarPlanoXMLOperationCompleted
            End If
            Me.InvokeAsync("GenerarPlanoXML", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, Path, strResultado}, Me.GenerarPlanoXMLOperationCompleted, userState)
        End Sub
        
        Private Sub OnGenerarPlanoXMLOperationCompleted(ByVal arg As Object)
            If (Not (Me.GenerarPlanoXMLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GenerarPlanoXMLCompleted(Me, New GenerarPlanoXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/ImportarDatosXML", RequestNamespace:="http://generictransfer.com/", ResponseNamespace:="http://generictransfer.com/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ImportarDatosXML(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal strFuenteDatos As String, ByRef Path As String) As String
            Dim results() As Object = Me.Invoke("ImportarDatosXML", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, strFuenteDatos, Path})
            Path = CType(results(1),String)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ImportarDatosXMLAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal strFuenteDatos As String, ByVal Path As String)
            Me.ImportarDatosXMLAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, strFuenteDatos, Path, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ImportarDatosXMLAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal strFuenteDatos As String, ByVal Path As String, ByVal userState As Object)
            If (Me.ImportarDatosXMLOperationCompleted Is Nothing) Then
                Me.ImportarDatosXMLOperationCompleted = AddressOf Me.OnImportarDatosXMLOperationCompleted
            End If
            Me.InvokeAsync("ImportarDatosXML", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, strFuenteDatos, Path}, Me.ImportarDatosXMLOperationCompleted, userState)
        End Sub
        
        Private Sub OnImportarDatosXMLOperationCompleted(ByVal arg As Object)
            If (Not (Me.ImportarDatosXMLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ImportarDatosXMLCompleted(Me, New ImportarDatosXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/ImportarDatosDS", RequestNamespace:="http://generictransfer.com/", ResponseNamespace:="http://generictransfer.com/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ImportarDatosDS(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByRef Path As String) As String
            Dim results() As Object = Me.Invoke("ImportarDatosDS", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, Path})
            Path = CType(results(1),String)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ImportarDatosDSAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByVal Path As String)
            Me.ImportarDatosDSAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, Path, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ImportarDatosDSAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByVal Path As String, ByVal userState As Object)
            If (Me.ImportarDatosDSOperationCompleted Is Nothing) Then
                Me.ImportarDatosDSOperationCompleted = AddressOf Me.OnImportarDatosDSOperationCompleted
            End If
            Me.InvokeAsync("ImportarDatosDS", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, Path}, Me.ImportarDatosDSOperationCompleted, userState)
        End Sub
        
        Private Sub OnImportarDatosDSOperationCompleted(ByVal arg As Object)
            If (Not (Me.ImportarDatosDSCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ImportarDatosDSCompleted(Me, New ImportarDatosDSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/ImportarDatosTablasXML", RequestNamespace:="http://generictransfer.com/", ResponseNamespace:="http://generictransfer.com/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ImportarDatosTablasXML(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal strFuenteDatos As String, ByVal tsProceso As String, ByRef Path As String) As String
            Dim results() As Object = Me.Invoke("ImportarDatosTablasXML", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, strFuenteDatos, tsProceso, Path})
            Path = CType(results(1),String)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ImportarDatosTablasXMLAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal strFuenteDatos As String, ByVal tsProceso As String, ByVal Path As String)
            Me.ImportarDatosTablasXMLAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, strFuenteDatos, tsProceso, Path, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ImportarDatosTablasXMLAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal strFuenteDatos As String, ByVal tsProceso As String, ByVal Path As String, ByVal userState As Object)
            If (Me.ImportarDatosTablasXMLOperationCompleted Is Nothing) Then
                Me.ImportarDatosTablasXMLOperationCompleted = AddressOf Me.OnImportarDatosTablasXMLOperationCompleted
            End If
            Me.InvokeAsync("ImportarDatosTablasXML", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, strFuenteDatos, tsProceso, Path}, Me.ImportarDatosTablasXMLOperationCompleted, userState)
        End Sub
        
        Private Sub OnImportarDatosTablasXMLOperationCompleted(ByVal arg As Object)
            If (Not (Me.ImportarDatosTablasXMLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ImportarDatosTablasXMLCompleted(Me, New ImportarDatosTablasXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://generictransfer.com/ImportarDatosTablasDS", RequestNamespace:="http://generictransfer.com/", ResponseNamespace:="http://generictransfer.com/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ImportarDatosTablasDS(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByVal tsProceso As String, ByRef Path As String) As String
            Dim results() As Object = Me.Invoke("ImportarDatosTablasDS", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, tsProceso, Path})
            Path = CType(results(1),String)
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ImportarDatosTablasDSAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByVal tsProceso As String, ByVal Path As String)
            Me.ImportarDatosTablasDSAsync(idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, tsProceso, Path, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ImportarDatosTablasDSAsync(ByVal idDocumento As Integer, ByVal strNombreDocumento As String, ByVal idCompania As Integer, ByVal strCompania As String, ByVal strUsuario As String, ByVal strClave As String, ByVal dsFuenteDatos As System.Data.DataSet, ByVal tsProceso As String, ByVal Path As String, ByVal userState As Object)
            If (Me.ImportarDatosTablasDSOperationCompleted Is Nothing) Then
                Me.ImportarDatosTablasDSOperationCompleted = AddressOf Me.OnImportarDatosTablasDSOperationCompleted
            End If
            Me.InvokeAsync("ImportarDatosTablasDS", New Object() {idDocumento, strNombreDocumento, idCompania, strCompania, strUsuario, strClave, dsFuenteDatos, tsProceso, Path}, Me.ImportarDatosTablasDSOperationCompleted, userState)
        End Sub
        
        Private Sub OnImportarDatosTablasDSOperationCompleted(ByVal arg As Object)
            If (Not (Me.ImportarDatosTablasDSCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ImportarDatosTablasDSCompleted(Me, New ImportarDatosTablasDSCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")>  _
    Public Delegate Sub GenerarPlanoXMLCompletedEventHandler(ByVal sender As Object, ByVal e As GenerarPlanoXMLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GenerarPlanoXMLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property Path() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),String)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property strResultado() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(2),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")>  _
    Public Delegate Sub ImportarDatosXMLCompletedEventHandler(ByVal sender As Object, ByVal e As ImportarDatosXMLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ImportarDatosXMLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property Path() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")>  _
    Public Delegate Sub ImportarDatosDSCompletedEventHandler(ByVal sender As Object, ByVal e As ImportarDatosDSCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ImportarDatosDSCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property Path() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")>  _
    Public Delegate Sub ImportarDatosTablasXMLCompletedEventHandler(ByVal sender As Object, ByVal e As ImportarDatosTablasXMLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ImportarDatosTablasXMLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property Path() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")>  _
    Public Delegate Sub ImportarDatosTablasDSCompletedEventHandler(ByVal sender As Object, ByVal e As ImportarDatosTablasDSCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ImportarDatosTablasDSCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
        
        '''<remarks/>
        Public ReadOnly Property Path() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(1),String)
            End Get
        End Property
    End Class
End Namespace
