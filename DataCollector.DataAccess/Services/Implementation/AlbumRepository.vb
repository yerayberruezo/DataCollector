Imports System.Threading.Tasks
Imports System.Linq
Imports System.Data.Entity

Public Class AlbumRepository
    Implements IAlbumRepository

    Private ReadOnly _dataContext As DataContext
    Private ReadOnly _apiClient As APIClient

    ' Constructor que recibe el contexto de la base de datos y el cliente de la API
    Public Sub New(dataContext As DataContext, apiClient As APIClient)
        _dataContext = dataContext
        _apiClient = apiClient
    End Sub

    ' Obtener todos los álbumes desde la base de datos
    Public Async Function GetAllAlbums() As Task(Of List(Of Album)) Implements IAlbumRepository.GetAllAlbums
        Return Await _dataContext.Albums.ToListAsync()
    End Function

    ' Obtener un álbum por su ID desde la base de datos
    Public Async Function GetAlbumById(id As Integer) As Task(Of Album) Implements IAlbumRepository.GetAlbumById
        Return Await _dataContext.Albums.FindAsync(id)
    End Function

    ' Obtener todos los álbumes desde la API externa
    Public Async Function GetAlbumsFromApi() As Task(Of List(Of Album)) Implements IAlbumRepository.GetAlbumsFromApi
        Dim apiAlbums = Await _apiClient.GetAlbumsAsync()
        Return apiAlbums.Select(Function(a) New Album With {
                .Id = a.Id,
                .UserId = a.UserId,
                .Title = a.Title
            }).ToList()
    End Function

    ' Obtener un álbum por su ID desde la API externa
    Public Async Function GetAlbumByIdFromApi(id As Integer) As Task(Of Album) Implements IAlbumRepository.GetAlbumByIdFromApi
        Dim apiAlbums = Await _apiClient.GetAlbumsAsync()

        Dim apiAlbum = apiAlbums.FirstOrDefault(Function(a) a.Id = id)
        If apiAlbum IsNot Nothing Then
            Return New Album With {
                    .Id = apiAlbum.Id,
                    .UserId = apiAlbum.UserId,
                    .Title = apiAlbum.Title
                }
        End If

        Return Nothing
    End Function
End Class
