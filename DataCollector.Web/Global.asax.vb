Imports Unity
Imports DataCollector.Business.DataCollector.Business.Services.Implementations
Imports DataCollector.Business.DataCollector.Business.Services.Interfaces
Imports DataCollector.DataAccess
Imports DataCollector.DataAccess.DataCollector.Business.Repositories
Imports DataCollector.Business.DataCollectorApp.Business.Services.Implementations

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        DependencyResolver.Initialize()
    End Sub
End Class
