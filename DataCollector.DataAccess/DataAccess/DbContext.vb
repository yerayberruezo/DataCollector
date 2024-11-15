Imports System.Configuration
Imports System.Data.Entity

Public Class DataContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=ConnectionStringDB")
    End Sub


    Public Property Albums As DbSet(Of Album)
    Public Property Photos As DbSet(Of Photo)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
    End Sub
End Class
