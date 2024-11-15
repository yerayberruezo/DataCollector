Imports System.Threading.Tasks
Imports DataCollectorApp.DataAccess.Entities

Namespace DataCollector.Business.Repositories
    Public Interface IPhotoRepository
        ' Métodos para obtener fotos de la base de datos
        Function GetAllPhotos() As Task(Of List(Of Photo))
        Function GetPhotoById(id As Integer) As Task(Of Photo)
        Function GetPhotosByAlbumId(idAlbum As Integer) As Task(Of List(Of Photo))

        ' Métodos para obtener fotos de la API externa
        Function GetPhotosFromApi() As Task(Of List(Of Photo))
        Function GetPhotoByIdFromApi(id As Integer) As Task(Of Photo)
    End Interface
End Namespace
