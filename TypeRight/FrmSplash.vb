Public NotInheritable Class FrmSplash
    Private _delay As Integer = 5
    Public Property Delay() As Integer
        Get
            Return _delay
        End Get
        Set(ByVal value As Integer)
            _delay = value
        End Set
    End Property
    Private Sub FrmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        Copyright.Text = My.Application.Info.Copyright

        Timer1.Interval = _delay * 1000
        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub
End Class
