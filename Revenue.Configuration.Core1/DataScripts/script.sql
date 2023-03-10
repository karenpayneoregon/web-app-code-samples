USE [master]
GO
/****** Object:  Database [ApplicationConfigurations]    Script Date: 1/31/2023 12:12:04 PM ******/
CREATE DATABASE [ApplicationConfigurations]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApplicationConfigurations', FILENAME = N'C:\Users\paynek\ApplicationConfigurations.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ApplicationConfigurations_log', FILENAME = N'C:\Users\paynek\ApplicationConfigurations_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ApplicationConfigurations] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApplicationConfigurations].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApplicationConfigurations] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApplicationConfigurations] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApplicationConfigurations] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ApplicationConfigurations] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApplicationConfigurations] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ApplicationConfigurations] SET  MULTI_USER 
GO
ALTER DATABASE [ApplicationConfigurations] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApplicationConfigurations] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApplicationConfigurations] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApplicationConfigurations] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ApplicationConfigurations] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ApplicationConfigurations] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ApplicationConfigurations] SET QUERY_STORE = OFF
GO
USE [ApplicationConfigurations]
GO
/****** Object:  Table [dbo].[AcedEmailSettings]    Script Date: 1/31/2023 12:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcedEmailSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Host] [nvarchar](max) NULL,
	[Port] [int] NULL,
	[TimeOut] [int] NULL,
	[RevenueCoordinator] [nvarchar](max) NULL,
	[TestFromAddress] [nvarchar](max) NULL,
	[PickupFolder] [nvarchar](max) NULL,
	[Identifier] [int] NULL,
 CONSTRAINT [PK_AcedEmailSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Applications]    Script Date: 1/31/2023 12:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Identifier] [int] NULL,
	[ContactName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AzureSettings]    Script Date: 1/31/2023 12:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AzureSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tenant] [nvarchar](max) NULL,
	[TenantName] [nvarchar](max) NULL,
	[TenantId] [nvarchar](max) NULL,
	[Audience] [nvarchar](max) NULL,
	[ClientId] [nvarchar](max) NULL,
	[GraphClientId] [nvarchar](max) NULL,
	[GraphClientSecret] [nvarchar](max) NULL,
	[SignUpSignInPolicyId] [nvarchar](max) NULL,
	[AzureGraphVersion] [nvarchar](max) NULL,
	[MicrosoftGraphVersion] [nvarchar](max) NULL,
	[AadInstance] [nvarchar](max) NULL,
	[UseAdal] [bit] NULL,
	[Identifier] [int] NULL,
 CONSTRAINT [PK_AzureSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralSettings]    Script Date: 1/31/2023 12:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicePath] [nvarchar](max) NULL,
	[ErrorMessageFromAddress] [nvarchar](max) NULL,
	[ClientValidationEnabled] [bit] NULL,
	[UnobtrusiveJavaScriptEnabled] [bit] NULL,
	[MainDatabaseConnection] [nvarchar](max) NULL,
	[Identifier] [int] NULL,
 CONSTRAINT [PK_GeneralSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MailSettings]    Script Date: 1/31/2023 12:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MailSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromAddress] [nvarchar](max) NULL,
	[Host] [nvarchar](max) NULL,
	[Port] [int] NULL,
	[TimeOut] [int] NULL,
	[PickupFolder] [nvarchar](max) NULL,
	[TestFromAddress] [nvarchar](max) NULL,
	[RevenueCoordinator] [nvarchar](max) NULL,
	[Identifier] [int] NULL,
 CONSTRAINT [PK_MailSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebPageSettings]    Script Date: 1/31/2023 12:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebPageSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VersionMajor] [int] NULL,
	[VersionMinor] [int] NULL,
	[VersionBuild] [int] NULL,
	[VersionRevison] [int] NULL,
	[Identifier] [int] NULL,
	[TheVersion]  AS ((((((replace(str([VersionMajor]),' ','')+'.')+replace(str([VersionMinor]),' ',''))+'.')+replace(str([VersionBuild]),' ',''))+'.')+replace(str([VersionRevison]),' ','')),
 CONSTRAINT [PK_WebPageSettings1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AcedEmailSettings] ON 

INSERT [dbo].[AcedEmailSettings] ([Id], [Host], [Port], [TimeOut], [RevenueCoordinator], [TestFromAddress], [PickupFolder], [Identifier]) VALUES (1, N'mail.oregon.gov', 25, 2000, N'WEBDEV.webdev@site.gov', N'WEBDEV.webdev@site.gov', N'MailDrop', 1)
SET IDENTITY_INSERT [dbo].[AcedEmailSettings] OFF
GO
SET IDENTITY_INSERT [dbo].[Applications] ON 

INSERT [dbo].[Applications] ([Id], [Name], [Identifier], [ContactName]) VALUES (1, N'ACED', 1, NULL)
INSERT [dbo].[Applications] ([Id], [Name], [Identifier], [ContactName]) VALUES (2, N'KAST', 2, NULL)
SET IDENTITY_INSERT [dbo].[Applications] OFF
GO
SET IDENTITY_INSERT [dbo].[AzureSettings] ON 

INSERT [dbo].[AzureSettings] ([Id], [Tenant], [TenantName], [TenantId], [Audience], [ClientId], [GraphClientId], [GraphClientSecret], [SignUpSignInPolicyId], [AzureGraphVersion], [MicrosoftGraphVersion], [AadInstance], [UseAdal], [Identifier]) VALUES (1, N'oregonctest.onmicrosoft.com', N'orb2ctest', N'cede2199-0000-4ccb-875d-8a77ec13bcd4', N'https://oregon.onmicrosoft.com/iisexpress/services/aced', N'161q59c3-97ce-4e63-84bf-b9568bc3ff4b', N'161e59c7-97ce-4r63-54bf-b9568bc3ff4b', N'AU7yO0HZEHTNKaDlUASK/onq0IZ9yDH5CUrvUczyGf4=', N'B2C_1_SignupOrSignin', N'api-version=1.6', N'1.0', N'https://login.microsoftonline.com/{0}/v2.0/.well-known/openid-configuration?p={1}', 1, 1)
INSERT [dbo].[AzureSettings] ([Id], [Tenant], [TenantName], [TenantId], [Audience], [ClientId], [GraphClientId], [GraphClientSecret], [SignUpSignInPolicyId], [AzureGraphVersion], [MicrosoftGraphVersion], [AadInstance], [UseAdal], [Identifier]) VALUES (2, N'oregondctest.onmicrosoft.com', N'ctest222', N'cede2199-1111-4ccb-875d-8a77ec13bcd4', N'https://oregon.onmicrosoft.com/iisexpress/services/kast', N'161d59c5-97ce-4e63-84bf-b9568bc3ff3c', N'111e59c7-97ce-4y63-94bf-b9568bc3ff4b', N'RU8yO0HZEHTNKaDlUASK/onq0IZ9yDH5CUrvUczyHf4=', N'B2C_2_SignupOrSignin', N'api-version=1.6', N'1.0', N'https://login.microsoftonline.com/{0}/v2.0/.well-known/openid-configuration?p={1}', 0, 2)
SET IDENTITY_INSERT [dbo].[AzureSettings] OFF
GO
SET IDENTITY_INSERT [dbo].[GeneralSettings] ON 

INSERT [dbo].[GeneralSettings] ([Id], [ServicePath], [ErrorMessageFromAddress], [ClientValidationEnabled], [UnobtrusiveJavaScriptEnabled], [MainDatabaseConnection], [Identifier]) VALUES (1, N'http://localhost:44340/api/', N'WEBV.webdev@washington.gov', 1, 0, N'Server=(localdb)\\mssqllocaldb1;Database=ApplicationConfigurations;Trusted_Connection=True', 1)
INSERT [dbo].[GeneralSettings] ([Id], [ServicePath], [ErrorMessageFromAddress], [ClientValidationEnabled], [UnobtrusiveJavaScriptEnabled], [MainDatabaseConnection], [Identifier]) VALUES (2, N'http://localhost:44341/api/', N'WEBD.webdev@cal.gov', 1, 0, N'Server=(localdb)\\mssqllocaldb3;Database=ApplicationConfigurations;Trusted_Connection=True', 2)
SET IDENTITY_INSERT [dbo].[GeneralSettings] OFF
GO
SET IDENTITY_INSERT [dbo].[MailSettings] ON 

INSERT [dbo].[MailSettings] ([Id], [FromAddress], [Host], [Port], [TimeOut], [PickupFolder], [TestFromAddress], [RevenueCoordinator], [Identifier]) VALUES (1, N'FromAddress1', N'Host1', 25, 1000, N'MailPickup', N'webdev@oregon.gov', NULL, 1)
INSERT [dbo].[MailSettings] ([Id], [FromAddress], [Host], [Port], [TimeOut], [PickupFolder], [TestFromAddress], [RevenueCoordinator], [Identifier]) VALUES (2, N'FromAddress2', N'Host2', 26, 3000, N'PickupMail', N'webdev@oregon.gov', NULL, 2)
SET IDENTITY_INSERT [dbo].[MailSettings] OFF
GO
SET IDENTITY_INSERT [dbo].[WebPageSettings] ON 

INSERT [dbo].[WebPageSettings] ([Id], [VersionMajor], [VersionMinor], [VersionBuild], [VersionRevison], [Identifier]) VALUES (1, 1, 1, 1, 1, 1)
INSERT [dbo].[WebPageSettings] ([Id], [VersionMajor], [VersionMinor], [VersionBuild], [VersionRevison], [Identifier]) VALUES (2, 2, 2, 2, 2, 2)
SET IDENTITY_INSERT [dbo].[WebPageSettings] OFF
GO
ALTER TABLE [dbo].[AcedEmailSettings]  WITH CHECK ADD  CONSTRAINT [FK_AcedEmailSettings_Applications] FOREIGN KEY([Identifier])
REFERENCES [dbo].[Applications] ([Id])
GO
ALTER TABLE [dbo].[AcedEmailSettings] CHECK CONSTRAINT [FK_AcedEmailSettings_Applications]
GO
ALTER TABLE [dbo].[AzureSettings]  WITH CHECK ADD  CONSTRAINT [FK_AzureSettings_Applications] FOREIGN KEY([Identifier])
REFERENCES [dbo].[Applications] ([Id])
GO
ALTER TABLE [dbo].[AzureSettings] CHECK CONSTRAINT [FK_AzureSettings_Applications]
GO
ALTER TABLE [dbo].[AzureSettings]  WITH CHECK ADD  CONSTRAINT [FK_AzureSettings_Applications1] FOREIGN KEY([Identifier])
REFERENCES [dbo].[Applications] ([Id])
GO
ALTER TABLE [dbo].[AzureSettings] CHECK CONSTRAINT [FK_AzureSettings_Applications1]
GO
ALTER TABLE [dbo].[GeneralSettings]  WITH CHECK ADD  CONSTRAINT [FK_GeneralSettings_Applications] FOREIGN KEY([Identifier])
REFERENCES [dbo].[Applications] ([Id])
GO
ALTER TABLE [dbo].[GeneralSettings] CHECK CONSTRAINT [FK_GeneralSettings_Applications]
GO
ALTER TABLE [dbo].[MailSettings]  WITH CHECK ADD  CONSTRAINT [FK_MailSettings_Applications] FOREIGN KEY([Identifier])
REFERENCES [dbo].[Applications] ([Id])
GO
ALTER TABLE [dbo].[MailSettings] CHECK CONSTRAINT [FK_MailSettings_Applications]
GO
ALTER TABLE [dbo].[WebPageSettings]  WITH CHECK ADD  CONSTRAINT [FK_WebPageSettings_Applications] FOREIGN KEY([Identifier])
REFERENCES [dbo].[Applications] ([Id])
GO
ALTER TABLE [dbo].[WebPageSettings] CHECK CONSTRAINT [FK_WebPageSettings_Applications]
GO
USE [master]
GO
ALTER DATABASE [ApplicationConfigurations] SET  READ_WRITE 
GO
