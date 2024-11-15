Imports System.Threading.Tasks
Imports DataCollector.Business.DataCollector.Business.DTOs

Namespace DataCollector.Business.Services.Interfaces
    Public Interface IPhotoService
        ' Métodos para obtener fotos de la base de datos
        Function GetPhotosFromDatabase() As Task(Of List(Of PhotoDTO))
        Function GetPhotoByIdFromDatabase(id As Integer) As Task(Of PhotoDTO)
        Function SearchPhotosByTitleInDatabase(title As String) As Task(Of List(Of PhotoDTO))
        Function GetPhotosFromDatabaseByIdAlbum(idAlbum As Integer) As Task(Of List(Of PhotoDTO))

        ' Métodos para obtener fotos de la API
        Function GetPhotosFromAPI() As Task(Of List(Of PhotoDTO))
        Function GetPhotoByIdFromAPI(id As Integer) As Task(Of PhotoDTO)
        Function SearchPhotosByTitleInAPI(title As String) As Task(Of List(Of PhotoDTO))
    End Interface
End Namespace
