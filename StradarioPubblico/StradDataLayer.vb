Imports System
Imports System.Data
'Imports Microsoft.Data.Odbc        ' old, .NET 1.0
Imports System.Data.Odbc
Imports Unisys.CdR.Servizi
Imports System.Configuration



Public Class StradDataLayer

    Public Function ricerca1(ByVal CodiceStrada As String, ByRef tab As DataTable, ByRef head() As String, ByRef errstring As String) As Boolean
        Dim street As String
        If CodiceStrada.Length <> 6 Then
            Throw New Exception("Il codice identificativo della strada deve essere di 6 cifre.")
        Else
            street = CodiceStrada.Substring(0, 5)
        End If

        Dim ssql0 As String = String.Concat("select cod_via, den_via, lim_via_da, lim_via_a from territ.strade where (territ.strade.cod_via='", street, "' or territ.strade.cod_via=(select lim_via_da from territ.strade where territ.strade.cod_via='", street, "') or territ.strade.cod_via=(select lim_via_a from territ.strade where territ.strade.cod_via='", street, "'));")
        Dim ssql1 As String = String.Concat("select tip_num_num, lim_civ_da, lim_civ_a, num_cir, cap from territ.territ where cod_via='", street, "';")
        Dim row As DataRow
        Dim a(4) As String
        Dim tab1 As New DataTable
        Dim row1 As DataRow
        Dim a1(3) As Object
        Dim tipoStringa As System.Type = System.Type.GetType("System.String")

        'ssql0 = String.Concat("select cod_via, den_via, lim_via_da, lim_via_a from territ.strade where (territ.strade.cod_via='", street, "' or territ.strade.cod_via=(select lim_via_da from territ.strade where territ.strade.cod_via='", street, "') or territ.strade.cod_via=(select lim_via_a from territ.strade where territ.strade.cod_via='", street, "'));")
        'ssql1 = String.Concat("select tip_num_num, lim_civ_da, lim_civ_a, num_cir, cap from territ.territ where cod_via='", street, "';")

        command.CommandText = ssql0

        With tab.Columns
            .Add(New DataColumn("a", tipoStringa))
            .Add(New DataColumn("b", tipoStringa))
            .Add(New DataColumn("c", tipoStringa))
            .Add(New DataColumn("d", tipoStringa))
            .Add(New DataColumn("e", tipoStringa))
        End With

        With tab1.Columns
            .Add(New DataColumn("codice", tipoStringa))
            .Add(New DataColumn("nome", tipoStringa))
            .Add(New DataColumn("inizio", tipoStringa))
            .Add(New DataColumn("fine", tipoStringa))
        End With


        ' prima lettura dal database 

        Dim reader As OdbcDataReader
        Try
            odbcconn.Open()
            reader = command.ExecuteReader()
            Dim mark As Integer
            Dim count As Integer = 0
            While reader.Read()
                'If Not CType(reader.GetValue(0), String) = "99999" Then
                If Not DirectCast(reader.GetValue(0), String) = "99999" Then
                    row1 = tab1.NewRow
                    reader.GetValues(a1)
                    row1.ItemArray = a1
                    'If CType(row1.Item("codice"), String) = street Then mark = count
                    If DirectCast(row1.Item("codice"), String) = street Then mark = count
                    tab1.Rows.Add(row1)
                    count = count + 1
                End If
            End While
            reader.Close()
            If count > 0 Then
                command.CommandText = ssql1
                reader = command.ExecuteReader()

                'seconda lettura dal database 
                'legge la prima riga ed estrae i valori utili alla classificazione globale della via

                reader.Read()
                row = tab.NewRow
                reader.GetValues(a)

                Select Case reader.GetValue(0)
                    Case 1 To 2
                        head(3) = "numerica: pari/dispari"
                    Case 3
                        head(3) = "numerica: progressiva"
                    Case 4
                        head(3) = "chilometrica"
                    Case Else
                        head(3) = "ignota"
                End Select

                row.ItemArray = a
                tab.Rows.Add(row)
                'legge i record successivi appartenenti alla via selezionata e riempe la tabella

                While reader.Read()
                    row = tab.NewRow
                    reader.GetValues(a)
                    row.ItemArray = a
                    tab.Rows.Add(row)
                End While

                reader.Close()
                odbcconn.Close()

                Dim i As Integer

                'head(0) = CType(tab1.Rows(mark).Item("nome"), String)
                head(0) = DirectCast(tab1.Rows(mark).Item("nome"), String)

                Dim rc As Int32 = tab1.Rows.Count - 1
                For i = 0 To rc
                    Dim tmp As String = DirectCast(tab1.Rows(i).Item("codice"), String)
                    'If CType(tab1.Rows(i).Item("codice"), String) = CType(tab1.Rows(mark).Item("inizio"), String) Then
                    '    head(1) = CType(tab1.Rows(i).Item("nome"), String)
                    'End If
                    'If CType(tab1.Rows(i).Item("codice"), String) = CType(tab1.Rows(mark).Item("fine"), String) Then
                    '    head(2) = CType(tab1.Rows(i).Item("nome"), String)
                    'End If
                    If tmp = DirectCast(tab1.Rows(mark).Item("inizio"), String) Then
                        head(1) = DirectCast(tab1.Rows(i).Item("nome"), String)
                    End If
                    If tmp = DirectCast(tab1.Rows(mark).Item("fine"), String) Then
                        head(2) = DirectCast(tab1.Rows(i).Item("nome"), String)
                    End If
                    System.Diagnostics.Debug.WriteLine(tmp)

                    ' ==================================
                    ' Agg. Emiliano, 03/02/2005
                    ' ---------> Aggiungo il controcodice!
                    tab1.Rows(i).Item("codice") = addCheckDigit(tmp)
                Next

                If head(1) = "" Then head(1) = "ignoto"
                If head(2) = "" Then head(2) = "ignoto"
            End If
        Catch e As OdbcException
            errstring = e.Message
            '-------->Me.err_log("111", "222", "333", "444", "555")
            Return (False)
        Finally
            If odbcconn.State <> ConnectionState.Closed Then odbcconn.Close()
            odbcconn.Dispose()
            If Not command Is Nothing Then command.Dispose()
        End Try
        Return (True)
    End Function
    ' Calcola il controcodice di controllo perché fuori facciamo
    ' sempre vedere i codici completi e in entrata le ns. transazioni si aspettano
    ' tutti i digit....
    ' (Somma digit dispari - somma digit pari) --> campo di controllo
    ' se il risultato > 9 prendiamo la cifra più a destra (12 -> 2)
    Private Function addCheckDigit(ByVal valore As String) As String
        Dim tempChar() As Char = valore.ToCharArray()
        Dim pari, dispari, itera, ris As Int16
        Dim lung As Int16 = CType(tempChar.Length, Int16) - 1S

        For itera = 0 To lung Step 2
            If (itera + 1) <= lung Then
                pari = pari + CType(Val(tempChar(itera + 1)), Int16)
            End If
            dispari = dispari + CType(Val(tempChar(itera)), Int16)
        Next

        ris = Math.Abs(dispari - pari)
        If ris > 9 Then
            Return valore & Right(ris.ToString, 1)
        Else
            Return valore & ris.ToString
        End If
    End Function

    Private odbcconn As OdbcConnection
    Private command As OdbcCommand

    Sub New()
        Dim cfg As New Config
        Dim connString, bridgeMessage As String
        connString = ConfigurationSettings.AppSettings.Get("DBStradario")
        If connString = "" Then
            Throw New Exception("Errore durante l'accesso alla base dati: impossibile individuare la stringa di connessione")
        Else
            odbcconn = New OdbcConnection(connString)
            command = New OdbcCommand(Nothing, odbcconn)
        End If
    End Sub

    Public Function Ricerca0(ByVal tipo As Byte, ByVal street As String, ByRef tab As DataTable, ByRef errstring As String) As Boolean

        Dim strada As String = street.Replace("'", "").Replace(" ", "")
        If tipo = 0 Then
            command.CommandText = "SELECT DISTINCT A.COD_VIA, A.DEN_VIA FROM territ.STRADE A , territ.RUSTRA B WHERE A.COD_VIA=B.COD_VIA AND A.DTA_FIN_VAL_VIA='29991231' AND B.DEN_VIA_CMP LIKE '" & strada & "%' ORDER BY A.DEN_VIA"
        ElseIf tipo = 1 Then
            command.CommandText = "SELECT DISTINCT A.COD_VIA, A.DEN_VIA FROM territ.STRADE A , territ.RUSTRA B WHERE A.COD_VIA=B.COD_VIA AND A.DTA_FIN_VAL_VIA='29991231' AND B.DEN_VIA_CMP = '" & strada & "' ORDER BY A.DEN_VIA"
        ElseIf tipo = 2 Then
            command.CommandText = "SELECT distinct CAP, NUM_CIR FROM TERRIT.TERRIT WHERE COD_VIA='" & strada & "'"
        End If


        'If tipo = 0 Then
        '    command.CommandText = "SELECT DISTINCT A.COD_VIA, A.DEN_VIA FROM STRADE A , RUSTRA B WHERE A.COD_VIA=B.COD_VIA AND A.DTA_FIN_VAL_VIA='29991231' AND B.DEN_VIA_CMP LIKE '" & strada & "%' ORDER BY A.DEN_VIA"
        'ElseIf tipo = 1 Then
        '    command.CommandText = "SELECT DISTINCT A.COD_VIA, A.DEN_VIA FROM STRADE A , RUSTRA B WHERE A.COD_VIA=B.COD_VIA AND A.DTA_FIN_VAL_VIA='29991231' AND B.DEN_VIA_CMP = '" & strada & "' ORDER BY A.DEN_VIA"
        'ElseIf tipo = 2 Then
        '    command.CommandText = "SELECT distinct CAP, NUM_CIR FROM TERRIT.TERRIT WHERE COD_VIA='" & strada & "'"
        'End If

        tab.Columns.Add(New DataColumn("a", GetType(String)))
        tab.Columns.Add(New DataColumn("b", GetType(String)))
        Dim row As DataRow
        Dim a(1) As String

        Dim reader As OdbcDataReader

        Try
            odbcconn.Open()
            reader = command.ExecuteReader
            While reader.Read()
                row = tab.NewRow
                reader.GetValues(a)
                row.ItemArray = a
                tab.Rows.Add(row)
            End While

            ' ==================================
            ' Agg. Emiliano, 03/02/2005
            ' ---------> Aggiungo il controcodice!
            If tipo <> 2 Then
                Dim j As Int32 = tab.Rows.Count - 1
                Dim i As Int32
                For i = 0 To j
                    tab.Rows(i).Item("a") = addCheckDigit(DirectCast(tab.Rows(i).Item("a"), String))
                Next
            End If
        Catch e As OdbcException
            errstring = e.Message
            Return (False)
        Finally
            If odbcconn.State <> ConnectionState.Closed Then odbcconn.Close()
            If Not reader Is Nothing Then reader.Close()
            odbcconn.Dispose()
            If Not command Is Nothing Then command.Dispose()
        End Try

        Return (True)

    End Function

    Public Function RicercaP(ByVal tipo As Byte, ByVal street As String, ByVal civic As Int32, ByRef tab As DataTable, ByRef errstring As String) As Boolean

        Dim strada As String = street.Replace("'", "").Replace(" ", "")
        Dim civico As String = AddZero(civic)
        If tipo = 0 Then
            command.CommandText = "SELECT DISTINCT A.COD_VIA, C.DEN_VIA, A.LIM_CIV_DA, A.COD_TIP_CIV, A.SEZ_CEN, A.COD_SUD_TER, A.COD_ZON_URB, A.NUM_CIR, A.CAP FROM territ.TERRITSITO A , territ.RUSTRA B, territ.STRADE C WHERE A.COD_VIA=B.COD_VIA AND A.COD_VIA=C.COD_VIA AND A.DTA_FIN_VAL_STR='29991231' AND B.DEN_VIA_CMP LIKE '" & strada & "%' AND A.LIM_CIV_DA ='" & civico & "' ORDER BY C.DEN_VIA"
        ElseIf tipo = 1 Then
            command.CommandText = "SELECT DISTINCT A.COD_VIA, C.DEN_VIA, A.LIM_CIV_DA, A.COD_TIP_CIV, A.SEZ_CEN, A.COD_SUD_TER, A.COD_ZON_URB, A.NUM_CIR, A.CAP FROM territ.TERRITSITO A , territ.RUSTRA B, territ.STRADE C WHERE A.COD_VIA=B.COD_VIA AND A.COD_VIA=C.COD_VIA AND A.DTA_FIN_VAL_STR='29991231' AND B.DEN_VIA_CMP = '" & strada & "'AND A.LIM_CIV_DA ='" & civico & "' ORDER BY C.DEN_VIA"
        ElseIf tipo = 2 Then
            command.CommandText = "SELECT distinct A.COD_VIA, A.LIM_CIV_DA, A.COD_TIP_CIV, A.SEZ_CEN, A.COD_SUD_TER, A.COD_ZON_URB, A.NUM_CIR, A.CAP FROM TERRIT.TERRITSITO WHERE COD_VIA='" & strada & "' AND A.LIM_CIV_DA='" & civico & "'"
        End If


        'If tipo = 0 Then
        '    command.CommandText = "SELECT DISTINCT A.COD_VIA, A.DEN_VIA FROM STRADE A , RUSTRA B WHERE A.COD_VIA=B.COD_VIA AND A.DTA_FIN_VAL_VIA='29991231' AND B.DEN_VIA_CMP LIKE '" & strada & "%' ORDER BY A.DEN_VIA"
        'ElseIf tipo = 1 Then
        '    command.CommandText = "SELECT DISTINCT A.COD_VIA, A.DEN_VIA FROM STRADE A , RUSTRA B WHERE A.COD_VIA=B.COD_VIA AND A.DTA_FIN_VAL_VIA='29991231' AND B.DEN_VIA_CMP = '" & strada & "' ORDER BY A.DEN_VIA"
        'ElseIf tipo = 2 Then
        '    command.CommandText = "SELECT distinct CAP, NUM_CIR FROM TERRIT.TERRIT WHERE COD_VIA='" & strada & "'"
        'End If

        tab.Columns.Add(New DataColumn("a", GetType(String)))
        tab.Columns.Add(New DataColumn("b", GetType(String)))
        tab.Columns.Add(New DataColumn("c", GetType(String)))
        tab.Columns.Add(New DataColumn("d", GetType(String)))
        tab.Columns.Add(New DataColumn("e", GetType(String)))
        tab.Columns.Add(New DataColumn("f", GetType(String)))
        tab.Columns.Add(New DataColumn("g", GetType(String)))
        tab.Columns.Add(New DataColumn("h", GetType(String)))
        tab.Columns.Add(New DataColumn("i", GetType(String)))

        Dim row As DataRow
        Dim a(8) As String

        Dim reader As OdbcDataReader

        Try
            odbcconn.Open()
            reader = command.ExecuteReader
            While reader.Read()
                row = tab.NewRow
                reader.GetValues(a)
                row.ItemArray = a
                tab.Rows.Add(row)
            End While

            ' ==================================
            ' Agg. Emiliano, 03/02/2005
            ' ---------> Aggiungo il controcodice!
            If tipo <> 2 Then
                Dim j As Int32 = tab.Rows.Count - 1
                Dim i As Int32
                For i = 0 To j
                    tab.Rows(i).Item("a") = addCheckDigit(DirectCast(tab.Rows(i).Item("a"), String))
                Next
            End If
        Catch e As OdbcException
            errstring = e.Message
            Return (False)
        Finally
            If odbcconn.State <> ConnectionState.Closed Then odbcconn.Close()
            If Not reader Is Nothing Then reader.Close()
            odbcconn.Dispose()
            If Not command Is Nothing Then command.Dispose()
        End Try

        Return (True)

    End Function
    ' funzione che normalizza i valori numerici del civico(stringhe con zero) come li abbiamo noi in tabella 
    Public Function AddZero(ByVal Num As Int32) As String

        Dim Max As Int32
        Dim vva As Int32
        Dim i As Int32
        Max = Num.ToString.Length
        vva = 5 - Max
        Dim rit As String = CType(Num, String)
        If vva < 5 Then
            For i = 1 To vva
                rit = "0" & rit
            Next
        End If
        Return rit
    End Function


End Class

