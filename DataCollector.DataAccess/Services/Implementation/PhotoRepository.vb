Imports System.Threading.Tasks
Imports System.Linq
Imports System.Data.Entity
Imports DataCollector.DataAccess.DataCollector.Business.Repositories

Public Class PhotoRepository
    Implements IPhotoRepository

    Private ReadOnly _dataContext As DataContext
    Private ReadOnly _apiClient As APIClient

    ' Constructor que recibe el contexto de la base de datos y el cliente de la API
    Public Sub New(dataContext As DataContext, apiClient As APIClient)
        _dataContext = dataContext
        _apiClient = apiClient
    End Sub

    ' Obtener todas las fotos desde la base de datos
    Public Async Function GetAllPhotos() As Task(Of List(Of Photo)) Implements IPhotoRepository.GetAllPhotos
        Return Await _dataContext.Photos.ToListAsync()
    End Function

    ' Obtener una foto por su ID desde la base de datos
    Public Async Function GetPhotoById(id As Integer) As Task(Of Photo) Implements IPhotoRepository.GetPhotoById
        Return Await _dataContext.Photos.FindAsync(id)
    End Function

    ' Obtener fotos por el ID de álbum desde la base de datos
    Public Async Function GetPhotosByAlbumId(idAlbum As Integer) As Task(Of List(Of Photo)) Implements IPhotoRepository.GetPhotosByAlbumId
        Return Await _dataContext.Photos.Where(Function(p) p.AlbumId = idAlbum).ToListAsync()
    End Function

    ' Obtener todas las fotos desde la API externa
    Public Async Function GetPhotosFromApi() As Task(Of List(Of Photo)) Implements IPhotoRepository.GetPhotosFromApi
        Dim apiPhotos = Await _apiClient.GetPhotosAsync()

        Return apiPhotos.Select(Function(p) New Photo With {
                .Id = p.Id,
                .AlbumId = p.AlbumId,
                .Title = p.Title,
                .Url = p.Url,
                .ThumbnailUrl = p.ThumbnailUrl
            }).ToList()
    End Function

    ' Obtener una foto por su ID desde la API externa
    Public Async Function GetPhotoByIdFromApi(id As Integer) As Task(Of Photo) Implements IPhotoRepository.GetPhotoByIdFromApi
        Dim apiPhotos = Await _apiClient.GetPhotosAsync()
        Dim apiPhoto = apiPhotos.FirstOrDefault(Function(p) p.Id = id)

        If apiPhoto IsNot Nothing Then
            Return New Photo With {
                    .Id = apiPhoto.Id,
                    .AlbumId = apiPhoto.AlbumId,
                    .Title = apiPhoto.Title,
                    .Url = apiPhoto.Url,
                    .ThumbnailUrl = apiPhoto.ThumbnailUrl
                }
        End If
        Return Nothing
    End Function

End Class