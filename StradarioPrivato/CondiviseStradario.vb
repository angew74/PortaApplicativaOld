Imports System
Imports Unisys.CdR.Servizi
Imports System.Diagnostics



Friend Module CondiviseStradario

    '______________________________________________________________________
    '<remarks> Verifica la correttezza della data inserita</remarks>
    Friend Function IsDateCorrect(ByVal gg As Int32, ByVal mm As Int32, ByVal aa As Int32) As Boolean

        Return IsDate(String.Concat(gg.ToString, "/", mm.ToString, "/", aa.ToString))

    End Function

    '______________________________________________________________________
    '<remarks> Scrive sulla coda i messaggi di errore</remarks>
    Friend Sub traccia(ByVal Problem As String, ByVal Detail As String, ByVal RoutineName As String)
        'linda serve traccia? 
        'Dim myLogger As New Unisys.CdR.Servizi.Log.Logger(String.Concat("Unisys.CdR.WS.Verifiche.Condivise - routine:", RoutineName), Problem, Detail, "")
        ''myLogger.WriteGenericError(String.Concat("Unisys.CdR.WS.Verifiche.Condivise - routine:", RoutineName))
        'myLogger.WriteError4PA()
        Dim logDetails As String = Problem & " - " & "Unisys.CdR.WS.Stradario.CondiviseStradario - routine:" & RoutineName & " - " & Detail
        If (logDetails.Length > 500) Then
            logDetails = logDetails.Substring(0, 500)
        End If
        Dim myLogger As New Unisys.CdR.Servizi.Log.Logger("NULL", 0, 0, "0000", System.Web.HttpContext.Current.Request.UserHostAddress, 0, 0, "0000", Unisys.CdR.Servizi.Log.Logger.AppCode.PortaApplicativaERRORS)
        myLogger.EnqueueError(Unisys.CdR.Servizi.Log.Logger.LogTypeCode.Errors, "ERR", logDetails)
    End Sub

End Module


