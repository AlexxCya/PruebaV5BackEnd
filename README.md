# PruebaV5BackEnd
Ejecutar el siguiente script en SQL para la generacion de la BD

------------------------------------------------------------------------------------------
USE [master]
GO
CREATE DATABASE [PruebaV5BD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaV5BD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaV5BD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaV5BD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PruebaV5BD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PruebaV5BD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaV5BD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaV5BD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaV5BD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaV5BD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaV5BD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaV5BD] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaV5BD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaV5BD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaV5BD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaV5BD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaV5BD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaV5BD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaV5BD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaV5BD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaV5BD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaV5BD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaV5BD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaV5BD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaV5BD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaV5BD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaV5BD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaV5BD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaV5BD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaV5BD] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaV5BD] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaV5BD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaV5BD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaV5BD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaV5BD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaV5BD] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PruebaV5BD', N'ON'
GO
ALTER DATABASE [PruebaV5BD] SET QUERY_STORE = OFF
GO
USE [PruebaV5BD]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 18/06/2021 01:13:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[alpha2Code] [varchar](2) NOT NULL,
	[alpha3Code] [varchar](3) NOT NULL,
	[code] [varchar](3) NOT NULL,
	[iso] [varchar](30) NOT NULL,
	[independent] [bit] NOT NULL,
	[imageUrl] [varchar](500) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 18/06/2021 01:13:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[countyId] [bigint] NOT NULL,
	[name] [varchar](150) NOT NULL,
	[abbrevation] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Security]    Script Date: 18/06/2021 01:13:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Security](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user] [varchar](50) NOT NULL,
	[userName] [varchar](100) NOT NULL,
	[pwd] [varchar](200) NOT NULL,
	[role] [varchar](15) NOT NULL,
 CONSTRAINT [PK__Segurity__3213E83F8263C85C] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([id], [name], [alpha2Code], [alpha3Code], [code], [iso], [independent], [imageUrl]) VALUES (1, N'Albania', N'AL', N'ALB', N'008', N'ISO 3166-2:AL', 1, NULL)
GO
INSERT [dbo].[Country] ([id], [name], [alpha2Code], [alpha3Code], [code], [iso], [independent], [imageUrl]) VALUES (2, N'Algeria', N'DZ', N'DZA', N'012', N'ISO 3166:2-DZ', 1, NULL)
GO
INSERT [dbo].[Country] ([id], [name], [alpha2Code], [alpha3Code], [code], [iso], [independent], [imageUrl]) VALUES (6, N'Mexico', N'MX', N'MEX', N'055', N'ISO 3166-2:MX', 0, NULL)
GO
INSERT [dbo].[Country] ([id], [name], [alpha2Code], [alpha3Code], [code], [iso], [independent], [imageUrl]) VALUES (7, N'Colombia', N'CO', N'COL', N'667', N'ISO 3166-2:CO', 0, NULL)
GO
INSERT [dbo].[Country] ([id], [name], [alpha2Code], [alpha3Code], [code], [iso], [independent], [imageUrl]) VALUES (8, N'United States', N'US', N'USA', N'986', N'ISO 8347-2:US', 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Province] ON 
GO
INSERT [dbo].[Province] ([id], [countyId], [name], [abbrevation]) VALUES (1, 6, N'Aguascalientes', N'AG')
GO
INSERT [dbo].[Province] ([id], [countyId], [name], [abbrevation]) VALUES (2, 6, N'Colima', N'COL')
GO
INSERT [dbo].[Province] ([id], [countyId], [name], [abbrevation]) VALUES (4, 6, N'Coahuila', N'CAH')
GO
INSERT [dbo].[Province] ([id], [countyId], [name], [abbrevation]) VALUES (10005, 6, N'Veracruz', N'VER')
GO
SET IDENTITY_INSERT [dbo].[Province] OFF
GO
SET IDENTITY_INSERT [dbo].[Security] ON 
GO
INSERT [dbo].[Security] ([id], [user], [userName], [pwd], [role]) VALUES (1, N'Alex', N'Alex', N'1234', N'Administrator')
GO
INSERT [dbo].[Security] ([id], [user], [userName], [pwd], [role]) VALUES (2, N'test@domain.com', N'test@domain.com', N'abc123', N'Administrator')
GO
SET IDENTITY_INSERT [dbo].[Security] OFF
GO
ALTER TABLE [dbo].[Province]  WITH CHECK ADD  CONSTRAINT [FK_Province_Country] FOREIGN KEY([countyId])
REFERENCES [dbo].[Country] ([id])
GO
ALTER TABLE [dbo].[Province] CHECK CONSTRAINT [FK_Province_Country]
GO
USE [master]
GO
ALTER DATABASE [PruebaV5BD] SET  READ_WRITE 
GO
