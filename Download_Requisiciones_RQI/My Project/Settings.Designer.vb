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
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0"),  _
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
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.54;Initial Catalog=WMS;User ID=sa;Password=Sa123456;Integra"& _ 
            "ted Security=False")>  _
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
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.211;Initial Catalog=SCPRD;User ID=sa;Password=Sa1234567;Int"& _ 
            "egrated Security=False")>  _
        Public Property strConexionWMS() As String
            Get
                Return CType(Me("strConexionWMS"),String)
            End Get
            Set
                Me("strConexionWMS") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("smtp.gmail.com")>  _
        Public Property ServidorCorreoSMTP() As String
            Get
                Return CType(Me("ServidorCorreoSMTP"),String)
            End Get
            Set
                Me("ServidorCorreoSMTP") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("587")>  _
        Public Property Puerto() As String
            Get
                Return CType(Me("Puerto"),String)
            End Get
            Set
                Me("Puerto") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property Ssl() As String
            Get
                Return CType(Me("Ssl"),String)
            End Get
            Set
                Me("Ssl") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("siesa@dislicores.com")>  _
        Public Property UsuarioMail() As String
            Get
                Return CType(Me("UsuarioMail"),String)
            End Get
            Set
                Me("UsuarioMail") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("D1sl1c0r3s2019")>  _
        Public Property PassMail() As String
            Get
                Return CType(Me("PassMail"),String)
            End Get
            Set
                Me("PassMail") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("siesa@dislicores.com")>  _
        Public Property CorreoRemitente() As String
            Get
                Return CType(Me("CorreoRemitente"),String)
            End Get
            Set
                Me("CorreoRemitente") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("elkin.munoz@dislicores.com")>  _
        Public Property strDestinatarios() As String
            Get
                Return CType(Me("strDestinatarios"),String)
            End Get
            Set
                Me("strDestinatarios") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.155;Initial Catalog=SCPRD;User ID=sa;Password=Sa123456;Inte"& _ 
            "grated Security=False")>  _
        Public Property strConexionWMS_Pruebas() As String
            Get
                Return CType(Me("strConexionWMS_Pruebas"),String)
            End Get
            Set
                Me("strConexionWMS_Pruebas") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property bitPruebas() As String
            Get
                Return CType(Me("bitPruebas"),String)
            End Get
            Set
                Me("bitPruebas") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.54;Initial Catalog=IntegracionesDislicores_Pruebas;User ID="& _ 
            "sa;Password=Sa123456;Integrated Security=False")>  _
        Public Property strConexionSQL_Pruebas() As String
            Get
                Return CType(Me("strConexionSQL_Pruebas"),String)
            End Get
            Set
                Me("strConexionSQL_Pruebas") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.155;Initial Catalog=INTSCE;User ID=sa;Password=Sa123456;Int"& _ 
            "egrated Security=False")>  _
        Public Property strConexion_ION_Pruebas() As String
            Get
                Return CType(Me("strConexion_ION_Pruebas"),String)
            End Get
            Set
                Me("strConexion_ION_Pruebas") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=192.168.0.155;Initial Catalog=INTSCE;User ID=sa;Password=Sa123456;Int"& _ 
            "egrated Security=False")>  _
        Public Property strConexion_ION() As String
            Get
                Return CType(Me("strConexion_ION"),String)
            End Get
            Set
                Me("strConexion_ION") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("DSN=SIESAPOB;Uid=UNOEE;Pwd=fedunoee2011;")>  _
        Public Property strConexionORACLE() As String
            Get
                Return CType(Me("strConexionORACLE"),String)
            End Get
            Set
                Me("strConexionORACLE") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("DSN=SIESAPOB;Uid=GT;Pwd=D1sl1c0r3s;")>  _
        Public Property strConexionORACLE_GT() As String
            Get
                Return CType(Me("strConexionORACLE_GT"),String)
            End Get
            Set
                Me("strConexionORACLE_GT") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.Download_Requisiciones_RQI.My.MySettings
            Get
                Return Global.Download_Requisiciones_RQI.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
