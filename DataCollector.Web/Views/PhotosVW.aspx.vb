Imports DataCollector.Business.DataCollector.Business.DTOs
Imports DataCollector.Business.DataCollector.Business.Services.Interfaces

Partial Public Class PhotosVW
    Inherits System.Web.UI.Page

    Private _photoService As IPhotoService

    ' Método que no es asincrónico pero llama al método asincrónico
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim albumId As Integer = Convert.ToInt32(Request.QueryString("albumId"))
            Dim fromApi As Boolean = Boolean.Parse(Request.QueryString("fromApi"))

            If fromApi Then
                SourceSelect.SelectedValue = "True"
            Else
                SourceSelect.SelectedValue = "False"
            End If

            _photoService = DependencyResolver.Resolve(Of IPhotoService)()
            LoadPhotos(albumId, fromApi)
        End If
    End Sub

    Protected Sub SourceSelect_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedValue As String = SourceSelect.SelectedValue
    End Sub


    ' Método asincrónico para cargar las fotos
    Private Async Sub LoadPhotos(albumId As Integer, fromApi As Boolean)
        Dim photos As List(Of PhotoDTO)

        If fromApi Then
            photos = Await _photoService.GetPhotosFromAPI()
        Else
            photos = Await _photoService.GetPhotosFromDatabase()
        End If

        Dim filteredPhotos = photos.Where(Function(p) p.AlbumId = albumId).ToList()
        Dim photoVMs = filteredPhotos.Select(Function(p) MapPhotoDTOtoVM(p)).ToList()

        PhotosRepeater.DataSource = photoVMs
        PhotosRepeater.DataBind()

        AlbumTitle.Text = "Album " & albumId
    End Sub

    ' Método de mapeo para convertir un DTO a un ViewModel
    Private Function MapPhotoDTOtoVM(photoDTO As PhotoDTO) As PhotoVM
        Return New PhotoVM With {
                .Id = photoDTO.Id,
                .Title = photoDTO.Title,
                .Url = photoDTO.Url
            }
    End Function
End Class
