Imports System.Threading.Tasks
Imports System.Linq
Imports DataCollector.Business.DataCollector.Business.DTOs
Imports DataCollector.Business.DataCollector.Business.Services.Interfaces
Imports DataCollector.Business.DataCollectorApp.Business.Mappers
Imports DataCollector.DataAccess.DataCollector.Business.Repositories

Namespace DataCollectorApp.Business.Services.Implementations
    Public Class PhotoService
        Implements IPhotoService

        Private ReadOnly _photoRepository As IPhotoRepository

        ' Constructor que recibe el repositorio
        Public Sub New(photoRepository As IPhotoRepository)
            _photoRepository = photoRepository
        End Sub

        ' Obtener todas las fotos desde la base de datos
        Public Async Function GetPhotosFromDatabase() As Task(Of List(Of PhotoDTO)) Implements IPhotoService.GetPhotosFromDatabase
            Dim photos = Await _photoRepository.GetAllPhotos()
            Return PhotoMapper.MapToDTOList(photos)
        End Function

        ' Obtener una foto por ID desde la base de datos
        Public Async Function GetPhotoByIdFromDatabase(id As Integer) As Task(Of PhotoDTO) Implements IPhotoService.GetPhotoByIdFromDatabase
            Dim photo = Await _photoRepository.GetPhotoById(id)
            Return If(photo IsNot Nothing, PhotoMapper.MapToDTO(photo), Nothing)
        End Function

        ' Buscar fotos por título en la base de datos
        Public Async Function SearchPhotosByTitleInDatabase(title As String) As Task(Of List(Of PhotoDTO)) Implements IPhotoService.SearchPhotosByTitleInDatabase
            Dim photos = Await _photoRepository.GetAllPhotos()
            Dim filteredPhotos = photos.Where(Function(p) p.Title.ToLower().Contains(title.ToLower())).ToList()
            Return PhotoMapper.MapToDTOList(filteredPhotos)
        End Function

        Public Async Function GetPhotosFromDatabaseByIdAlbum(idAlbum As Integer) As Task(Of List(Of PhotoDTO)) Implements IPhotoService.GetPhotosFromDatabaseByIdAlbum
            Dim photos = Await _photoRepository.GetPhotosByAlbumId(idAlbum)
            Return PhotoMapper.MapToDTOList(photos)
        End Function

        ' Obtener todas las fotos desde la API
        Public Async Function GetPhotosFromAPI() As Task(Of List(Of PhotoDTO)) Implements IPhotoService.GetPhotosFromAPI
            Dim photos = Await _photoRepository.GetPhotosFromApi()
            Return PhotoMapper.MapToDTOList(photos)
        End Function

        ' Obtener una foto por ID desde la API
        Public Async Function GetPhotoByIdFromAPI(id As Integer) As Task(Of PhotoDTO) Implements IPhotoService.GetPhotoByIdFromAPI
            Dim photo = Await _photoRepository.GetPhotoByIdFromApi(id)
            Return If(photo IsNot Nothing, PhotoMapper.MapToDTO(photo), Nothing)
        End Function

        ' Buscar fotos por título en la API
        Public Async Function SearchPhotosByTitleInAPI(title As String) As Task(Of List(Of PhotoDTO)) Implements IPhotoService.SearchPhotosByTitleInAPI
            Dim photos = Await _photoRepository.GetPhotosFromApi()
            Dim filteredPhotos = photos.Where(Function(p) p.Title.ToLower().Contains(title.ToLower())).ToList()
            Return PhotoMapper.MapToDTOList(filteredPhotos)
        End Function
    End Class
End Namespace
