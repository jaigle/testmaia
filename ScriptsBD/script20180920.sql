USE [master]
GO
/****** Object:  Database [BD1]    Script Date: 09/20/2018 01:01:55 ******/
CREATE DATABASE [BD1] ON  PRIMARY 
( NAME = N'BD1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\BD1.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BD1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\BD1_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BD1] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD1] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BD1] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BD1] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BD1] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BD1] SET ARITHABORT OFF
GO
ALTER DATABASE [BD1] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BD1] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BD1] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BD1] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BD1] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BD1] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BD1] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BD1] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BD1] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BD1] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BD1] SET  DISABLE_BROKER
GO
ALTER DATABASE [BD1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BD1] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BD1] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BD1] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BD1] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BD1] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BD1] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BD1] SET  READ_WRITE
GO
ALTER DATABASE [BD1] SET RECOVERY FULL
GO
ALTER DATABASE [BD1] SET  MULTI_USER
GO
ALTER DATABASE [BD1] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BD1] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD1', N'ON'
GO
USE [BD1]
GO
/****** Object:  UserDefinedFunction [dbo].[CSVToList]    Script Date: 09/20/2018 01:01:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[CSVToList] (@CSV varchar(3000)) 
    RETURNS @Result TABLE (Value varchar(30))
AS   
BEGIN
    DECLARE @List TABLE
    (
        Value varchar(30)
    )

    DECLARE
        @Value varchar(30),
        @Pos int

    SET @CSV = LTRIM(RTRIM(@CSV))+ ','
    SET @Pos = CHARINDEX(',', @CSV, 1)

    IF REPLACE(@CSV, ',', '') <> ''
    BEGIN
        WHILE @Pos > 0
        BEGIN
            SET @Value = LTRIM(RTRIM(LEFT(@CSV, @Pos - 1)))

            IF @Value <> ''
                INSERT INTO @List (Value) VALUES (@Value) 

            SET @CSV = RIGHT(@CSV, LEN(@CSV) - @Pos)
            SET @Pos = CHARINDEX(',', @CSV, 1)
        END
    END     

    INSERT @Result
    SELECT
        Value
    FROM
        @List

    RETURN
END
GO
/****** Object:  Table [dbo].[MA_ModalidadComponente]    Script Date: 09/20/2018 01:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MA_ModalidadComponente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[CodigoInterno] [varchar](50) NOT NULL,
	[Orden] [int] NOT NULL,
 CONSTRAINT [PK_MA_ModalidadComponente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MA_Malla]    Script Date: 09/20/2018 01:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MA_Malla](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[Activo] [bit] NOT NULL,
	[UsuarioCreacion] [varchar](5) NULL,
	[CantVersiones] [int] NOT NULL,
	[IdEscuela] [int] NOT NULL,
 CONSTRAINT [PK_MA_Malla] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MA_TipoNotificacion]    Script Date: 09/20/2018 01:01:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MA_TipoNotificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[CodigoInterno] [varchar](150) NOT NULL,
 CONSTRAINT [PK_MA_TipoNotificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Personas]    Script Date: 09/20/2018 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Personas]
AS
SELECT     Id, IdentificacionUnica, Dv, Nombre, ApellidoPaterno, ApellidoMaterno, Email, IdCodigoArea, Fono, Celular, IdConexion, ClaveSence, Activo, ConectaSENCE, Instructor
FROM         HCMCH.dbo.Personas
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Personas (HCMCH.dbo)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Personas'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Personas'
GO
/****** Object:  Table [dbo].[MA_Version]    Script Date: 09/20/2018 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MA_Version](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[IdMalla] [int] NOT NULL,
	[Version] [varchar](50) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaTermino] [datetime] NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_MA_Version] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[CatalogoCurso]    Script Date: 09/20/2018 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CatalogoCurso]
AS
SELECT     Id, Codigo, Nombre, IdModalidad, Duracion, HorasSalas, HorasOnLine, IdTematica, AprobacionMinima, AsistenciaMinima, AceptaListaEspera, FechaCreacion, FechaModificacion, IdSociedad, 
                      IdScorm, DescripcionContenidoCentral, Vigente, CodigoErp, IdTipoDiploma, IdValidezDiploma, Activo, Imagen
FROM         HCMCH.dbo.CatalogoCurso
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CatalogoCurso (HCMCH.dbo)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CatalogoCurso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CatalogoCurso'
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ActualizarMalla]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ActualizarMalla]
@IdMalla int,
@NombreMalla VARCHAR(150),
@DescripcionMalla VARCHAR(200),
@ActivoMalla VARCHAR(1),
@IdEscuela INT
as 
begin
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
		 update MA_Malla
		 set Nombre = @NombreMalla,
			Descripcion = @DescripcionMalla,
			Activo = @ActivoMalla,
			IdEscuela = @IdEscuela
		 where Id = @IdMalla
		commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  View [dbo].[Capacitacion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Capacitacion]
AS
SELECT     Id, IdPersona, NombreEvento, FechaInicio, FechaTermino, PorcentajeAsistencia, PorcentajeEvaluacion, IdModalidad, IdSociedad, HorasToles, IdSituacion, IdEvento, Activo, Vigencia, IdDocumento, 
                      IdModoObtencion, UsuarioRegistro, IdUnidadCurricular, AcreditaUnidadCurricular, AcreditaCompetencia
FROM         HCMCH.dbo.Capacitacion
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Capacitacion (HCMCH.dbo)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Capacitacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Capacitacion'
GO
/****** Object:  Table [dbo].[MA_Certificado]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MA_Certificado](
	[Id] [int] NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[RutaLogo] [varchar](250) NULL,
	[RutaCertificado] [varchar](250) NULL,
	[RutaFirma] [varchar](250) NULL,
	[Encabezado] [varchar](250) NULL,
	[Cuerpo] [varchar](250) NULL,
	[EncabezadoListaUC] [varchar](250) NULL,
 CONSTRAINT [Unq_MA_Certificado_Id] UNIQUE NONCLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Escuela]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Escuela]
AS
SELECT     Id, Nombre, UsuarioCr, FechaCr, UsuarioUp, FechaUp, Activo
FROM         HCMCH.dbo.Escuela
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Escuela (HCMCH.dbo)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Escuela'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Escuela'
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerListadoModalidadComponente]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerListadoModalidadComponente]
AS
BEGIN	
SET NOCOUNT ON

select Id,
		Nombre
from MA_ModalidadComponente

End
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerMallaCertificado]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerMallaCertificado]
@IdMalla Int, @IdSociedad int
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			SELECT C.Id,C.IdSociedad,C.Cuerpo,C.Encabezado,C.EncabezadoListaUC,C.RutaCertificado,C.RutaFirma,C.RutaLogo
			FROM MA_Certificado AS C
			WHERE C.Id = @IdMalla AND C.IdSociedad = @IdSociedad
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_GuardarMalla]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESB_MA_GuardarMalla]
				@IdSociedad INT,				
				@NombreMalla VARCHAR(150),
				@DescripcionMalla VARCHAR(200),
				@ActivoMalla BIT = 1,
				@UsuarioCreacion VARCHAR(5),		
				@IdEscuela INT
AS
begin
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
		
		INSERT INTO MA_Malla
		(				
			IdSociedad,
			FechaCreacion,
			Nombre,
			Descripcion,
			Activo,
			usuarioCreacion,
			CantVersiones		
		)
		VALUES
		(
			@IdSociedad,GETDATE(),@NombreMalla,@DescripcionMalla,@ActivoMalla,@UsuarioCreacion,0		
		)	
				 
		INSERT INTO [MA_Certificado]
           ([Id]
           ,[IdSociedad]
           ,[RutaLogo]
           ,[RutaCertificado]
           ,[RutaFirma]
           ,[Encabezado]
           ,[Cuerpo]
           ,[EncabezadoListaUC])
     VALUES
           (IDENT_CURRENT('MA_Malla'),@IdSociedad,'','','',
           'Se otorga el presente certificado a',
           'por haber aprobado la malla curricular,',
           'A continuación se detalla el resultado del colaborador en cada una de las UC cursadas:')
		commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerEscuelas]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESB_MA_ObtenerEscuelas] 
	@IdSociedad int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT id,nombre from Escuela where (@IdSociedad = 0) --OR IdSociedad = @IdSociedad
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_GuardarVersion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_GuardarVersion]
@IdMalla Int, @IdSociedad int, @FechaInicio varchar(10)
AS
BEGIN	
DECLARE @numVersion int, @fecha datetime
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			set @numVersion = (select CantVersiones from MA_Malla where Id = @IdMalla)+1
			set @fecha = convert(datetime, @FechaInicio, 111)
			INSERT INTO MA_Version
			(				
				IdSociedad,
				IdMalla,
				Version,
				FechaInicio,
				Activo	
			)
			VALUES
			(
				@IdSociedad,
				@IdMalla,
				@numVersion,
				@fecha,
				0	
			)
			update MA_Malla	set CantVersiones = @numVersion where Id = @IdMalla
			
			update MA_Version 
			set FechaTermino = @fecha - 1
			where FechaTermino is null and Version <> @numVersion
		commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ActualizarCertificado]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ActualizarCertificado]
@IdMalla int,
@IdSociedad int,
@RutaLogo varchar(250),
@RutaCertificado varchar(250),
@RutaFirma varchar(250)
as 
BEGIN
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
		 IF (@RutaLogo <> '')
		 BEGIN
			UPDATE [MA_Certificado]
			SET [RutaLogo] = @RutaLogo
			WHERE Id = @IdMalla AND IdSociedad = @IdSociedad
		 END
		 IF (@RutaCertificado <> '')
		 BEGIN
			UPDATE [MA_Certificado]
			SET RutaCertificado = @RutaCertificado
			WHERE Id = @IdMalla AND IdSociedad = @IdSociedad
		 END
		 IF (@RutaFirma <> '')
		 BEGIN
			UPDATE [MA_Certificado]
			SET RutaFirma = @RutaFirma
			WHERE Id = @IdMalla AND IdSociedad = @IdSociedad
		 END	 
		commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  Table [dbo].[MA_Seccion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MA_Seccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[IdVersion] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Color] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MA_Seccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MA_Itinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MA_Itinerario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[IdVersion] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaTermino] [datetime] NOT NULL,
	[CantUCTotal] [int] NULL,
	[ACtivo] [bit] NOT NULL,
	[AvanUC] [int] NOT NULL,
	[AvanColab] [int] NOT NULL,
 CONSTRAINT [PK_MA_Itinerario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [Unq_MA_Itinerario_Id] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MA_ItinerarioTipoNotificacion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MA_ItinerarioTipoNotificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[IdItinerario] [int] NOT NULL,
	[IdTipoNotificacion] [int] NOT NULL,
 CONSTRAINT [PK_MA_ItinerarioTipoNotificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ActualizarItinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ActualizarItinerario]
				@IdItinerario INT,
				@IdSociedad INT,				
				@Nombre VARCHAR(150),
				@IdMalla int,
				@FechaInicio datetime,
				@FechaTermino datetime,
				@Activo bit
as 
BEGIN
SET NOCOUNT ON
	DECLARE @IdVersion int,@IdVersionAnterior int
	SET @IdVersionAnterior = (select Id from MA_Itinerario where Id = @IdItinerario AND IdSociedad = @IdSociedad AND Activo = 1)
	SET @IdVersion = (select Id from MA_Version where IdMalla = @IdMalla AND IdSociedad = @IdSociedad AND Activo = 1)
	BEGIN TRY
		BEGIN TRAN
		 UPDATE [MA_Itinerario]
			SET Nombre = @Nombre ,[FechaInicio] = @FechaInicio, [FechaTermino] =  @FechaTermino,[ACtivo] = @Activo
			WHERE [IdSociedad] = @IdSociedad AND [Id] = @IdItinerario
		IF (@IdMalla is not null)
		BEGIN
			IF (@IdVersionAnterior <> @IdVersion)
			BEGIN
			UPDATE [MA_Itinerario]
			SET IdVersion = @IdVersion
			WHERE [IdSociedad] = @IdSociedad AND [Id] = @IdItinerario
			--Llamar a actualizar todo el listado
			END
		END
		commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_GuardarSeccion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ESB_MA_GuardarSeccion]
@IdSociedad Int, @IdVersion Int, 
@nombreSeccion varchar(100), @colorSeccion varchar(100)
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			insert into MA_Seccion
			(IdSociedad,
			IdVersion,
			Nombre,
			Color)
			values
			(@IdSociedad,
			@IdVersion,
			@nombreSeccion,
			@colorSeccion)
			commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ActualizarSeccion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ESB_MA_ActualizarSeccion]
@idSeccion Int,@idSociedad Int, @nombreSeccion varchar(100), @colorSeccion varchar(100)
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			update MA_Seccion
			 set Nombre = @nombreSeccion,
			     Color = @colorSeccion
			where Id = @idSeccion AND IdSociedad = @IdSociedad
			commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_EliminarSeccion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_EliminarSeccion]
@idSeccion Int, @IdSociedad int
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			delete from MA_Seccion where Id = @idSeccion and IdSociedad = @IdSociedad
			commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  Table [dbo].[MA_Componente]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MA_Componente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[IdSeccion] [int] NOT NULL,
	[IdModalidadComponente] [int] NOT NULL,
	[IdUnidadCurricular] [int] NOT NULL,
 CONSTRAINT [PK_MA_Componente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[MA_ActualizarEstadoVersiones]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MA_ActualizarEstadoVersiones]
AS
BEGIN
	declare @fecha date
	set @fecha = getdate()
	update MA_Version set Activo = 1 where (FechaInicio < @fecha AND (FechaTermino > @fecha OR FechaTermino is null))
	and Activo = 0
	
	update MA_Version set Activo = 0 where (FechaInicio > @fecha OR FechaTermino < @fecha)
	and Activo = 1

	update MA_Itinerario set ACtivo = 1 where (FechaInicio < @fecha AND FechaTermino > @fecha)
	and Activo = 0

	update MA_Itinerario set ACtivo = 0 where (FechaInicio > @fecha OR FechaTermino < @fecha) and ACtivo = 1
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerListadoMalla]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerListadoMalla]
@IdSociedad int,
@Nombre varchar(255),
@Escuela varchar(255),
@SoloActivas bit = 0
AS
BEGIN	
SET NOCOUNT ON

	select	M.Id,
			IdSociedad,
			E.Nombre as Escuela,
			FechaCreacion,
			M.Nombre,
			Descripcion,
			M.Activo,
			UsuarioCreacion,
			CantVersiones,
			(select COUNT(1) from MA_Itinerario I inner join MA_Version V on I.IdVersion = V.Id where V.IdMalla = M.Id) as ItinerariosTotal,
			(select COUNT(1) from MA_Itinerario I inner join MA_Version V on I.IdVersion = V.Id where V.IdMalla = M.Id and I.ACtivo = 1) as ItinerariosActivos
	from	MA_Malla as M
	LEFT JOIN HCMCH.dbo.Escuela E on M.IdEscuela = E.Id
	where	IdSociedad = @IdSociedad 
	AND (@Nombre = '' OR M.Nombre like '%'+@Nombre+'%')
	AND (@Escuela = '' OR E.Nombre like '%'+@Escuela+'%')
	AND (@SoloActivas = 0  OR M.Activo = 1)
end
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerListadoSeccion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ESB_MA_ObtenerListadoSeccion]
 @IdVersion int
 AS
BEGIN	
SET NOCOUNT ON

select  Id,
		IdSociedad,
		IdVersion,
		Nombre,
		Color
from MA_Seccion
where IdVersion = @IdVersion
End
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerSeccion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerSeccion]
@Id int
AS
BEGIN	
SET NOCOUNT ON
	select Id,
		   IdSociedad,
		   IdVersion,
		   Nombre,
		   Color
	from MA_Seccion
	where Id = @Id
END
GO
/****** Object:  Table [dbo].[MA_Nomina]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MA_Nomina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[IdItinerario] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Activo] [bit] NULL,
	[Finalizada] [bit] NOT NULL,
	[FechaInscripcion] [time](7) NOT NULL,
	[IdPersonaCreacion] [varchar](50) NOT NULL,
	[CantUCCompletas] [int] NOT NULL,
	[CantUCEnCurso] [int] NOT NULL,
	[CantUCAprobadas] [int] NULL,
	[CantUCReprobadas] [int] NOT NULL,
 CONSTRAINT [PK_MA_Audiencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [Unq_MA_Audiencia_Id] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ActualizarComponente]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ESB_MA_ActualizarComponente] 
@Id int, 
@IdSeccion int, 
@IdModalidadComponente int
AS
BEGIN	

SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
		update MA_Componente set
			IdSeccion = @IdSeccion,
			IdModalidadComponente = @IdModalidadComponente
		where Id = @Id
		commit tran
END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerNotificacionItinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerNotificacionItinerario]
@idItinerario Int, @IdSociedad int
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			SELECT IT.Id, T.CodigoInterno as Codigo, T.Nombre, 1 AS Seleccionado 
			FROM MA_ItinerarioTipoNotificacion IT
			INNER JOIN MA_TipoNotificacion T ON IT.IdTipoNotificacion = T.Id AND IT.IdSociedad = T.IdSociedad
			UNION ALL
			SELECT IT.Id, T.CodigoInterno as Codigo, T.Nombre, 0 AS Seleccionado 
			FROM MA_ItinerarioTipoNotificacion IT
			RIGHT JOIN MA_TipoNotificacion T ON IT.IdTipoNotificacion = T.Id AND IT.IdSociedad = T.IdSociedad			
			WHERE IT.Id IS NULL
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerMallaCertificadoVistaPreviaCursos]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerMallaCertificadoVistaPreviaCursos]
@IdMalla Int, @IdSociedad int
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			SELECT Uc.Id as IdMallaUnidadCurr, e.Nombre AS NombreUnidadCurricular,
			'100' as Evaluacion, 'Aprobado' as SituacionFinal, M.Nombre as NombreMalla,
			m.Activo as Estado
			FROM MA_Malla AS M
			inner join MA_Certificado AS C on C.Id = M.Id and c.IdSociedad = M.IdSociedad
			INNER JOIN MA_Version V ON C.Id = V.IdMalla AND C.IdSociedad = V.IdSociedad
			INNER JOIN MA_Seccion S ON S.IdVersion = V.Id AND S.IdSociedad = V.IdSociedad
			INNER JOIN MA_Componente UC ON UC.IdSeccion = S.Id AND UC.IdSociedad = S.IdSociedad
			INNER JOIN MA_ModalidadComponente MC ON UC.IdModalidadComponente = MC.Id AND UC.IdSociedad = MC.IdSociedad 
			inner join CatalogoCurso e on UC.IdUnidadCurricular = e.Id
			WHERE M.Id = @IdMalla AND C.IdSociedad = @IdSociedad
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END

select top 5 * from CatalogoCurso
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerListadoVersion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerListadoVersion]
@IdMalla int,
@IdSociedad int
AS
BEGIN	
SET NOCOUNT ON
  select Id,
		IdSociedad,
		IdMalla,
		Version,
		Convert(varchar(10), FechaInicio,103)+'-'+coalesce((Convert(varchar(15), FechaTermino,103)),'') as Vigencia,
		(select COUNT(*) from MA_Componente c 
		inner join MA_Seccion b on c.IdSeccion = b.Id and c.IdSociedad = b.IdSociedad
		where b.IdVersion = V.Id) as UC,
		Estado = case Activo WHEN 1 then 'Activa' ELSE 'No Activa' END		
  from MA_Version V
  where V.IdMalla = @IdMalla and V.IdSociedad = @IdSociedad
  
 End
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerListadoNomina]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ESB_MA_ObtenerListadoNomina]
@IdItinerario int,
@IdSociedad int
AS
BEGIN	
SET NOCOUNT ON
	DECLARE @TotalUC int
	SET @TotalUC = (select CantUCTotal from MA_Itinerario where Id = @IdItinerario AND IdSociedad = @IdSociedad)
	select N.IdPersona, (P.IdentificacionUnica+'-'+P.Dv) Rut
	,(P.Nombre + ' '+ P.ApellidoPaterno + ' ' + P.ApellidoMaterno) as [NombreCompleto]
	, N.FechaInscripcion Asignacion
	, (N.CantUCAprobadas/@TotalUC * 100) Avance
	from MA_Nomina N
	inner join HCMCH.dbo.Personas P on N.IdPersona = P.Id
	where N.IdItinerario = @IdItinerario AND N.IdSociedad = @IdSociedad	and N.Activo = 1 

END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_EliminarComponente]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ESB_MA_EliminarComponente] 
@Id int
AS
BEGIN	

SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
		delete from MA_Componente
		where Id = @Id
		commit tran
END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_AgregarNotificacionItinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_AgregarNotificacionItinerario]
@idItinerario Int, @IdSociedad int, @Lista varchar(MAX)
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			DELETE FROM MA_ItinerarioTipoNotificacion
			where IdItinerario = @idItinerario AND IdSociedad = @IdSociedad
		
			INSERT INTO [BD1].[dbo].[MA_ItinerarioTipoNotificacion]
           ([IdSociedad]
           ,[IdItinerario]
           ,[IdTipoNotificacion])
			SELECT @IdSociedad,@idItinerario,Value
			FROM dbo.CSVToLIst(@Lista) as A
			INNER JOIN MA_TipoNotificacion T on T.Id = A.Value AND T.IdSociedad = @IdSociedad
			
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerComponente]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerComponente]
@Id int
AS
BEGIN	
SET NOCOUNT ON
	select	Id,
			IdSeccion,
			IdModalidadComponente,
			IdUnidadCurricular
	from MA_Componente
	where Id = 	@Id
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_GuardarItinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESB_MA_GuardarItinerario]
				@IdSociedad INT,				
				@IdMalla INT,
				@Nombre VARCHAR(150),
				@FechaInicio datetime,
				@FechaTermino datetime
AS
begin
SET NOCOUNT ON
	DECLARE @IdVersion int,@IdVersionAnterior int
	SET @IdVersion = (select Id from MA_Version where IdMalla = @IdMalla AND IdSociedad = @IdSociedad AND Activo = 1)
	BEGIN TRY
		BEGIN TRAN
		INSERT INTO [BD1].[dbo].[MA_Itinerario]
           ([IdSociedad]
           ,[IdVersion]
           ,[Nombre]
           ,[FechaInicio]
           ,[FechaTermino]
           ,[CantUCTotal]
           ,[ACtivo])
     VALUES
           (@IdSociedad
           ,@IdVersion
           ,@Nombre
           ,@FechaInicio
           ,@FechaTermino
           ,(select COUNT(1) as CantUC from MA_Seccion S inner join MA_Componente C on C.IdSeccion = C.IdSeccion AND C.IdSociedad = S.IdSociedad where IdVersion = @IdVersion and C.IdSociedad = @IdSociedad)
           ,1)
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_GuardarComponente]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_GuardarComponente] 
@IdSociedad int, @IdSeccion int, 
@IdModalidadComponente int, @IdUnidadCurricular int
AS
BEGIN	
DECLARE @a int
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
		INSERT INTO MA_Componente
			(				
				IdSociedad,
				IdSeccion,
				IdModalidadComponente,
				IdUnidadCurricular	
			)
			VALUES
			(
				@IdSociedad,
				@IdSeccion,
				@IdModalidadComponente,
				@IdUnidadCurricular	
			)	
		commit tran
END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_getListadoItinerariosHistoricos]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_getListadoItinerariosHistoricos]
 @IdPersona int, @IdSociedad INT
 AS
BEGIN	
SET NOCOUNT ON
select I.Nombre as Itinerario, M.Nombre Malla, COALESCE(E.nombre, 'Sin Escuela') as Escuela, i.AvanUC as Avance  
from MA_Itinerario I
inner join MA_Nomina N on N.IdItinerario = I.Id and N.IdSociedad = I.IdSociedad AND N.Activo = 0
inner join MA_Version V on I.IdVersion = V.Id AND I.IdSociedad = V.IdSociedad
inner join MA_Malla M on m.Id = V.IdMalla and M.IdSociedad = V.IdSociedad
left join Escuela E on M.IdEscuela = E.id
where I.ACtivo = 1 AND M.Activo = 1 AND N.IdPersona = @IdPersona and N.IdSociedad = @IdSociedad
End
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_getListadoItinerariosActivos]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_getListadoItinerariosActivos]
 @IdPersona int, @IdSociedad INT
 AS
BEGIN	
SET NOCOUNT ON
select I.Nombre as Itinerario, M.Nombre Malla, COALESCE(E.nombre, 'Sin Escuela') as Escuela, i.AvanUC as Avance  
from MA_Itinerario I
inner join MA_Nomina N on N.IdItinerario = I.Id and N.IdSociedad = I.IdSociedad AND N.Activo = 1
inner join MA_Version V on I.IdVersion = V.Id AND I.IdSociedad = V.IdSociedad
inner join MA_Malla M on m.Id = V.IdMalla and M.IdSociedad = V.IdSociedad
left join Escuela E on M.IdEscuela = E.id
where I.ACtivo = 1 AND M.Activo = 1 AND N.IdPersona = @IdPersona and N.IdSociedad = @IdSociedad
End
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ActualizarAvanceItinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ActualizarAvanceItinerario]
 @IdItinerario int, @IdSociedad INT
 AS
BEGIN	
DECLARE @totalUC int, @totalNomina int, @totalUCAprobadas int,@totalNominaCompletos int, @AvanceUC int, @AvanceColab int
SET @totalUC = (select CantUCTotal from MA_Itinerario where Id = @IdItinerario AND IdSociedad = @IdSociedad)
SET @totalNomina = (select COUNT(1) from MA_Nomina where IdItinerario = @IdItinerario AND IdSociedad = @IdSociedad AND Activo = 1)
SET @totalUCAprobadas = (select SUM(CantUCAprobadas) from MA_Nomina where IdItinerario = @IdItinerario AND IdSociedad = @IdSociedad AND Activo = 1)
SET @totalNominaCompletos = (select COUNT(1) from MA_Nomina where IdItinerario = @IdItinerario AND IdSociedad = @IdSociedad AND Activo = 1 AND CantUCAprobadas = @totalUC)

SET @AvanceUC = ROUND( (@totalUCAprobadas* 100 /((@totalUC * @totalNomina))),0)
SET @AvanceColab = ROUND(((@totalNominaCompletos * 100 /@totalNomina)),0)


SET NOCOUNT ON
BEGIN TRY
		BEGIN TRAN
			UPDATE MA_Itinerario
			SET AvanUC = @AvanceUC, AvanColab = @AvanceColab
			WHERE Id = @IdItinerario AND IdSociedad = @IdSociedad
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  Table [dbo].[MA_DetalleNOmina]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MA_DetalleNOmina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[IdNomina] [int] NOT NULL,
	[IdUc] [int] NOT NULL,
	[IdCapacitacion] [int] NOT NULL,
	[IdSituacionFinal] [int] NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [Pk_MA_DetalleAudiencia_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Idx_MA_DetalleAudiencia_IdAudiencia] ON [dbo].[MA_DetalleNOmina] 
(
	[IdNomina] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha en la que es registrado en el itinerario el resultado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MA_DetalleNOmina', @level2type=N'COLUMN',@level2name=N'FechaActualizacion'
GO
/****** Object:  StoredProcedure [dbo].[MA_CopiarEstructuraVersion]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MA_CopiarEstructuraVersion]
	@IdVersionOrigen int, 
	@IdVersionDestino int,
	@IdSociedad int
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			
			INSERT INTO [MA_Seccion]
     		select @IdSociedad,@IdVersionDestino,S.Nombre,S.Color
     		from MA_Seccion as S where IdVersion = @IdVersionOrigen and IdSociedad = @IdSociedad


			INSERT INTO [MA_Componente]
           ([IdSociedad]
           ,[IdSeccion]
           ,[IdModalidadComponente]
           ,[IdUnidadCurricular])
			select @IdSociedad,C.IdSeccion,C.IdModalidadComponente,c.IdUnidadCurricular 
			from MA_Componente as C 
			inner join MA_Seccion as S on C.IdSeccion = S.Id AND C.IdSociedad = S.IdSociedad
			inner join MA_Seccion as SNueva on SNueva.Nombre = S.Nombre and S.IdSociedad = SNueva.IdSociedad
			where C.IdSociedad = @IdSociedad
			and C.IdSeccion in (select Id from MA_Seccion where IdVersion = @IdVersionOrigen and IdSociedad = @IdSociedad)
					
		commit tran
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  Table [dbo].[MA_Prerrequisito]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MA_Prerrequisito](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSociedad] [int] NOT NULL,
	[IdComponente] [int] NOT NULL,
	[IdComponenteRequisito] [int] NOT NULL,
 CONSTRAINT [PK_MA_Prerrequisito] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[IdSociedad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[MA_ObtenerListaPrerrequisitos]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[MA_ObtenerListaPrerrequisitos](@IdComponente int, @IdSociedad int) 
RETURNS VARCHAR(MAX) 
AS 
BEGIN 
   
	DECLARE @uc varchar(200)
	SET @uc = NULL

	SELECT @uc = COALESCE(@uc + ',','') + Cat.Codigo
	FROM MA_Componente C
	inner join MA_Prerrequisito P on C.Id = P.IdComponente and P.IdSociedad = C.IdSociedad
	inner join MA_Componente CP on P.IdComponenteRequisito = CP.Id and P.IdSociedad = CP.IdSociedad
	inner join CatalogoCurso Cat on CP.IdUnidadCurricular = Cat.Id
   
   RETURN @uc 
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ActualizarDetalleColaborador]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ESB_MA_ActualizarDetalleColaborador](
	@IdItinerario INT = 0,
	@IdSociedad INT,
	@Lista VARCHAR(MAX) --CSV Ids
)
AS
BEGIN
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			  BEGIN
			  --INSERTAR LOS QUE NO ESTABAN
				INSERT INTO [dbo].[MA_DetalleNOmina]
				   ([IdSociedad],[IdNomina],[IdUc],[IdCapacitacion],[IdSituacionFinal],[FechaActualizacion])
				SELECT N.IdSociedad,N.Id,Cap.IdUnidadCurricular, Cap.Id,Cap.IdSituacion, GETDATE()
				FROM [MA_DetalleNOmina] DN 
				RIGHT JOIN MA_Nomina N ON DN.IdNomina = N.Id AND DN.IdSociedad = N.IdSociedad
				INNER JOIN dbo.CSVToLIst(@Lista) as A ON A.Value = N.IdPersona AND N.IdSociedad = @IdSociedad
				INNER JOIN MA_Itinerario I ON N.IdItinerario = I.Id AND N.IdSociedad = I.IdSociedad
				INNER JOIN MA_Version V ON I.IdVersion = V.Id AND V.IdSociedad = I.IdSociedad
				INNER JOIN MA_Malla M ON V.IdMalla = M.Id AND V.IdSociedad = M.IdSociedad
				INNER JOIN MA_Seccion S ON V.Id = S.IdVersion AND S.IdSociedad = V.IdSociedad
				INNER JOIN MA_Componente C ON C.IdSeccion = S.Id  AND C.IdSociedad = S.IdSociedad
				INNER JOIN MA_ModalidadComponente MC ON C.IdModalidadComponente = MC.Id
				INNER JOIN Capacitacion Cap ON A.Value = Cap.idPersona
				   AND C.IdUnidadCurricular = Cap.IdUnidadCurricular
				   AND (MC.CodigoInterno = Cap.IdModalidad OR mc.CodigoInterno = 0)
				WHERE DN.Id is null  AND (@IdItinerario = 0 OR I.Id = @IdItinerario)
				AND I.ACtivo = 1 AND M.Activo = 1
						
				
				--ACTUALZIAR DETALLE DE USUARIOS	
				UPDATE DN
				SET [IdCapacitacion] = Cap.Id
					  ,[IdSituacionFinal] = Cap.IdSituacion
					  ,[FechaActualizacion] = GETDATE()
				FROM [MA_DetalleNOmina] DN 
				INNER JOIN MA_Nomina N ON DN.IdNomina = N.Id AND DN.IdSociedad = N.IdSociedad
				INNER JOIN dbo.CSVToLIst(@Lista) as A ON A.Value = N.IdPersona AND N.IdSociedad = @IdSociedad
				INNER JOIN MA_Itinerario I ON N.IdItinerario = I.Id AND N.IdSociedad = I.IdSociedad AND I.Id = @IdItinerario
				INNER JOIN MA_Version V ON I.IdVersion = V.Id AND V.IdSociedad = I.IdSociedad
				INNER JOIN MA_Malla M ON V.IdMalla = M.Id AND V.IdSociedad = M.IdSociedad
				INNER JOIN MA_Seccion S ON V.Id = S.IdVersion AND S.IdSociedad = V.IdSociedad
				INNER JOIN MA_Componente C ON C.IdSeccion = S.Id  AND C.IdSociedad = S.IdSociedad
				INNER JOIN MA_ModalidadComponente MC ON C.IdModalidadComponente = MC.Id
				INNER JOIN Capacitacion Cap ON A.Value = Cap.idPersona
				   AND C.IdUnidadCurricular = Cap.IdUnidadCurricular
				   AND (MC.CodigoInterno = Cap.IdModalidad OR mc.CodigoInterno = 0)
				WHERE (@IdItinerario = 0 OR I.Id = @IdItinerario)
				AND I.ACtivo = 1 AND M.Activo = 1			
			  END
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_getDetalleItinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_getDetalleItinerario]
 @IdPersona int, @IdSociedad INT, @IdItinerario INT
 AS
BEGIN	
SET NOCOUNT ON
SELECT S.Nombre as Seccion, S.Color, C.IdUnidadCurricular, D.IdCapacitacion, D.IdSituacionFinal from MA_Itinerario I
inner join MA_Version V on V.Id = I.IdVersion AND V.IdSociedad = I.IdSociedad
inner join MA_Seccion S on S.IdVersion = V.Id AND S.IdSociedad = V.IdSociedad
inner join MA_Componente C on C.IdSeccion = S.Id AND C.IdSociedad = S.IdSociedad
inner join MA_Nomina N on N.IdItinerario = I.Id AND N.IdSociedad = I.IdSociedad AND N.IdSociedad = @IdSociedad
inner join MA_DetalleNOmina D on D.IdNomina = N.Id AND D.IdSociedad = N.IdSociedad
where I.Id = @IdItinerario AND N.IdPersona = @IdPersona and N.IdSociedad = @IdSociedad
End
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ActualizarPrerequisito]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ActualizarPrerequisito]
 @IdComponente int, @IdSociedad INT, @IdPrerrequisito int, @valor bit
 AS
BEGIN	
SET NOCOUNT ON
declare @existe bit
set @existe = (select id from MA_Prerrequisito 
where IdComponente = @IdComponente and IdComponenteRequisito = @IdPrerrequisito
and IdSociedad = @IdSociedad)

IF (@existe <> 0)
BEGIN
	IF (@valor = 0)	DELETE FROM MA_Prerrequisito WHERE Id = @existe;  
END
ELSE
BEGIN
	IF (@valor = 1)	
		BEGIN
			INSERT INTO MA_Prerrequisito SELECT @IdSociedad,@IdComponente,@IdPrerrequisito;
		END
END

End
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_EliminarNominaItinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_EliminarNominaItinerario]
@IdItinerario Int, @IdSociedad int, @todos bit, @arreglo varchar(2000)
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
			if (@todos = 1)
			BEGIN
				UPDATE [BD1].[dbo].[MA_Nomina]
				SET [Activo] = 0
				WHERE IdItinerario = @idItinerario AND IdSociedad = @IdSociedad
			END
			ELSE
			BEGIN
				UPDATE [BD1].[dbo].[MA_Nomina]
				SET [Activo] = 0
				WHERE IdItinerario = @idItinerario AND IdSociedad = @IdSociedad
				AND IdPersona IN (SELECT * FROM dbo.CSVToLIst(@arreglo))	
			END
			EXEC [dbo].[ESB_MA_ActualizarAvanceItinerario] @idItinerario ,@IdSociedad
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerListadoItinerarioMalla]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ESB_MA_ObtenerListadoItinerarioMalla]
@IdMalla int,
@IdSociedad int
AS
BEGIN	
SET NOCOUNT ON

	select I.Nombre, M.Nombre as Malla, 
	Convert(varchar(10), I.FechaInicio,103)+'-'+coalesce((Convert(varchar(15), I.FechaTermino,103)),'') as Vigencia,
	(select  COUNT(1) from MA_Nomina where IdItinerario = I.Id and IdSociedad = I.IdSociedad)as Inscriptos,
	Estado = case I.Activo WHEN 1 then 'Activa' ELSE 'No Activa' END,
	I.AvanUC, I.AvanColab
	from MA_Itinerario I
	inner join MA_Nomina N on N.IdItinerario = N.IdItinerario and N.IdSociedad = I.IdSociedad
	inner join MA_DetalleNOmina D on D.IdNomina = N.Id and N.IdSociedad = D.IdSociedad
	inner join MA_Version V on I.IdVersion = V.Id
	inner join MA_Malla M on V.IdMalla = M.Id
	where N.Activo = 1 
	and M.Id = @IdMalla and M.IdSociedad = @IdSociedad

END
GO
/****** Object:  StoredProcedure [dbo].[MA_ActualizarAvanceItinerarios]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MA_ActualizarAvanceItinerarios]
	@IdSociedad INT
 AS
BEGIN
CREATE TABLE #ItinerariosActivos (
 RowID int IDENTITY(1, 1), 
 IdItinerario int
)
DECLARE @NumberRecords int, @RowCount int
DECLARE @IdItinerario int

INSERT INTO #ItinerariosActivos (IdItinerario)
SELECT Id FROM MA_Itinerario WHERE ACtivo = 1 

SET @NumberRecords = @@ROWCOUNT
SET @RowCount = 1

WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @IdItinerario = IdItinerario
 FROM #ItinerariosActivos
 WHERE RowID = @RowCount
 EXEC ESB_MA_ActualizarAvanceItinerario @IdItinerario,@IdSociedad
 SET @RowCount = @RowCount + 1
END

-- drop the temporary table
DROP TABLE #ItinerariosActivos
END
GO
/****** Object:  StoredProcedure [dbo].[MA_ActualizarAvanceColaboradores]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MA_ActualizarAvanceColaboradores]
 @IdSociedad INT
 AS
BEGIN	
SET NOCOUNT ON
BEGIN TRY
		BEGIN TRAN
			UPDATE [dbo].[MA_Nomina]
			   SET [Finalizada] = FF.Finalizada
				  ,[CantUCCompletas] = FF.Completados
				  ,[CantUCEnCurso] = 0
				  ,[CantUCAprobadas] = FF.Aprobados
				  ,[CantUCReprobadas] = FF.Reprobados
			FROM
			(
			select Id as IdNomina, IdSociedad, CantUCTotal, SUM(Aprobados) as Aprobados, SUM(Reprobados) as Reprobados, SUM(Completados) as Completados, (SUM(Aprobados)/ CantUCTotal) AS Finalizada  from
			(
			select N.Id, N.IdSociedad, I.CantUCTotal, COUNT(1) as Aprobados, 0 as Reprobados, 0 as Completados    
			from MA_Nomina N
			inner join MA_Itinerario I on N.IdItinerario = I.Id AND I.IdSociedad = N.IdSociedad
			inner join MA_DetalleNOmina D on D.IdNomina = N.Id and n.IdSociedad = D.IdSociedad
			where D.IdSituacionFinal = 1 AND N.IdSociedad = @IdSociedad AND N.Finalizada = 0
			group by  N.Id, N.IdSociedad, I.CantUCTotal
			union all
			select N.Id, N.IdSociedad, I.CantUCTotal, 0 as Aprobados, COUNT(1) as Reprobados, 0 as Completados    
			from MA_Nomina N
			inner join MA_Itinerario I on N.IdItinerario = I.Id AND I.IdSociedad = N.IdSociedad
			inner join MA_DetalleNOmina D on D.IdNomina = N.Id and n.IdSociedad = D.IdSociedad
			where D.IdSituacionFinal > 1  AND N.IdSociedad = @IdSociedad AND N.Finalizada = 0
			group by  N.Id, N.IdSociedad, I.CantUCTotal
			union all
			select N.Id, N.IdSociedad, I.CantUCTotal, 0 as Aprobados, 0 as Reprobados, COUNT(1) as Completados    
			from MA_Nomina N
			inner join MA_Itinerario I on N.IdItinerario = I.Id AND I.IdSociedad = N.IdSociedad
			inner join MA_DetalleNOmina D on D.IdNomina = N.Id and n.IdSociedad = D.IdSociedad
			where D.IdSituacionFinal > 0  AND N.IdSociedad = @IdSociedad AND N.Finalizada = 0
			group by  N.Id, N.IdSociedad, I.CantUCTotal
			) as A
			group by Id, IdSociedad, CantUCTotal) as FF
			where FF.IdNomina = [dbo].[MA_Nomina].Id
			
			EXECUTE [MA_ActualizarAvanceItinerarios] @IdSociedad
		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_ObtenerListadoComponente]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_ObtenerListadoComponente]
 @IdVersion int, @IdSociedad INT, @ParaRequesitos int = 0, @IdUcActual int
 AS
BEGIN	
SET NOCOUNT ON
IF (@ParaRequesitos = 1)
BEGIN
	select  a.Id, a.IdSociedad,
			e.nombre as UnidadCurricular,
			c.Nombre as Modalidad,
			b.Nombre as Seccion,
			b.Color as Color,
			' ' as Prerrequisitos,
			(SELECT COALESCE((select 1 from MA_Prerrequisito as P
where P.IdComponente = @IdUcActual and P.IdComponenteRequisito = a.IdUnidadCurricular),0)) as Seleccionado
	from MA_Componente a
	inner join MA_Seccion b on a.IdSeccion = b.Id
	inner join MA_ModalidadComponente c on a.IdModalidadComponente = c.Id
	inner join CatalogoCurso e on a.IdUnidadCurricular = e.Id
	where a.IdSeccion in (select IdSeccion from MA_Version where Id = @IdVersion)
	and a.IdSociedad = @IdSociedad and a.IdUnidadCurricular <> @IdUcActual
END
	
ELSE
BEGIN
	select  a.Id,
			e.nombre as UnidadCurricular,
			c.Nombre as Modalidad,
			b.Nombre as Seccion,
			b.Color as Color,
			dbo.MA_ObtenerListaPrerrequisitos(a.Id, a.IdSociedad) as Prerrequisitos,
			0 as Seleccionado
	from MA_Componente a
	inner join MA_Seccion b on a.IdSeccion = b.Id
	inner join MA_ModalidadComponente c on a.IdModalidadComponente = c.Id
	inner join CatalogoCurso e on a.IdUnidadCurricular = e.Id
	where a.IdSeccion in (select IdSeccion from MA_Version where Id = @IdVersion)
	and a.IdSociedad = @IdSociedad
END
End
GO
/****** Object:  StoredProcedure [dbo].[ESB_MA_AgregarNominaItinerario]    Script Date: 09/20/2018 01:02:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ESB_MA_AgregarNominaItinerario]
@idItinerario Int, @IdSociedad int, @Lista varchar(MAX), @usuario varchar(100)
AS
BEGIN	
SET NOCOUNT ON
	BEGIN TRY
		BEGIN TRAN
	INSERT INTO [dbo].[MA_Nomina]
           ([IdSociedad]
           ,[IdItinerario]
           ,[IdPersona]
           ,[Activo]
           ,[Finalizada]
           ,[FechaInscripcion]
           ,[IdPersonaCreacion]
           ,[CantUCCompletas]
           ,[CantUCEnCurso]
           ,[CantUCAprobadas]
           ,[CantUCReprobadas])
    
			SELECT @IdSociedad,@idItinerario,Value,1,0,GETDATE(),@usuario,0,0,0,0
			   FROM dbo.CSVToLIst(@Lista) as A
			   left join MA_Nomina N on N.IdItinerario = @idItinerario AND N.IdSociedad = @IdSociedad AND N.IdPersona = A.Value
			   where N.Id is null

			EXEC [ESB_MA_ActualizarDetalleColaborador] @IdItinerario,@IdSociedad,@Lista

		COMMIT TRAN
	END TRY
	BEGIN CATCH		
		IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN
	END CATCH
END
GO
/****** Object:  Default [defo_MA_Malla_FechaCreacion]    Script Date: 09/20/2018 01:01:59 ******/
ALTER TABLE [dbo].[MA_Malla] ADD  CONSTRAINT [defo_MA_Malla_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
/****** Object:  Default [defo_MA_Malla_CantVersiones]    Script Date: 09/20/2018 01:01:59 ******/
ALTER TABLE [dbo].[MA_Malla] ADD  CONSTRAINT [defo_MA_Malla_CantVersiones]  DEFAULT ((0)) FOR [CantVersiones]
GO
/****** Object:  Default [DF_MA_Malla_IdEscuela]    Script Date: 09/20/2018 01:01:59 ******/
ALTER TABLE [dbo].[MA_Malla] ADD  CONSTRAINT [DF_MA_Malla_IdEscuela]  DEFAULT ((0)) FOR [IdEscuela]
GO
/****** Object:  Default [defo_MA_Version_Activo]    Script Date: 09/20/2018 01:02:00 ******/
ALTER TABLE [dbo].[MA_Version] ADD  CONSTRAINT [defo_MA_Version_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [defo_MA_Itinerario_CantUCTotal]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Itinerario] ADD  CONSTRAINT [defo_MA_Itinerario_CantUCTotal]  DEFAULT ((0)) FOR [CantUCTotal]
GO
/****** Object:  Default [defo_MA_Itinerario_ACtivo]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Itinerario] ADD  CONSTRAINT [defo_MA_Itinerario_ACtivo]  DEFAULT ((1)) FOR [ACtivo]
GO
/****** Object:  Default [DF_MA_Itinerario_AvanUC]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Itinerario] ADD  CONSTRAINT [DF_MA_Itinerario_AvanUC]  DEFAULT ((0)) FOR [AvanUC]
GO
/****** Object:  Default [DF_MA_Itinerario_AvanColab]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Itinerario] ADD  CONSTRAINT [DF_MA_Itinerario_AvanColab]  DEFAULT ((0)) FOR [AvanColab]
GO
/****** Object:  Default [defo_MA_Nomina_Activo]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Nomina] ADD  CONSTRAINT [defo_MA_Nomina_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  Default [defo_MA_Nomina_Finalizada]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Nomina] ADD  CONSTRAINT [defo_MA_Nomina_Finalizada]  DEFAULT ((0)) FOR [Finalizada]
GO
/****** Object:  Default [defo_MA_Nomina_FechaInscripcion]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Nomina] ADD  CONSTRAINT [defo_MA_Nomina_FechaInscripcion]  DEFAULT (getdate()) FOR [FechaInscripcion]
GO
/****** Object:  Default [defo_MA_Nomina_CantUCCompletas]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Nomina] ADD  CONSTRAINT [defo_MA_Nomina_CantUCCompletas]  DEFAULT ((0)) FOR [CantUCCompletas]
GO
/****** Object:  Default [defo_MA_Nomina_CantUCEnCurso]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Nomina] ADD  CONSTRAINT [defo_MA_Nomina_CantUCEnCurso]  DEFAULT ((0)) FOR [CantUCEnCurso]
GO
/****** Object:  Default [defo_MA_Nomina_CantUCReprobadas]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Nomina] ADD  CONSTRAINT [defo_MA_Nomina_CantUCReprobadas]  DEFAULT ((0)) FOR [CantUCReprobadas]
GO
/****** Object:  Default [defo_MA_DetalleNOmina_FechaActualizacion]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_DetalleNOmina] ADD  CONSTRAINT [defo_MA_DetalleNOmina_FechaActualizacion]  DEFAULT (getdate()) FOR [FechaActualizacion]
GO
/****** Object:  ForeignKey [FK_MA_Version_MA_Malla]    Script Date: 09/20/2018 01:02:00 ******/
ALTER TABLE [dbo].[MA_Version]  WITH CHECK ADD  CONSTRAINT [FK_MA_Version_MA_Malla] FOREIGN KEY([IdMalla], [IdSociedad])
REFERENCES [dbo].[MA_Malla] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Version] CHECK CONSTRAINT [FK_MA_Version_MA_Malla]
GO
/****** Object:  ForeignKey [Fk_MA_Certificado_MA_Malla]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Certificado]  WITH CHECK ADD  CONSTRAINT [Fk_MA_Certificado_MA_Malla] FOREIGN KEY([Id], [IdSociedad])
REFERENCES [dbo].[MA_Malla] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Certificado] CHECK CONSTRAINT [Fk_MA_Certificado_MA_Malla]
GO
/****** Object:  ForeignKey [FK_MA_Seccion_MA_Version]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Seccion]  WITH CHECK ADD  CONSTRAINT [FK_MA_Seccion_MA_Version] FOREIGN KEY([IdVersion], [IdSociedad])
REFERENCES [dbo].[MA_Version] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Seccion] CHECK CONSTRAINT [FK_MA_Seccion_MA_Version]
GO
/****** Object:  ForeignKey [FK_MA_Itinerario_MA_Version]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Itinerario]  WITH CHECK ADD  CONSTRAINT [FK_MA_Itinerario_MA_Version] FOREIGN KEY([IdVersion], [IdSociedad])
REFERENCES [dbo].[MA_Version] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Itinerario] CHECK CONSTRAINT [FK_MA_Itinerario_MA_Version]
GO
/****** Object:  ForeignKey [FK_MA_ItinerarioTipoNotificacion_MA_Itinerario]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_ItinerarioTipoNotificacion]  WITH CHECK ADD  CONSTRAINT [FK_MA_ItinerarioTipoNotificacion_MA_Itinerario] FOREIGN KEY([IdItinerario], [IdSociedad])
REFERENCES [dbo].[MA_Itinerario] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_ItinerarioTipoNotificacion] CHECK CONSTRAINT [FK_MA_ItinerarioTipoNotificacion_MA_Itinerario]
GO
/****** Object:  ForeignKey [FK_MA_ItinerarioTipoNotificacion_MA_TipoNotificacion]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_ItinerarioTipoNotificacion]  WITH CHECK ADD  CONSTRAINT [FK_MA_ItinerarioTipoNotificacion_MA_TipoNotificacion] FOREIGN KEY([IdTipoNotificacion], [IdSociedad])
REFERENCES [dbo].[MA_TipoNotificacion] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_ItinerarioTipoNotificacion] CHECK CONSTRAINT [FK_MA_ItinerarioTipoNotificacion_MA_TipoNotificacion]
GO
/****** Object:  ForeignKey [FK_MA_Componente_MA_ModalidadComponente]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Componente]  WITH CHECK ADD  CONSTRAINT [FK_MA_Componente_MA_ModalidadComponente] FOREIGN KEY([IdModalidadComponente], [IdSociedad])
REFERENCES [dbo].[MA_ModalidadComponente] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Componente] CHECK CONSTRAINT [FK_MA_Componente_MA_ModalidadComponente]
GO
/****** Object:  ForeignKey [FK_MA_Componente_MA_Seccion]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Componente]  WITH CHECK ADD  CONSTRAINT [FK_MA_Componente_MA_Seccion] FOREIGN KEY([IdSeccion], [IdSociedad])
REFERENCES [dbo].[MA_Seccion] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Componente] CHECK CONSTRAINT [FK_MA_Componente_MA_Seccion]
GO
/****** Object:  ForeignKey [FK_MA_Audiencia_MA_Itinerario]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Nomina]  WITH CHECK ADD  CONSTRAINT [FK_MA_Audiencia_MA_Itinerario] FOREIGN KEY([IdItinerario], [IdSociedad])
REFERENCES [dbo].[MA_Itinerario] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Nomina] CHECK CONSTRAINT [FK_MA_Audiencia_MA_Itinerario]
GO
/****** Object:  ForeignKey [Fk_MA_DetalleAudiencia_MA_Audiencia]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_DetalleNOmina]  WITH CHECK ADD  CONSTRAINT [Fk_MA_DetalleAudiencia_MA_Audiencia] FOREIGN KEY([IdNomina], [IdSociedad])
REFERENCES [dbo].[MA_Nomina] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_DetalleNOmina] CHECK CONSTRAINT [Fk_MA_DetalleAudiencia_MA_Audiencia]
GO
/****** Object:  ForeignKey [FK_MA_Prerrequisito_Componente_MA_Componente]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Prerrequisito]  WITH CHECK ADD  CONSTRAINT [FK_MA_Prerrequisito_Componente_MA_Componente] FOREIGN KEY([IdComponente], [IdSociedad])
REFERENCES [dbo].[MA_Componente] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Prerrequisito] CHECK CONSTRAINT [FK_MA_Prerrequisito_Componente_MA_Componente]
GO
/****** Object:  ForeignKey [FK_MA_Prerrequisito_ComponenteRequisito_MA_Componente]    Script Date: 09/20/2018 01:02:03 ******/
ALTER TABLE [dbo].[MA_Prerrequisito]  WITH CHECK ADD  CONSTRAINT [FK_MA_Prerrequisito_ComponenteRequisito_MA_Componente] FOREIGN KEY([IdComponenteRequisito], [IdSociedad])
REFERENCES [dbo].[MA_Componente] ([Id], [IdSociedad])
GO
ALTER TABLE [dbo].[MA_Prerrequisito] CHECK CONSTRAINT [FK_MA_Prerrequisito_ComponenteRequisito_MA_Componente]
GO
