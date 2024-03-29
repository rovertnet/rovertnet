USE [master]
GO
/****** Object:  Database [GOS]    Script Date: 13/11/2020 14:03:58 ******/
CREATE DATABASE [GOS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = 'GOS', FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GOS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = 'GOS_log', FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GOS_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GOS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GOS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GOS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GOS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GOS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GOS] SET ARITHABORT OFF 
GO
ALTER DATABASE [GOS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GOS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GOS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GOS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GOS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GOS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GOS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GOS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GOS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GOS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GOS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GOS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GOS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GOS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GOS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GOS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GOS] SET RECOVERY FULL 
GO
ALTER DATABASE [GOS] SET  MULTI_USER 
GO
ALTER DATABASE [GOS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GOS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GOS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GOS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GOS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GOS', N'ON'
GO
USE [GOS]
GO
/****** Object:  Table [dbo].[T_Appartenir]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Appartenir](
	[Num] [int] NOT NULL,
	[CodProm] [nchar](10) NULL,
	[CodVac] [nchar](10) NULL,
 CONSTRAINT [PK_T_Appartenir] PRIMARY KEY CLUSTERED 
(
	[Num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Cours]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Cours](
	[CodCour] [nchar](10) NOT NULL,
	[LibCour] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Cours] PRIMARY KEY CLUSTERED 
(
	[CodCour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Enseignant]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Enseignant](
	[CodEns] [nchar](10) NOT NULL,
	[Nom] [nvarchar](20) NULL,
	[Postnom] [nvarchar](20) NULL,
	[Prenom] [nvarchar](20) NULL,
	[Sexe] [nvarchar](50) NULL,
	[Adresse] [nvarchar](150) NULL,
	[Tel] [nvarchar](30) NULL,
	[Email] [nvarchar](80) NULL,
	[CodFonct] [nchar](10) NULL,
 CONSTRAINT [PK_T_Fonction] PRIMARY KEY CLUSTERED 
(
	[CodEns] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Enseignement]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Enseignement](
	[CodEngn] [nchar](10) NOT NULL,
	[DateEnseig] [datetime] NULL,
	[HeureDeb] [time](7) NULL,
	[HeureFin] [time](7) NULL,
	[CodEns] [nchar](10) NULL,
	[CodProm] [nchar](10) NULL,
	[CodSit] [nchar](10) NULL,
	[CodLoc] [nchar](10) NULL,
	[CodCour] [nchar](10) NULL,
 CONSTRAINT [PK_T_Enseignement] PRIMARY KEY CLUSTERED 
(
	[CodEngn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_EtreLie]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EtreLie](
	[CodLoc] [nchar](10) NULL,
	[CodNiv] [nchar](10) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_EtreProgrammer]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_EtreProgrammer](
	[CodSem] [nchar](10) NULL,
	[CodCour] [nchar](10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Fonction]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Fonction](
	[CodFonct] [nchar](10) NOT NULL,
	[LibFonct] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Fonction_1] PRIMARY KEY CLUSTERED 
(
	[CodFonct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Fonctionn]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Fonctionn](
	[CodFonct] [nchar](10) NOT NULL,
	[LibFonct] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Fonctionn] PRIMARY KEY CLUSTERED 
(
	[CodFonct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Grade]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Grade](
	[CodGrad] [nchar](10) NOT NULL,
	[LibGrad] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Grade] PRIMARY KEY CLUSTERED 
(
	[CodGrad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Local]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Local](
	[CodLoc] [nchar](10) NOT NULL,
	[Intitul] [nvarchar](50) NULL,
	[CodNiv] [nchar](10) NULL,
 CONSTRAINT [PK_T_Local] PRIMARY KEY CLUSTERED 
(
	[CodLoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Login]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Login](
	[Login] [nchar](10) NOT NULL,
	[MDP] [nchar](10) NULL,
	[NomUtilisateur] [nvarchar](50) NULL,
	[Fonction] [nchar](15) NULL,
 CONSTRAINT [PK_T_Login] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Niveau]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Niveau](
	[CodNiv] [nchar](10) NOT NULL,
	[Descript] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Niveau] PRIMARY KEY CLUSTERED 
(
	[CodNiv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Option]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Option](
	[CodOpt] [nchar](10) NOT NULL,
	[LibOpt] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Option] PRIMARY KEY CLUSTERED 
(
	[CodOpt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Posseder]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Posseder](
	[CodPosseder] [int] IDENTITY(1,1) NOT NULL,
	[CodEns] [nchar](10) NULL,
	[CodGrad] [nchar](10) NULL,
	[DatDeb] [date] NULL,
	[DatFin] [date] NULL,
 CONSTRAINT [PK_T_Posseder] PRIMARY KEY CLUSTERED 
(
	[CodPosseder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Promotion]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Promotion](
	[CodProm] [nchar](10) NOT NULL,
	[LibProm] [nvarchar](50) NULL,
	[CodOpt] [nchar](10) NULL,
 CONSTRAINT [PK_T_Promotion] PRIMARY KEY CLUSTERED 
(
	[CodProm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Semetre]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Semetre](
	[CodSem] [nchar](10) NOT NULL,
	[LibSem] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Semetre] PRIMARY KEY CLUSTERED 
(
	[CodSem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Site]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Site](
	[CodSit] [nchar](10) NOT NULL,
	[LibSit] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Site] PRIMARY KEY CLUSTERED 
(
	[CodSit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Vacation]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Vacation](
	[CodVac] [nchar](10) NOT NULL,
	[LibVac] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Vacation] PRIMARY KEY CLUSTERED 
(
	[CodVac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[V_horraire]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_horraire]
AS
SELECT        dbo.T_Site.LibSit, dbo.T_Niveau.Descript, dbo.T_Local.Intitul, dbo.T_Enseignement.DateEnseig, dbo.T_Enseignement.HeureDeb, dbo.T_Enseignement.HeureFin, dbo.T_Cours.LibCour, dbo.T_Enseignant.Nom, 
                         dbo.T_Enseignant.Postnom, dbo.T_Enseignant.Prenom, dbo.T_Semetre.LibSem
FROM            dbo.T_Cours INNER JOIN
                         dbo.T_Enseignement ON dbo.T_Cours.CodCour = dbo.T_Enseignement.CodCour INNER JOIN
                         dbo.T_EtreProgrammer ON dbo.T_Cours.CodCour = dbo.T_EtreProgrammer.CodCour INNER JOIN
                         dbo.T_Semetre ON dbo.T_EtreProgrammer.CodSem = dbo.T_Semetre.CodSem INNER JOIN
                         dbo.T_Enseignant ON dbo.T_Enseignement.CodEns = dbo.T_Enseignant.CodEns INNER JOIN
                         dbo.T_Local ON dbo.T_Enseignement.CodLoc = dbo.T_Local.CodLoc INNER JOIN
                         dbo.T_Niveau ON dbo.T_Local.CodNiv = dbo.T_Niveau.CodNiv INNER JOIN
                         dbo.T_Site ON dbo.T_Enseignement.CodSit = dbo.T_Site.CodSit

GO
/****** Object:  View [dbo].[V_OptionPromo]    Script Date: 13/11/2020 14:03:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_OptionPromo]
AS
SELECT        dbo.T_Option.CodOpt, dbo.T_Option.LibOpt, dbo.T_Promotion.CodProm, dbo.T_Promotion.LibProm
FROM            dbo.T_Promotion INNER JOIN
                         dbo.T_Option ON dbo.T_Promotion.CodOpt = dbo.T_Option.CodOpt

GO
ALTER TABLE [dbo].[T_Enseignant]  WITH CHECK ADD  CONSTRAINT [FK_T_Enseignant_T_Fonction] FOREIGN KEY([CodFonct])
REFERENCES [dbo].[T_Fonction] ([CodFonct])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Enseignant] CHECK CONSTRAINT [FK_T_Enseignant_T_Fonction]
GO
ALTER TABLE [dbo].[T_Enseignement]  WITH CHECK ADD  CONSTRAINT [FK_T_Enseignement_T_Cours] FOREIGN KEY([CodCour])
REFERENCES [dbo].[T_Cours] ([CodCour])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Enseignement] CHECK CONSTRAINT [FK_T_Enseignement_T_Cours]
GO
ALTER TABLE [dbo].[T_Enseignement]  WITH CHECK ADD  CONSTRAINT [FK_T_Enseignement_T_Enseignant] FOREIGN KEY([CodEns])
REFERENCES [dbo].[T_Enseignant] ([CodEns])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Enseignement] CHECK CONSTRAINT [FK_T_Enseignement_T_Enseignant]
GO
ALTER TABLE [dbo].[T_Enseignement]  WITH CHECK ADD  CONSTRAINT [FK_T_Enseignement_T_Local] FOREIGN KEY([CodLoc])
REFERENCES [dbo].[T_Local] ([CodLoc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Enseignement] CHECK CONSTRAINT [FK_T_Enseignement_T_Local]
GO
ALTER TABLE [dbo].[T_Enseignement]  WITH CHECK ADD  CONSTRAINT [FK_T_Enseignement_T_Promotion] FOREIGN KEY([CodProm])
REFERENCES [dbo].[T_Promotion] ([CodProm])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Enseignement] CHECK CONSTRAINT [FK_T_Enseignement_T_Promotion]
GO
ALTER TABLE [dbo].[T_Enseignement]  WITH CHECK ADD  CONSTRAINT [FK_T_Enseignement_T_Site] FOREIGN KEY([CodSit])
REFERENCES [dbo].[T_Site] ([CodSit])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Enseignement] CHECK CONSTRAINT [FK_T_Enseignement_T_Site]
GO
ALTER TABLE [dbo].[T_EtreLie]  WITH CHECK ADD  CONSTRAINT [FK_T_EtreLie_T_Local] FOREIGN KEY([CodLoc])
REFERENCES [dbo].[T_Local] ([CodLoc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_EtreLie] CHECK CONSTRAINT [FK_T_EtreLie_T_Local]
GO
ALTER TABLE [dbo].[T_EtreLie]  WITH CHECK ADD  CONSTRAINT [FK_T_EtreLie_T_Niveau] FOREIGN KEY([CodNiv])
REFERENCES [dbo].[T_Niveau] ([CodNiv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_EtreLie] CHECK CONSTRAINT [FK_T_EtreLie_T_Niveau]
GO
ALTER TABLE [dbo].[T_EtreProgrammer]  WITH CHECK ADD  CONSTRAINT [FK_T_EtreProgrammer_T_Cours] FOREIGN KEY([CodCour])
REFERENCES [dbo].[T_Cours] ([CodCour])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_EtreProgrammer] CHECK CONSTRAINT [FK_T_EtreProgrammer_T_Cours]
GO
ALTER TABLE [dbo].[T_EtreProgrammer]  WITH CHECK ADD  CONSTRAINT [FK_T_EtreProgrammer_T_Semetre] FOREIGN KEY([CodSem])
REFERENCES [dbo].[T_Semetre] ([CodSem])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_EtreProgrammer] CHECK CONSTRAINT [FK_T_EtreProgrammer_T_Semetre]
GO
ALTER TABLE [dbo].[T_Posseder]  WITH CHECK ADD  CONSTRAINT [FK_T_Posseder_T_Enseignant] FOREIGN KEY([CodEns])
REFERENCES [dbo].[T_Enseignant] ([CodEns])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Posseder] CHECK CONSTRAINT [FK_T_Posseder_T_Enseignant]
GO
ALTER TABLE [dbo].[T_Posseder]  WITH CHECK ADD  CONSTRAINT [FK_T_Posseder_T_Grade] FOREIGN KEY([CodGrad])
REFERENCES [dbo].[T_Grade] ([CodGrad])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Posseder] CHECK CONSTRAINT [FK_T_Posseder_T_Grade]
GO
ALTER TABLE [dbo].[T_Promotion]  WITH CHECK ADD  CONSTRAINT [FK_T_Promotion_T_Option] FOREIGN KEY([CodOpt])
REFERENCES [dbo].[T_Option] ([CodOpt])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[T_Promotion] CHECK CONSTRAINT [FK_T_Promotion_T_Option]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[51] 4[10] 2[20] 3) )"
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
         Begin Table = "T_Cours"
            Begin Extent = 
               Top = 8
               Left = 414
               Bottom = 114
               Right = 623
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_Enseignement"
            Begin Extent = 
               Top = 0
               Left = 158
               Bottom = 213
               Right = 366
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_EtreProgrammer"
            Begin Extent = 
               Top = 118
               Left = 439
               Bottom = 220
               Right = 647
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_Semetre"
            Begin Extent = 
               Top = 191
               Left = 810
               Bottom = 293
               Right = 1021
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_Enseignant"
            Begin Extent = 
               Top = 9
               Left = 695
               Bottom = 182
               Right = 903
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_Local"
            Begin Extent = 
               Top = 226
               Left = 376
               Bottom = 341
               Right = 584
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_Niveau"
            Begin Extent = 
               Top = 239
               Left = 588
               Bottom = 346
               Right = 774
            End
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_horraire'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'       DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_Site"
            Begin Extent = 
               Top = 229
               Left = 0
               Bottom = 325
               Right = 159
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
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_horraire'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_horraire'
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
         Begin Table = "T_Promotion"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "T_Option"
            Begin Extent = 
               Top = 6
               Left = 284
               Bottom = 121
               Right = 492
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OptionPromo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OptionPromo'
GO
USE [master]
GO
ALTER DATABASE [GOS] SET  READ_WRITE 
GO
