USE [master]
GO
/****** Object:  Database [TempDataSample1]    Script Date: 1/12/2023 7:26:51 AM ******/
CREATE DATABASE [TempDataSample1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TempDataSample1', FILENAME = N'C:\Users\paynek\TempDataSample1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TempDataSample1_log', FILENAME = N'C:\Users\paynek\TempDataSample1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TempDataSample1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TempDataSample1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TempDataSample1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TempDataSample1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TempDataSample1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TempDataSample1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TempDataSample1] SET ARITHABORT OFF 
GO
ALTER DATABASE [TempDataSample1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TempDataSample1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TempDataSample1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TempDataSample1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TempDataSample1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TempDataSample1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TempDataSample1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TempDataSample1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TempDataSample1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TempDataSample1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TempDataSample1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TempDataSample1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TempDataSample1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TempDataSample1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TempDataSample1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TempDataSample1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TempDataSample1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TempDataSample1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TempDataSample1] SET  MULTI_USER 
GO
ALTER DATABASE [TempDataSample1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TempDataSample1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TempDataSample1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TempDataSample1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TempDataSample1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TempDataSample1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TempDataSample1] SET QUERY_STORE = OFF
GO
USE [TempDataSample1]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 1/12/2023 7:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[SitePassword] [nvarchar](max) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (1, N'Stefanie', N'Buckley', N'Buckley58@bxcwtl.org', N'1VDV3ZIFZ5QSZM5J52')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (2, N'Sandy', N'Mc Gee', N'Gee22@rxmkwq.net', N'IXND9H')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (3, N'Lee', N'Warren', N'Lee7@cusfu.brsovb.org', N'WK20MQ')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (4, N'Regina', N'Forbes', N'qiekszc.txpoca@tflkg.rsetzb.net', N'HQCNPY')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (5, N'Daniel', N'Kim', N'nfds20@ldyif.-qpucw.net', N'F6BQU6')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (6, N'Dennis', N'Nunez', N'Nunez156@ikjvwn.net', N'2GLXUI')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (7, N'Myra', N'Zuniga', N'tzdajoot1@kfiuto.com', N'OX8VGO')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (8, N'Teddy', N'Ingram', N'pwlf.fqvth@byfic.xmtanx.net', N'QY2LUP')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (9, N'Annie', N'Larson', N'Larson@kyihcl.com', N'22FIOW8B')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [EmailAddress], [SitePassword]) VALUES (10, N'Herman', N'Anderson', N'Anderson@uqiiky.nmrknj.org', N'CO84T')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unsecure password, keeping it simple' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Person', @level2type=N'COLUMN',@level2name=N'SitePassword'
GO
USE [master]
GO
ALTER DATABASE [TempDataSample1] SET  READ_WRITE 
GO
