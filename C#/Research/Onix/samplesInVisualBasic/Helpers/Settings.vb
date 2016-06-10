' Copyright Onix Solutions Limited [OnixS]. All rights reserved.
'
' This software owned by Onix Solutions Limited [OnixS] and is protected by copyright law
' and international copyright treaties.
'
' Access to and use of the software is governed by the terms of the applicable ONIXS Software
' Services Agreement (the Agreement) and Customer end user license agreements granting
' a non-assignable, non-transferable and non-exclusive license to use the software
' for it's own data processing purposes under the terms defined in the Agreement.
'
' Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part
' of this source code or associated reference material to any other location for further reproduction
' or redistribution, and any amendments to this copyright notice, are expressly prohibited.
'
' Any reproduction or redistribution for sale or hiring of the Software not in accordance with
' the terms of the Agreement is a violation of copyright law.

Imports System
Imports System.Configuration
Imports FIXForge.NET.FIX
Imports FF = FIXForge.NET.FIX


Public Class Settings

    Public Shared Function [Get](ByVal key As String) As String
        Dim v As String = System.Configuration.ConfigurationManager.AppSettings(key)
        If Nothing = v Then
            Throw New ApplicationException("Cannot find the '" + key + "' setting in the configuration file")
        End If
        Return v
    End Function 'Get


    Public Shared Function GetInteger(ByVal key As String) As Integer
        Dim v As String = [Get](key)
        Return Integer.Parse(v)
    End Function 'GetInteger


    Public Shared Function GetBoolean(ByVal key As String) As [Boolean]
        Dim v As String = [Get](key)
        Return v.ToLower().Trim() = "true"
    End Function 'GetBoolean


    Public Overloads Shared Function GetOptional(ByVal key As String) As String
        Dim v As String = System.Configuration.ConfigurationManager.AppSettings(key)
        Return v
    End Function 'GetOptional


    Public Overloads Shared Function GetOptional(ByVal key As String, ByVal defaultValue As String) As String
        Dim v As String = System.Configuration.ConfigurationManager.AppSettings(key)
        If Nothing = v Then
            Return defaultValue
        End If
        Return v
    End Function 'GetOptional


    Public Shared Function GetVersion() As FIXForge.NET.FIX.ProtocolVersion
        Dim str As String = [Get]("FIX version")
        Select Case str
            Case "4.0"
                Return ProtocolVersion.FIX40

            Case "4.1"
                Return ProtocolVersion.FIX41

            Case "4.2"
                Return ProtocolVersion.FIX42

            Case "4.3"
                Return ProtocolVersion.FIX43

            Case "4.4"
                Return ProtocolVersion.FIX44
        End Select
        Throw New ApplicationException("Unknown FIX version: '" + str + "'")
    End Function 'GetVersion
End Class 'Settings
