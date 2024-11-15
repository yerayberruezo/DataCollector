Imports DataCollector.Business.DataCollector.Business.Services.Implementations
Imports DataCollector.Business.DataCollector.Business.Services.Interfaces
Imports DataCollector.Business.DataCollectorApp.Business.Services.Implementations
Imports DataCollector.DataAccess
Imports DataCollector.DataAccess.DataCollector.Business.Repositories
Imports Unity
Imports Unity.Lifetime

Public Class DependencyResolver

    Private Shared _container As UnityContainer

    Public Shared Sub Initialize()
        If _container Is Nothing Then
            _container = New UnityContainer()

            _container.RegisterType(Of IAlbumService, AlbumService)()
            _container.RegisterType(Of IPhotoService, PhotoService)()
            _container.RegisterType(Of IAlbumRepository, AlbumRepository)()
            _container.RegisterType(Of IPhotoRepository, PhotoRepository)()


        End If
    End Sub

    Public Shared Function GetContainer() As UnityContainer
        Return _container
    End Function
    Public Shared Function Resolve(Of T)() As T
        Return _container.Resolve(Of T)()
    End Function
End Class
