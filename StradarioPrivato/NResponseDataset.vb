'definizione della classe che modella la risposta del web service
'La classe è disegnata per poter ospitare una risposta completa o una parziale in modo non ambiguo, prevede cioè 
'locazioni e nomi diversi per i due tipi di risposta.

Imports System.Xml.Serialization


<XmlRoot(Namespace:="http://servizi.comune.roma.it/stradario/namespace", _
            ElementName:="Strade", _
            DataType:="", _
            IsNullable:=True)> _
Public Class NResponseDataset

    <XmlElement("Strada")> Public strada_name As String
    <XmlElement("Inizio")> Public inizio As String
    <XmlElement("Fine")> Public fine As String
    <XmlElement("TipoNumerazione")> Public tipo_num As String

    <System.Xml.Serialization.XmlArray("Elenco"), _
        System.Xml.Serialization.XmlArrayItem("Strada", GetType(NItems))> _
    Public list As ArrayList

    Public Sub New()
        list = New ArrayList
    End Sub

    Public Function AddItem(ByVal item As NItems) As Integer
        Return list.Add(item)
    End Function
End Class

' Items in the list

Public Class NItems


    <XmlAttributeAttribute("Codice")> Public _cod As String
    <XmlAttributeAttribute("Nome")> Public _nome As String
    <XmlAttributeAttribute("Civico")> Public _civico As String
    <XmlAttributeAttribute("Tipo")> Public _tipo As String
    <XmlAttributeAttribute("Circ")> Public _circ As String
    <XmlAttributeAttribute("Zurb")> Public _zurb As String
    <XmlAttributeAttribute("Sudt")> Public _sudt As String
    <XmlAttributeAttribute("Sezc")> Public _sezc As String
    <XmlAttributeAttribute("CAP")> Public _cap As String
    <XmlAttributeAttribute("Loc")> Public _side As String
    <XmlAttributeAttribute("Inizio")> Public _initial As String
    <XmlAttributeAttribute("Fine")> Public _final As String


    Public Sub New()
    End Sub

    '<remarks> Costruttore richiamato dalla ricerca completa</remarks>
    Public Sub New(ByVal a1 As String, ByVal b1 As String, ByVal c1 As String, ByVal d1 As String, ByVal e1 As String)

        _initial = c1.TrimStart(Chr(48))
        _final = d1.TrimStart(Chr(48))
        _cap = b1
        _circ = a1
        Select Case e1
            Case "1"
                _side = "dispari"
            Case "2"
                _side = "pari"
            Case "3"
                _side = "n°"
            Case "4"
                _side = "Km"
        End Select
    End Sub

    '<remarks> Costruttore richiamato dalla ricerca parziale</remarks>
    Public Sub New(ByVal Codice As String, ByVal Descrizione As String)
        _cod = Codice
        _nome = Descrizione
    End Sub

    '<remarks> Costruttore richiamato dalla ricerca puntuale</remarks>
    Public Sub New(ByVal Codice As String, ByVal Nome As String, ByVal Civico As String, ByVal Tipo As String, ByVal Sezc As String, ByVal Sudt As String, ByVal Zurb As String, ByVal Circ As String, ByVal Cap As String)
        _nome = Nome
        _tipo = Tipo
        _civico = Civico
        _cap = Cap
        _cod = Codice
        _sudt = Sudt
        _zurb = Zurb
        _sezc = Sezc
        _circ = Circ
    End Sub


End Class
