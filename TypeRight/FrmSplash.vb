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
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build)
        Copyright.Text = My.Application.Info.Copyright

    End Sub

End Class
