Imports System.Threading.Tasks
Imports DataCollector.Business.DataCollector.Business.DTOs
Imports DataCollector.Business.DataCollector.Business.Services.Interfaces
Imports DataCollector.Business.DataCollectorApp.Business.Mappers
Imports DataCollector.DataAccess

Namespace DataCollector.Business.Services.Implementations
    Public Class AlbumService
        Implements IAlbumService

        Private ReadOnly _albumRepository As IAlbumRepository

        Public Sub New(albumRepository As IAlbumRepository)
            _albumRepository = albumRepository
        End Sub

        ' Obtener todos los álbumes desde la base de datos
        Public Async Function GetAlbumsFromDatabase() As Task(Of List(Of AlbumDTO)) Implements IAlbumService.GetAlbumsFromDatabase
            Dim albums = Await _albumRepository.GetAllAlbums()
            Return AlbumMapper.MapToDTOList(albums)
        End Function

        ' Obtener un álbum por ID desde la base de datos
        Public Async Function GetAlbumByIdFromDatabase(id As Integer) As Task(Of AlbumDTO) Implements IAlbumService.GetAlbumByIdFromDatabase
            Dim album = Await _albumRepository.GetAlbumById(id)
            Return If(album IsNot Nothing, AlbumMapper.MapToDTO(album), Nothing)
        End Function

        ' Buscar álbumes por título en la base de datos
        Public Async Function SearchAlbumsByTitleInDatabase(title As String) As Task(Of List(Of AlbumDTO)) Implements IAlbumService.SearchAlbumsByTitleInDatabase
            Dim albums = Await _albumRepository.GetAllAlbums()
            ' Filtra los álbumes por el título
            Dim filteredAlbums = albums.Where(Function(a) a.Title.ToLower().Contains(title.ToLower())).ToList()
            Return AlbumMapper.MapToDTOList(filteredAlbums)
        End Function

        ' Obtener todos los álbumes desde la API
        Public Async Function GetAlbumsFromAPI() As Task(Of List(Of AlbumDTO)) Implements IAlbumService.GetAlbumsFromAPI
            Dim albums = Await _albumRepository.GetAlbumsFromApi()
            Return AlbumMapper.MapToDTOList(albums)
        End Function

        ' Obtener un álbum por ID desde la API
        Public Async Function GetAlbumByIdFromAPI(id As Integer) As Task(Of AlbumDTO) Implements IAlbumService.GetAlbumByIdFromAPI
            Dim album = Await _albumRepository.GetAlbumByIdFromApi(id)
            Return If(album IsNot Nothing, AlbumMapper.MapToDTO(album), Nothing)
        End Function

        ' Buscar álbumes por título en la API
        Public Async Function SearchAlbumsByTitleInAPI(title As String) As Task(Of List(Of AlbumDTO)) Implements IAlbumService.SearchAlbumsByTitleInAPI
            Dim albums = Await _albumRepository.GetAlbumsFromApi()
            Dim filteredAlbums = albums.Where(Function(a) a.Title.ToLower().Contains(title.ToLower())).ToList()
            Return AlbumMapper.MapToDTOList(filteredAlbums)
        End Function
    End Class
End Namespace
