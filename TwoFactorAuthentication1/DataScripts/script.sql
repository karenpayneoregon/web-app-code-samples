USE [AuthenticateSample]
GO
/****** Object:  Table [dbo].[Verifications]    Script Date: 2/1/2023 9:47:46 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Verifications]') AND type in (N'U'))
DROP TABLE [dbo].[Verifications]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 2/1/2023 9:47:46 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Organizations]') AND type in (N'U'))
DROP TABLE [dbo].[Organizations]
GO
USE [master]
GO
/****** Object:  Database [AuthenticateSample]    Script Date: 2/1/2023 9:47:46 AM ******/
DROP DATABASE [AuthenticateSample]
GO
/****** Object:  Database [AuthenticateSample]    Script Date: 2/1/2023 9:47:46 AM ******/
CREATE DATABASE [AuthenticateSample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AuthenticateSample', FILENAME = N'C:\Users\paynek\AuthenticateSample.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AuthenticateSample_log', FILENAME = N'C:\Users\paynek\AuthenticateSample_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AuthenticateSample] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AuthenticateSample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AuthenticateSample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AuthenticateSample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AuthenticateSample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AuthenticateSample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AuthenticateSample] SET ARITHABORT OFF 
GO
ALTER DATABASE [AuthenticateSample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AuthenticateSample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AuthenticateSample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AuthenticateSample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AuthenticateSample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AuthenticateSample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AuthenticateSample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AuthenticateSample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AuthenticateSample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AuthenticateSample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AuthenticateSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AuthenticateSample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AuthenticateSample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AuthenticateSample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AuthenticateSample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AuthenticateSample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AuthenticateSample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AuthenticateSample] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AuthenticateSample] SET  MULTI_USER 
GO
ALTER DATABASE [AuthenticateSample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AuthenticateSample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AuthenticateSample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AuthenticateSample] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AuthenticateSample] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AuthenticateSample] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AuthenticateSample] SET QUERY_STORE = OFF
GO
USE [AuthenticateSample]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 2/1/2023 9:47:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[Issuer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Verifications]    Script Date: 2/1/2023 9:47:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](max) NOT NULL,
	[Secret] [nvarchar](max) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedTime] [time](7) NOT NULL,
 CONSTRAINT [PK_Verifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [AuthenticateSample] SET  READ_WRITE 
GO
