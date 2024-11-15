Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class APIClient
    Private ReadOnly _httpClient As HttpClient

    Public Sub New()
        _httpClient = New HttpClient()
        _httpClient.BaseAddress = New Uri("https://jsonplaceholder.typicode.com/")
    End Sub

    ' Obtener todos los álbumes de la API
    Public Async Function GetAlbumsAsync() As Task(Of List(Of Album))
        Return Await Task.Run(Async Function()
                                  Dim response As HttpResponseMessage = Await _httpClient.GetAsync("albums")
                                  response.EnsureSuccessStatusCode()
                                  Dim json As String = Await response.Content.ReadAsStringAsync()
                                  Return JsonConvert.DeserializeObject(Of List(Of Album))(json)
                              End Function)
    End Function

    ' Obtener todas las fotos de la API
    Public Async Function GetPhotosAsync() As Task(Of List(Of Photo))
        Dim response As HttpResponseMessage = Await _httpClient.GetAsync("photos")
        response.EnsureSuccessStatusCode()

        Dim json As String = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of List(Of Photo))(json)
    End Function

    ' Obtener un álbum por ID
    Public Async Function GetAlbumByIdAsync(id As Integer) As Task(Of Album)
        Dim response As HttpResponseMessage = Await _httpClient.GetAsync($"albums/{id}")

        If Not response.IsSuccessStatusCode Then
            Return Nothing
        End If

        Dim json As String = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of Album)(json)
    End Function

    ' Obtener álbumes por título
    Public Async Function GetAlbumsByTitleAsync(title As String) As Task(Of List(Of Album))
        Dim albums As List(Of Album) = Await GetAlbumsAsync()
        Return albums.Where(Function(a) a.Title.ToLower().Contains(title.ToLower())).ToList()
    End Function

    ' Obtener una foto por ID
    Public Async Function GetPhotoByIdAsync(id As Integer) As Task(Of Photo)
        Dim response As HttpResponseMessage = Await _httpClient.GetAsync($"photos/{id}")

        If Not response.IsSuccessStatusCode Then
            Return Nothing
        End If

        Dim json As String = Await response.Content.ReadAsStringAsync()
        Return JsonConvert.DeserializeObject(Of Photo)(json)
    End Function

    ' Obtener fotos por título
    Public Async Function GetPhotosByTitleAsync(title As String) As Task(Of List(Of Photo))
        Dim photos As List(Of Photo) = Await GetPhotosAsync()
        Return photos.Where(Function(p) p.Title.ToLower().Contains(title.ToLower())).ToList()
    End Function
End Class
