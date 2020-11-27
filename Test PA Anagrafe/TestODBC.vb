Public Class TestODBC
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OdbcConnection1 As System.Data.Odbc.OdbcConnection
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.OdbcConnection1 = New System.Data.Odbc.OdbcConnection
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(160, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Test"
        '
        'OdbcConnection1
        '
        Me.OdbcConnection1.ConnectionString = "DSN=STRADARIO;UID=TERRIT;PWD="
        '
        'TestODBC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 349)
        Me.Controls.Add(Me.Button1)
        Me.Name = "TestODBC"
        Me.Text = "TestODBC"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oc As New System.Data.Odbc.OdbcConnection("DSN=STRADARIO;UID=TERRIT;PWD=")
        Try
            oc.Open()
            oc.Close()
        Finally
            oc.Dispose()
        End Try

    End Sub

    Private Sub OdbcConnection1_InfoMessage(ByVal sender As System.Object, ByVal e As System.Data.Odbc.OdbcInfoMessageEventArgs) Handles OdbcConnection1.InfoMessage

    End Sub
End Class
