Solución: DataCollector
DataCollector.DataAccess: Proyecto que se encarga únicamente del acceso a los datos, por parte de la API utilizo (APIClient) y por parte a SQL Server utilizo Entity Framework con (DbContext.vb). 
DataCollector.Business: Proyecto que se encarga de la capa de negocio, actúa como capa intermedia y hace las consultas sobre AlbumRepository y PhotoRepository (de DataAccess).
DataCollector.Web: Hago las consultas sobre AlbumService y PhotoService (de Business), por parte de la vista tengo /Views/AlbumsVW.aspx, desde aquí puedo navegar a las Fotos. 
Notas: Modificar la connection string en Web.config de DataCollector.Web para acceso a la BD.
Base de datos:

CREATE DATABASE DataCollectorDb;
GO
CREATE TABLE Albums (
    Id INT PRIMARY KEY IDENTITY(1,1),  -- El campo Id será autoincremental
    Title NVARCHAR(255) NOT NULL,
    UserId INT NOT NULL
);
GO
CREATE TABLE Photos (
    Id INT PRIMARY KEY IDENTITY(1,1),  -- El campo Id será autoincremental
    AlbumId INT NOT NULL,  -- Relación con la tabla Albums
    Title NVARCHAR(255) NOT NULL,
    Url NVARCHAR(255) NOT NULL,
    ThumbnailUrl NVARCHAR(255) NOT NULL,
    FOREIGN KEY (AlbumId) REFERENCES Albums(Id)  -- Establecemos la relación entre Photos y Albums
);
GO

