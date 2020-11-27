Imports System.Xml.Serialization
Imports System.Xml
Imports Unisys.CdR.Servizi
Imports Unisys.CdR.CustomProfile
Imports System.Web



Public Class NStradBusinessLayer

    Private mylist As NResponseDataset
    Private data As NStradDataLayer
    Sub New()
        mylist = New NResponseDataset
        data = New NStradDataLayer
    End Sub

    Public Function Request(ByVal street As String, ByVal tipo As Byte, ByRef doc As XmlDocument, ByRef errstring As String) As Boolean
        Dim tab As New DataTable
        Dim TipoR As String = "1"
        Dim i, j As Integer
        If tipo = 0 Then
            TipoR = 4
        End If
        If data.Ricerca0(tipo, street, tab, errstring) = False Then Return (False)

        j = tab.Rows.Count - 1
        For i = 0 To j
            mylist.AddItem(New NItems(DirectCast(tab.Rows.Item(i).Item(0), String), StrConv(CType(tab.Rows.Item(i).Item(1), String), VbStrConv.ProperCase).TrimEnd(Chr(32))))
        Next

        serialize(doc)
        If (DoLog(TipoR, street, tipo, "") = True) Then
            Return (True)
        End If
    End Function

    '<remarks> </remarks>
    Public Function Request1(ByVal street As String, ByRef doc As XmlDocument, ByRef errstring As String) As Boolean
        Dim tab As New DataTable
        Dim head(3) As String

        If data.ricerca1(street, tab, head, errstring) = False Then Return (False)

        mylist.strada_name = head(0)
        mylist.inizio = head(1)
        mylist.fine = head(2)
        mylist.tipo_num = head(3)

        Dim view As New DataView(tab, Nothing, "a,d,e,b", DataViewRowState.CurrentRows)

        Dim i As Integer = 0
        Dim j As Integer
        While i < view.Count
            j = i
            While (i < view.Count AndAlso DirectCast(view(i).Item("d"), String) = DirectCast(view(j).Item("d"), String) AndAlso DirectCast(view(i).Item("e"), String) = DirectCast(view(j).Item("e"), String) AndAlso DirectCast(view(i).Item("a"), String) = DirectCast(view(j).Item("a"), String))
                i = i + 1
            End While
            mylist.AddItem(New NItems(DirectCast(view(j).Item("d"), String), DirectCast(view(j).Item("e"), String), DirectCast(view(j).Item("b"), String), DirectCast(view(i - 1).Item("c"), String), DirectCast(view(j).Item("a"), String)))
        End While

        serialize(doc)
        If (DoLog("2", street, "", "") = True) Then
            Return (True)
        End If

    End Function
    ' richiesta per dati puntuali strada e civico 
    Public Function RequestPuntuale(ByVal street As String, ByVal civic As Int32, ByVal tipo As Byte, ByRef doc As XmlDocument, ByRef errstring As String) As Boolean
        Dim tab As New DataTable
        Dim i, j As Integer

        If data.RicercaP(tipo, street, civic, tab, errstring) = False Then Return (False)
        j = tab.Rows.Count - 1
        For i = 0 To j
            mylist.AddItem(New NItems((DirectCast(tab.Rows.Item(i).Item(0), String)), (DirectCast(tab.Rows.Item(i).Item(1), String)).TrimEnd, (DirectCast(tab.Rows.Item(i).Item(2), String)), (DirectCast(tab.Rows.Item(i).Item(3), String)), (DirectCast(tab.Rows.Item(i).Item(4), String)), (DirectCast(tab.Rows.Item(i).Item(5), String)), (DirectCast(tab.Rows.Item(i).Item(6), String)), (DirectCast(tab.Rows.Item(i).Item(7), String)), (DirectCast(tab.Rows.Item(i).Item(8), String))))
            serialize(doc)
        Next
        If (DoLog("3", street, tipo, civic) = True) Then
            Return (True)
        End If
    End Function







    '<remarks> </remarks>
    Private Function serialize(ByRef doc As XmlDocument) As Boolean

        Dim xmldoc As New XmlDocument
        Dim s As New XmlSerializer(GetType(NResponseDataset))
        Dim oo As New System.IO.MemoryStream
        Dim enc As System.Text.Encoding
        Dim stream As New System.IO.StreamWriter(oo, enc.UTF8)
        Dim stream1 As New System.IO.StreamReader(oo)
        Dim reader1 As XmlTextReader

        Try
            s.Serialize(stream, mylist)
            oo.Position = 0
            reader1 = New XmlTextReader(oo)
            reader1.MoveToContent()
            doc.Load(reader1)
        Finally
            reader1.Close()
            stream.Close()
            stream1.Close()
            oo.Close()
        End Try

    End Function

    Protected Function DoLog(ByVal tipo As String, ByVal Street As String, ByVal TipoStrada As String, ByVal Civico As String) As Boolean

        Dim parametri(4) As String
        Dim lobj As Object
        Dim uobj As Object = System.Web.HttpRuntime.Cache.Get(System.Web.HttpContext.Current.User.Identity.Name)
        Dim upro As UserProfile
        Dim logguid As String
        If (System.Web.HttpContext.Current.Application.Get("IBM") Is Nothing) Then
            If uobj Is Nothing Then
                Throw New Exception("Errore nel recuperare il profilo utente in cache")
            Else
                upro = DirectCast(uobj, UserProfile)
            End If

            lobj = System.Web.HttpContext.Current.Items.Item("logheader")
            If lobj Is Nothing Then
                Throw New Exception("Errore nel recuperare l'identificativo del log in cache")
            Else
                logguid = CType(lobj, String)
            End If
        End If


        'preparazione array con i parametri della ricerca
        Select Case tipo
            Case "1"
                parametri(0) = "DenominazioneVia: " & Street
                parametri(1) = "TipoInterrogazione: " & TipoStrada
            Case "2"
                parametri(0) = "CodiceVia:" & Street
            Case "3"
                parametri(0) = "DenominazioneVia: " & Street
                parametri(1) = "TipoInterrogazione: " & TipoStrada
                parametri(2) = "NumeroCivico:" & Civico
            Case "4"
                parametri(0) = "DenominazioneViaParziale: " & Street
                parametri(1) = "TipoInterrogazione: " & TipoStrada
        End Select

        Select Case tipo
            Case "1" 'Verifica con Denominazione
                parametri(parametri.Length - 1) = "CercaStradaDalNome"
            Case "2" 'Verifica con codice
                parametri(parametri.Length - 1) = "CercaStradaDalCodice"
            Case "3" 'Verifica puntuale
                parametri(parametri.Length - 1) = "CercaStradaDalNomeeDalCivico"
            Case "4" 'Verifica puntuale
                parametri(parametri.Length - 1) = "ElencoStrade"
        End Select

        Dim i As Int32
        Dim sb As New System.Text.StringBuilder(parametri.Length)
        For i = 0 To parametri.Length - 2
            If parametri(i) <> Nothing Then
                sb.Append(parametri(i))
                sb.Append(" - ")
            End If
        Next

        Dim logDetails As String = String.Concat(parametri(parametri.Length - 1), " - ", sb.ToString)
        If (logDetails.Length > 500) Then
            logDetails = logDetails.Substring(0, 500)
        End If


        Dim log As Unisys.CdR.Servizi.Log.Logger
        If (HttpContext.Current.Application.Get("IBM") Is Nothing) Then
            log = New Unisys.CdR.Servizi.Log.Logger(logguid, upro.Principal.UniqueID, upro.Principal.IdGruppo, upro.Principal.ParentCode, HttpContext.Current.Request.UserHostAddress, 0, 0, "0000", Unisys.CdR.Servizi.Log.Logger.AppCode.PortaApplicativaLOGS)
        Else
            log = New Unisys.CdR.Servizi.Log.Logger("NULL", 11422, 6201, "0104", HttpContext.Current.Request.UserHostAddress, 0, 0, "0000", Unisys.CdR.Servizi.Log.Logger.AppCode.PortaApplicativaLOGS)
        End If
        log.EnqueueError(Unisys.CdR.Servizi.Log.Logger.LogTypeCode.Actions, "QRY", logDetails)

        Return True


    End Function

End Class

