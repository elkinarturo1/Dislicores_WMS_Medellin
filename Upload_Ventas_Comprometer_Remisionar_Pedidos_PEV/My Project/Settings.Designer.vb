﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.1.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Funcionalidad para autoguardar My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property EnviarDatosUNOEE() As String
            Get
                Return CType(Me("EnviarDatosUNOEE"),String)
            End Get
            Set
                Me("EnviarDatosUNOEE") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("300000")>  _
        Public Property tiempoEsperaPaquete() As String
            Get
                Return CType(Me("tiempoEsperaPaquete"),String)
            End Get
            Set
                Me("tiempoEsperaPaquete") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("WSREAL")>  _
        Public Property strConexionSiesa() As String
            Get
                Return CType(Me("strConexionSiesa"),String)
            End Get
            Set
                Me("strConexionSiesa") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("wms.integracion")>  _
        Public Property strUsuarioSiesa() As String
            Get
                Return CType(Me("strUsuarioSiesa"),String)
            End Get
            Set
                Me("strUsuarioSiesa") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Wms2020")>  _
        Public Property strClaveSiesa() As String
            Get
                Return CType(Me("strClaveSiesa"),String)
            End Get
            Set
                Me("strClaveSiesa") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.54;Initial Catalog=WMS_Medellin;User ID=sa;Password=D1sl1c0"& _ 
            "r3s;Integrated Security=False")>  _
        Public Property strConexionSQL() As String
            Get
                Return CType(Me("strConexionSQL"),String)
            End Get
            Set
                Me("strConexionSQL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("6")>  _
        Public Property numeroPaquetesCorte() As String
            Get
                Return CType(Me("numeroPaquetesCorte"),String)
            End Get
            Set
                Me("numeroPaquetesCorte") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://192.168.0.54:8082/ServiciosWeb/wsGenerarPlano.asmx")>  _
        Public ReadOnly Property Upload_Ventas_Comprometer_Remisionar_Pedidos_PEV_WSGT_wsGenerarPlano() As String
            Get
                Return CType(Me("Upload_Ventas_Comprometer_Remisionar_Pedidos_PEV_WSGT_wsGenerarPlano"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://192.168.0.105:8057/WSUNOEE_ODISEO_WMS_Medellin/WSUNOEE.ASMX")>  _
        Public ReadOnly Property Upload_Ventas_Comprometer_Remisionar_Pedidos_PEV_WSUNOEE_WSUNOEE() As String
            Get
                Return CType(Me("Upload_Ventas_Comprometer_Remisionar_Pedidos_PEV_WSUNOEE_WSUNOEE"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.Upload_Ventas_Comprometer_Remisionar_Pedidos_PEV.My.MySettings
            Get
                Return Global.Upload_Ventas_Comprometer_Remisionar_Pedidos_PEV.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
