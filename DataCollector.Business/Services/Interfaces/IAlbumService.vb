Imports System.Threading.Tasks
Imports DataCollector.Business.DataCollector.Business.DTOs

Namespace DataCollector.Business.Services.Interfaces
    Public Interface IAlbumService
        ' Métodos para obtener álbumes de la base de datos
        Function GetAlbumsFromDatabase() As Task(Of List(Of AlbumDTO))
        Function GetAlbumByIdFromDatabase(id As Integer) As Task(Of AlbumDTO)
        Function SearchAlbumsByTitleInDatabase(title As String) As Task(Of List(Of AlbumDTO))

        ' Métodos para obtener álbumes de la API
        Function GetAlbumsFromAPI() As Task(Of List(Of AlbumDTO))
        Function GetAlbumByIdFromAPI(id As Integer) As Task(Of AlbumDTO)
        Function SearchAlbumsByTitleInAPI(title As String) As Task(Of List(Of AlbumDTO))
    End Interface
End Namespace
