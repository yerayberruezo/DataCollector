Imports DataCollector.Business.DataCollector.Business.DTOs
Imports DataCollector.Business.DataCollector.Business.Services.Interfaces
Imports System.Threading.Tasks

Partial Public Class AlbumsVW
    Inherits System.Web.UI.Page

    Private _albumService As IAlbumService

    Protected Async Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If _albumService Is Nothing Then
                _albumService = DependencyResolver.Resolve(Of IAlbumService)()
            End If
            Await LoadAlbums()
        End If
    End Sub

    ' Método para cargar los álbumes según la opción seleccionada
    Private Async Function LoadAlbums() As Task
        Dim fromApi As Boolean = Boolean.Parse(SourceSelect.SelectedValue)
        Dim albums As List(Of AlbumDTO)

        If _albumService Is Nothing Then
            _albumService = DependencyResolver.Resolve(Of IAlbumService)()
        End If

        If fromApi Then
            albums = Await _albumService.GetAlbumsFromAPI()
        Else
            albums = Await _albumService.GetAlbumsFromDatabase()
        End If

        ViewState("Albums") = albums
        ApplyTitleFilter(albums)
        BindAlbums(albums)
    End Function

    ' Método para aplicar el filtro por título
    Private Sub ApplyTitleFilter(ByRef albums As List(Of AlbumDTO))
        Dim titleFilterText As String = titleFilter.Text.Trim().ToLower()
        If Not String.IsNullOrEmpty(titleFilterText) Then
            albums = albums.Where(Function(a) a.Title.ToLower().Contains(titleFilterText)).ToList()
        End If
    End Sub

    ' Método para enlazar los álbumes al Repeater
    Private Sub BindAlbums(albums As List(Of AlbumDTO))
        Dim albumVMs = albums.Select(Function(a) MapAlbumDTOtoVM(a)).ToList()
        AlbumsRepeater.DataSource = albumVMs
        AlbumsRepeater.DataBind()
    End Sub

    ' Método para mapear un DTO a un ViewModel
    Private Function MapAlbumDTOtoVM(albumDTO As AlbumDTO) As AlbumVM
        Return New AlbumVM With {
            .Id = albumDTO.Id,
            .Title = albumDTO.Title
        }
    End Function

    ' Evento cuando cambia la fuente seleccionada (API o Base de Datos)
    Protected Async Sub SourceSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SourceSelect.SelectedIndexChanged
        Await LoadAlbums()
    End Sub

    Protected Sub FilterAlbums(sender As Object, e As EventArgs)
        ' Obtener la lista de álbumes de ViewState
        Dim albums As List(Of AlbumDTO) = CType(ViewState("Albums"), List(Of AlbumDTO))

        If albums IsNot Nothing Then
            ApplyTitleFilter(albums)
            BindAlbums(albums)
        End If
    End Sub

    ' Evento cuando el usuario hace clic en un álbum
    Protected Sub Album_Click(sender As Object, e As EventArgs)
        Dim albumId As Integer = Convert.ToInt32((CType(sender, LinkButton)).CommandArgument)
        Dim fromApi As Boolean = Boolean.Parse(SourceSelect.SelectedValue)

        Response.Redirect($"PhotosVW.aspx?albumId={albumId}&fromApi={fromApi}")
    End Sub

    ' Evento de enlace para establecer el CommandArgument
    Protected Sub AlbumsRepeater_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles AlbumsRepeater.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim albumId As Integer = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Id"))
            Dim albumLink As LinkButton = CType(e.Item.FindControl("AlbumLink"), LinkButton)
            If albumLink IsNot Nothing Then
                albumLink.CommandArgument = albumId.ToString()
            End If
        End If
    End Sub
End Class
