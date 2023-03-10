USE [master]
GO
/****** Object:  Database [EF.NotesDatabase]    Script Date: 1/31/2023 1:27:39 PM ******/
CREATE DATABASE [EF.NotesDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EF.NotesDatabase', FILENAME = N'C:\Users\paynek\EF.NotesDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EF.NotesDatabase_log', FILENAME = N'C:\Users\paynek\EF.NotesDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EF.NotesDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EF.NotesDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EF.NotesDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EF.NotesDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EF.NotesDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EF.NotesDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EF.NotesDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EF.NotesDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EF.NotesDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EF.NotesDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [EF.NotesDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EF.NotesDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EF.NotesDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EF.NotesDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EF.NotesDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EF.NotesDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EF.NotesDatabase] SET QUERY_STORE = OFF
GO
USE [EF.NotesDatabase]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/31/2023 1:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 1/31/2023 1:27:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[NoteId] [int] IDENTITY(1,1) NOT NULL,
	[BodyText] [nvarchar](max) NULL,
	[DueDate] [datetime2](7) NULL,
	[Completed] [bit] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[NoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Shopping list')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Today')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Next week')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Appointments')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Note] ON 

INSERT [dbo].[Note] ([NoteId], [BodyText], [DueDate], [Completed], [CategoryId]) VALUES (1, N'Buy eggs, milk and sugar', CAST(N'2022-11-03T14:23:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Note] ([NoteId], [BodyText], [DueDate], [Completed], [CategoryId]) VALUES (2, N'Dental checkup', CAST(N'2022-11-16T08:15:00.0000000' AS DateTime2), 1, 4)
INSERT [dbo].[Note] ([NoteId], [BodyText], [DueDate], [Completed], [CategoryId]) VALUES (3, N'Check oil in car', CAST(N'2022-11-11T15:45:00.0000000' AS DateTime2), 0, 3)
INSERT [dbo].[Note] ([NoteId], [BodyText], [DueDate], [Completed], [CategoryId]) VALUES (4, N'Wash the 2019', CAST(N'2022-12-09T13:55:46.0280000' AS DateTime2), 0, 3)
INSERT [dbo].[Note] ([NoteId], [BodyText], [DueDate], [Completed], [CategoryId]) VALUES (5, N'Take out the trash', CAST(N'2022-11-10T06:17:33.9330000' AS DateTime2), 0, 3)
INSERT [dbo].[Note] ([NoteId], [BodyText], [DueDate], [Completed], [CategoryId]) VALUES (6, N'Check for Amazon package', CAST(N'2022-11-09T07:32:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[Note] ([NoteId], [BodyText], [DueDate], [Completed], [CategoryId]) VALUES (7, N'Doctor appointment', CAST(N'2022-11-25T07:33:00.0000000' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[Note] OFF
GO
/****** Object:  Index [IX_Note_CategoryId]    Script Date: 1/31/2023 1:27:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Note_CategoryId] ON [dbo].[Note]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Category]
GO
USE [master]
GO
ALTER DATABASE [EF.NotesDatabase] SET  READ_WRITE 
GO
