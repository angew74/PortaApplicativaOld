Imports System
Imports System.Diagnostics
Imports System.Web.Services
Imports Unisys.CdR.CustomProfile
Imports System.Web.Services.Protocols
Imports Unisys.CdR.RefreshCounters
Imports Unisys.CdR.Servizi
Imports System.Web.Services.Description
Imports System.Web



Public Class GenericStradario
    Inherits System.Web.Services.WebService

    Private _circ As String
    Private _cap As String
    Private _side As String
    Private _initial As String
    Private _final As String
    Private _cod As String
    Private _nome As String
    Private _civico As String
    Private _tipo As Byte
    Private _zurb As String
    Private _sudt As String
    Private _sezc As String
    Private XmlDocIN As Xml.XmlDocument

    '______________________________________________________________________
    '<remarks> Scatena una eccezione personalizzata SOAP per parlare con il client.</remarks>
    Protected Sub ThrowSoapException(ByVal msg As String, ByVal errCode As String)
        Dim e As New Unisys.CdR.Servizi.SoapExcepGest(msg, _
                                SoapException.ServerFaultCode, _
                                Context.Request.Url.AbsoluteUri, _
                                errCode)

        Throw e.Exception
    End Sub

    '<remarks> Verifica che il profilo abbia i diritti per invocare il servizio specificato.
    '           Se il controllo ha esito positivo, la funzione ritorna il livello di servizio
    '           assegnato al profilo in modo da filtrare i dati in uscita (operazione eseguita
    '           centralmente da BIS).
    '</remarks>
    Protected Function checkRights(ByVal MethodCode As String, ByVal ClientServiceLevel As Byte) As Byte
        Dim modify As Modifier = New Modifier("PORTA APPLICATIVA", False)
        Dim objectProfile As Object = HttpRuntime.Cache.Get(System.Web.HttpContext.Current.User.Identity.Name)
        If Not objectProfile Is Nothing Then
            Dim upro As UserProfile = DirectCast(objectProfile, UserProfile)
            Dim liv As Int16
            Try
                liv = upro.Principal.IsServiceAssigned(MethodCode)
            Catch ex As Exception
                modify.IncrementCounter("Errori autenticazione/sec")
                'traccia("Profilo utente corrotto o anomalo", ex.Message, "Unisys.CdR.WS.Verifiche.GenericStradario.checkRights")
            End Try
            If liv = -99 Then
                modify.IncrementCounter("Errori autenticazione/sec")
                Throw New Exception("Il profilo della porta delegata non è autorizzato a chiamare il servizio indicato: contattare l'amministratore del proprio sistema")
                'ThrowSoapException("Il profilo della porta delegata non è autorizzato a chiamare il servizio indicato: contattare l'amministratore del proprio sistema", "NO-AUTH-FOR-METHOD")
            ElseIf liv < 0 Then
                modify.IncrementCounter("Errori autenticazione/sec")
                Throw New Exception("Il servizio richiesto è sospeso o non abilitato: contattare l'amministratore del proprio sistema")
                'ThrowSoapException("Il servizio richiesto è sospeso o non abilitato: contattare l'amministratore del proprio sistema", "SERVICE-NOT-ENABLED")
            End If

            ' Abilito il livello più basso possibile
            If liv < ClientServiceLevel Then
                Return CType(liv, Byte)
            Else
                Return ClientServiceLevel
            End If
        Else
            modify.IncrementCounter("Errori autenticazione/sec")
            Throw New Exception("Impossibile verificare l'identità del client (token di sicurezza non trovato)")
            'ThrowSoapException("Impossibile verificare l'identità del client (token di sicurezza non trovato)", "APPCACHE-PROBLEM")
        End If

    End Function
#Region "Parte di codice necessaria per il funzionamento del web service"

    Public Sub New()
        MyBase.New()
        'Chiamata richiesta da Progettazione servizi Web
        'InitializeComponent()
        'Aggiungere il codice di inizializzazione dopo la chiamata a InitializeComponent()
    End Sub

    'Richiesto da Progettazione servizi Web
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione servizi Web.
    'Può essere modificata in Progettazione servizi Web.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: questa procedura è richiesta da Progettazione servizi Web.
        'Non modificarla nell'editor del codice.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

End Class

