Imports DataCollector.Business.DataCollector.Business.DTOs
Imports DataCollector.DataAccess
Namespace DataCollectorApp.Business.Mappers
    Public Class AlbumMapper
        ' Mapea un Album a un AlbumDTO
        Public Shared Function MapToDTO(album As Album) As AlbumDTO
            Return New AlbumDTO With {
                .Id = album.Id,
                .UserId = album.UserId,
                .Title = album.Title
            }
        End Function

        ' Mapea una lista de Albums a una lista de AlbumDTO
        Public Shared Function MapToDTOList(albums As List(Of Album)) As List(Of AlbumDTO)
            Return albums.Select(Function(a) MapToDTO(a)).ToList()
        End Function
    End Class
End Namespace
