﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
 Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0"),  _
 Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
Partial Friend NotInheritable Class Settings
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared defaultInstance As Settings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()),Settings)
    
#Region "My.Settings Auto-Save Functionality"
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
    
    Public Shared ReadOnly Property [Default]() As Settings
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
     Global.System.Configuration.DefaultSettingValueAttribute("Eric Hindle")>  _
    Public Property RegName() As String
        Get
            Return CType(Me("RegName"),String)
        End Get
        Set
            Me("RegName") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("CGL26PUYVR950JEA")>  _
    Public Property RegCode() As String
        Get
            Return CType(Me("RegCode"),String)
        End Get
        Set
            Me("RegCode") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("120")>  _
    Public Property ButtonWidth() As Integer
        Get
            Return CType(Me("ButtonWidth"),Integer)
        End Get
        Set
            Me("ButtonWidth") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
    Public Property Transparency() As Integer
        Get
            Return CType(Me("Transparency"),Integer)
        End Get
        Set
            Me("Transparency") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
    Public Property Delay() As Integer
        Get
            Return CType(Me("Delay"),Integer)
        End Get
        Set
            Me("Delay") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property ToolBar() As Boolean
        Get
            Return CType(Me("ToolBar"),Boolean)
        End Get
        Set
            Me("ToolBar") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property Minimise() As Boolean
        Get
            Return CType(Me("Minimise"),Boolean)
        End Get
        Set
            Me("Minimise") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Tahoma")>  _
    Public Property FontName() As String
        Get
            Return CType(Me("FontName"),String)
        End Get
        Set
            Me("FontName") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("9")>  _
    Public Property FontSize() As Decimal
        Get
            Return CType(Me("FontSize"),Decimal)
        End Get
        Set
            Me("FontSize") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property FontBold() As Boolean
        Get
            Return CType(Me("FontBold"),Boolean)
        End Get
        Set
            Me("FontBold") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
    Public Property FontItalic() As Boolean
        Get
            Return CType(Me("FontItalic"),Boolean)
        End Get
        Set
            Me("FontItalic") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property OnTop() As Boolean
        Get
            Return CType(Me("OnTop"),Boolean)
        End Get
        Set
            Me("OnTop") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
    Public Property Group() As Integer
        Get
            Return CType(Me("Group"),Integer)
        End Get
        Set
            Me("Group") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
    Public Property Columns() As Integer
        Get
            Return CType(Me("Columns"),Integer)
        End Get
        Set
            Me("Columns") = value
        End Set
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=NETWYRKS_6-PC\SQLEXPRESS;Initial Catalog=TypeRight;Persist Security I"& _ 
        "nfo=True;User ID=sa;Password=dkk.sql")>  _
    Public ReadOnly Property TypeRightConnectionString() As String
        Get
            Return CType(Me("TypeRightConnectionString"),String)
        End Get
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
    Public Property Sender() As Integer
        Get
            Return CType(Me("Sender"),Integer)
        End Get
        Set
            Me("Sender") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property DBUpdatePos() As String
        Get
            Return CType(Me("DBUpdatePos"),String)
        End Get
        Set
            Me("DBUpdatePos") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property EditButtonPos() As String
        Get
            Return CType(Me("EditButtonPos"),String)
        End Get
        Set
            Me("EditButtonPos") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property GroupMaintPos() As String
        Get
            Return CType(Me("GroupMaintPos"),String)
        End Get
        Set
            Me("GroupMaintPos") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property OptionsPos() As String
        Get
            Return CType(Me("OptionsPos"),String)
        End Get
        Set
            Me("OptionsPos") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("F:\TypeRight\Logs")>  _
    Public Property LogFolder() As String
        Get
            Return CType(Me("LogFolder"),String)
        End Get
        Set
            Me("LogFolder") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
    Public Property DebugOn() As Boolean
        Get
            Return CType(Me("DebugOn"),Boolean)
        End Get
        Set
            Me("DebugOn") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("F:\TypeRight\Backups")>  _
    Public Property BackupFolder() As String
        Get
            Return CType(Me("BackupFolder"),String)
        End Get
        Set
            Me("BackupFolder") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("")>  _
    Public Property ButtonListPos() As String
        Get
            Return CType(Me("ButtonListPos"),String)
        End Get
        Set
            Me("ButtonListPos") = value
        End Set
    End Property
    
    <Global.System.Configuration.UserScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.DefaultSettingValueAttribute("2.0.4")>  _
    Public Property Version() As String
        Get
            Return CType(Me("Version"),String)
        End Get
        Set
            Me("Version") = value
        End Set
    End Property
End Class

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.TypeRight.Settings
            Get
                Return Global.TypeRight.Settings.Default
            End Get
        End Property
    End Module
End Namespace
