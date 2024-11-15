
Public Interface IAlbumRepository
    ' Métodos para obtener los álbumes desde la base de datos
    Function GetAllAlbums() As Task(Of List(Of Album))
    Function GetAlbumById(id As Integer) As Task(Of Album)

    ' Métodos para obtener los álbumes desde la API externa
    Function GetAlbumsFromApi() As Task(Of List(Of Album))
    Function GetAlbumByIdFromApi(id As Integer) As Task(Of Album)
End Interface
