Imports System.Xml.Serialization
Imports System.Xml
Imports Unisys.CdR.Servizi.Dati.Stradario

Public Class StradBusinessLayer

    Private mylist As ResponseDataset
    Private data As StradDataLayer
    Sub New()
        mylist = New ResponseDataset
        data = New StradDataLayer
    End Sub

    Public Function Request(ByVal street As String, ByVal tipo As Byte, ByRef doc As XmlDocument, ByRef errstring As String) As Boolean
        Dim tab As New DataTable
        Dim i, j As Integer

        If data.Ricerca0(tipo, street, tab, errstring) = False Then Return (False)

        j = tab.Rows.Count - 1
        For i = 0 To j
            mylist.AddItem(New Items(DirectCast(tab.Rows.Item(i).Item(0), String), StrConv(CType(tab.Rows.Item(i).Item(1), String), VbStrConv.ProperCase).TrimEnd(Chr(32))))
        Next

        serialize(doc)
        Return (True)
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
            mylist.AddItem(New Items(DirectCast(view(j).Item("d"), String), DirectCast(view(j).Item("e"), String), DirectCast(view(j).Item("b"), String), DirectCast(view(i - 1).Item("c"), String), DirectCast(view(j).Item("a"), String)))
        End While

        serialize(doc)

        Return (True)

    End Function
    ' richiesta per dati puntuali strada e civico 
    Public Function RequestPuntuale(ByVal street As String, ByVal civic As Int32, ByVal tipo As Byte, ByRef doc As XmlDocument, ByRef errstring As String) As Boolean
        Dim tab As New DataTable
        Dim i, j As Integer

        If data.RicercaP(tipo, street, civic, tab, errstring) = False Then Return (False)
        j = tab.Rows.Count - 1
        For i = 0 To j
            mylist.AddItem(New Items((DirectCast(tab.Rows.Item(i).Item(0), String)), (DirectCast(tab.Rows.Item(i).Item(1), String)).TrimEnd, (DirectCast(tab.Rows.Item(i).Item(2), String)), (DirectCast(tab.Rows.Item(i).Item(3), String)), (DirectCast(tab.Rows.Item(i).Item(4), String)), (DirectCast(tab.Rows.Item(i).Item(5), String)), (DirectCast(tab.Rows.Item(i).Item(6), String)), (DirectCast(tab.Rows.Item(i).Item(7), String)), (DirectCast(tab.Rows.Item(i).Item(8), String))))
            serialize(doc)
        Next
        Return (True)
    End Function







    '<remarks> </remarks>
    Private Function serialize(ByRef doc As XmlDocument) As Boolean

        Dim xmldoc As New XmlDocument
        Dim s As New XmlSerializer(GetType(ResponseDataset))
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

End Class

