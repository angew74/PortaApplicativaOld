Imports Microsoft.Web.Services2

Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TestVA As System.Windows.Forms.Button
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPW As System.Windows.Forms.TextBox
    Friend WithEvents URL As System.Windows.Forms.TextBox
    Friend WithEvents chkAut As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCF As System.Windows.Forms.TextBox
    Friend WithEvents risbox As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ButtonP As System.Windows.Forms.Button
    Friend WithEvents LabelStrada As System.Windows.Forms.Label
    Friend WithEvents TextStrada As System.Windows.Forms.TextBox
    Friend WithEvents Civico As System.Windows.Forms.Label
    Friend WithEvents TextCivico As System.Windows.Forms.TextBox
    Friend WithEvents LabelTipo As System.Windows.Forms.Label
    Friend WithEvents TextTipo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextUrl As System.Windows.Forms.TextBox
    Friend WithEvents ButtonNome As System.Windows.Forms.Button
    Friend WithEvents ButtonCodice As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextCodice As System.Windows.Forms.TextBox
    Friend WithEvents ButtonParz As System.Windows.Forms.Button
    Friend WithEvents ATER As System.Windows.Forms.Button
    Friend WithEvents TextInterno As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextScala As System.Windows.Forms.TextBox
    Friend WithEvents BtnVIndirizzo As System.Windows.Forms.Button
    Friend WithEvents PermButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TestVA = New System.Windows.Forms.Button
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.chkAut = New System.Windows.Forms.CheckBox
        Me.txtPW = New System.Windows.Forms.TextBox
        Me.URL = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCF = New System.Windows.Forms.TextBox
        Me.risbox = New System.Windows.Forms.RichTextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.ButtonP = New System.Windows.Forms.Button
        Me.LabelStrada = New System.Windows.Forms.Label
        Me.TextStrada = New System.Windows.Forms.TextBox
        Me.Civico = New System.Windows.Forms.Label
        Me.TextCivico = New System.Windows.Forms.TextBox
        Me.LabelTipo = New System.Windows.Forms.Label
        Me.TextTipo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextUrl = New System.Windows.Forms.TextBox
        Me.ButtonNome = New System.Windows.Forms.Button
        Me.ButtonCodice = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextCodice = New System.Windows.Forms.TextBox
        Me.ButtonParz = New System.Windows.Forms.Button
        Me.PermButton = New System.Windows.Forms.Button
        Me.ATER = New System.Windows.Forms.Button
        Me.TextInterno = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextScala = New System.Windows.Forms.TextBox
        Me.BtnVIndirizzo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TestVA
        '
        Me.TestVA.Location = New System.Drawing.Point(8, 132)
        Me.TestVA.Name = "TestVA"
        Me.TestVA.Size = New System.Drawing.Size(75, 23)
        Me.TestVA.TabIndex = 0
        Me.TestVA.Text = "Test VA"
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(212, 8)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(180, 20)
        Me.txtUser.TabIndex = 2
        Me.txtUser.Text = "uniadmin"
        '
        'chkAut
        '
        Me.chkAut.Checked = True
        Me.chkAut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAut.Location = New System.Drawing.Point(12, 8)
        Me.chkAut.Name = "chkAut"
        Me.chkAut.Size = New System.Drawing.Size(148, 24)
        Me.chkAut.TabIndex = 3
        Me.chkAut.Text = "usa UsernameToken"
        '
        'txtPW
        '
        Me.txtPW.Location = New System.Drawing.Point(432, 12)
        Me.txtPW.Name = "txtPW"
        Me.txtPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPW.Size = New System.Drawing.Size(228, 20)
        Me.txtPW.TabIndex = 4
        Me.txtPW.Text = "roberta4"
        '
        'URL
        '
        Me.URL.Location = New System.Drawing.Point(52, 38)
        Me.URL.Name = "URL"
        Me.URL.Size = New System.Drawing.Size(336, 20)
        Me.URL.TabIndex = 5
        Me.URL.Text = "http://CDRDEV225/PA/pri/Verifiche/nva.asmx"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "URL"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(396, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "PW"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(164, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "User"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(400, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "CF"
        '
        'txtCF
        '
        Me.txtCF.Location = New System.Drawing.Point(436, 40)
        Me.txtCF.Name = "txtCF"
        Me.txtCF.Size = New System.Drawing.Size(228, 20)
        Me.txtCF.TabIndex = 10
        Me.txtCF.Text = "DLFMLN73D01H501D"
        '
        'risbox
        '
        Me.risbox.Location = New System.Drawing.Point(0, 236)
        Me.risbox.Name = "risbox"
        Me.risbox.Size = New System.Drawing.Size(656, 280)
        Me.risbox.TabIndex = 11
        Me.risbox.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(88, 132)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Stradario"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(176, 132)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "ICID"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(260, 132)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(112, 23)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Test VA 4 People"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(380, 132)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Strade"
        '
        'ButtonP
        '
        Me.ButtonP.Location = New System.Drawing.Point(464, 132)
        Me.ButtonP.Name = "ButtonP"
        Me.ButtonP.Size = New System.Drawing.Size(96, 23)
        Me.ButtonP.TabIndex = 16
        Me.ButtonP.Text = "StradePuntuali"
        '
        'LabelStrada
        '
        Me.LabelStrada.Location = New System.Drawing.Point(8, 172)
        Me.LabelStrada.Name = "LabelStrada"
        Me.LabelStrada.Size = New System.Drawing.Size(40, 16)
        Me.LabelStrada.TabIndex = 17
        Me.LabelStrada.Text = "Strada"
        '
        'TextStrada
        '
        Me.TextStrada.Location = New System.Drawing.Point(60, 168)
        Me.TextStrada.Name = "TextStrada"
        Me.TextStrada.Size = New System.Drawing.Size(220, 20)
        Me.TextStrada.TabIndex = 18
        Me.TextStrada.Text = "Massaia"
        '
        'Civico
        '
        Me.Civico.Location = New System.Drawing.Point(292, 172)
        Me.Civico.Name = "Civico"
        Me.Civico.Size = New System.Drawing.Size(36, 16)
        Me.Civico.TabIndex = 19
        Me.Civico.Text = "Civico"
        '
        'TextCivico
        '
        Me.TextCivico.Location = New System.Drawing.Point(336, 168)
        Me.TextCivico.MaxLength = 5
        Me.TextCivico.Name = "TextCivico"
        Me.TextCivico.Size = New System.Drawing.Size(44, 20)
        Me.TextCivico.TabIndex = 20
        Me.TextCivico.Text = "45"
        '
        'LabelTipo
        '
        Me.LabelTipo.Location = New System.Drawing.Point(388, 168)
        Me.LabelTipo.Name = "LabelTipo"
        Me.LabelTipo.Size = New System.Drawing.Size(48, 16)
        Me.LabelTipo.TabIndex = 21
        Me.LabelTipo.Text = "TipoCiv"
        '
        'TextTipo
        '
        Me.TextTipo.Location = New System.Drawing.Point(448, 164)
        Me.TextTipo.Name = "TextTipo"
        Me.TextTipo.Size = New System.Drawing.Size(24, 20)
        Me.TextTipo.TabIndex = 22
        Me.TextTipo.Text = "0"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "URLS"
        '
        'TextUrl
        '
        Me.TextUrl.Location = New System.Drawing.Point(64, 88)
        Me.TextUrl.Name = "TextUrl"
        Me.TextUrl.Size = New System.Drawing.Size(324, 20)
        Me.TextUrl.TabIndex = 24
        Me.TextUrl.Text = "http://10.173.2.133/PA/pri/Stradario/stradario.asmx"
        '
        'ButtonNome
        '
        Me.ButtonNome.Location = New System.Drawing.Point(572, 132)
        Me.ButtonNome.Name = "ButtonNome"
        Me.ButtonNome.Size = New System.Drawing.Size(76, 23)
        Me.ButtonNome.TabIndex = 25
        Me.ButtonNome.Text = "StradaNome"
        '
        'ButtonCodice
        '
        Me.ButtonCodice.Location = New System.Drawing.Point(488, 164)
        Me.ButtonCodice.Name = "ButtonCodice"
        Me.ButtonCodice.Size = New System.Drawing.Size(84, 23)
        Me.ButtonCodice.TabIndex = 26
        Me.ButtonCodice.Text = "StradaCodice"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 16)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Codice"
        '
        'TextCodice
        '
        Me.TextCodice.Location = New System.Drawing.Point(60, 196)
        Me.TextCodice.MaxLength = 6
        Me.TextCodice.Name = "TextCodice"
        Me.TextCodice.Size = New System.Drawing.Size(60, 20)
        Me.TextCodice.TabIndex = 28
        Me.TextCodice.Text = "058366"
        '
        'ButtonParz
        '
        Me.ButtonParz.Location = New System.Drawing.Point(584, 164)
        Me.ButtonParz.Name = "ButtonParz"
        Me.ButtonParz.Size = New System.Drawing.Size(75, 23)
        Me.ButtonParz.TabIndex = 29
        Me.ButtonParz.Text = "StradaParz"
        '
        'PermButton
        '
        Me.PermButton.Location = New System.Drawing.Point(460, 92)
        Me.PermButton.Name = "PermButton"
        Me.PermButton.Size = New System.Drawing.Size(75, 23)
        Me.PermButton.TabIndex = 30
        Me.PermButton.Text = "Perm"
        '
        'ATER
        '
        Me.ATER.Location = New System.Drawing.Point(572, 88)
        Me.ATER.Name = "ATER"
        Me.ATER.Size = New System.Drawing.Size(75, 23)
        Me.ATER.TabIndex = 31
        Me.ATER.Text = "ATER"
        Me.ATER.UseVisualStyleBackColor = True
        '
        'TextInterno
        '
        Me.TextInterno.Location = New System.Drawing.Point(167, 196)
        Me.TextInterno.Name = "TextInterno"
        Me.TextInterno.Size = New System.Drawing.Size(38, 20)
        Me.TextInterno.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(136, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Int"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(227, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Scala"
        '
        'TextScala
        '
        Me.TextScala.Location = New System.Drawing.Point(283, 196)
        Me.TextScala.Name = "TextScala"
        Me.TextScala.Size = New System.Drawing.Size(30, 20)
        Me.TextScala.TabIndex = 35
        '
        'BtnVIndirizzo
        '
        Me.BtnVIndirizzo.Location = New System.Drawing.Point(360, 196)
        Me.BtnVIndirizzo.Name = "BtnVIndirizzo"
        Me.BtnVIndirizzo.Size = New System.Drawing.Size(75, 23)
        Me.BtnVIndirizzo.TabIndex = 36
        Me.BtnVIndirizzo.Text = "V. Dom Ind"
        Me.BtnVIndirizzo.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(668, 521)
        Me.Controls.Add(Me.BtnVIndirizzo)
        Me.Controls.Add(Me.TextScala)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextInterno)
        Me.Controls.Add(Me.ATER)
        Me.Controls.Add(Me.PermButton)
        Me.Controls.Add(Me.ButtonParz)
        Me.Controls.Add(Me.TextCodice)
        Me.Controls.Add(Me.TextUrl)
        Me.Controls.Add(Me.TextTipo)
        Me.Controls.Add(Me.TextCivico)
        Me.Controls.Add(Me.TextStrada)
        Me.Controls.Add(Me.txtCF)
        Me.Controls.Add(Me.URL)
        Me.Controls.Add(Me.txtPW)
        Me.Controls.Add(Me.chkAut)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ButtonCodice)
        Me.Controls.Add(Me.ButtonNome)
        Me.Controls.Add(Me.ButtonP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LabelTipo)
        Me.Controls.Add(Me.Civico)
        Me.Controls.Add(Me.LabelStrada)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.risbox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TestVA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MainForm"
        Me.Text = "usa UsernameToken"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private w As PAVerifiche1.NVA

    'Private w4p As VA4People.VA4PeopleWSE
    Private wss As Stradario.Stradario



    Private Sub SetWS()

        risbox.Text = ""
        risbox.Refresh()

        w = New PAVerifiche1.NVA

        w.Url = URL.Text
        w.LogHeaderValue = New PAVerifiche1.LogHeader

        w.LogHeaderValue.LogGuid = "provanico"
        If chkAut.Checked Then
            'w.LogHeaderValue = ""
            '  w.RequestSoapContext.Security.Tokens.Add(New Security.Tokens.UsernameToken(txtUser.Text, PlainToSHA1(txtPW.Text), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone))
            'w.RequestSoapContext.Security.Tokens.Add(New Security.Tokens.UsernameToken(txtUser.Text, PlainToSHA1(txtPW.Text), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone))
            'w.RequestSoapContext.Security.Tokens.Add(New Security.Tokens.UsernameToken(txtUser.Text, txtPW.Text, Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone))
        End If
        'inpsdcsitarcoweb
    End Sub
    Private Sub SetWS4People()

        risbox.Text = ""
        risbox.Refresh()

        ' w4p = New VA4People.VA4PeopleWSE
        'w4p.Url = URL.Text
        'If chkAut.Checked Then
        '  w4p.RequestSoapContext.Security.Tokens.Add(New Security.Tokens.UsernameToken(txtUser.Text, PlainToSHA1(txtPW.Text), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone))
        'w.RequestSoapContext.Security.Tokens.Add(New Security.Tokens.UsernameToken(txtUser.Text, txtPW.Text, Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone))
        ' End If
        'inpsdcsitarcoweb
    End Sub
    Private Sub SetWSStradario()
        risbox.Text = ""
        risbox.Refresh()
        wss = New Stradario.Stradario
        wss.Url = TextUrl.Text
        wss.LogHeaderValue = New Stradario.LogHeader
        wss.LogHeaderValue.LogGuid = "provanico"
        If chkAut.Checked Then

            '  wss.RequestSoapContext.Security.Tokens.Add(New Security.Tokens.UsernameToken(txtUser.Text, PlainToSHA1(txtPW.Text), Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone))
            'w.RequestSoapContext.Security.Tokens.Add(New Security.Tokens.UsernameToken(txtUser.Text, txtPW.Text, Microsoft.Web.Services2.Security.Tokens.PasswordOption.SendNone))
        End If


    End Sub


    '<remarks>Calcola l'HASH di una stringa con SHA-1</remarks>
    Private Function PlainToSHA1(ByVal Stringa As String) As String
        Dim sha As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim objEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
        Dim pwHashed() As Byte = sha.ComputeHash(objEncoding.GetBytes(Stringa))
        Return System.Convert.ToBase64String(pwHashed)
    End Function

    Private Sub TestVA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestVA.Click

        'Dim i As Int32
        'For i = 1 To 1
        '    Dim th As New System.Threading.Thread(AddressOf NETVA)
        '    th.Start()
        'Next

        NETVA()

    End Sub

    Private Sub NETVA()

        SetWS()

        Dim x As System.Xml.XmlNode
        Try
            Dim i As Int32
            For i = 1 To 1
                ' x = w.VerificaCRI(3, "", "FMMGNN43D42D451X", "F", "FIAMMENGHI", "", "02", "04", "1943", 0, 0, 1)
                'x = w.VerificaAnagrafica(1, "1A123456", txtCF.Text.Trim(), "M", "", "", 0, 0, 0, 1)
                'x = w.VerificaAnagrafica(1, "00000011", txtCF.Text.Trim(), "M", "", "", 0, 0, 0, 1)
                'x = w.VerificaStatoFamigliaConv(3, "", "", "M", "DEL FIUME", "EMILIANO", 0, 0, 1973, 1)
                x = w.VerificaAnagraficaSuper(1, "24392602", "", "", "", "", 0, 0, 0, 0)
                risbox.Text = x.OuterXml
            Next
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim x As System.Xml.XmlNode
        SetWSStradario()
        Try
            x = wss.ElencoStrade(TextStrada.Text)
            risbox.Text = x.OuterXml
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try
        ' s.Dispose()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'SetWS()

        'Dim x As System.Xml.XmlNode
        'Try
        '    'x = w.VerificaCartaIdent
        '    x = w.VerificaCartaId("AH3832394", 0)
        '    risbox.Text = x.OuterXml
        'Catch ex As Exception
        '    If Not ex.InnerException Is Nothing Then
        '        risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
        '    Else
        '        risbox.Text = ex.Message
        '    End If
        'End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        SetWS4People()

        Dim x As System.Xml.XmlNode
        Try
            ' x = w4p.CertByAnag("DEL FIUME", "EMILIANO", 1, 4, 1973, "M", "DLFMLN73d01h501d", "AH3832394", 1, 10, 2002)
            risbox.Text = x.OuterXml
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        SetWSStradario()

        Dim x As System.Xml.XmlNode
        Try
            ' x = w4p.ElencoStrade("CASSIA")
            x = wss.ElencoStrade(TextStrada.Text)
            risbox.Text = x.OuterXml
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try
    End Sub

    Private Sub txtUser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUser.TextChanged

    End Sub

    Private Sub txtPW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPW.TextChanged

    End Sub

    Private Sub ButtonP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonP.Click
        SetWSStradario()
        Dim Street As String = TextStrada.Text
        Dim Civic As Int32 = CType(TextCivico.Text, Int32)
        Dim Tipo As Byte = CType(TextTipo.Text, Byte)
        Dim x As System.Xml.XmlNode
        Try
            x = wss.CercaStradaDalNomeeDalCivico(Street, Civic, Tipo)
            risbox.Text = x.OuterXml
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try
    End Sub



    Private Sub ButtonNome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNome.Click
        SetWSStradario()
        Dim Tipo As Byte = CType(TextTipo.Text, Byte)
        Dim Street As String = TextStrada.Text
        Dim x As System.Xml.XmlNode
        Try
            x = wss.CercaStradaDalNome(Street, Tipo)
            risbox.Text = x.OuterXml
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try
    End Sub

    Private Sub ButtonCodice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCodice.Click
        SetWSStradario()
        Dim Tipo As Byte = CType(TextTipo.Text, Byte)
        Dim Codice As String = TextCodice.Text
        Dim x As System.Xml.XmlNode
        Try
            x = wss.CercaStradaDalCodice(Codice)
            risbox.Text = x.OuterXml
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try
    End Sub


    Private Sub ButtonParz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonParz.Click
        SetWSStradario()
        Dim Tipo As Byte = CType(TextTipo.Text, Byte)
        Dim Street As String = TextStrada.Text
        Dim x As System.Xml.XmlNode
        Try
            x = wss.ElencoStrade(Street)
            risbox.Text = x.OuterXml
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try
    End Sub

    Private Sub PermButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PermButton.Click
        SetWS()

        Dim x As System.Xml.XmlNode
        Try
            Dim i As Int32
            For i = 1 To 1
                x = w.VerificaPerm(4, "46925550", "", "", "", "", 0, 0, 0, 0, 0, "", "", 1)
                'x = w.VerificaAnagrafica(2, 0, txtCF.Text.Trim(), "M"c, "", "", 0, 0, 0, 1)
                risbox.Text = x.OuterXml
            Next
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try


    End Sub

    Private Sub ATER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ATER.Click
        SetWS()

        Dim x As System.Xml.XmlNode
        Try
            Dim i As Int32
            For i = 1 To 1
                ' x = w.VerificaCRI(3, "", "FMMGNN43D42D451X", "F", "FIAMMENGHI", "", "02", "04", "1943", 0, 0, 1)
                'x = w.VerificaAnagrafica(1, "1A123456", txtCF.Text.Trim(), "M", "", "", 0, 0, 0, 1)
                'x = w.VerificaAnagrafica(1, "00000011", txtCF.Text.Trim(), "M", "", "", 0, 0, 0, 1)
                x = w.VerificaDomiciliatiperIndirizzoeFamiglia(1, 0, "Carso", 23, "", "", "", "", "", "", "", 0)

                risbox.Text = x.OuterXml
            Next
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try
    End Sub

    Private Sub BtnVIndirizzo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVIndirizzo.Click
        SetWS()

        Dim x As System.Xml.XmlNode
        Try
            Dim i As Int32
            For i = 1 To 1
                ' x = w.VerificaCRI(3, "", "FMMGNN43D42D451X", "F", "FIAMMENGHI", "", "02", "04", "1943", 0, 0, 1)
                'x = w.VerificaAnagrafica(1, "1A123456", txtCF.Text.Trim(), "M", "", "", 0, 0, 0, 1)
                'x = w.VerificaAnagrafica(1, "00000011", txtCF.Text.Trim(), "M", "", "", 0, 0, 0, 1)
                x = w.VerificaDomiciliatiperIndirizzo(1, 0, "Carso", 23, "", "", "", "", TextScala.Text, "", TextInterno.Text, 0)

                risbox.Text = x.OuterXml
            Next
        Catch ex As Exception
            If Not ex.InnerException Is Nothing Then
                risbox.Text = ex.Message & " --- Inner: " & ex.InnerException.Message
            Else
                risbox.Text = ex.Message
            End If
        End Try
    End Sub
End Class
