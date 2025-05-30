USE [AddressDatabase]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 4/15/2025 8:57:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Zipcode] [nvarchar](max) NULL,
	[Street] [nvarchar](max) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (1, N'Stefanie', N'Regina', N'Bates', N'Lincoln', N'Kentucky', N'59893', NULL)
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (2, N'Sandy', N'Roy', N'Huang', N'Arlington', N'Iowa', N'47471', N'98 Second Street')
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (3, N'Lee', N'Dewayne', N'Rubio', N'Newark', N'Indiana', N'51737', N'84 Nobel Drive')
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (4, N'Regina', N'Beth', N'Cunningham', N'Sacramento', N'New York', N'66301', N'613 North Nobel Road')
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (5, N'Daniel', N'Jolene', N'Flowers', N'Los Angeles', N'Mississippi', N'30429', N'771 West Green Nobel Boulevard')
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (6, N'Dennis', N'Nicolas', N'Daniels', N'San Diego', N'Washington', N'07170', N'25 Fabien Way')
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (7, N'Myra', N'Tricia', N'Howell', N'Anchorage', N'Delaware', N'43313', N'69 Fabien St.')
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (8, N'Teddy', N'Hilary', N'Joyce', N'Honolulu', N'West Virginia', N'90035', N'87 Clarendon Street')
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (9, N'Annie', N'Shane', N'Thornton', N'Fresno', N'New Jersey', N'01497', N'63 North Fabien Way')
INSERT [dbo].[Address] ([Id], [FirstName], [MiddleName], [LastName], [City], [State], [Zipcode], [Street]) VALUES (10, N'Herman', N'Linda', N'Chandler', N'Raleigh', N'Colorado', N'55855', N'280 Clarendon Drive')
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
USE [master]
GO
ALTER DATABASE [AddressDatabase] SET  READ_WRITE 
GO
