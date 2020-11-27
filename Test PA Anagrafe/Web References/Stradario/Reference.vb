﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Il codice è stato generato da uno strumento.
'     Versione runtime:2.0.50727.4961
'
'     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
'     il codice viene rigenerato.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'Il codice sorgente è stato generato automaticamente da Microsoft.VSDesigner, versione 2.0.50727.4961.
'
Namespace Stradario
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="StradarioSoap", [Namespace]:="http://servizi.comune.roma.it/stradario")>  _
    Partial Public Class Stradario
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private logHeaderValueField As LogHeader
        
        Private CercaStradaDalNomeOperationCompleted As System.Threading.SendOrPostCallback
        
        Private CercaStradaDalNomeeDalCivicoOperationCompleted As System.Threading.SendOrPostCallback
        
        Private ElencoStradeOperationCompleted As System.Threading.SendOrPostCallback
        
        Private CercaStradaDalCodiceOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.Test_PA_Anagrafe.My.MySettings.Default.Test_PA_Anagrafe_Stradario_Stradario
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Property LogHeaderValue() As LogHeader
            Get
                Return Me.logHeaderValueField
            End Get
            Set
                Me.logHeaderValueField = value
            End Set
        End Property
        
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
        Public Event CercaStradaDalNomeCompleted As CercaStradaDalNomeCompletedEventHandler
        
        '''<remarks/>
        Public Event CercaStradaDalNomeeDalCivicoCompleted As CercaStradaDalNomeeDalCivicoCompletedEventHandler
        
        '''<remarks/>
        Public Event ElencoStradeCompleted As ElencoStradeCompletedEventHandler
        
        '''<remarks/>
        Public Event CercaStradaDalCodiceCompleted As CercaStradaDalCodiceCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("LogHeaderValue"),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://servizi.comune.roma.it/stradario/CercaStradaDalNome", RequestNamespace:="http://servizi.comune.roma.it/stradario", ResponseNamespace:="http://servizi.comune.roma.it/stradario", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CercaStradaDalNome(ByVal Nome As String, ByVal Tipo As Byte) As System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("CercaStradaDalNome", New Object() {Nome, Tipo})
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Function BeginCercaStradaDalNome(ByVal Nome As String, ByVal Tipo As Byte, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CercaStradaDalNome", New Object() {Nome, Tipo}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndCercaStradaDalNome(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CercaStradaDalNomeAsync(ByVal Nome As String, ByVal Tipo As Byte)
            Me.CercaStradaDalNomeAsync(Nome, Tipo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CercaStradaDalNomeAsync(ByVal Nome As String, ByVal Tipo As Byte, ByVal userState As Object)
            If (Me.CercaStradaDalNomeOperationCompleted Is Nothing) Then
                Me.CercaStradaDalNomeOperationCompleted = AddressOf Me.OnCercaStradaDalNomeOperationCompleted
            End If
            Me.InvokeAsync("CercaStradaDalNome", New Object() {Nome, Tipo}, Me.CercaStradaDalNomeOperationCompleted, userState)
        End Sub
        
        Private Sub OnCercaStradaDalNomeOperationCompleted(ByVal arg As Object)
            If (Not (Me.CercaStradaDalNomeCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CercaStradaDalNomeCompleted(Me, New CercaStradaDalNomeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("LogHeaderValue"),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://servizi.comune.roma.it/stradario/CercaStradaDalNomeeDalCivico", RequestNamespace:="http://servizi.comune.roma.it/stradario", ResponseNamespace:="http://servizi.comune.roma.it/stradario", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CercaStradaDalNomeeDalCivico(ByVal Nome As String, ByVal Civico As Integer, ByVal Tipo As Byte) As System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("CercaStradaDalNomeeDalCivico", New Object() {Nome, Civico, Tipo})
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Function BeginCercaStradaDalNomeeDalCivico(ByVal Nome As String, ByVal Civico As Integer, ByVal Tipo As Byte, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CercaStradaDalNomeeDalCivico", New Object() {Nome, Civico, Tipo}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndCercaStradaDalNomeeDalCivico(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CercaStradaDalNomeeDalCivicoAsync(ByVal Nome As String, ByVal Civico As Integer, ByVal Tipo As Byte)
            Me.CercaStradaDalNomeeDalCivicoAsync(Nome, Civico, Tipo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CercaStradaDalNomeeDalCivicoAsync(ByVal Nome As String, ByVal Civico As Integer, ByVal Tipo As Byte, ByVal userState As Object)
            If (Me.CercaStradaDalNomeeDalCivicoOperationCompleted Is Nothing) Then
                Me.CercaStradaDalNomeeDalCivicoOperationCompleted = AddressOf Me.OnCercaStradaDalNomeeDalCivicoOperationCompleted
            End If
            Me.InvokeAsync("CercaStradaDalNomeeDalCivico", New Object() {Nome, Civico, Tipo}, Me.CercaStradaDalNomeeDalCivicoOperationCompleted, userState)
        End Sub
        
        Private Sub OnCercaStradaDalNomeeDalCivicoOperationCompleted(ByVal arg As Object)
            If (Not (Me.CercaStradaDalNomeeDalCivicoCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CercaStradaDalNomeeDalCivicoCompleted(Me, New CercaStradaDalNomeeDalCivicoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("LogHeaderValue"),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://servizi.comune.roma.it/stradario/ElencoStrade", RequestNamespace:="http://servizi.comune.roma.it/stradario", ResponseNamespace:="http://servizi.comune.roma.it/stradario", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function ElencoStrade(ByVal DescrizioneParziale As String) As System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("ElencoStrade", New Object() {DescrizioneParziale})
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Function BeginElencoStrade(ByVal DescrizioneParziale As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("ElencoStrade", New Object() {DescrizioneParziale}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndElencoStrade(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Overloads Sub ElencoStradeAsync(ByVal DescrizioneParziale As String)
            Me.ElencoStradeAsync(DescrizioneParziale, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub ElencoStradeAsync(ByVal DescrizioneParziale As String, ByVal userState As Object)
            If (Me.ElencoStradeOperationCompleted Is Nothing) Then
                Me.ElencoStradeOperationCompleted = AddressOf Me.OnElencoStradeOperationCompleted
            End If
            Me.InvokeAsync("ElencoStrade", New Object() {DescrizioneParziale}, Me.ElencoStradeOperationCompleted, userState)
        End Sub
        
        Private Sub OnElencoStradeOperationCompleted(ByVal arg As Object)
            If (Not (Me.ElencoStradeCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent ElencoStradeCompleted(Me, New ElencoStradeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("LogHeaderValue"),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://servizi.comune.roma.it/stradario/CercaStradaDalCodice", RequestNamespace:="http://servizi.comune.roma.it/stradario", ResponseNamespace:="http://servizi.comune.roma.it/stradario", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CercaStradaDalCodice(ByVal Codice As String) As System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("CercaStradaDalCodice", New Object() {Codice})
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Function BeginCercaStradaDalCodice(ByVal Codice As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CercaStradaDalCodice", New Object() {Codice}, callback, asyncState)
        End Function
        
        '''<remarks/>
        Public Function EndCercaStradaDalCodice(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),System.Xml.XmlNode)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CercaStradaDalCodiceAsync(ByVal Codice As String)
            Me.CercaStradaDalCodiceAsync(Codice, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CercaStradaDalCodiceAsync(ByVal Codice As String, ByVal userState As Object)
            If (Me.CercaStradaDalCodiceOperationCompleted Is Nothing) Then
                Me.CercaStradaDalCodiceOperationCompleted = AddressOf Me.OnCercaStradaDalCodiceOperationCompleted
            End If
            Me.InvokeAsync("CercaStradaDalCodice", New Object() {Codice}, Me.CercaStradaDalCodiceOperationCompleted, userState)
        End Sub
        
        Private Sub OnCercaStradaDalCodiceOperationCompleted(ByVal arg As Object)
            If (Not (Me.CercaStradaDalCodiceCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CercaStradaDalCodiceCompleted(Me, New CercaStradaDalCodiceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
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
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.4927"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://servizi.comune.roma.it/stradario"),  _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://servizi.comune.roma.it/stradario", IsNullable:=false)>  _
    Partial Public Class LogHeader
        Inherits System.Web.Services.Protocols.SoapHeader
        
        Private logGuidField As String
        
        Private anyAttrField() As System.Xml.XmlAttribute
        
        '''<remarks/>
        Public Property LogGuid() As String
            Get
                Return Me.logGuidField
            End Get
            Set
                Me.logGuidField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlAnyAttributeAttribute()>  _
        Public Property AnyAttr() As System.Xml.XmlAttribute()
            Get
                Return Me.anyAttrField
            End Get
            Set
                Me.anyAttrField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub CercaStradaDalNomeCompletedEventHandler(ByVal sender As Object, ByVal e As CercaStradaDalNomeCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CercaStradaDalNomeCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Xml.XmlNode
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Xml.XmlNode)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub CercaStradaDalNomeeDalCivicoCompletedEventHandler(ByVal sender As Object, ByVal e As CercaStradaDalNomeeDalCivicoCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CercaStradaDalNomeeDalCivicoCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Xml.XmlNode
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Xml.XmlNode)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub ElencoStradeCompletedEventHandler(ByVal sender As Object, ByVal e As ElencoStradeCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class ElencoStradeCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Xml.XmlNode
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Xml.XmlNode)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")>  _
    Public Delegate Sub CercaStradaDalCodiceCompletedEventHandler(ByVal sender As Object, ByVal e As CercaStradaDalCodiceCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CercaStradaDalCodiceCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As System.Xml.XmlNode
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),System.Xml.XmlNode)
            End Get
        End Property
    End Class
End Namespace