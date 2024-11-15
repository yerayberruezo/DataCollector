
Imports DataCollector.Business.DataCollector.Business.DTOs
Imports DataCollector.DataAccess

Namespace DataCollectorApp.Business.Mappers
    Public Class PhotoMapper
        ' Mapea una Photo a un PhotoDTO
        Public Shared Function MapToDTO(photo As Photo) As PhotoDTO
            Return New PhotoDTO With {
                .Id = photo.Id,
                .AlbumId = photo.AlbumId,
                .Title = photo.Title,
                .Url = photo.Url,
                .ThumbnailUrl = photo.ThumbnailUrl
            }
        End Function

        ' Mapea una lista de Photos a una lista de PhotoDTO
        Public Shared Function MapToDTOList(photos As List(Of Photo)) As List(Of PhotoDTO)
            Return photos.Select(Function(p) MapToDTO(p)).ToList()
        End Function
    End Class
End Namespace
