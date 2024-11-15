Public Class Album
    Public Property Id As Integer
    Public Property Title As String
    Public Property UserId As Integer

    Public Property Photos As ICollection(Of Photo)
End Class
